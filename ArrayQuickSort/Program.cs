using System;

namespace ArrayQuickSort
{
    class Program
    {
        static void ShowArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Arr [{i}] = " + arr[i]);
            }
        }

        static void Swap(ref int x, ref int y)
        {
            var z = x;
            x = y;
            y = z;
        }

        static int Partition(int[] arr, int minIndex, int maxIndex) //This method returns index of a so-called "pivot" element in our array 
        {
            var pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (arr[i] < arr[maxIndex])
                {
                    pivot++;
                    Swap(ref arr[pivot], ref arr[i]);
                }
            }

            pivot++;
            Swap(ref arr[pivot], ref arr[maxIndex]);
            return pivot;
        }

        static int[] QuickSort(int[] arr, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return arr;
            }

            var pivotIndex = Partition(arr, minIndex, maxIndex);
            QuickSort(arr, minIndex, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, maxIndex);

            return arr;
        }

        static int[] QuickSort(int[] arr)
        {
            return QuickSort(arr, 0, arr.Length - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter array length:");
            try
            {
                var arrLen = Convert.ToInt32(Console.ReadLine()); //Entering array size
                int[] arr = new int[arrLen];
                for (int i = 0; i < arrLen; i++) //Cycle for entering elements of our array
                {
                    Console.WriteLine($"Element [{i}]: ");
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("\nSorted array:");
                ShowArray(QuickSort(arr)); //Displaying array that's already been sorted
            }
            catch (FormatException f_ex) { Console.WriteLine("Incorrect data! "+$"{f_ex.Message}"); }
        }
    }
}
