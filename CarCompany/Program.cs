using CarCompany;

var generator = new Generator();
var cars = generator.GenerateDummyCarsData();

var users = generator.GenerateRandomUsersData(cars);

var company = new Company()
{
    Cars = cars,
    Users = users,

};


var userChoice = ConsoleKey.G;// just initializing starter key nothing special

while (userChoice != ConsoleKey.D3)// D3 in keyboard is 3
{

    company.DisplayAuthMenu();
    userChoice = Console.ReadKey().Key;

    Console.Clear();

    if (userChoice == ConsoleKey.D1)
    {
        var loggedInUser = company.LoginUser();

        if (loggedInUser == null)
        {
            continue;
        }
        // if user is not null so we can log in him
        // and we can work with UserMenu() to avoid nesting 
        // while loops and if statements

        company.CurrentUser = loggedInUser;

        company.WorkWithUserMenu();


    }
    else if (userChoice == ConsoleKey.D2)
    {
        company.RegisterUser();
    }
    else if (userChoice == ConsoleKey.D3)
    {
        company.CurrentUser = null;
        Console.Clear();
        Console.WriteLine("Thanks for using our service!");
        break;
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Invalid key pressed");
    }

}
