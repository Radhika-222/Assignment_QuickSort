using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_QuickSort
{
    internal class Program
    {
        //Quicksort
        public static void quicksort(int[] array)
        {
            quicksort(array, 0, array.Length - 1);
        }
        private static void quicksort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotindex = Partition(array, left, right);
                quicksort(array, left, pivotindex - 1);
                quicksort(array, pivotindex + 1, right);
            }
        }
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    swap(array, i, j);
                }
            }
            swap(array, i + 1, right);
            return i + 1;
        }
        private static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        //Check array is sorted correctly
        public static bool IsSorted(int[] arr)
        {
            for(int i=1; i<arr.Length; i++)
            {
                if (arr[i] < arr[i - 1])
                    return false;
            }
            return true;
        }

        //Merge sort 
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);

        }
        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);

            }
        }
        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (i < n2)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
        }
        static void Main(string[] args)
        {    //quicksort Sort

            int[] arr = { 12, 7, 3, 1, 8, 9, 15, 4, 5 };
            Console.WriteLine("\noriginal array for Quick Sort is \n");
            Print(arr);
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            quicksort(arr);
            stopwatch1.Stop();
            Console.WriteLine("\nAfter applying quick sort elements are in ascending order\n");
            Print(arr);

            int[] arr1 = { 12, 7, 3, 1, 8, 9, 15, 4, 5 };
            Console.WriteLine("\nOriginal array for Merge sort array is \n");
            Print(arr1);
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            MergeSort(arr1, 0, arr1.Length - 1);
            stopwatch2.Stop();
            Console.WriteLine("\nAfter Merge Sorted array is\n");
            Print(arr1);


            Console.WriteLine("\nIs the array sorted correctly ?  " + IsSorted(arr1));
            Console.WriteLine($"\nArray size is {arr1.Length} \nTime Taken for quick sort is {stopwatch1.Elapsed.TotalMilliseconds} milliseconds  \nTime Taken for merge sort is {stopwatch2.Elapsed.TotalMilliseconds} milliseconds");





            Console.ReadKey();


        }
    }
}