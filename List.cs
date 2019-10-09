using System;
using System.Collections;

namespace List
{
  public class CustomList<T> : IEnumerable
  {
    private T[] items;
    private int count;

    public int Capacity
    {
      get
      {
        return items.Length;
      }
    }

    public int Count { get => count; }

    public CustomList()
    {
      items = new T[1];
    }

    public CustomList(int startingCapacity)
    {
      items = new T[startingCapacity];
    }

    public T this[int i]
    {
      get { 
        if (i < 0 || i >= count)
        {
          throw new IndexOutOfRangeException();
        }
        else
        {
          return items[i];
        }
      }
      set {
        if (i < 0 || i > count)
        {
          throw new ArgumentOutOfRangeException();
        }
        else
        {
          items[i] = value;
        } 
      }
    }

    public void Add(T itemToAdd)
    {
      count += 1;
      T[] workingArray = SetArraySize(ref items);
      workingArray[count-1] = itemToAdd;
      items = workingArray;
    }

    public void Remove(T itemToRemove)
    {
      count -= 1;
      T[] workingArray = SetArraySize(ref items);
      workingArray[count-1] = itemToRemove;
    }

    public T[] SetArraySize(ref T[] workingArray)
    {
      if (count > Capacity)
      {
        return buildNewArray(new T[Capacity * 2]);
      }
      else if (count < Capacity / 2)
      {
        return buildNewArray(new T[Capacity / 2]);
      }
      else
      {
        return workingArray;
      }
    }

    private T[] buildNewArray(T[] workingArray)
    {
      for (int i = 0; i < items.Length; i++)
      {
        workingArray[i] = items[i];
      }
      return workingArray;
    }

    public IEnumerator GetEnumerator()
    {
      throw new System.NotImplementedException();
    }
  }
}
