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
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Indexer_GetAtCount_ThrowOutsideOfIndex()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);
      testList.Remove(4);

      int number = testList[4];
    }

    [TestMethod]
    public void Capacity_ConstructorMakesThree_CapacityEquals3()
    {
      CustomList<int> testList = new CustomList<int>(3);
      
      int actual = testList.Capacity;
      int expected = 3;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Capacity_IntCreateEmptyClassWithConstructorSet_ShouldThrow()
    {
      CustomList<int> testList = new CustomList<int>(3);
      testList[2] = 5;
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

      testList.Add(6);
      testList.Add(7);
      testList.Add(8);
      testList.Add(9);

      Assert.AreEqual(16, testList.Capacity);
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
      CustomList<int> customList = new CustomList<int>();
      int actual;
      int expected = 4;

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
      CustomList<int> customList = new CustomList<int>();
      int actual;
      int expected = 4;

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
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Remove_RemoveLastIntItem_ElementIsRemoved()
    {
      // arrange
      CustomList<int> customList = new CustomList<int>();

      // act
      customList.Add(0);
      customList.Add(1);
      customList.Add(2);
      customList.Add(3);
      customList.Add(4);
      customList.Remove(4);

      int actual = customList[4]; // throws exception
    }

    [TestMethod]
    public void Remove_RemoveSecondToLastIntItem_ElementIsRemoved()
    {
      // arrange
      CustomList<int> customList = new CustomList<int>();

      // act
      customList.Add(0);
      customList.Add(1);
      customList.Add(2);
      customList.Add(3);
      customList.Add(4);
      customList.Remove(3);

      // assert
      Assert.AreEqual(4, customList[3]);
    }

    [TestMethod]
    public void Remove_ListDecreasesCapacity_CapacityGoesDownTimes2()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);
      testList.Add(5);
      testList.Add(6);
      testList.Add(7);
      testList.Add(8);
      testList.Add(9); // count == 9

      Assert.AreEqual(9, testList.Count);
      Assert.AreEqual(16, testList.Capacity);

      testList.Remove(8); // count == 8
      testList.Remove(9); // count == 7

      Assert.AreEqual(8, testList.Capacity);
    }

    [TestMethod]
    public void Remove_ListDecreasesCount_CountGoesDownBy1()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);

      Assert.AreEqual(4, testList.Count);

      testList.Remove(2);

      Assert.AreEqual(3, testList.Count);
    }

    [TestMethod]
    public void Remove_ListWithMultipleSameIntValues_OnlyRemovesOne()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(1);
      testList.Add(2);
      testList.Add(1);
      testList.Add(3);
      testList.Add(1);

      Assert.AreEqual(5, testList.Count);

      testList.Remove(1);

      Assert.AreEqual(4, testList.Count);
      Assert.AreEqual(2, testList[0]);
      Assert.AreEqual(1, testList[1]);
      Assert.AreEqual(1, testList[3]);
    }

    [TestMethod]
    public void GetEnumerator_UseForEachOnIntList()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);

      int expected = 10;
      int actual = 0;

      foreach (int item in testList)
      {
        actual += item;
      }

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ToString_WithInts()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);

      string expected = "[0, 1, 2, 3, 4]";
      string actual = testList.ToString();

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ToString_WithStrings()
    {
      CustomList<string> testList = new CustomList<string>();

      testList.Add("bob");
      testList.Add("bob");
      testList.Add("bob");
      testList.Add("bob");
      testList.Add("bob");

      string expected = "[bob, bob, bob, bob, bob]";
      string actual = testList.ToString();

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void PlusOperator_CombineTwoIntLists()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);

      CustomList<int> testListb = new CustomList<int>();

      testListb.Add(5);
      testListb.Add(6);
      testListb.Add(7);
      testListb.Add(8);
      testListb.Add(9);

      CustomList<int> actual = testList + testListb;
      CustomList<int> testListc = new CustomList<int>();

      testListc.Add(0);
      testListc.Add(1);
      testListc.Add(2);
      testListc.Add(3);
      testListc.Add(4);
      testListc.Add(5);
      testListc.Add(6);
      testListc.Add(7);
      testListc.Add(8);
      testListc.Add(9);

      for (int i = 0; i < testListc.Count; i++)
      {
        Assert.AreEqual(testListc[i], actual[i]);
      }
    }

    [TestMethod]
    public void PlusOperator_CombineTwoIntLists_ReturnCombinedCount()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);

      CustomList<int> testListb = new CustomList<int>();

      testListb.Add(5);
      testListb.Add(6);
      testListb.Add(7);
      testListb.Add(8);
      testListb.Add(9);

      CustomList<int> actual = testList + testListb;


      Assert.AreEqual(10, actual.Count);
    }

    [TestMethod]
    public void PlusOperator_CombineListsAreUnaltered_ReturnCombinedCount()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);

      CustomList<int> testListb = new CustomList<int>();

      testListb.Add(5);
      testListb.Add(6);
      testListb.Add(7);
      testListb.Add(8);
      testListb.Add(9);

      CustomList<int> actual = testList + testListb;


      Assert.AreEqual(actual.Count, testList.Count + testListb.Count);
    }

    [TestMethod]
    public void MinusOperator_SubtractOneIstanceFromAnother()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(1);
      testList.Add(2);
      testList.Add(3);
      testList.Add(4);

      CustomList<int> testListb = new CustomList<int>();

      testListb.Add(0);
      testListb.Add(1);
      testListb.Add(5);
      testListb.Add(6);
      testListb.Add(7);

      CustomList<int> actual = testList - testListb;
      CustomList<int> testListc = new CustomList<int>();

      testListc.Add(2);
      testListc.Add(3);
      testListc.Add(4);

      for (int i = 0; i < testListc.Count; i++)
      {
        Assert.AreEqual(testListc[i], actual[i]);
      }
    }

    [TestMethod]
    public void MinusOperator_SubtractOneIstanceFromAnother_Strings()
    {
      CustomList<string> testList = new CustomList<string>();

      testList.Add("aaa");
      testList.Add("ccc");
      testList.Add("eee");
      testList.Add("ggg");
      testList.Add("iii");

      CustomList<string> testListb = new CustomList<string>();

      testListb.Add("bbb");
      testListb.Add("ddd");
      testListb.Add("fff");
      testListb.Add("hhh");
      testListb.Add("jjj");
      testListb.Add("ggg");

      CustomList<string> actual = testList - testListb;
      CustomList<string> testListc = new CustomList<string>();

      testListc.Add("aaa");
      testListc.Add("ccc");
      testListc.Add("eee");
      testListc.Add("iii");

      for (int i = 0; i < testListc.Count; i++)
      {
        Assert.AreEqual(testListc[i], actual[i]);
      }

    }

    [TestMethod]
    public void MinusOperator_SubtractMultipleIstanceFromAnother_Strings()
    {
      CustomList<string> testList = new CustomList<string>();

      testList.Add("aaa");
      testList.Add("ccc");
      testList.Add("eee");
      testList.Add("ggg");
      testList.Add("iii");
      testList.Add("ggg");

      CustomList<string> testListb = new CustomList<string>();

      testListb.Add("bbb");
      testListb.Add("ddd");
      testListb.Add("fff");
      testListb.Add("hhh");
      testListb.Add("jjj");
      testListb.Add("ggg");
      testListb.Add("aaa");

      CustomList<string> actual = testList - testListb;
      CustomList<string> testListc = new CustomList<string>();

      testListc.Add("ccc");
      testListc.Add("eee");
      testListc.Add("iii");

      for (int i = 0; i < testListc.Count; i++)
      {
        Assert.AreEqual(testListc[i], actual[i]);
      }

    }


    [TestMethod]
    public void Zip_PutTwoCustomIntListsTogether()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(2);
      testList.Add(4);
      testList.Add(6);
      testList.Add(8);

      CustomList<int> testListb = new CustomList<int>();

      testListb.Add(1);
      testListb.Add(3);
      testListb.Add(5);
      testListb.Add(7);
      testListb.Add(9);

      CustomList<int> actual = testList.Zip(testListb);
      CustomList<int> testListc = new CustomList<int>();

      testListc.Add(0);
      testListc.Add(1);
      testListc.Add(2);
      testListc.Add(3);
      testListc.Add(4);
      testListc.Add(5);
      testListc.Add(6);
      testListc.Add(7);
      testListc.Add(8);
      testListc.Add(9);

      for (int i = 0; i < testListc.Count; i++)
      {
        Assert.AreEqual(testListc[i], actual[i]);
      }
    }

    [TestMethod]
    public void Zip_PutTwoCustomStringListsTogether()
    {
      CustomList<string> testList = new CustomList<string>();

      testList.Add("aaa");
      testList.Add("ccc");
      testList.Add("eee");
      testList.Add("ggg");
      testList.Add("iii");

      CustomList<string> testListb = new CustomList<string>();

      testListb.Add("bbb");
      testListb.Add("ddd");
      testListb.Add("fff");
      testListb.Add("hhh");
      testListb.Add("jjj");

      CustomList<string> actual = testList.Zip(testListb);
      CustomList<string> testListc = new CustomList<string>();

      testListc.Add("aaa");
      testListc.Add("bbb");
      testListc.Add("ccc");
      testListc.Add("ddd");
      testListc.Add("eee");
      testListc.Add("fff");
      testListc.Add("ggg");
      testListc.Add("hhh");
      testListc.Add("iii");
      testListc.Add("jjj");

      for (int i = 0; i < testListc.Count; i++)
      {
        Assert.AreEqual(testListc[i], actual[i]);
      }
    }

    [TestMethod]
    public void Zip_PutTwoUnevenIntListsTogether()
    {
      CustomList<int> testList = new CustomList<int>();

      testList.Add(0);
      testList.Add(2);
      testList.Add(4);
      testList.Add(6);
      testList.Add(7);
      testList.Add(8);
      testList.Add(9);

      CustomList<int> testListb = new CustomList<int>();

      testListb.Add(1);
      testListb.Add(3);
      testListb.Add(5);

      CustomList<int> actual = testList.Zip(testListb);
      CustomList<int> testListc = new CustomList<int>();

      testListc.Add(0);
      testListc.Add(1);
      testListc.Add(2);
      testListc.Add(3);
      testListc.Add(4);
      testListc.Add(5);
      testListc.Add(6);
      testListc.Add(7);
      testListc.Add(8);
      testListc.Add(9);

      for (int i = 0; i < testListc.Count; i++)
      {
        Assert.AreEqual(testListc[i], actual[i]);
      }
    }

    [TestMethod]
    public void Zip_PutTwoUnevenStringListsTogether()
    {
      CustomList<string> testList = new CustomList<string>();

      testList.Add("aaa");
      testList.Add("ccc");
      testList.Add("eee");

      CustomList<string> testListb = new CustomList<string>();

      testListb.Add("bbb");
      testListb.Add("ddd");
      testListb.Add("fff");
      testListb.Add("ggg");
      testListb.Add("hhh");
      testListb.Add("iii");
      testListb.Add("jjj");

      CustomList<string> actual = testList.Zip(testListb);
      CustomList<string> testListc = new CustomList<string>();

      testListc.Add("aaa");
      testListc.Add("bbb");
      testListc.Add("ccc");
      testListc.Add("ddd");
      testListc.Add("eee");
      testListc.Add("fff");
      testListc.Add("ggg");
      testListc.Add("hhh");
      testListc.Add("iii");
      testListc.Add("jjj");

      for (int i = 0; i < testListc.Count; i++)
      {
        Assert.AreEqual(testListc[i], actual[i]);
      }
    }



  }
}
