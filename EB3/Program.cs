using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Crear inventario
        List<Producto> inventario = new List<Producto>
        {
            new Producto(1, "Laptop Lenovo", 15999.00, 10),
            new Producto(2, "Mouse Inalámbrico", 349.00, 25),
            new Producto(3, "Teclado Mecánico", 899.00, 0),
            new Producto(4, "Monitor 24\"", 4500.00, 5),
            new Producto(5, "Audífonos Sony", 1200.00, 0)
        };

        // Agregar producto con Add()
        inventario.Add(new Producto(6, "Webcam HD", 750.00, 12));

        // Agregar producto usando var
        var otroProducto = new Producto(7, "Hub USB-C", 450.00, 8);
        inventario.Add(otroProducto);

        // Mostrar total de productos
        Console.WriteLine($"Total en inventario: {inventario.Count} productos");

        Console.WriteLine("\n=== INVENTARIO COMPLETO ===");
        foreach (var producto in inventario)
        {
            Console.WriteLine(producto);
        }

        // LINQ: Ordenar por precio descendente
        var porPrecio = inventario
            .OrderByDescending(p => p.Precio)
            .ToList();

        Console.WriteLine("\n=== PRODUCTOS ORDENADOS POR PRECIO ===");
        foreach (var p in porPrecio)
        {
            Console.WriteLine(p);
        }

        // LINQ: Productos agotados
        var agotados = inventario
            .Where(p => p.Cantidad == 0)
            .ToList();

        Console.WriteLine("\n=== PRODUCTOS AGOTADOS ===");

        if (agotados.Count == 0)
        {
            Console.WriteLine("Sin productos agotados.");
        }
        else
        {
            agotados.ForEach(p => Console.WriteLine(p));
        }

        // Crear diccionario
        Dictionary<int, Producto> catalogo =
            inventario.ToDictionary(
                p => p.ID,
                p => p
            );

        // Buscar producto por ID
        BuscarPorID(catalogo);
    }

    static void BuscarPorID(Dictionary<int, Producto> catalogo)
    {
        Console.Write("\nIngresa el ID del producto a buscar: ");

        if (int.TryParse(Console.ReadLine(), out int idBuscado))
        {
            if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
            {
                Console.WriteLine("\nProducto encontrado:");
                Console.WriteLine(encontrado);
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }
}