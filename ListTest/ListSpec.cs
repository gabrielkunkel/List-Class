﻿using List;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListTest
{
  [TestClass]
  public class ListSpec
  {

    [TestMethod]
    public void Count_2ItemsHaveNullableTypes()
    {
      // arrange
      CustomList<string> testList = new CustomList<string>(10);
      testList[2] = "Bob";
      testList[4] = "Shari";

      // act
      int actual = testList.Count;
      int expected = 2;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Capacity_2ItemsHaveNullableTypes()
    {
      // arrange
      CustomList<string> testList = new CustomList<string>(10);
      testList[2] = "Bob";
      testList[4] = "Shari";

      // act
      int actual = testList.Capacity;
      int expected = 10;

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Constructor_IntCreateEmptyClassWithSetCapacity()
    {
      // arrange
      CustomList<int> testList = new CustomList<int>(3);
      testList[2] = 4;

      // act
      int actual = testList[2];
      int expected = 4;

      // assert
      Assert.AreEqual(expected, actual);
      Assert.AreEqual(testList[0], 0);
    }

    [TestMethod]
    public void Constructor_IntCreateEmptyClassWithSetCapacity_UnassignedAreZero()
    {
      // arrange
      CustomList<int> testList = new CustomList<int>(3);

      // act
      testList[2] = 4;

      // assert
      Assert.AreEqual(testList[0], 0);
      Assert.AreEqual(testList[1], 0);
    }

    [TestMethod]
    public void Constructor_StringCreateEmptyClassWithSetCapacity()
    {
      // arrange
      CustomList<string> testList = new CustomList<string>(3);
      testList[2] = "Daryl";

      // act
      string actual = testList[2];
      string expected = "Daryl";

      // assert
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Constructor_StringCreateEmptyClassWithSetCapacity_UnassignedAreNull()
    {
      // arrange
      CustomList<string> testList = new CustomList<string>(3);


      // act
      testList[2] = "Daryl";

      // assert
      Assert.AreEqual(testList[0], null);
      Assert.AreEqual(testList[1], null);
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

  }
}
