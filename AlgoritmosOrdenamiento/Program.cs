using System.Diagnostics;

Console.WriteLine("----------------ALGORITMOS DE ORDENAMIENTO---------------------------");


//int[] smallArray = GenerateRandomArray(1000);
//int[] mediumArray = GenerateRandomArray(50000);
int[] largeArray = GenerateRandomArray(100000);

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
int[] sortedArray = HeapSort(largeArray);
stopwatch.Stop();

Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");

//static void printArray(int[] array)
//{
//    foreach (int item in array)
//    {
//        Console.Write(item + " ");
//    }
//    Console.WriteLine();
//}

static int[] GenerateRandomArray(int size)
{
    Random random = new Random();
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
    {
        array[i] = random.Next(1, 1000000);
    }
    return array;
}

static int[] HeapSort(int[] array)
{
    int heap = array.Length;
    for (int i = heap / 2 - 1; i >= 0; i--)
    {
        Heapify(array, heap, i);
    }

    for(int i = heap - 1; i > 0; i--)
    {
        int temp = array[i];
        array[i] = array[0];
        array[0] = temp;
        Heapify(array, i, 0);
    }

    return array;
}

static void Heapify(int[] array, int heap, int i)
{
    int max = i;
    int left = 2 * i + 1;
    int right = 2 * i + 2;
    if (left < heap && array[left] > array[max])
        max = left;

    if (right < heap && array[right] > array[max])
        max = right;
    if (max != i)
    {
        int temp = array[i];
        array[i] = array[max];
        array[max] = temp;
        Heapify(array, heap, max);
    }
}

static int[] mergeSort(int[] array)
{
    if (array.Length <= 1)
    {
        return array;
    }
    int middle = array.Length / 2;
    int[] left = mergeSort(array.Take(middle).ToArray());
    int[] right = mergeSort(array.Skip(middle).ToArray());
    int[] result = new int[array.Length];
    int i = 0;
    int j = 0;

    while (i < left.Length && j < right.Length) {
        if (left[i] < right[j])
        {
            result[i + j] = left[i];
            i++;
        }
        else
        {
            result[i + j] = right[j];
            j++;
        }
    }

    while (i < left.Length)
    {
        result[i + j] = left[i];
        i++;
    }
    while (j < right.Length)
    {
        result[i + j] = right[j];
        j++;
    }

    return result;
}

static int[] QuickSort(int[] array, int left, int right)
{
    int temp;
    int pivot = array[(left + right) / 2];
    int originalLeft = left;
    int originalRight = right;
    do
    {
        while (array[left] < pivot)
            left++;

        while (pivot < array[right])
            right--;
        if (left <= right)
        {
            temp = array[left];
            array[left] = array[right];
            array[right] = temp;
            left++;
            right--;
        }
    }
    while (left <= right);

    if (originalLeft < right)
        QuickSort(array, originalLeft, right);
    if (left < originalRight)
        QuickSort(array, left, originalRight);

    return array;
}

static int[] bubbleSort(int[] array)
{
   for(int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                int temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
            }
        }
   }
    return array;

}

static int[] SelectionSort (int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        int min = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[min])
            {
                min = j;
            }
        }
        int temp = array[i];
        array[i] = array[min];
        array[min] = temp;
    }
    return array;
}

static int[] InsertionSort(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (i > 0)
        {
            int value = array[i];
            int j = i - 1;
            while (j >= 0)
            {
                if (array[j] > value)
                {
                    array[j + 1] = array[j];
                }
                else
                {
                    break;
                }
                j--;
            }
            array[j + 1] = value;
        }
    }
    return array;
}
