namespace Meth3;

public class User : IDomainObject
{
    public int ID { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Date_create { get; set; }
    public string Date_update { get; set; }
    public bool is_Blocked { get; set; }
    public int Right_id { get; set; }

    public List<UserGame> UserGames { get; set; } = new(); // Установка зависимости, в данном случае представление
                                                           // User будет главной сущностью по отношению к UserGame

    // public override bool Equals(object? obj)
    // {
    //     if (_equals(obj as User))
    //     {
    //         return true;
    //     }
    //
    //     return false;
    // }
    //
    // protected bool _equals(User other)
    // {
    //     return ID == other.ID 
    //            && Login == other.Login 
    //            && Password == other.Password 
    //            && Email == other.Email 
    //            && Date_create == other.Date_create 
    //            && Date_update == other.Date_update 
    //            && is_Blocked == other.is_Blocked 
    //            && Right_id == other.Right_id;
    // }
    //
    // public override int GetHashCode()
    // {
    //     return HashCode.Combine(ID, Login, Password, Email, Date_create, Date_update, is_Blocked, Right_id);
    // }
}

public class Game : IDomainObject
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Date_Release { get; set; }
    public string Date_Update { get; set; }
    public bool Removed { get; set; }
    public int Creator_id { get; set; }
    public int Genre_id { get; set; }
    public int Photogame_id { get; set; }

    public List<UserGame> UserGames { get; set; } = new(); // Установка зависимости, в данном случае представление
                                                           // Game будет главной сущностью по отношению к UserGame

    // public override bool Equals(object? obj)
    // {
    //     if (_equals(obj as Game))
    //     {
    //         return true;
    //     }
    //
    //     return false;
    // }
    //
    // protected bool _equals(Game other)
    // {
    //     return ID == other.ID 
    //            && Name == other.Name 
    //            && Description == other.Description 
    //            && Date_Release == other.Date_Release 
    //            && Date_Update == other.Date_Update 
    //            && Removed == other.Removed 
    //            && Creator_id == other.Creator_id 
    //            && Genre_id == other.Genre_id 
    //            && Photogame_id == other.Photogame_id;
    // }
    //
    // public override int GetHashCode()
    // {
    //     var hashCode = new HashCode();
    //     hashCode.Add(ID);
    //     hashCode.Add(Name);
    //     hashCode.Add(Description);
    //     hashCode.Add(Date_Release);
    //     hashCode.Add(Date_Update);
    //     hashCode.Add(Removed);
    //     hashCode.Add(Creator_id);
    //     hashCode.Add(Genre_id);
    //     hashCode.Add(Photogame_id);
    //     return hashCode.ToHashCode();
    // }
}

public class UserGame : IDomainObject
{
    public int ID { get; set; }
    public int User_ID { get; set; } // Внешний ключ
    public User? User { get; set; } // Навигационное свойство
    public int Game_ID { get; set; } // Внешний ключ
    public Game? Game { get; set; } // Навигационное свойство
}

public class Achievements
{
    public int id;
    public int game_id;
    public string Name;
    
}

public record Right
{
    public int id;
    public byte right;
    public Right(byte _right) => right = _right;
}

public class User_Achieve
{
    public int id;
    public int user_id;
    public int ach_id;
}

public class User_Game_Manager
{
    public Dictionary<User, List<Game>> usergame = new Dictionary<User, List<Game>>();
    public Game game;
    public User user;

    public void AddGametoUser(Dictionary<User, List<Game>> ug, Game game, User user)
    {
        var gamelist = new List<Game>() { game };
        if (ug.ContainsKey(user))
        {
            ug[user].Add(game);
        }
        else ug.Add(user, gamelist);
    }

    public List<Game> GetAllGamesByUser(Dictionary<User, List<Game>> ug, User user)
    {
        return ug[user];
    }

    public void DeleteGamesByUser(Dictionary<User, List<Game>> ug, Game game, User user)
    {
        int index = 0;
        foreach (var games in ug[user])
        {
            if (game.Equals(games))
            {
                ug[user].RemoveAt(index);
            }
            index++;
        }
    }

}