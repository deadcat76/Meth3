using Meth3;

User user1 = new User()
{
    Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, ID = 0, Email = "123@gmail.com",
    Password = "12345678", Right_id = 1, Login = "user1"
};
User user2 = new User()
{
    Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, ID = 1, Email = "124@gmail.com",
    Password = "22345678", Right_id = 1, Login = "user2"
};
User user3 = new User()
{
    Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, ID = 2, Email = "125@gmail.com",
    Password = "32345678", Right_id = 1, Login = "user3"
};
User user4 = new User()
{
    Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, ID = 3, Email = "126@gmail.com",
    Password = "42345678", Right_id = 1, Login = "user4"
};
Game game1 = new Game()
{
    Creator_id = 0, ID = 0, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
    Photogame_id = 0, Genre_id = 3, Name = "Fable"
};
Game game2 = new Game()
{
    Creator_id = 1, ID = 1, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
    Photogame_id = 3, Genre_id = 2, Name = "Diablo"
};
Game game3 = new Game()
{
    Creator_id = 3, ID = 3, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
    Photogame_id = 5, Genre_id = 3, Name = "Space Rangers"
};
Game game4 = new Game()
{
    Creator_id = 2, ID = 2, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
    Photogame_id = 1, Genre_id = 1, Name = "Pac-Man"
    
};

Achievements achievements1 = new Achievements() { game_id = 0, id = 0, Name = "Первый вход в игру" };
Achievements achievements2 = new Achievements() { game_id = 1, id = 1, Name = "Первое знакомство" };
Achievements achievements3 = new Achievements() { game_id = 2, id = 2, Name = "Стриккк" };
Achievements achievements4 = new Achievements() {game_id = 3, id = 3, Name = "Кто я?"};

User_Achieve userAchieve = new User_Achieve() {id = 0, ach_id = 0, user_id = 3 };
User_Achieve userAchieve1 = new User_Achieve() {id = 1, ach_id = 1, user_id = 0 };
User_Achieve userAchieve2 = new User_Achieve() {id = 2,  ach_id = 3, user_id = 1 };

Rep2<User> user_repository = new Rep2<User>();
Rep2<Game> game_repository = new Rep2<Game>();
Rep2<Achievements> achieve_repository = new Rep2<Achievements>();
Rep2<User_Achieve> us_ach_repository = new Rep2<User_Achieve>();

user_repository.Add(user1);
user_repository.Add(user2);
user_repository.Add(user3);
user_repository.Add(user4);

game_repository.Add(game1);
game_repository.Add(game2);
game_repository.Add(game3);
game_repository.Add(game4);

achieve_repository.Add(achievements1);
achieve_repository.Add(achievements2);
achieve_repository.Add(achievements3);
achieve_repository.Add(achievements4);

us_ach_repository.Add(userAchieve);
us_ach_repository.Add(userAchieve1);
us_ach_repository.Add(userAchieve2);

var list = user_repository.GetAll();
foreach (var us in list)
{
        Console.WriteLine(us.Email);
}
user_repository.RemoveById(3);

Console.WriteLine();

var list1 = user_repository.GetAll();
foreach (var us in list1)
{
    Console.WriteLine(us.Email);
}


Console.WriteLine(game_repository.GetById(3).Name);