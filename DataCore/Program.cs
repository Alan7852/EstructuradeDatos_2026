using System;
using DataCore; // Importa el namespace donde están RegistroDatos y QuickSorter

class Program
{
    static void Main()
    {
        var rnd = new Random();
        var registros = new RegistroDatos[20];

        for (int i = 0; i < registros.Length; i++)
            registros[i] = new RegistroDatos(i, rnd.NextDouble() * 100, $"Item{i}");

        Console.WriteLine("Array inicial:");
        foreach (var r in registros) Console.WriteLine(r);

        Console.WriteLine("\nElige algoritmo: 1 = Selection Sort, 2 = QuickSort");
        var opcion = Console.ReadLine();

        if (opcion == "1")
        {
            var metricas = OrdenarPorSeleccion(ref registros);
            Console.WriteLine("\nArray ordenado con Selection Sort:");
            foreach (var r in registros) Console.WriteLine(r);
            Console.WriteLine(metricas);
        }
        else
        {
            QuickSorter.QuickSort(registros, 0, registros.Length - 1);
            Console.WriteLine("\nArray ordenado con QuickSort:");
            foreach (var r in registros) Console.WriteLine(r);
        }
    }

    // Método de Selection Sort de la Fase 1
    static MetricasOrdenacion OrdenarPorSeleccion(ref RegistroDatos[] arr)
    {
        var metricas = new MetricasOrdenacion();
        var sw = System.Diagnostics.Stopwatch.StartNew();

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                metricas.TotalComparaciones++;
                if (arr[j].Valor < arr[minIdx].Valor)
                    minIdx = j;
            }

            if (minIdx != i)
            {
                (arr[i], arr[minIdx]) = (arr[minIdx], arr[i]);
                metricas.TotalIntercambios++;
            }
        }

        sw.Stop();
        metricas.TiempoMs = sw.ElapsedMilliseconds;
        return metricas;
    }
}

struct MetricasOrdenacion
{
    public int TotalComparaciones { get; set; }
    public int TotalIntercambios { get; set; }
    public long TiempoMs { get; set; }

    public override string ToString() =>
        $"Comparaciones: {TotalComparaciones}, Intercambios: {TotalIntercambios}, Tiempo: {TiempoMs} ms";
}
