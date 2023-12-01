using System;

public class MsortnHsort
{
    static int lastindex;
    public static void Main(string[] args) {

        bool loop = true;

        while (loop) {

            Console.WriteLine("Choose What Sortiing Method");
            Console.WriteLine("1. Heap Sort");
            Console.WriteLine("2. Merge Sort");
            Console.Write("Enter your Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    heapsort();
                    break;
                case 2:
                    mergesort();
                    break;
            }
            Console.WriteLine("");
            Console.Write("Sort Again? (Y/N): ");
            String choice1 = Console.ReadLine();
            if (choice1.ToUpper() != "Y") {
                loop = false;
            }

        }

    }


    //MERGE SORT CODE STARTS HERE!!!!!!

    public static void mergesort() {

        Console.Write("Enter Max Array Size: ");
        int maxarr = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[maxarr];
        for (int i = 0; i < maxarr; i++)
        {

            Console.Write("Enter element {0}: ", i + 1);
            arr[i] = Convert.ToInt32(Console.ReadLine());

        }
        pakitaarr("Given Array", arr);

        int[] finalarr = checkarr(arr);
        pakitaarr("Sorted Array", finalarr);

        Console.WriteLine("----Sorting Finished----");
        Console.ReadLine();

    }

    static void pakitaarr(String txt, int[] arr) {
        Console.Write(txt + ": ");
        for (int i=0; i < arr.Length; i++) {
            Console.Write(arr[i]+", ");
        }
        Console.WriteLine("\n");
    }

    static int[] checkarr(int[] arr) {
        if (arr.Length > 1)
        {
            int kalahati = arr.Length / 2;
            int[] arrkaliwa = arrhatikalahati(arr, 0, kalahati, "Left");
            int[] arrkanan = arrhatikalahati(arr, kalahati, arr.Length, "Right");
            arrkaliwa = checkarr(arrkaliwa);
            arrkanan = checkarr(arrkanan);
            return mergearr(arrkaliwa, arrkanan);
        }
        else {
            return arr;
        }
    }

    static int[] arrhatikalahati(int[] lumaarr, int from, int to, String arrSide) {
        Console.WriteLine("===Cut Half===");
        int[] bagoarr = new int[to - from];
        Console.WriteLine("new size ["+ arrSide + "]:" + bagoarr.Length);
        int c = 0;
        for (int i = from; i < to; i++) {
            bagoarr[c] = lumaarr[i];
            c++;
        }
        pakitaarr("newarr[" + arrSide + "]", bagoarr);
        return bagoarr;
    }

    static int[] mergearr(int[] arrkaliwa, int[] arrkanan) { 
        Console.WriteLine("===Merge Sort===");
        int[] pagsamaarr = new int[arrkaliwa.Length + arrkanan.Length];
        int indexmerge = 0;
        int indexleft = 0;
        int indexright = 0;
        while (indexleft < arrkaliwa.Length && indexright < arrkanan.Length) {
            Console.Write(arrkaliwa[indexleft] + ">" + arrkanan[indexright]);
            if (arrkaliwa[indexleft] > arrkanan[indexright])
            {
                pagsamaarr[indexmerge] = arrkanan[indexright];
                Console.WriteLine(":true, insert" + arrkanan[indexright]);
                indexright++;
                indexmerge++;
            }
            else {
                pagsamaarr[indexmerge] = arrkaliwa[indexleft];
                Console.WriteLine(":false, insert" + arrkaliwa[indexleft]);
                indexleft++;
                indexmerge++;
            }
        }
        while (indexleft < arrkaliwa.Length) {
            pagsamaarr[indexmerge] = arrkaliwa[indexleft];
            Console.WriteLine("insert" + arrkaliwa[indexleft]);
            indexleft++;
            indexmerge++;
        }
        while (indexright < arrkanan.Length) {
            pagsamaarr[indexmerge] = arrkanan[indexright];
            Console.WriteLine("insert" + arrkanan[indexright]);
            indexright++;
            indexmerge++;
        }
        pakitaarr("arrmerge", pagsamaarr);
        return pagsamaarr;   
}


    //HEAP SORT CODE STARTS HERE!!!!!!

    public static void heapsort() {
        Console.Write("Enter Max Array Size: ");
        int maxarr = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[maxarr];
        lastindex = arr.Length;

        for (int i = 0; i < maxarr; i++)
        {

            Console.Write("Enter element {0}: ", i + 1);
            arr[i] = Convert.ToInt32(Console.ReadLine());

        }

        Disparr("The Array Inputted: ", arr);

        Console.WriteLine("Choose a Sorting");
        Console.WriteLine("1. Ascending");
        Console.WriteLine("2. Descending");
        Console.Write("Enter your Choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {

            case 1:
                for (int i = 0; i < arr.Length - 1; i++)
                {

                    Console.WriteLine("-----");
                    arr = Maxheap(arr);
                    Disparr("Max Heap[" + (i + 1) + "]:", arr);
                    arr = heapify(arr);
                    Disparr("Heapify[" + (i + 1) + "]:", arr);

                }
                break;
            case 2:
                for (int i = 0; i < arr.Length - 1; i++)
                {

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
