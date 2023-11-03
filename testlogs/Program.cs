using System;

public class HelloWorld
{
    static int lastindex;
    public static void Main(string[] args) {

        Console.Write("Enter Max Array Size: ");
        int maxarr = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[maxarr];
        lastindex = arr.Length;

        for (int i = 0; i < maxarr; i++) {

            Console.Write("Enter element {0}: ", i + 1);
            arr[i] = Convert.ToInt32(Console.ReadLine());

        }

        Disparr("The Array Inputted: ", arr);

        Console.WriteLine("Choose a Sorting");
        Console.WriteLine("1. Ascending");
        Console.WriteLine("2. Descending");
        Console.Write("Enter your Choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice) {

            case 1:
                for (int i = 0; i < arr.Length-1; i++) {

                    Console.WriteLine("-----");
                    arr = Maxheap(arr);
                    Disparr("Max Heap[" + (i + 1) + "]:", arr);
                    arr = heapify(arr);
                    Disparr("Heapify[" + (i + 1) + "]:", arr);

                }
                break;
            case 2:
                for (int i = 0; i < arr.Length - 1; i++) {

                    Console.WriteLine("-----");
                    arr = Minheap(arr);
                    Disparr("Max Heap[" + (i + 1) + "]:", arr);
                    arr = heapify(arr);
                    Disparr("Heapify[" + (i + 1) + "]:", arr);

                }
                break;

        }
        Console.Read();
    }

    static int[] Minheap(int[] arr) {

        for (int i = lastindex; i > 1; i--)
        {

            int parent = (i / 2);
            int left = (2 * parent);
            int right = (2 * parent + 1);
            parent--;
            left--;
            right--;

            Boolean rightchi = false;

            
            if (right < lastindex)
            {

                rightchi = true;

            }

            if (rightchi)
            {

                if (arr[parent] > arr[right] & arr[right] < arr[left])
                {

                    int temp = arr[parent];
                    arr[parent] = arr[right];
                    arr[right] = temp;

                }

            }
            if (arr[parent] > arr[left])
            {

                int temp = arr[parent];
                arr[parent] = arr[left];
                arr[left] = temp;

            }
        }
        return arr;
    }

    static int[] Maxheap(int[] arr) {

        for (int i = lastindex; i > 1; i--) {

            int parent = (i/2);
            int left = (2 * parent);
            int right = (2 * parent + 1);
            parent--;
            left--;
            right--;

            Boolean rightchi = false;

            if (right < lastindex) {

                rightchi = true;

            }

            if (rightchi) {

                if (arr[parent] < arr[right] & arr[right] > arr[left]) {

                    int temp = arr[parent];
                    arr[parent] = arr[right];
                    arr[right] = temp;

                }

            }
            if (arr[parent] < arr[left]) {

                int temp = arr[parent];
                arr[parent] = arr[left];
                arr[left] = temp;

            }
        }
        return arr;
    }

    static int[] heapify(int[] arr) {

        int temp = arr[0];
        arr[0] = arr[lastindex-1];
        arr[lastindex-1] = temp;
        lastindex--;
        return arr;

    }

    static void Disparr(String txt, int[] arr) {

        Console.Write(txt);
        for (int i = 0; i < arr.Length; i++) {

            Console.Write(arr[i] + ", ");

        }
        Console.WriteLine();
    }

}   
