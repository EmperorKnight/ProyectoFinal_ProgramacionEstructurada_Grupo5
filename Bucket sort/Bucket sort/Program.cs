using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Programa
{
    /// Ordena un arreglo de calificaciones usando Bucket Sort.
    public static void BucketSort(int[] array)
    {
        if (array == null || array.Length == 0)
            return;

        const int NUMBER_OF_BUCKETS = 10;

        // Crear los buckets (k)
        List<int>[] buckets = new List<int>[NUMBER_OF_BUCKETS];
        for (int i = 0; i < NUMBER_OF_BUCKETS; i++)
            buckets[i] = new List<int>();

        // Distribuir los elementos en los buckets (n)
        foreach (int score in array)
        {
            int bucketIndex = Math.Min(score / 10, NUMBER_OF_BUCKETS - 1);
            buckets[bucketIndex].Add(score);
        }

        // Ordenar cada bucket y concatenar (Σ mᵢ log mᵢ )
        for (int i = 0; i < NUMBER_OF_BUCKETS; i++)
            buckets[i].Sort();

        int k = 0;
        // Reconstruir el arreglo final (n)
        for (int i = 0; i < NUMBER_OF_BUCKETS; i++)
            foreach (int value in buckets[i])
                array[k++] = value;
    }

    /// Genera arreglo aleatorio (mejor caso).
    public static int[] GenerateBestCase(int size)
    {
        Random rand = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
            array[i] = rand.Next(0, 101);

        return array;
    }

    /// Genera arreglo concentrado en 0-9 (peor caso).
    public static int[] GenerateWorstCase(int size)
    {
        Random rand = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
            array[i] = rand.Next(0, 10);

        return array;
    }

    public static int[] GenerateAverageCase(int size)
    {
        Random rand = new Random();
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            int zone = rand.Next(0, 100);

            if (zone < 20)           // 20% en 0–30
                array[i] = rand.Next(0, 31);

            else if (zone < 50)      // 30% en 31–70
                array[i] = rand.Next(31, 71);

            else                     // 50% en 71–100
                array[i] = rand.Next(71, 101);
        }

        return array;
    }

    public static Dictionary<string, int> CalculateDistribution(int[] array)
    {
        var distribution = new Dictionary<string, int>();

        for (int i = 0; i <= 90; i += 10)
        {
            string range = $"{i}-{i + 9}";
            int count = array.Count(s => s >= i && s <= i + 9);
            distribution.Add(range, count);
        }

        distribution.Add("100", array.Count(s => s == 100));

        return distribution;
    }

    public static void Main(string[] args)
    {
        int[] dataSizes = { 10000, 50000, 100000, 500000 };

        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine("  PRUEBAS DE RENDIMIENTO DE BUCKET SORT EN CALIFICACIONES");
        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine($"{"N (Estudiantes)",-15} | {"Mejor Caso (ms)",-15} | {"Promedio (ms)",-15} | {"Peor Caso (ms)",-15}");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (int size in dataSizes)
        {
            // Mejor caso
            int[] bestCaseArray = GenerateBestCase(size);
            Stopwatch sw1 = Stopwatch.StartNew();
            BucketSort(bestCaseArray);
            sw1.Stop();
            long bestTime = sw1.ElapsedMilliseconds;

            // Promedio (NUEVO)
            int[] avgCaseArray = GenerateAverageCase(size);
            Stopwatch sw2 = Stopwatch.StartNew();
            BucketSort(avgCaseArray);
            sw2.Stop();
            long avgTime = sw2.ElapsedMilliseconds;

            // Peor caso
            int[] worstCaseArray = GenerateWorstCase(size);
            Stopwatch sw3 = Stopwatch.StartNew();
            BucketSort(worstCaseArray);
            sw3.Stop();
            long worstTime = sw3.ElapsedMilliseconds;

            Console.WriteLine($"{size,-15} | {bestTime,-15} | {avgTime,-15} | {worstTime,-15}");
        }

        Console.WriteLine("--------------------------------------------------------------------------");
        Console.WriteLine("\nRESULTADOS ADICIONALES (Prueba con 50,000 datos uniformes)");

        int[] sampleScores = GenerateBestCase(50000);
        BucketSort(sampleScores);

        var distribution = CalculateDistribution(sampleScores);
        Console.WriteLine("Distribución de Frecuencias por Rango de 10 puntos:");
        foreach (var pair in distribution)
            Console.WriteLine($"  {pair.Key,-8}: {pair.Value} estudiantes");
    }
}
