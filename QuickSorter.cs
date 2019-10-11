using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
  public class QuickSorter
  {

    // Adapted from: https://blogsprajeesh.blogspot.com/2008/07/generic-implementation-of-sorting_17.html
    public T[] Sort<T>(T[] items, int count) where T : IComparable
    {
      T[] sortedItems = items;
      QuickSort(ref items, 0, count);
      return sortedItems;
    }

    private void QuickSort<T>(ref T[] sortedItems, int left, int right) where T : IComparable
    {
      if (right <= left) return;
      int i = Partition(ref sortedItems, left, right);
      QuickSort(ref sortedItems, left, i - 1);
      QuickSort(ref sortedItems, i + 1, right);
    }
    private int Partition<T>(ref T[] a, int l, int r) where T : IComparable
    {
      T tmp;
      int i = l - 1;
      int j = r;
      T v = a[r]; for (; ; )
      {
        while (a[++i].CompareTo(v) == -1)
        {
        }
        while (v.CompareTo(a[--j]) == -1)
        {
          if (j == l) break;
        }
        if (i >= j) break;
        tmp = a[i];
        a[i] = a[j];
        a[j] = tmp;
      }
      a[r] = a[i];
      a[i] = v;
      return i;
    }

    internal object[] Sort<M>(object[] items, int count) where M : IComparable
    {
      throw new NotImplementedException();
    }
  }
}
