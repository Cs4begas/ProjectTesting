using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageLongestOrderSequence
{
    public class LongestOrderSequence
    {
        public decimal FindAverageMedianLongestOrderSequence(string input)
        {
            List<List<int>> longestSequenceList = FindLongestSequenceInList(input);
            List<decimal> medianList = FindMedianOfLongestOrderSequenceList(longestSequenceList);
            return FindAverangeOfListMedian(medianList);

        }
        public List<List<int>> FindLongestSequenceInList(string input)
        {
            List<List<int>> longestOrderSequenceLists = new List<List<int>>();
            List<int> tempLongestOrderSequence = new List<int>();
            int longestCount = 0;
            int lastValueSave = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char characterInput = input[i];
                int integerInput = (int)Char.GetNumericValue(characterInput);
                if (tempLongestOrderSequence.Count == 0)
                {
                    tempLongestOrderSequence.Add(integerInput);
                    lastValueSave = integerInput;
                    longestCount = tempLongestOrderSequence.Count;
                }
                else
                {
                    if (lastValueSave < integerInput)
                    {
                        tempLongestOrderSequence.Add(integerInput);
                        lastValueSave = integerInput;
                        if (i == input.Length - 1 && tempLongestOrderSequence.Count == longestCount)
                        {
                            longestOrderSequenceLists.Add(tempLongestOrderSequence);
                        }
                    }
                    else
                    {
                        lastValueSave = integerInput;
                        if (tempLongestOrderSequence.Count > longestCount)
                        {
                            longestOrderSequenceLists.Clear();
                            longestOrderSequenceLists.Add(tempLongestOrderSequence);
                            longestCount = tempLongestOrderSequence.Count;
                        }
                        else if (tempLongestOrderSequence.Count == longestCount)
                        {
                            longestOrderSequenceLists.Add(tempLongestOrderSequence);
                        }
                        tempLongestOrderSequence = new List<int>() { lastValueSave };
                        if(i == input.Length - 1 && tempLongestOrderSequence.Count == longestCount)
                        {
                            longestOrderSequenceLists.Add(tempLongestOrderSequence);
                        }
                    }
                }
            }
            return longestOrderSequenceLists;
        }
        public List<decimal> FindMedianOfLongestOrderSequenceList(List<List<int>> longestOrderSequenceLists)
        {
            List<decimal> medianListResult = new List<decimal>();
            foreach (List<int> item in longestOrderSequenceLists)
            {
                decimal medianResult = FindMedian(item);
                medianListResult.Add(medianResult);
            }
            return medianListResult;
        }

        public decimal FindMedian(List<int> listValue)
        {
            int count = listValue.Count;
            if(listValue.Count % 2 == 0)
            {
                int a = listValue[count / 2 - 1];
                int b = listValue[count / 2];
                return (a + b) / 2m;
            }
            else
            {
                return listValue[count / 2];
            }
        }
        public decimal FindAverangeOfListMedian(List<decimal> listMedian)
        {
            return Math.Round(listMedian.Average(),2);
        }
    }
}
