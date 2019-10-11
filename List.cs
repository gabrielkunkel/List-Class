using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
  public class CustomList<T> : IEnumerable<T> where T : IComparable
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
        if (i < 0 || i >= count)
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

    public static CustomList<T> operator + (CustomList<T> a, CustomList<T> b)
    {
      CustomList<T> workingList = new CustomList<T>();

      foreach (T item in a)
      {
        workingList.Add(item);
      }

      foreach (T item in b)
      {
        workingList.Add(item);
      }

      return workingList;
    }

    public static CustomList<T> operator - (CustomList<T> a, CustomList<T> b)
    {
      CustomList<T> newList = new CustomList<T>();

      for (int i = 0; i < a.Count; i++)
      {
        if(IsElementInCustomList(a[i], b) == false)
        {
          newList.Add(a[i]);
        }
      }

      return newList;
    }

    public override string ToString()
    {
      StringBuilder workingString = new StringBuilder();
      workingString.Append("[");

      for (int i = 0; i < Count; i++)
      {
        workingString.Append(items[i]);

        if(i < Count-1)
        {
          workingString.Append(", ");
        }
      }
      workingString.Append("]");

      return workingString.ToString();
    }

    private static bool IsElementInCustomList(T element, CustomList<T> customList)
    {

      for (int i = 0; i < customList.Count; i++)
      {
        if (customList[i].Equals(element))
        {
          return true;
        }
      }

      return false;
    }

    public CustomList<T> Zip(CustomList<T> listToZipWith)
    {
      CustomList<T> workingCustomList = new CustomList<T>();

      for (int i = 0; i < Count || i < listToZipWith.Count; i++)
      {
        if (i < Count)
        {
          workingCustomList.Add(items[i]);
        }

        if (i < listToZipWith.Count)
        {
          workingCustomList.Add(listToZipWith[i]);
        }
      }

      return workingCustomList;
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

    public void Sort()
    {
      QuickSorter quickSorter = new QuickSorter();
      items = quickSorter.Sort<T>(items, Count - 1);
    }

    public IEnumerator<T> GetEnumerator()
    {

      for (int i = 0; i < Count; i++)
      {
        if (items[i] == null)
        {
          break;
        }
        yield return items[i];

      }

    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

  }
}
