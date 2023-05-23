namespace Meth3;
using Microsoft.EntityFrameworkCore;

public abstract class Repository <T>
{
    public abstract T GetById(int id);
    public abstract void Add(T t);
    public abstract void RemoveById(int id);
    public abstract List<T> GetAll();
    public abstract void UpdateById(int id, T t);
}