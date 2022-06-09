using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays

            //TODONE: Create an integer Array of size 50
            int[] myArray = new int[50];

            //TODONE: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(myArray);

            //TODONE: Print the first number of the array
            Console.WriteLine(myArray[0]);

            //TODONE: Print the last number of the array            
            Console.WriteLine(myArray[myArray.Length - 1]);
            Console.WriteLine("All Numbers Original");

            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(myArray);
            Console.WriteLine("-------------------");

            //TODONE: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            //  1) First way, using a custom method => Hint: Array._____(); 
            //  2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            Console.WriteLine("All Numbers Reversed:");
            NumberPrinter(myArray.Reverse());
            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(myArray);
            NumberPrinter(myArray);
            Console.WriteLine("-------------------");

            //TODONE: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(myArray);
            Console.WriteLine("-------------------");

            //TODONE: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(myArray);
            NumberPrinter(myArray);
            Console.WriteLine("\n************End Arrays*************** \n");

            #endregion

            #region Lists

            Console.WriteLine("************Start Lists**************");
            /*   Set Up   */

            //TODONE: Create an integer List
            List<int> myList = new List<int>();

            //TODONE: Print the capacity of the list to the console
            Console.WriteLine($"capacity of myList = {myList.Capacity}");

            //TODONE: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(myList);

            //TODONE: Print the new capacity
            Console.WriteLine($"new capacity of myList = {myList.Capacity}");
            Console.WriteLine("---------------------");

            //TODONE: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            Console.WriteLine("-------------------");
            int userInput = AskForInt("please enter a number");
            NumberChecker(myList, userInput);
            Console.WriteLine("All Numbers:");

            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(myList);
            Console.WriteLine("-------------------");

            //TODONE: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(myList);
            Console.WriteLine("------------------");

            //TODONE: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            myList.Sort();
            NumberPrinter(myList);
            Console.WriteLine("------------------");

            //TODONE: Convert the list to an array and store that into a variable
            var listToArray = myList.ToArray();
            NumberPrinter(listToArray);

            //TODONE: Clear the list
            myList.Clear();
            NumberPrinter(myList);

            #endregion
        }

        public static int AskForInt(string msg)
        {
            bool isInt = false;
            int userInput = 0;
            do {
                Console.WriteLine(msg);
                isInt = int.TryParse(Console.ReadLine(), out userInput);
            } while (!isInt);
            return userInput;
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                    numbers[i] = 0;
            }
            NumberPrinter(numbers);
        }

        private static void OddKiller(List<int> numberList)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 == 1)
                {
                    numberList.Remove(numberList[i]);
                    i--;
                }
            }
            NumberPrinter(numberList);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            Console.WriteLine((numberList.Contains(searchNumber) ? "we found your number!" : "sorry bud, we cant find your number"));
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
                numberList.Add(rng.Next(1, 50));

        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rng.Next(1, 50);
        }

        private static void ReverseArray(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                int temp = array[i];
                array[i] = array[(array.Length - 1) - i];
                array[(array.Length - 1) - i] = temp;
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
