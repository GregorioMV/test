using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] score = { 1, 2, 1, 3, 2 };
            //int[] scores = { 100, 100, 50, 40, 40, 40, 10 };
            //nt[] alice = { 5, 25, 50, 120 };
            //climbingLeaderboard(scores, alice);
            //int[] scores = { 92, 91, 27, 20, 9, 43, 73, 39, 24, 54, 33, 64, 27, 47, 32, 58, 76, 78, 33, 57, 5, 22, 89, 78, 64, 48, 41, 39, 74, 33, 45, 16 };
            //divisibleSumPairs(100, 31, scores);
            //int x = saveThePrisoner(5, 2, 1);
            //int y = saveThePrisoner(5, 2, 2);
            //int d = saveThePrisoner(352926151, 380324688, 94730870);
            //TestHash();
            //beautifulDays(20, 23, 6);
            //int[] score = { 4 };
            //int res = solve(1, score, 4, 1);
            //int res = solve(5, score, 3, 3);
            //int res = migratoryBirds(6, new int[] { 2, 4, 4, 4, 2, 2 });
            //Console.WriteLine(res);
            //getMoneySpent(new int[] { 3, 1 }, new int[] { 5, 2, 8 }, 10);
            catAndMouse(1, 2, 3);
            Console.ReadKey();

        }

        static int viralAdvertising(int n)
        {
            int shared = 5;
            int liked = 2;
            int cumulative = 2;

            for (int i = 1; i < n; i++)
            {
                shared = (shared / 2) * 3;
                liked = shared / 2;
                cumulative += liked;
            }
            return cumulative;
        }


        //saveThePrisoner(5, 2, 1); res = 2
        //saveThePrisoner(5, 2, 2); res = 3
        //5 prisioners, 2 candy, 1 seat start
        //5 prisioners, 2 candy, 2 seat start
        static int saveThePrisoner(int n, int m, int s)
        {
            //while i less than candies we keep giving candys

            for (int i = 1; i <= m; i++)
            {
                if (i < n)
                    s++;
                else
                {
                    s = 1;
                }
            }

            return s-1;
        }

        static void TestHash()
        {
            HashSet<int> hasTest = new HashSet<int>();
            hasTest.Add(1);
            hasTest.Add(2);

            foreach (var item in hasTest)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int res = 0;
            int maxBudget = 0;
            if (keyboards.Contains(b) || drives.Contains(b))
                return -1;

            for (int i = 0; i < keyboards.Length; i++)
            {
                for (int j = 0; i < drives.Length; j++)
                {
                    res = keyboards[i] + drives[j];
                    if (maxBudget <= b && res <= b && res > maxBudget)
                        maxBudget = res;
                }
            }
            return maxBudget;
        }

        static string catAndMouse(int x, int y, int z)
        {
            int catStepsA = 0;
            int catStepsB = 0;
            catStepsA = CountCatSteps(0, x, z);
            catStepsB = CountCatSteps(0, y, z);

            if (catStepsA < catStepsB)
                return "Cat A";
            else if (catStepsA > catStepsB)
                return "Cat B";
            else
                return "Mouse C";
        }

        static int CountCatSteps(int catSteps, int catPosition, int mousePosition)
        {
            if (catPosition < mousePosition)
                return CountCatSteps(catSteps + 1, catPosition + 1, mousePosition);
            else if(catPosition > mousePosition)
                return CountCatSteps(catSteps + 1, catPosition - 1, mousePosition);
            else 
                return catSteps;
        }

        static string timeConversion(string s)
        {
            /*
             * Write your code here.
             */
            DateTime date = new DateTime();
            date = Convert.ToDateTime(s);
            return date.ToString("HH:mm");


        }

        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            List<int> leaderBoard = new List<int>();
            List<KeyValuePair<int, int>> myDictionary = new List<KeyValuePair<int, int>>();
            int countSamePlace = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                leaderBoard.Add(scores[i]);
            }

            leaderBoard.Sort();
            leaderBoard.Reverse();

            for (int i = 1; i < leaderBoard.Count; i++)
            {
                bool checkRepeated = false;
                foreach (var item in myDictionary)
                {
                    if (item.Value.Equals(leaderBoard[i]))
                        checkRepeated = true;
                        
                }
                if (!checkRepeated)
                {
                    myDictionary.Add(new KeyValuePair<int, int>(i - countSamePlace, leaderBoard[i]));
                }
                else
                {
                    countSamePlace++;
                    SortSameScore(myDictionary, leaderBoard[i - countSamePlace], i);
                }
            }



            return AddAliceToLeaderBoard(myDictionary, alice); 
        }

        static int[] AddAliceToLeaderBoard(List<KeyValuePair<int, int>> list, int[] alice)
        {
            int countRes = 0;
            int longestValue = 0;
            bool addedItem = false;
            int[] res = new int[alice.Length];
            for (int i = 0; i < alice.Length; i++)
            {
                addedItem = false;
                foreach (var item in list)
                {
                    if (alice[i] > item.Value && longestValue <= item.Value)
                    {
                        addedItem = true;
                        longestValue = item.Value;
                        res[countRes] = item.Key;
                    }
                }
                if (!addedItem)
                    res[countRes] = list.Count;
                countRes++;
            }
            return res;
        }

        static int beautifulDays(int i, int j, int k)
        {
            string numberString = "";
            string turnedNumber = "";
            int intTurnedNumber = 0;
            int sum = 0;

            int beautifulDays = 0;

          
            for (int dateA = i; dateA < j; dateA++)
            {
                numberString = dateA.ToString();
                turnedNumber = "";
                for (int date = numberString.Length -1; date >= 0; date--)
                {
                    turnedNumber += numberString[date];
                }

                intTurnedNumber = Convert.ToInt32(turnedNumber);
                if (dateA > intTurnedNumber)
                    sum = dateA - intTurnedNumber;
                else
                    sum = intTurnedNumber - dateA;
                if (sum % k == 0)
                    beautifulDays++;
            }
            return beautifulDays;
        }

        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int res = 0;
            int sum = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = 0; j < ar.Length; j++)
                {
                    if (ar[i] >= 0)
                    {
                        if (ar[i] <= ar[j])
                        {
                            sum = ar[i] + ar[j];
                            if (sum % k == 0)
                                res++;
                        }
                    }
                }
            }
            return res;
        }

        static List<KeyValuePair<int, int>> SortSameScore(List<KeyValuePair<int, int>> dictionary, int value, int index)
        {
            var orderLeaderBoard = from myDic in dictionary where myDic.Value.Equals(value) select myDic.Key;
            int key = orderLeaderBoard.FirstOrDefault();
            dictionary.Add(new KeyValuePair<int, int>(key,value));
            return dictionary;
        }


        static int migratoryBirds(int n, int[] ar)
        {
            int longestOcurrance = 0;
            Dictionary<int, int> listIds = new Dictionary<int, int>();

            for (int i = 0; i < ar.Length; i++)
            {
                if (longestOcurrance < ar[i])
                {
                    if (listIds.Count == 0)
                    {
                        listIds.Add(ar[i], longestOcurrance);
                    }
                    else if (!checkList(listIds, ar[i]))
                    {
                        listIds.Add(ar[i], longestOcurrance);
                    }

                    listIds[ar[i]] += 1;
                }
            }
            var res = from x in listIds where x.Value == listIds.Values.Max() orderby x.Value select x.Key;
     
            return res.Min();
        }

        static void SayHello()
        {
            Console.WriteLine("Hello, world");
        }

        static bool checkList(Dictionary<int, int> birdDictionary, int num)
        {
            return birdDictionary.ContainsKey(num) ? true : false;
        }

        static int solve(int n, int[] s, int d, int m)
        {
            int res = 0;
            int combinations = 0;
            int startingPos = 0;
            int endPos = m;
            int count = 0;
            List<int[]> listArray = new List<int[]>();
            int[] myArray = new int[m];
            Dictionary<int, int> dic = new Dictionary<int, int>();
            dic.Add(1, 1);
            while (endPos <= s.Length)
            {
                combinations = 0;
                count = 0;
                if (m <= s.Length)
                {
                    for (int j = startingPos; j < endPos; j++)
                    {
                        myArray[count] = s[j];
                        count++;
                    }

                    for (int k = 0; k < myArray.Length; k++)
                    {
                        combinations += myArray[k];
                    }

                    if (combinations == d)
                        res++;

                    combinations = 0;
                }
                startingPos = endPos - 1;
                if (m > 1)
                    endPos += m - 1;
                else
                    endPos += m + 1;

            }
            return res;

        }

        static int[] breakingRecords(int[] score)
        {
            int lower = 0;
            int max = 0;
            int[] res = new int[1];
            res[0] = 0;
            res[1] = 0;

            for (int i = 0; i < score.Length; i++)
            {
                if (i == 0)
                {
                    lower = score[i];
                    max = score[i];
                }
                if (lower > score[i])
                {
                    lower = score[i];
                    res[1] = res[1] + 1;
                }
                if (max < score[i])
                {
                    max = score[i];
                    res[0] = res[0] + 1;
                }
            }
            return res;
        }


        static void drawer(int rows)
        {
            string x = "#";
            int[] arr = new int[6];
             

            for (int i = rows; i > 0; i--)
            {
                Console.WriteLine(x);
                x += "    #";
            }
          
        }
    }
}