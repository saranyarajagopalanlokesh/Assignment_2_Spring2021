using System;
using System.Collections.Generic;
using System.Linq;
using DotNetty.Common.Utilities;
using Lucene.Net.Support;

namespace Assignment2_DIS_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            ShuffleArray(ar1, n1);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        /// Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        ///Example 1:
        ///Input: nums = [2,5,1,3,4,7], n = 3
        ///Output: [2,3,5,4,1,7]
        ///  Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        ///Example 2:
        ///Input: nums = [1,2,3,4,4,3,2,1], n = 4
        ///Output: [1,4,2,3,3,2,4,1]
        ///Example 3:
        ///Input: nums = [1,1,2,2], n = 2
        ///Output: [1,2,1,2]
        /// </summary>

        private static void ShuffleArray(int[] nums, int n)
        {
            try
            {
                //write your code here.

                var res = new int[nums.Length];
                var index = 0;
                for (int i = 0, j = n; j < nums.Length; i++, j++)
                {
                    res[index] = nums[i];
                    index++;
                    res[index] = nums[j];
                    index++;
                }
                foreach(int a in res)
                Console.Write(a +",");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
        /// Example:
        ///Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </summary>

        private static void MoveZeroes(int[] ar2)
        {
            try
            {
                //write your code here.
                int counter = 0;
                int size = ar2.Length;
                // change the array
                for (int i = 0; i < size; i++)
                    if (ar2[i] != 0)
                        ar2[counter++] = ar2[i];
                while (counter < size)
                    ar2[counter++] = 0;
                for (int i = 0; i < size; i++)
                    Console.Write(ar2[i] + ",");
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Question 3
        /// <summary>
        /// For an array of integers - nums
        ///A pair(i, i) is called cool if nums[i] == nums[i] and i<i
        ///Print the number of cool pairs
        ///Example 1
        ///Input: nums = [1,2,3,1,1,3]
        ///Output: 4
        ///Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        ///Example 3:
        ///Input: nums = [1, 2, 3]
        ///Output: 0
        ///Constraints: time complexity should be O(n).
        /// </summary>

        private static void CoolPairs(int[] nums)
        {
            try
            {
                //write your code here.
                var coolpair = new Dictionary<int, int>();

                foreach (var el in nums)
                {
                    if (coolpair.ContainsKey(el)) 
                        coolpair[el] += 1;
                    else coolpair.Add(el, 1);
                }

                var pairs = 0;

                foreach (var el in coolpair)
                {
                    pairs += el.Value * (el.Value - 1) / 2;
                }

                Console.WriteLine(pairs);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two numbers such that they add up to the target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can print the answer in any order
        ///Example 1:
        ///Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        ///Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        ///Example 2:
        ///Input: nums = [3,2,4], target = 6
        ///Output: [1,2]
        ///Example 3:
        ///Input: nums = [3,3], target = 6
        ///Output: [0,1]
        ///Constraints: Time complexity should be O(n)
        /// </summary>
        private static void TwoSum(int[] nums, int target)
        {
            try
            {

                //write your code here.
                int l, r;
                int arr_size = nums.Length;
                // Sort
                sort(nums, 0, arr_size - 1);

               
                l = 0;
                r = arr_size - 1;
                while (l < r)
                {
                    if (nums[l] + nums[r] == target)
                    {
                        Console.WriteLine(nums[l] + " " + nums[r]); break;
                    }
                    else if (nums[l] + nums[r] < target)
                        l++;
                    else // num[i] + num[i] > sum
                        r--;
                }
            }
            catch (Exception)
            {

                throw;
            }
            /* to sort array using QuickSort */

            static int divideRule(int[] arr, int low, int high)
            {
                int pivot = arr[high];

                // index of smaller element
                int i = (low - 1);
                for (int j = low; j <= high - 1; j++)
                {
                    if (arr[j] <= pivot)
                    {
                        i++;

                        // swap arr[i] and arr[i]
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }

                // swap arr[i+1] and arr[high] (or pivot)
                int temp1 = arr[i + 1];
                arr[i + 1] = arr[high];
                arr[high] = temp1;

                return i + 1;
            }
            static void sort(int[] arr, int low, int high)
            {
                if (low < high)
                {
                    int pi = divideRule(arr, low, high);
                    sort(arr, low, pi - 1);
                    sort(arr, pi + 1, high);
                }
            }

        }

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        ///The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        ///Print the shuffled string.
        ///Example 1
        ///Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        ///Output: "usfrocky"
        ///Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        ///Example 2:
        ///Input: s = "USF", indices = [0,1,2]
        ///Output: "USF"
        ///Explanation: After shuffling, each character remains in its position.
        ///Example 3:
        ///Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        ///Output: "rocky"
        /// </summary>
        private static void RestoreString(string s, int[] indices)
        {
            try
            {
                //write your code here.
                Dictionary<int, string> map = new Dictionary<int, string>();
                string resultStr = "";
                for (int i = 0; i < s.Length; i++)
                {
                   map.Add(indices[i],s[i].ToString());
                }

                for (int i = 0; i < s.Length; i++)
				{
                    resultStr = resultStr + map[i];

                }
                Console.WriteLine("Reordered string :" + resultStr);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        ///Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        ///All occurrences of a character must be replaced with another character while preserving the order of characters.
        ///No two characters may map to the same character but a character may map to itself.
        ///Example 1:
        ///Input:s1 = “bulls” s2 = “sunny” 
        ///Output : True
        ///Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        ///Example 2:
        ///Input: s1 = “usf” s2 = “add”
        ///Output : False
        ///Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        ///Example 3:
        ///Input : s1 = “ab” s2 = “aa”
        ///Output: False
        /// </summary>
        private static bool Isomorphic(string s1, string s2)
        {
            try
            {
                //write your code here.
                int size = 256;
                int m = s1.Length;
                int n = s2.Length;
                if (m != n)
                    return false;

                // To mark visited characters in str2 
                bool[] flagvisited = new bool[size];

                for (int i = 0; i < size; i++)
                    flagvisited[i] = false;

                int[] map = new int[size];

                for (int i = 0; i < size; i++)
                    map[i] = -1;

                // loop through all characters
                for (int i = 0; i < n; i++)
                {
                    if (map[s1[i]] == -1)
                    { 
                        if (flagvisited[s2[i]] == true)
                        {
                            return false;
                        }
                        flagvisited[s2[i]] = true;
                        map[s1[i]] = s2[i];
                    }

                    else if (map[s1[i]] != s2[i])
                        return false;
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[i] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {
                //write your code here
                IDictionary<int,  List<int[]>> kv = new Dictionary<int, List<int[]>>();
                Dictionary<int, int> studentscore = new Dictionary<int, int>();
                SortedList<int, int> scores = new SortedList<int, int>();
                Console.WriteLine(items.Length);
                for (int i = 0; i <= ((items.Length / 2) - 1); i++)
                {
                    // studentscore = items[i, 0],items[items,1];
                    Console.Write(items[i, 0]);
                    Console.Write(items[i, 1]);
                    int studentid = items[i, 0];
                    int score = items[i, 1]; 
                    List<int[]> scorelist = new List<int[]>();
                    //scorelist= scorelist.AddRange(score);
                    
                  /*  var popularCities = new List<int>();

                    // adding an array in a List
                    scorelist.AddRange(scorelist);

                    var scoretrack = new List<int>();

                    // adding a List 
                   // studentscore.Add(studentid, scorelist);*/
                    HashMap<int, List<int>> map = new HashMap<int, List<int>>(5);
                    if (!kv.ContainsKey(studentid))
                    {
                        List<int> pq = new List<int>(5);
                        //scorelist.Add(score);
                       // pq.AddRange(scorelist);
                       // if(pq.Count==5)
                        ///    pq.Sum();
                       // Console.Write(pq);
                        ///map.Add(studentid, pq);
                        //kv.Add(studentid, score);
                        //studentscore.Add(studentid, score);
                    }
                    else
                    {
                        //find teh key and get teh value and append the values for that key
                           // map.get(studentid);
                       // var resut = studentscore.OrderByDescending(scorelist => scorelist.Value).Take(5);
                        //pq.Add(score);
                        
                       // var numbers = new List<int>();
                        //numbers.Add(score);
                        //if (numbers.Count() > 5)
                        {
                            //numbers.Max();
                            /*var rest = studentscore.OrderByDescending(numbers => numbers.Value).Take(5);
                            var top5 = studentscore.OrderByDescending(pair => pair.Value).Take(5)
                       .ToDictionary(pair => pair.Key, pair => pair.Value);
                            Console.Write(rest);
                            Console.Write(top5);*/
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        ///A happy number is a number defined by the following process:
        ///•	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        ///•	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        ///•	Those numbers for which this process ends in 1 are happy.
        ///Return true if n is a happy number, and false if not.
        ///Example 1:
        ///Input: n = 19
        ///Output: true
        ///Explanation:
        ///12 + 92 = 82
        ///82 + 22 = 68
        ///62 + 82 = 100
        ///12 + 02 + 02 = 1
        ///Example 2:
        ///Input: n = 2
        ///Output: false
        ///Constraints:
        ///1 <= n <= 231 - 1
        /// </summary>

        private static bool HappyNumber(int n)
        {
            try
            {
                //write your code here.
                    int sqOnce, sqTwice;

                    sqOnce = sqTwice = n;
                    do
                    {

                        sqOnce = numSquareSum(sqOnce);
                        sqTwice = numSquareSum(numSquareSum(sqTwice));

                    }
                    while (sqOnce != sqTwice);
                return (sqOnce == 1);                
            }
            catch (Exception)
            {

                throw;
            }
            static int numSquareSum(int n)
            {
                int squareSum = 0;
                while (n != 0)
                {
                    squareSum += (n % 10) *
                                (n % 10);
                    n /= 10;
                }
                return squareSum;
            }
        }

        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>

        private static int Stocks(int[] prices)
        {
            try
            {
                //write your code here.
                return maxProfit(prices, 0, prices.Length - 1);                
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        static int maxProfit(int[] prices, int startDay, int lastDay)
        {
            // If the stocks can't be bought
            if (lastDay <= startDay)
                return 0;

            // Initialise the profit
            int profit = 0;

            // The day at which the stock
            // must be bought
            for (int i = startDay; i < lastDay; i++)
            {

                // The day at which the
                // stock must be sold
                for (int j = i + 1; j <= lastDay; j++)
                {

                    // If byuing the stock at ith day and
                    // selling it at jth day is profitable
                    if (prices[j] > prices[i])
                    {

                        // Update the current profit
                        int curr_profit = prices[j] - prices[i]
                                        + maxProfit(prices, startDay, i - 1)
                                        + maxProfit(prices, j + 1, lastDay);

                        // Update the maximum profit so far
                        profit = Math.Max(profit, curr_profit);
                    }
                }
            }
            return profit;
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        ///Input: n = 2
        ///Output: 2
        ///Explanation: There are two ways to climb to the top.
        ///1. 1 step + 1 step
        ///2. 2 steps
        ///Example 2:
        ///Input: n = 3
        ///Output: 3
        ///Explanation: There are three ways to climb to the top.
        ///1. 1 step + 1 step + 1 step
        ///2. 1 step + 2 steps
        ///3. 2 steps + 1 step
        ///Hint : Use the concept of Fibonacci series.
        /// </summary>

        private static void Stairs(int steps)
        {
            try
            {
                //write your code here.
                Console.WriteLine(fibonacci(steps + 1));

                static int fibonacci(int n)
                {
                    if (n <= 1)
                        return n;
                    return fibonacci(n - 1) + fibonacci(n - 2);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
