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
    public void Capacity_IntCreateEmptyClassWithConstructorSet_ShouldThrow()
    {
      CustomList<int> testList = new CustomList<int>(3);
      testList[2] = 5;
    }

    //[TestMethod]
    //public void SetArraySize_AddPastCapacity_Return2TimesArraySize()
    //{
    //  string[] workingArray = new string[]


    //}



    [TestMethod]
    public void Add_ListIncreasesCapacityPassingCapacity_CapacityGoesUpTimes2()
    {
      CustomList<int> testList = new CustomList<int>();
      
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);

      Assert.AreEqual(4, testList.Capacity);
    }

    [TestMethod]
    public void Add_ListIncreasesCapacityPassingCapacity_CapacityGoesUpTimes2Past4()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);
      testList.Add(5);

      Assert.AreEqual(8, testList.Capacity);
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

    [TestMethod]
    public void Remove_ListDecreasesCapacity_CapacityGoesDownTimes2()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);
      testList.Add(5);
      testList.Add(6);
      testList.Add(7);
      testList.Add(8);

      Assert.AreEqual(16, testList.Capacity);

      testList.Remove(8);
      testList.Remove(9);

      Assert.AreEqual(8, testList.Capacity);
    }
  }
}
