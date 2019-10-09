using System.Collections;

namespace List
{
  public class CustomList<T> : IEnumerable
  {
    private T[] items;

    public int Capacity
    {
      get
      {
        return items.Length;
      }
    }

    public int Count { get => getTotalElementsUsed(); }
    // todo: when you set Count, check capacity and update it accordingly?


    public CustomList()
    {
      items = new T[0];
    }

    public CustomList(int startingLength)
    {
      items = new T[startingLength];
    }

    public T this[int i]
    {
      get { return items[i]; }
      // todo: if out of Count range throw exception
      set { items[i] = value; }
    }

    public void Add(T itemToAdd)
    {
      T[] newArray = new T[items.Length + 1];
      // todo: set length at 2X threshold when at capacity

      for (int i = 0; i < items.Length; i++)
      {
        newArray[i] = items[i];
      }
      newArray[newArray.Length - 1] = itemToAdd;
      items = newArray;
    }

    public void Remove(T itemToRemove)
    {
      // todo: reduce length at Capacity/2

    }

    private int getTotalElementsUsed()
    {
      int totalElementsUsed = 0;

      for (int i = 0; i < items.Length; i++)
      {
        if (items[i] == null)
        {
          continue;
        }
        else
        {
          totalElementsUsed += 1;
        }
      }
      return totalElementsUsed;
    }

    public IEnumerator GetEnumerator()
    {
      throw new System.NotImplementedException();
    }
  }
}
