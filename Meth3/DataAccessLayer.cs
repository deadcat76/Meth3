using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Meth3;

public class DataAccessLayer
{
    public class Context : DbContext
    {
        public DbSet<Right> Rights { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!; // Создаем представление для Юзеров
        public DbSet<Game> Games { get; set; } = null!; // Cоздаем представление для Игр
        public DbSet<UserGame> UserGames { get; set; } = null!; // Связующая таблица для игр и юзеров
        public DbSet<Achievement> Achievements { get; set; } = null!;
        public DbSet<User_Achieve> UserAchieves { get; set; } = null!;

        public Context()
        {
            //Database.EnsureDeleted(); // Удаляем старую базу для того, чтобы при проверке не было ошибок
            Database.EnsureCreated(); // Если не создана база, то создаем
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source =meth3.db"); // Устанавливаем соединение с базой данных
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
    
}
