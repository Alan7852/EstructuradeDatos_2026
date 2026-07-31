using System;
using DataCore;

class Program
{
    static void Main()
    {
        Console.WriteLine("Selecciona fase: 1 = Selection Sort, 2 = QuickSort, 3 = Lista Enlazada, 4 = Integración Completa");
        var opcion = Console.ReadLine();

        if (opcion == "1")
        {
            // Fase 1: Selection Sort
            var registros = GenerarRegistros(20);
            var metricas = OrdenarPorSeleccion(ref registros);
            Console.WriteLine("\nArray ordenado con Selection Sort:");
            foreach (var r in registros) Console.WriteLine(r);
            Console.WriteLine(metricas);
        }
        else if (opcion == "2")
        {
            // Fase 2: QuickSort
            var registros = GenerarRegistros(20);
            QuickSorter.QuickSort(registros, 0, registros.Length - 1);
            Console.WriteLine("\nArray ordenado con QuickSort:");
            foreach (var r in registros) Console.WriteLine(r);
        }
        else if (opcion == "3")
        {
            // Fase 3: Lista Enlazada
            EjecutarListaEnlazada();
        }
        else if (opcion == "4")
        {
            // Fase 4: Integración Completa
            Console.WriteLine("\n--- Fase 4: Integración ---");
            EjecutarListaEnlazada();
            Console.WriteLine("\nAhora ordenando con Selection Sort y QuickSort para comparar...");

            var arreglo = GenerarRegistros(1000); // conjunto grande
            var copia1 = (RegistroDatos[])arreglo.Clone();
            var copia2 = (RegistroDatos[])arreglo.Clone();

            var metricasSel = OrdenarPorSeleccion(ref copia1);
            QuickSorter.QuickSort(copia2, 0, copia2.Length - 1);

            Console.WriteLine("\nSelection Sort métricas:");
            Console.WriteLine(metricasSel);

            Console.WriteLine("\nQuickSort resultado:");
            foreach (var r in copia2[..10]) // mostrar primeros 10
                Console.WriteLine(r);
        }
    }

    static RegistroDatos[] GenerarRegistros(int cantidad)
    {
        var rnd = new Random();
        var registros = new RegistroDatos[cantidad];
        for (int i = 0; i < cantidad; i++)
            registros[i] = new RegistroDatos(i, rnd.NextDouble() * 100, $"Item{i}");
        return registros;
    }

    static void EjecutarListaEnlazada()
    {
        TablaDinamica dataCore = new TablaDinamica();

        for (int i = 1; i <= 15; i++)
        {
            var reg = new RegistroDatos(i, i * 100.0, $"Transacción-{i}");
            dataCore.InsertarFinal(reg);
            Console.WriteLine($"[INSERT] Registro {i} añadido a la cadena.");
        }

        Console.WriteLine("\n--- Eliminando registros con Id 5 y Id 11 ---");
        dataCore.EliminarPorId(5);
        dataCore.EliminarPorId(11);
        Console.WriteLine("Cadena reestructurada exitosamente.");

        var arreglo = dataCore.ObtenerComoArreglo();
        Console.WriteLine($"\nRegistros en arreglo: {arreglo.Length} (esperado: 13)");

        QuickSorter.QuickSort(arreglo, 0, arreglo.Length - 1);
        Console.WriteLine("\n--- Arreglo ordenado por Id (QuickSort) ---");
        foreach (var r in arreglo)
            Console.WriteLine($"Id: {r.Id} | Etiqueta: {r.Etiqueta} | Valor: {r.Valor}");
    }

    // Método de Selection Sort (Fase 1)
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

