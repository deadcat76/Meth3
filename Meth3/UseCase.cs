namespace Meth3;
using System.Xml.Linq;
using System.Xml;
using System.Text.Json;
using System.Reflection;
public class UseCase
{
    public void XmlAddUser(User _user, XElement root)
    {
        XElement user = new XElement("user");
        XAttribute userNameAttr = new XAttribute("login", $"{_user.Login}");
        XElement userEmailElement = new XElement("email", $"{_user.Email}");
        XElement userIsBlockedElement = new XElement("IsBlocked", $"{_user.is_Blocked}");
        user.Add(userNameAttr);
        user.Add(userEmailElement);
        user.Add(userIsBlockedElement);
        root.Add(user);
    }

    public void XmlAddGame(Game _game, XElement root)
    {
        XElement game = new XElement("game");
        XAttribute gameNameAttr = new XAttribute("name", $"{_game.Name}");
        XElement gameDescriptionElement = new XElement("description", $"{_game.Description}");
        XElement gameDateReleaseElement = new XElement("date_release", $"{_game.Date_Release}");
        game.Add(gameNameAttr);
        game.Add(gameDescriptionElement);
        game.Add(gameDateReleaseElement);
        root.Add(game);
    }

    public XmlNodeList XmlRead(string path)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(path);
        XmlElement? xRoot = xDoc.DocumentElement; //выбор дочерних элементов
        XmlNodeList nodes = xRoot?.SelectNodes("*");
        return nodes;
    }

    public async Task JsonSaveUser(User user)
    {
        
        using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<User>(fs, user);
            Console.WriteLine("User has been saved to file");
        }
    }

    public async Task JsonGetUsers()
    {
        using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            User? user = await JsonSerializer.DeserializeAsync<User>(fs);
            Console.WriteLine($"Login: {user?.Login} Email: {user?.Email}");
        }
    }

    public async Task JsonSaveGame(Game game)
    {
        using (FileStream fs = new FileStream("game.json", FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<Game>(fs, game);
            Console.WriteLine("Game has been saved to file");
        }
    }

    public async Task JsonGetGames()
    {
        using (FileStream fs = new FileStream("game.json", FileMode.OpenOrCreate))
        {
            Game? game = await JsonSerializer.DeserializeAsync<Game>(fs);
            Console.WriteLine($"Name: {game?.Name} DateRelease: {game?.Date_Release}");
        }
    }
}