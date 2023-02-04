
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarCompany
{
    public class Company
    {
        public List<User> Users { get; set; }
        public List<Car> Cars { get; set; }
        public User? CurrentUser { get; set; }


        public Company()
        {
            // if we don't provide any user or car list 
            // we will have empty lists
            Users = new List<User>();
            Cars = new List<Car>();

        }

        public void DisplayAuthMenu()
        {
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");
            Console.WriteLine("3.Quit");
        }
        public void RegisterUser()
        {
            Console.Write("Enter your username: ");
            var userName = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            var newUser = new User()
            {
                UserName = userName,
                Password = password,
                //id and amount will be generated automatically
            };
            Console.Clear();
            Console.WriteLine("Registered successfuly!");
            Console.WriteLine();
            Users.Add(newUser);
        }

        public User? LoginUser()
        {
            Console.Write("Enter your username: ");
            var userName = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();

            //find user by given username
            //lambda expression ->    user => user.UserName == userName;
            var user = Users.FirstOrDefault(u => u.UserName == userName);

            //foreach (var myUser in Users)
            //{
            //    if(myUser.UserName == userName)
            //    {
            //        return myUser;
            //    }
            //}

            //if user can't be found with given username we return null
            if (user == null)
            {
                Console.WriteLine("Incorrect Credentials");
                return null;
            }
            if (user.Password != password)
            {
                Console.WriteLine("Passwords don't match");
                return null;
            }
            Console.Clear();
            Console.WriteLine("Logged in successfuly");
            Console.WriteLine();
            //if user is found and also password is correct we are returning founded user
            return user;

        }


        //its private because only logged users are available to see user menu
        private void DisplayUserMenu()
        {
            Console.WriteLine("1.Display all cars");
            Console.WriteLine("2.Show your information");
            Console.WriteLine("3.Show owned cars information");
            Console.WriteLine("4.Add Car");
            Console.WriteLine("5.Log out");
            Console.WriteLine();
        }

        //its private because only logged users are available to see all cars
        private void DisplayAllCars()
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                Console.Write((i + 1) + ". ");
                Cars[i].ShowInformation();
            }
        }

        public void WorkWithUserMenu()
        {
            var userChoice = ConsoleKey.G;
            while (userChoice != ConsoleKey.D5)
            {
                Console.WriteLine();
                DisplayUserMenu();
                userChoice = Console.ReadKey().Key;
                Console.Clear();
                if (userChoice == ConsoleKey.D1)
                {
                    DisplayAllCars();
                    Console.Write("Enter number of car you want to buy: ");
                    var indexOfCar = int.Parse(Console.ReadLine()) - 1;

                    Console.Clear();
                    // int.Parse(Console.ReadLine()) - 1 because we have numbered cars in this manner
                    // 1. 2. 3. ... so if user will choose 1. we should get 
                    // car at index 0 

                    if (indexOfCar < 0 || indexOfCar >= Cars.Count)
                    {
                        Console.WriteLine("Invalid car number");
                        continue;
                    }

                    var carToPurchase = Cars[indexOfCar];

                    if (CurrentUser!.CanPurchaseCar(carToPurchase))
                    {
                        var carSeller = Users.Find(s => s.Id == carToPurchase.OwnerId);

                        CurrentUser!.PurchaseCar(carToPurchase, carSeller!);
                    }

                }
                else if (userChoice == ConsoleKey.D2)
                {
                    CurrentUser!.ShowUserInformation();
                }
                else if (userChoice == ConsoleKey.D3)
                {
                    CurrentUser!.ShowOwnedCars();
                }
                else if (userChoice == ConsoleKey.D4)
                {
                    var newCar = CurrentUser!.AddCar();
                    Cars.Add(newCar);
                }
                else if (userChoice == ConsoleKey.D5)
                {
                    CurrentUser = null;
                    Console.WriteLine("Signed out");
                    break;
                }

            }
        }

    }
}