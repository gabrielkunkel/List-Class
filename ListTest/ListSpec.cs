using List;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ListTest
{
  [TestClass]
  public class ListSpec
  {

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Indexer_GreaterCapacity_ThrowOutsideOfRange()
    {
      CustomList<string> testList = new CustomList<string>(10);
      testList[2] = "Bob";
    }

    [TestMethod]
    public void Capacity_ConstructorMakesThree()
    {
      CustomList<int> testList = new CustomList<int>(3);
      
      int actual = testList.Capacity;
      int expected = 3;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Count_ConstructorMakesThree_ShouldReturn0()
    {
      CustomList<int> testList = new CustomList<int>(3);

      int actual = testList.Count;
      int expected = 0;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Capacity_StringCreateEmptyClassWithConstructorSet_ShouldThrow()
    {
      CustomList<string> testList = new CustomList<string>(3);
      testList[2] = "Daryl";
    }


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

    [TestMethod]
    public void Add_AddMultipleItemsToList_CheckPositionOfLastItem()
    {
      // arrange
      CustomList<int> testList = new CustomList<int>();
      int expected = 6;
      int actual;

      // act
      testList.Add(4);
      testList.Add(5);
      testList.Add(6);
      actual = testList[testList.Count - 1];

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Add_AddMultipleItemsToList_CountProperty()
    {
      // arrange
      CustomList<int> testList = new CustomList<int>();
      int expected = 3;
      int actual;

      // act
      testList.Add(4);
      testList.Add(5);
      testList.Add(6);
      actual = testList.Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Remove_RemoveLastIntItem_CountReduces()
    {
      // arrange
      CustomList<int> customList = new CustomList<int>(5);
      int actual;
      int expected = 9;

      // act
      customList.Add(1);
      customList.Add(2);
      customList.Add(3);
      customList.Add(4);
      customList.Add(5);
      customList.Remove(5);

      actual = customList.Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Remove_RemoveSecondToLastIntItem_CountReduces()
    {
      // arrange
      CustomList<int> customList = new CustomList<int>(5);
      int actual;
      int expected = 9;

      // act
      customList.Add(1);
      customList.Add(2);
      customList.Add(3);
      customList.Add(4);
      customList.Add(5);
      customList.Remove(4);

      actual = customList.Count;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Remove_RemoveLastIntItem_ElementIsRemoved()
    {
      // arrange
      CustomList<int> customList = new CustomList<int>(5);

      // act
      customList.Add(5);
      customList.Add(4);
      customList.Add(3);
      customList.Add(2);
      customList.Add(1);
      customList.Remove(1);

      int actual = customList[9]; // throws exception
    }

    [TestMethod]
    public void Remove_RemoveSecondToLastIntItem_ElementIsRemoved()
    {
      // arrange
      CustomList<int> customList = new CustomList<int>(5);
      int actual;
      int expected = 5;

      // act
      customList.Add(1);
      customList.Add(2);
      customList.Add(3);
      customList.Add(4);
      customList.Add(5);
      customList.Remove(4);

      actual = customList[8];

      // assert
      Assert.AreEqual(expected, actual);
    }


  }
}
