using System;

class Program
{
    // --- Módulo 1: Intercambiar con ref ---
    static void Intercambiar(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // --- Módulo 2: CalcularYValidar con out ---
    static int CalcularYValidar(int dividendo, int divisor, out int residuo)
    {
        residuo = dividendo % divisor;
        return dividendo / divisor;
    }

    // --- Módulo 3: Demostración de referencias de objetos ---
    class Alumno
    {
        public string Nombre { get; set; }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=== Entregable 6: ref, out y referencias ===\n");

        // --- Prueba Módulo 1 ---
        int x = 10, y = 25;
        Console.WriteLine($"Antes de Intercambiar: x={x}, y={y}");
        Intercambiar(ref x, ref y);
        Console.WriteLine($"Después de Intercambiar: x={x}, y={y}\n");

        // --- Prueba Módulo 2 ---
        int cociente = CalcularYValidar(17, 5, out int resto);
        Console.WriteLine($"División 17 / 5");
        Console.WriteLine($"Cociente: {cociente}");
        Console.WriteLine($"Residuo: {resto}\n");

        // --- Prueba Módulo 3 ---
        Alumno alumno1 = new Alumno { Nombre = "Dany" };
        Alumno alumno2 = alumno1; // ambas variables apuntan al mismo objeto
        alumno2.Nombre = "3Treum";

        Console.WriteLine("Demostración de referencias de objetos:");
        Console.WriteLine($"Nombre en alumno1: {alumno1.Nombre}");
        Console.WriteLine($"Nombre en alumno2: {alumno2.Nombre}");
        // Ambos muestran "3Treum" porque apuntan al mismo objeto en el Heap
    }
}

