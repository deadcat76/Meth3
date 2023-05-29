namespace Meth3;
using Microsoft.EntityFrameworkCore;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(string table = null);
    void Update(T obj);
    T GetById(int ID);
    void Add(T obj);
    void Delete(int ID);
}