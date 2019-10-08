using System.Collections;

namespace List
{
  public class CustomList<T> : IEnumerable
  {
    private T[] items;
    public int Count;


    public CustomList()
    {
      items = new T[4];
    }

    public T this[int i]
    {
      get { return items[i]; }
      set { items[i] = value; }
    }

    public void Add(T itemToAdd)
    {

    }

    public IEnumerator GetEnumerator()
    {
      throw new System.NotImplementedException();
    }
  }
}
