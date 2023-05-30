using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Meth3;

public class DataAccessLayer
{
    public class Context : DbContext
    {
        public DbSet<Right> Rights { get; set; }
        public DbSet<User> Users { get; set; } // Создаем представление для Юзеров
        public DbSet<Game> Games { get; set; } // Cоздаем представление для Игр
        public DbSet<UserGame> UserGames { get; set; } // Связующая таблица для игр и юзеров
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<User_Achieve> UserAchieves { get; set; }

        public Context()
        {
            //Database.EnsureDeleted(); // Удаляем старую базу для того, чтобы при проверке не было ошибок
            Database.EnsureCreated(); // Если не создана база, то создаем
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = meth3.db"); // Устанавливаем соединение с базой данных
        }

        public List<User> GetAllUsers()
        {
            using (Context db = new Context())
            {
                var users = db.Users.ToList();
                return users;
            }
        }

        public void AddGame(Game game)
        {
            using (Context db = new Context())
            {
                db.Games.Add(game);
            }
        }

        public User FindUserByEmail(string email)
        {
            using (Context db = new Context())
            {
                var user = db.Users.ToList().Where(e => e.Email == email);
                return user.FirstOrDefault();

            }
        }

        public List<User> FindUsersWithSameGames()
        {
            using (Context db = new Context())
            {
                // var users = db.UserGames
                //     .Include(p => p.User)
                //     .Where(p => p.Game_ID == game.ID)
                //     .ToList();
                // return users;
                var users = db.UserGames
                    .GroupBy(x => x.User)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();
                return users;
            }
        }
    }
    public class GameRepo : IRepository<Game>
    {
        private Context db;

        public GameRepo(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Game> GetAll(string table = null)
        {
            return db.Games.ToList();
        }

        public void Update(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
        }

        public Game GetById(int ID)
        {
            return db.Games.Find(ID);
        }

        public void Add(Game game)
        {
            db.Games.Add(game);
        }

        public void Delete(int ID)
        {
            Game game = db.Games.Find(ID);
            if (game != null)
            {
                db.Games.Remove(game);
            }
        }
    }

    public class UserRepo : IRepository<User>
    {

        private Context db;

        public UserRepo(Context context)
        {
            this.db = context;
        }
        public IEnumerable<User> GetAll(string table = null)
        {
            return db.Users.ToList();
        }

        public void Update(User obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public User GetById(int ID)
        {
            return db.Users.Find(ID);
        }

        public void Add(User obj)
        {
            db.Users.Add(obj);
        }

        public void Delete(int ID)
        {
            User user = db.Users.Find(ID);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }
    }
    public class UserGameRepo : IRepository<UserGame>
    {
        private Context db;

        public UserGameRepo(Context context)
        {
            this.db = context;
        }
        public IEnumerable<UserGame> GetAll(string table = null)
        {
            return db.UserGames.ToList();
        }

        public void Update(UserGame obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public UserGame GetById(int ID)
        {
            return db.UserGames.Find(ID);
        }

        public void Add(UserGame obj)
        {
            db.UserGames.Add(obj);
        }

        public void Delete(int ID)
        {
            UserGame ug = db.UserGames.Find(ID);
            if (ug != null)
            {
                db.UserGames.Remove(ug);
            }
        }
    }
    
    public class UnitOfWork : IDisposable
    {
        private Context db = new Context();

        public GameRepo gameRepo;

        public UserRepo userRepo;

        public UserGameRepo usergameRepo;

        public GameRepo Games
        {
            get
            {
                if (gameRepo == null)
                {
                    gameRepo = new GameRepo(db);
                }

                return gameRepo;
            }
        }

        public UserRepo Users
        {
            get
            {
                if (userRepo == null)
                {
                    userRepo = new UserRepo(db);
                }

                return userRepo;
            }
        }

        public UserGameRepo UserGames
        {
            get
            {
                if (usergameRepo == null)
                {
                    usergameRepo = new UserGameRepo(db);
                }

                return usergameRepo;
            }
        }

        private bool disposed = false;

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class JsonRepo<T> where T : class
    {
        public List<T> repo;

        public JsonRepo(List<T> list)
        {
            repo = list;
        }

        public void GetType()
        {
            var type = typeof(T).ToString();
            var type2 = type.Split('.')[1];
            Console.WriteLine(type2);
        }
        public void JsonSaveData(List<T> repo)
        {
            using (StreamWriter file = File.CreateText($"C:\\Users\\Deadcat\\RiderProjects\\Meth3\\Meth3\\Json\\{typeof(T)}.json"))
            {
                var Json = JsonConvert.SerializeObject(repo, Formatting.Indented );
                file.Write(Json);
                Console.WriteLine("Data has been saved to file");
            }
        }

        public List<T> JsonGetData()
        {
            List<T> obj = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText("C:\\Users\\Deadcat\\RiderProjects\\Meth3\\Meth3\\Json\\data.json"));
            using (StreamReader file = File.OpenText("data.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<T> obj2 = (List<T>)serializer.Deserialize(file, typeof(T));
                return obj2;
            }
        }

        // public void JsonAddData(T data)
        // {
        //     List<T> list = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText("data.json"));
        //     using (var fs = new FileStream("data.json"))
        //     {
        //         JsonSerializer serializer = new JsonSerializer();
        //         List<T> list2 = (List<T>)serializer.Deserialize(file, typeof(T));
        //         list2.Add(data);
        //         var Json = JsonConvert.SerializeObject(list2);
        //         var file2 = File.OpenWrite("data.json");    
        //     }
        //     
        // }
    }

}
