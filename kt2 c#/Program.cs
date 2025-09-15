using System;
using System.Collections.Generic;

namespace SimpleHumanProgram
{
    class Program
    {
        public class Human
        {
            public bool IsMan;        
            public bool IsWorker;    
            public bool IsOld;        


            public Human(bool isMan, bool isWorker, bool isOld)
            {
                IsMan = isMan;
                IsWorker = isWorker;
                IsOld = isOld;
            }
            public static Human CreateRandom(Random random)
            {
                bool randomIsMan = random.Next(0, 2) == 1;     
                bool randomIsWorker = random.Next(0, 2) == 1;  
                bool randomIsOld = random.Next(0, 2) == 1;     

                return new Human(randomIsMan, randomIsWorker, randomIsOld);
            }
            public static bool AreEqual(Human first, Human second)
            {
                if (first == null && second == null) return true;
                if (first == null || second == null) return false;

                return first.IsMan == second.IsMan &&
                       first.IsWorker == second.IsWorker &&
                       first.IsOld == second.IsOld;
            }

            public void PrintInfo()
            {
                string gender = IsMan ? "Man" : "Woman";
                string workStatus = IsWorker ? "Worker" : "Not worker";
                string ageStatus = IsOld ? "Old" : "Young";

                Console.WriteLine($"{gender}, {workStatus}, {ageStatus}");
            }
        }
        static List<Human> CreatePeopleList(int count)
        {
            List<Human> people = new List<Human>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                people.Add(Human.CreateRandom(random));
            }

            return people;
        }
        static void PrintAllPeople(List<Human> people)
        {
            Console.WriteLine("=== LIST OF PEOPLE ===");
            for (int i = 0; i < people.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                people[i].PrintInfo();
            }
            Console.WriteLine();
        }

        static int GetPersonNumber(string message, int maxNumber)
        {
            int number;

            while (true)
            {
                Console.Write($"{message} (1-{maxNumber}): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number) && number >= 1 && number <= maxNumber)
                {
                    return number;
                }

                Console.WriteLine($"Please enter a number between 1 and {maxNumber}");
            }
        }
        static void CompareTwoPeople(List<Human> people)
        {
            int firstNumber = GetPersonNumber("Enter first person number", people.Count);
            int secondNumber = GetPersonNumber("Enter second person number", people.Count);

            Human firstPerson = people[firstNumber - 1];
            Human secondPerson = people[secondNumber - 1];

            Console.WriteLine("\n=== COMPARISON RESULTS ===");

            Console.Write("First person: ");
            firstPerson.PrintInfo();

            Console.Write("Second person: ");
            secondPerson.PrintInfo();

            bool areSame = Human.AreEqual(firstPerson, secondPerson);
            Console.WriteLine($"These people are {(areSame ? "THE SAME" : "DIFFERENT")}");
            Console.WriteLine($"\nAdditional info:");
            Console.WriteLine($"First person is {(firstPerson.IsMan ? "man" : "woman")}");
            Console.WriteLine($"Second person is {(secondPerson.IsMan ? "man" : "woman")}");
        }
        static bool AskToContinue()
        {
            Console.Write("\nDo you want to continue? (yes/no): ");
            string answer = Console.ReadLine().ToLower();

            return answer == "yes" || answer == "y" || answer == "да";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=== HUMAN COMPARISON PROGRAM ===\n");
            List<Human> people = CreatePeopleList(10);

            bool continueProgram = true;

            while (continueProgram)
            {
                PrintAllPeople(people);
                CompareTwoPeople(people);

                continueProgram = AskToContinue();
                Console.WriteLine();
            }

            Console.WriteLine("Thank you for using the program! Goodbye!");
            Console.ReadKey();
        }
    }
}