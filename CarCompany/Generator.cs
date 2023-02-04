
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CarCompany
{
    public class Generator
    {

        public List<Car> GenerateDummyCarsData()
        {
            var dummyCarModels = new List<string>()
            {
                "Mercedes",
                "BMW",
                "Ferrari"
            };
            var dummyCarPrices = new List<int>()
            {
                3000,
                6000,
                2400,
            };
            var dummyCars = new List<Car>();

            for (int i = 0; i < dummyCarModels.Count; i++)
            {
                var dummyCar = new Car()
                {
                    Model = dummyCarModels[i],
                    Price = dummyCarPrices[i],
                    IsUsed = false,
                };
                dummyCars.Add(dummyCar);
            }

            return dummyCars;
        }


        public List<User> GenerateRandomUsersData(List<Car> dummyCars)
        {
            var dummyUsers = new List<User>();
            var dummyUserNames = new List<string>() { "givi", "bondo", "jimiko" };

            for (int i = 0; i < dummyUserNames.Count; i++)
            {
                var userName = dummyUserNames[i];
                var user = new User()
                {
                    UserName = userName,
                    Password = userName + "1234"
                    // id and amount will be generated automatically-- see User class
                };

                // before adding car to user we should give car an OwnderId so we can find 
                // its owner and remove car from him after purchasing from another user

                dummyCars[i].OwnerId = user.Id;

                // each user will have 1 car - Givi -> Mercedes, bondo -> BMW and jimiko -> Ferrari
                user.UserCars.Add(dummyCars[i]);
                dummyUsers.Add(user);

            }


            return dummyUsers;

        }

    }
}