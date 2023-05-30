using System.Xml;
using Meth3;
using System.Xml.Linq;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

// using (DataAccessLayer.Context db = new DataAccessLayer.Context())
// {
//     Right right = new Right() { right = 0 };
//     Right right1 = new Right() { right = 1 };
//     User user1 = new User()
//     {
//         Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, Email = "123@gmail.com",
//         Password = "12345678", Right_ID = 1, Login = "user1", Right = right
//     };
//     User user2 = new User()
//     {
//         Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, Email = "124@gmail.com",
//         Password = "22345678", Right_ID = 1, Login = "user2", Right = right
//     };
//     User user3 = new User()
//     {
//         Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, Email = "125@gmail.com",
//         Password = "32345678", Right_ID = 1, Login = "user3", Right = right1
//     };
//     User user4 = new User()
//     {
//         Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, Email = "126@gmail.com",
//         Password = "42345678", Right_ID = 1, Login = "user4", Right = right
//     };
     Game game1 = new Game()
     {
         Creator_id = 0, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
         Photogame_id = 0, Genre_id = 3, Name = "Fable"
     };
     Game game2 = new Game()
     {
         Creator_id = 1, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
         Photogame_id = 3, Genre_id = 2, Name = "Diablo"
     };
     Game game3 = new Game()
     {
         Creator_id = 3, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
         Photogame_id = 5, Genre_id = 3, Name = "Space Rangers"
     };
     Game game4 = new Game()
     {
         Creator_id = 2, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
         Photogame_id = 1, Genre_id = 1, Name = "Pac-Man"

     };
//     UserGame ug = new UserGame() { User = user1, Game = game1 };
//     UserGame ug1 = new UserGame() { User = user2, Game = game2 };
//     UserGame ug2 = new UserGame() { User = user3, Game = game3 };
//     UserGame ug3 = new UserGame() { User = user4, Game = game4 };
//     UserGame ug4 = new UserGame() { User = user4, Game = game2 };
//
//     Achievement achievements1 = new Achievement() { Name = "Первый вход в игру", Game = game1 };
//     Achievement achievements2 = new Achievement() { Name = "Первое знакомство", Game = game2 };
//     Achievement achievements3 = new Achievement() { Name = "Стриккк", Game = game3 };
//     Achievement achievements4 = new Achievement() { Name = "Кто я?", Game = game4 };
//
//     User_Achieve userAchieve = new User_Achieve() { User = user1, Achievement = achievements2 };
//     User_Achieve userAchieve1 = new User_Achieve() { User = user2, Achievement = achievements3 };
//     User_Achieve userAchieve2 = new User_Achieve() { User = user1, Achievement = achievements4 };
//     
//     db.Rights.AddRange(right,right1);
//     db.Games.AddRange(game1,game2,game3,game4);
//     db.Users.AddRange(user1,user2,user3,user4);
//     db.Achievements.AddRange(achievements1,achievements3,achievements2,achievements4);
//     db.UserGames.AddRange(ug,ug1,ug2,ug3,ug4);
//     db.UserAchieves.AddRange(userAchieve,userAchieve1,userAchieve2);
//     db.SaveChanges();
//
// }
     BLService service = new BLService();
     var y = service.FindUsersWithSameGames();
     Console.WriteLine(JsonConvert.SerializeObject(y, Formatting.Indented));
#region 5 Работа
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

    var x = JsonConvert.SerializeObject(db.GetAllUsers(), Formatting.Indented);
    Console.WriteLine(x);
    foreach (var users in db.FindUsersWithSameGames())
    {
        Console.WriteLine(users.Login);
    }

}


#endregion
#region Добавление в XML данных из БД
//
// UseCase xmlusecase = new UseCase();
// using (DataAccessLayer.Context db = new DataAccessLayer.Context())
// {
//     var users = db.Users.ToList();
//     XDocument xdoc = new XDocument();
//     XElement people = new XElement("people");
//     foreach (var _user in users)
//     {
//         xmlusecase.XmlAddUser(_user, people);
//     }
//     xdoc.Add(people);
//     xdoc.Save("C:\\Users\\Deadcat\\RiderProjects\\Meth3\\Meth3\\XmlDirectory\\people.xml");
//     
// }
//
// using (DataAccessLayer.Context db = new DataAccessLayer.Context())
// {
//     var games = db.Games.ToList();
//     XDocument xdoc = new XDocument();
//     XElement people = new XElement("game");
//     foreach (var _game in games)
//     {
//         xmlusecase.XmlAddGame(_game, people);
//     }
//     xdoc.Add(people);
//     xdoc.Save("C:\\Users\\Deadcat\\RiderProjects\\Meth3\\Meth3\\XmlDirectory\\game.xml");
//     
// }
#endregion
#region Чтение из XML
// foreach (XmlNode node in
//          xmlusecase.XmlRead("C:\\Users\\Deadcat\\RiderProjects\\Meth3\\Meth3\\XmlDirectory\\people.xml"))
// {
//     Console.WriteLine(node.OuterXml);
// }
#endregion

#region JSON

// List<Game> games = new List<Game>();
// games.Add(game1);
// games.Add(game2);
// DataAccessLayer.JsonRepo<Game> gamerepo = new DataAccessLayer.JsonRepo<Game>(games);
// // gamerepo.JsonSaveData(gamerepo.repo);
// // var list = gamerepo.JsonGetData();
// //      foreach (var x in list)
// //      {
// //          Console.WriteLine(x);
// //      } 
// gamerepo.GetType();
//
//


#endregion