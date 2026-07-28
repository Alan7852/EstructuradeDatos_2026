using System;
using System.Diagnostics;

readonly struct RegistroDatos
{
    public int Id { get; }
    public double Valor { get; }
    public string Etiqueta { get; }

    public RegistroDatos(int id, double valor, string etiqueta)
    {
        Id = id;
        Valor = valor;
        Etiqueta = etiqueta;
    }

    public override string ToString() => $"[{Id}] {Etiqueta}: {Valor}";
}

struct MetricasOrdenacion
{
    public int TotalComparaciones { get; set; }
    public int TotalIntercambios { get; set; }
    public long TiempoMs { get; set; }

    public override string ToString() =>
        $"Comparaciones: {TotalComparaciones}, Intercambios: {TotalIntercambios}, Tiempo: {TiempoMs} ms";
}

class Program
{
    static void Main()
    {
        var registros = new RegistroDatos[20];
        var rnd = new Random();

        for (int i = 0; i < registros.Length; i++)
            registros[i] = new RegistroDatos(i, rnd.NextDouble() * 100, $"Item{i}");

        Console.WriteLine("Array inicial:");
        foreach (var r in registros) Console.WriteLine(r);

        var metricas = OrdenarPorSeleccion(ref registros);

        Console.WriteLine("\nArray ordenado:");
        foreach (var r in registros) Console.WriteLine(r);

        Console.WriteLine("\nMétricas:");
        Console.WriteLine(metricas);
    }

    static MetricasOrdenacion OrdenarPorSeleccion(ref RegistroDatos[] arr)
    {
        var metricas = new MetricasOrdenacion();
        var sw = Stopwatch.StartNew();

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
                (arr[i], arr[minIdx]) = (arr[minIdx], arr[i]); // swap con tuplas
                metricas.TotalIntercambios++;
            }
        }

        sw.Stop();
        metricas.TiempoMs = sw.ElapsedMilliseconds;
        return metricas;
    }
}

