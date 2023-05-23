namespace Meth3;

public class Rep2 <T> : Repository<T>
{
    public List<T> rep = new List<T>();
    public override T GetById(int id)
    {
        return rep[id];
    }

    public override void Add(T t)
    {
        if (rep.Contains(t))
        {
            Console.WriteLine("Вы пытаетесь добавить уже существующую запись");
        }
        else rep.Add(t);
    }

    public override void RemoveById(int id)
    {
        rep.RemoveAt(id);
    }

    public override List<T> GetAll()
    {
        return rep;
    }

    public override void UpdateById(int id, T t)
    {
        rep[id] = t;
    }
}