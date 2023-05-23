using Meth3;



// Achievements achievements1 = new Achievements() { game_id = 0, id = 0, Name = "Первый вход в игру" };
// Achievements achievements2 = new Achievements() { game_id = 1, id = 1, Name = "Первое знакомство" };
// Achievements achievements3 = new Achievements() { game_id = 2, id = 2, Name = "Стриккк" };
// Achievements achievements4 = new Achievements() {game_id = 3, id = 3, Name = "Кто я?"};
//
// User_Achieve userAchieve = new User_Achieve() {id = 0, ach_id = 0, user_id = 3 };
// User_Achieve userAchieve1 = new User_Achieve() {id = 1, ach_id = 1, user_id = 0 };
// User_Achieve userAchieve2 = new User_Achieve() {id = 2,  ach_id = 3, user_id = 1 };

using (DataAccessLayer.Context db = new DataAccessLayer.Context())
{
    // #region Создаем объекты классов
    // User user1 = new User()
    // {
    //     Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, Email = "123@gmail.com",
    //     Password = "12345678", Right_id = 1, Login = "user1"
    // };
    // User user2 = new User()
    // {
    //     Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false,  Email = "124@gmail.com",
    //     Password = "22345678", Right_id = 1, Login = "user2"
    // };
    // User user3 = new User()
    // {
    //     Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, Email = "125@gmail.com",
    //     Password = "32345678", Right_id = 1, Login = "user3"
    // };
    // User user4 = new User()
    // {
    //     Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, Email = "126@gmail.com",
    //     Password = "42345678", Right_id = 1, Login = "user4"
    // };
    // Game game1 = new Game()
    // {
    //     Creator_id = 0, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
    //     Photogame_id = 0, Genre_id = 3, Name = "Fable"
    // };
    // Game game2 = new Game()
    // {
    //     Creator_id = 1, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
    //     Photogame_id = 3, Genre_id = 2, Name = "Diablo"
    // };
    // Game game3 = new Game()
    // {
    //     Creator_id = 3, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
    //     Photogame_id = 5, Genre_id = 3, Name = "Space Rangers"
    // };
    // Game game4 = new Game()
    // {
    //     Creator_id = 2, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
    //     Photogame_id = 1, Genre_id = 1, Name = "Pac-Man"
    //
    // };
    // UserGame ug = new UserGame() { User = user1, Game = game1 };
    // UserGame ug1 = new UserGame() { User = user2, Game = game2 };
    // UserGame ug2 = new UserGame() { User = user3, Game = game3 };
    // UserGame ug3 = new UserGame() { User = user4, Game = game4 };
    // UserGame ug4 = new UserGame() { User = user4, Game = game2 };
    //
    //
    // #endregion
    //
    // db.Games.AddRange(game1,game2, game3, game4); // Добавляем в бд игры
    // db.Users.AddRange(user1, user2, user3, user4); // Добавляем в бд юзеров
    // db.UserGames.AddRange(ug,ug1,ug2,ug3, ug4); // Добавляем в бд юзеров с их играми
    // db.SaveChanges(); // Сохранение изменений

    // foreach (var usergames in db.UserGames.ToList())
    // {
    //     Console.WriteLine($"{usergames.User?.Login} играл в {usergames.Game?.Name}");
    // }
    //
    foreach (var users in db.GetAllUsers())
    {
        Console.WriteLine(users.Login);
    }
    Console.WriteLine();
    foreach (var users in db.FindUsersWithSameGames())
    {
        Console.WriteLine(users.Login);
    }

}


