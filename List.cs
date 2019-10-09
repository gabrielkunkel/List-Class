using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
  public class CustomList<T> : IEnumerable<T>
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
      T[] workingArray = SetItemsArrayCapacityForGrowth(ref items);
      workingArray[count-1] = itemToAdd;
      items = workingArray;
    }

    public void Remove(T itemToRemove)
    {
      count -= 1;
      SearchAndRemoveFirstInstance(itemToRemove);
      ShrinkItemsArrayCapacity();
    }



    private void SearchAndRemoveFirstInstance(T itemToRemove)
    {
      bool firstInstanceFound = false;

      for (int i = 0; i < items.Length; i++)
      {
        if (firstInstanceFound == false)
        {
          if (object.Equals(itemToRemove, items[i]))
          {
            firstInstanceFound = true;
            continue;
          }
        }
        else
        {
          items[i-1] = items[i];
        }
      }
    }

    private T[] SetItemsArrayCapacityForGrowth(ref T[] workingArray)
    {
      if (count > Capacity)
      {
        return BuildLargerArray(new T[Capacity * 2]);
      }
      else
      {
        return workingArray;
      }
    }

    private void ShrinkItemsArrayCapacity()
    {
      if (count < Capacity / 2)
      {
        items = BuildSmallerArray(new T[Capacity / 2]);
      }
    }

    private T[] BuildLargerArray(T[] workingArray)
    {
      for (int i = 0; i < items.Length; i++)
      {
        workingArray[i] = items[i];
      }
      return workingArray;
    }

    private T[] BuildSmallerArray(T[] workingArray)
    {
      for (int i = 0; i < workingArray.Length; i++)
      {
        workingArray[i] = items[i];
      }
      return workingArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
      foreach (T item in items)
      {
        if (item == null)
        {
          break;
        }

        yield return item;
      }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

  }
}
