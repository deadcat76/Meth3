namespace TestMeth;
using Meth3;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void AddGameTest()
    {
        Game game1 = new Game()
        {
            Creator_id = 0, ID = 0, Description = "", Date_Release = "20.03.2007", Date_Update = "20.08.2008", Removed = false,
            Photogame_id = 0, Genre_id = 3, Name = "Fable"
        };
        User user1 = new User()
        {
            Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, ID = 0, Email = "123@gmail.com",
            Password = "12345678", Right_id = 1, Login = "user1"
        };
        User_Game_Manager userGameManager = new User_Game_Manager();
        List<Game> games = new List<Game>();
        userGameManager.usergame.Add(user1, new List<Game>());
        userGameManager.AddGametoUser(userGameManager.usergame ,game1, user1);
        Assert.AreEqual(game1, userGameManager.usergame[user1].Last());
    }

    [TestMethod]
    public void GetAllGamesTest()
    {
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
        User user1 = new User()
        {
            Date_create = "16.04.2023", Date_update = "16.05.2023", is_Blocked = false, ID = 0, Email = "123@gmail.com",
            Password = "12345678", Right_id = 1, Login = "user1"
        };
        Dictionary<User, List<Game>> ugDictionary = new Dictionary<User, List<Game>>();
        User_Game_Manager userGameManager = new User_Game_Manager();
        List<Game> games = new List<Game>();
        games.Add(game1);
        games.Add(game2);
        games.Add(game3);
        
        userGameManager.AddGametoUser(ugDictionary, game1, user1);
        userGameManager.AddGametoUser(ugDictionary, game2, user1);
        userGameManager.AddGametoUser(ugDictionary, game3, user1);
        
        CollectionAssert.AreEqual(games, userGameManager.GetAllGamesByUser(ugDictionary, user1));
        
    }
}