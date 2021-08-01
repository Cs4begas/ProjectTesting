using Microsoft.VisualStudio.TestTools.UnitTesting;
using AverageLongestOrderSequence;
using System;
using System.Collections.Generic;
namespace AverageLongestOrderSequenceTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly LongestOrderSequence longestOrderSequence = new LongestOrderSequence();
        [TestMethod]
        public void TestInput1()
        {
            List<List<int>> response = longestOrderSequence.FindLongestSequenceInList("12401021");
            Assert.AreEqual(1, response.Count);
            List<decimal> listMedianCheck = new List<decimal>() { 2 };
            List<decimal> listMedianResponse = longestOrderSequence.FindMedianOfLongestOrderSequenceList(response);
            CollectionAssert.AreEqual(listMedianCheck, listMedianResponse);
            decimal averageMedian = longestOrderSequence.FindAverangeOfListMedian(listMedianResponse);
            Assert.AreEqual(2, averageMedian);

        }
        [TestMethod]
        public void TestInput2()
        {
            List<List<int>> response = longestOrderSequence.FindLongestSequenceInList("7124501115793");
            Assert.AreEqual(2, response.Count);
            List<decimal> listMedianCheck = new List<decimal>() { 3, 6 };
            List<decimal> listMedianResponse = longestOrderSequence.FindMedianOfLongestOrderSequenceList(response);
            CollectionAssert.AreEqual(listMedianCheck, listMedianResponse);
            decimal averageMedian = longestOrderSequence.FindAverangeOfListMedian(listMedianResponse);
            Assert.AreEqual(4.5m, averageMedian);
        }
        [TestMethod]
        public void TestInput3()
        {
            List<List<int>> response = longestOrderSequence.FindLongestSequenceInList("78912340123");
            Assert.AreEqual(2, response.Count);
            List<decimal> listMedianCheck = new List<decimal>() { 2.5m, 1.5m };
            List<decimal> listMedianResponse = longestOrderSequence.FindMedianOfLongestOrderSequenceList(response);
            CollectionAssert.AreEqual(listMedianCheck, listMedianResponse);
            decimal averageMedian = longestOrderSequence.FindAverangeOfListMedian(listMedianResponse);
            Assert.AreEqual(2, averageMedian);
        }
        [TestMethod]
        public void TestInput4()
        {
            List<List<int>> response = longestOrderSequence.FindLongestSequenceInList("8765");
            Assert.AreEqual(4, response.Count);
            List<decimal> listMedianCheck = new List<decimal>() { 8, 7, 6, 5 };
            List<decimal> listMedianResponse = longestOrderSequence.FindMedianOfLongestOrderSequenceList(response);
            CollectionAssert.AreEqual(listMedianCheck, listMedianResponse);
            decimal averageMedian = longestOrderSequence.FindAverangeOfListMedian(listMedianResponse);
            Assert.AreEqual(6.5m, averageMedian);
        }
        [TestMethod]
        public void TestInput5()
        {
            List<List<int>> response = longestOrderSequence.FindLongestSequenceInList("913578345692801789");
            Assert.AreEqual(3, response.Count);
            List<decimal> listMedianCheck = new List<decimal>() { 5,5,7 };
            List<decimal> listMedianResponse = longestOrderSequence.FindMedianOfLongestOrderSequenceList(response);
            CollectionAssert.AreEqual(listMedianCheck, listMedianResponse);
            decimal averageMedian = longestOrderSequence.FindAverangeOfListMedian(listMedianResponse);
            Assert.AreEqual(5.67m, averageMedian);
        }
    }
}
