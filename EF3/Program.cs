using System;

public struct Transaccion
{
    public int Id;
    public string Descripcion;
    public double Monto;
}

public class Program
{
    // Método de ordenamiento por inserción
    public static void InsertionSort(Transaccion[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            Transaccion clave = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j].Id > clave.Id)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = clave; // 👈 faltaba esta línea en tu código
        }
    }

    // Método Main para probar
    public static void Main(string[] args)
    {
        Transaccion[] transacciones = new Transaccion[]
        {
            new Transaccion { Id = 3, Descripcion = "Pago luz", Monto = 500 },
            new Transaccion { Id = 1, Descripcion = "Depósito nómina", Monto = 3000 },
            new Transaccion { Id = 2, Descripcion = "Compra supermercado", Monto = 1200 }
        };

        Console.WriteLine("Antes de ordenar:");
        foreach (var t in transacciones)
            Console.WriteLine($"{t.Id} - {t.Descripcion} - {t.Monto}");

        InsertionSort(transacciones);

        Console.WriteLine("\nDespués de ordenar:");
        foreach (var t in transacciones)
            Console.WriteLine($"{t.Id} - {t.Descripcion} - {t.Monto}");
    }
}

