using System;

/*
 * Shuffle
 * 
 * A console app that allows the user to input a single integer N and outputs the integers 1..N in random order.
 * This app is optimized for speed.
 * 
 */

namespace shuffle
{
    class Program
    {
        static Random random = new Random();
        static string exit;
        static int N;
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Please enter an integer to shuffle:  ");
                if (int.TryParse(Console.ReadLine(), out N))
                {
                    shuffle(N);
                }
                else
                {
                    Console.WriteLine("Input must be an integer!");
                }
                Console.Write("Type E to exit the program or press return to shuffle another set of integers: ");
                exit = Console.ReadLine();
            } while (exit != "e" && exit != "E");
        }
        /// <summary>
        /// Randomly display all the integers from 1..N
        /// 1. Generate data structure of integers
        /// 2. Randomly select the index of an element and swap it with the last unswapped element in the array
        /// 3. Display all integers in the array
        /// </summary>
            static void shuffle(int N)
            {
                
                if (N > 0)
                {
                    int[] integers = new int[N];
                    // Populate integer array
                    for (int i = 1; i <= N; i++)
                    {
                        integers[i - 1] = i;
                    }
                    // Randomly shuffle the position of the integers in the array
                    for (int i = N - 1; i > 0; i--)
                    {
                    int n = random.Next(i + 1);
                    Swap(integers, i, n);
                    }
                    DisplayInts(integers);
                }
                else
                {
                    // Handles negative integers
                    int[] integers = new int[N * -1 + 2];
                    for (int i = 1; i >= N; i--)
                    {
                        if (i < 0)
                        {
                            integers[i * -1 + 1] = i;
                        }
                        else
                        {
                            integers[i] = i;
                        }
                    }
                    for (int i = N * -1 + 1; i > 1; i--)
                    {
                        int n = random.Next(i + 1);
                        Swap(integers, i, n);
                    }
                    DisplayInts(integers);
                }    
            }
        /// <summary>
        /// Swap the index positions of integer elements in an array
        /// </summary>
        static void Swap(int[] integers, int n1, int n2)
        {
            int temp = integers[n1];
            integers[n1] = integers[n2];
            integers[n2] = temp;
        }
        /// <summary>
        /// Display all integer elements in an array.
        /// </summary>
        static void DisplayInts(int[] integers)
        {
            foreach (int n in integers) { Console.Write(n + " "); };
            //or I could use
            //Console.WriteLine(string.Join(" ", integers));
            Console.WriteLine();
        }
    }
        
    }

