using System;
using System.Collections.Generic;

namespace NastyHacks
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nasty Hacks
            // https://open.kattis.com/problems/nastyhacks
            // simple comparsion program

            int myTestsCount = EnterNumOfTests();

            var myAdvertiseTests = AdvertiseTests(myTestsCount);

            PrintList(myAdvertiseTests);
        }
        private static void PrintList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static List<string> AdvertiseTests(int testsCount)
        {
            int[] myTest;
            int difference;
            var AdvertiseTests = new List<string>();
            for (int i = 0; i < testsCount; i++)
            {
                myTest = EnterAdvetisementTest();
                difference = AdvertisementResidue(myTest);
                AdvertiseTests.Add(AdvertiseTest(difference));
            }
            return AdvertiseTests;
        }

        private static string AdvertiseTest(int diff)
        {
            if (diff == 0)
                return "does not matter";
            else if (diff > 0)
                return "advertise";
            else
                return "do not advertise";
        }

        private static int AdvertisementResidue(int[] test)
        {
            int expectedRevenueNotAdvertise = test[0];
            int expectedRevenueDoAdvertise = test[1];
            int CostOfAdvertising = test[2];

            return (expectedRevenueDoAdvertise - expectedRevenueNotAdvertise) - CostOfAdvertising;
        }
        private static int[] EnterAdvetisementTest()
        {
            string[] arr = new string[3] { "", "", "" };
            int[] res = new int[3] { 0, 0, 0 };
            try
            {
                arr = Console.ReadLine().Split(' ', 3);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = int.Parse(arr[i]);
                }
                if (Conditions(res) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterAdvetisementTest();
            }
            return res;
        }
        private static bool Conditions(int[] nums)
        {
            int r = nums[0];
            int e = nums[1];
            int c = nums[2];
            if (r >= -1000000 && e <= 1000000 && c >= 0 && c <= 1000000)
                return true;
            else
                return false;
        }

        private static int EnterNumOfTests()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 100)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString() + ": " + ex.Message);
                return EnterNumOfTests();
            }
            return a;
        }
    }
}
