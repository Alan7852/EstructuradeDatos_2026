using System;
using DataCore;

class Program
{
    static void Main()
    {
        Console.WriteLine("Selecciona fase: 1 = Selection Sort, 2 = QuickSort, 3 = Lista Enlazada");
        var opcion = Console.ReadLine();

        if (opcion == "1")
        {
            // Aquí dejas tu código de Fase 1 (Selection Sort)
        }
        else if (opcion == "2")
        {
            // Aquí dejas tu código de Fase 2 (QuickSort)
        }
        else if (opcion == "3")
        {
            // Aquí pegas el orquestador de Fase 3
            TablaDinamica dataCore = new TablaDinamica();

            // Paso 1: Insertar 15 registros
            for (int i = 1; i <= 15; i++)
            {
                var reg = new RegistroDatos(i, i * 100.0, $"Transacción-{i}");
                dataCore.InsertarFinal(reg);
                Console.WriteLine($"[INSERT] Registro {i} añadido a la cadena.");
            }

            // Paso 2: Eliminar 2 registros
            Console.WriteLine("\n--- Eliminando registros con Id 5 y Id 11 ---");
            dataCore.EliminarPorId(5);
            dataCore.EliminarPorId(11);
            Console.WriteLine("Cadena reestructurada exitosamente.");

            // Paso 3: Convertir a arreglo y ordenar con QuickSort
            var arreglo = dataCore.ObtenerComoArreglo();
            Console.WriteLine($"\nRegistros en arreglo: {arreglo.Length} (esperado: 13)");

            QuickSorter.QuickSort(arreglo, 0, arreglo.Length - 1);
            Console.WriteLine("\n--- Arreglo ordenado por Id (QuickSort) ---");
            foreach (var r in arreglo)
                Console.WriteLine($"Id: {r.Id} | Etiqueta: {r.Etiqueta} | Valor: {r.Valor}");
        }
    }
}
