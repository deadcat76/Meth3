using Meth3;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var service = new BLService();
using (DataAccessLayer.Context meth = new DataAccessLayer.Context())
{
    app.Map("/FindUsersWithSameGames/", () => $"{JsonConvert.SerializeObject(meth.FindUsersWithSameGames())}");

    app.Map("/FindByEmail/{email}", (string email) => $"{JsonConvert.SerializeObject(meth.FindUserByEmail(email))}");

    app.Map("/Users/", () => $"{JsonConvert.SerializeObject(meth.GetAllUsers())}");
    
    app.Run();
}

