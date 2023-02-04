using System.Xml.Schema;

namespace CarCompany
{
    public class User
    {

        public long Id { get; set; } = new Random().NextInt64();
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public double Amount { get; set; } = new Random().Next(3000, 20000);
        public List<Car> UserCars { get; set; }

        public User()
        {
            UserCars = new List<Car>();
        }

        public bool CanPurchaseCar(Car carToPurchase)
        {
            if (carToPurchase.OwnerId == Id)
            {
                Console.WriteLine("You already own this car");
                return false;
            }

            if (Amount < carToPurchase.Price)
            {
                Console.WriteLine("Not enough money on account");
                return false;
            }

            return true;
        }
        public void PurchaseCar(Car carToPurchase, User carSeller)
        {
            carSeller!.RemoveCar(carToPurchase);
            carSeller.Amount += carToPurchase.Price;
            Amount -= carToPurchase.Price;

            // We change OwnerId to current user's Id
            // because he is the owner now
            carToPurchase.OwnerId = Id;

            UserCars.Add(carToPurchase);
            Console.WriteLine($"{carToPurchase.Model} Purchased by {UserName}");
        }
        public void RemoveCar(Car carToRemove)
        {
            UserCars.Remove(carToRemove);
        }
        public Car AddCar()
        {
            Console.Write("Enter model: ");
            var carModel = Console.ReadLine();
            Console.Write("Enter Price: ");
            var carPrice = double.Parse(Console.ReadLine());

            var newCar = new Car()
            {
                Model = carModel,
                Price = carPrice,
                IsUsed = false,
                OwnerId = Id,
            };

            UserCars.Add(newCar);
            Console.WriteLine("Car added successfuly");
            return newCar;
        }
        public void ShowUserInformation()
        {
            Console.WriteLine("UserName: " + UserName);
            Console.WriteLine("Amount: " + Amount);
            Console.WriteLine();
        }
        public void ShowOwnedCars()
        {
            foreach (var car in UserCars)
            {
                car.ShowInformation();
            }
        }
        public void ChangeUserName(string userName)
        {
            Console.Write($"Username changed from ,,{UserName}'' to ");
            UserName = userName;
            Console.WriteLine($",,{UserName}''");

        }
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
            Console.WriteLine("Password changed!");
        }



    }
}
