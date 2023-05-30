namespace Meth3;

public class BLService
{
    private readonly IRepository<User> _userrepo;
    private readonly IRepository<Game> _gamerepo;
    private readonly IRepository<UserGame> _usergamerepo;
    private readonly DataAccessLayer.UnitOfWork _unitOfWork;

    public BLService()
    {
        _unitOfWork = new DataAccessLayer.UnitOfWork();
        _userrepo = _unitOfWork.Users;
        _gamerepo = _unitOfWork.Games;
        _usergamerepo = _unitOfWork.UserGames;
    }
    
    public List<User?> FindUsersWithSameGames()
    {
        var users = _usergamerepo.GetAll()
            .GroupBy(x => x.User)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();
        return users;
    }

    
}