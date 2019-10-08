using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListTest
{
  [TestClass]
  public class ListSpec
  {

    [TestMethod]
    public void Add_AddToEmptyList_ItemGoesToIndexZero()
    {
      // arrange
      CustomList<int> testList = new CustomList<int>();
      int expected = 12;
      int actual;

      // act
      testList.Add(12);
      actual = testList[0];

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Add_AddItemToList_CountIncrements()
    {
      // arrange
      CustomList<int> testList = new CustomList<int>();
      int expected = 1;
      int actual;

      // act
      testList.Add(234);
      actual = testList.Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    // unit test for adding multiple items to check position of last item
    // unit test for adding multiple items to check Count property
    // unit test for adding number of items beyond 'Capacity' but it still adds


  }
}
