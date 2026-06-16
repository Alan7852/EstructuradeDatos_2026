using System;
using System.Numerics;

class Program
{
    // -------------------------------
    // Factorial Recursivo con int
    // -------------------------------
    static int FactorialInt(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        return n * FactorialInt(n - 1);
    }

    // -------------------------------
    // Factorial Iterativo con int
    // -------------------------------
    static int FactorialIterativo(int n)
    {
        int resultado = 1;
        for (int i = 2; i <= n; i++)
            resultado *= i;
        return resultado;
    }

    // -------------------------------
    // Factorial con BigInteger
    // -------------------------------
    static BigInteger FactorialProfesional(BigInteger n)
    {
        if (n == 0 || n == 1)
            return BigInteger.One;

        return n * FactorialProfesional(n - 1);
    }

    static void Main()
    {
        Console.WriteLine("=== Factorial con int (Recursivo vs Iterativo) ===");
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine($"n={i:D2} | Recursivo: {FactorialInt(i),25} | Iterativo: {FactorialIterativo(i),25}");
        }

        // 📌 Documentación del punto de quiebre:
        // A partir de n=13, ambos métodos con int producen valores incorrectos (overflow).
        // Ejemplo: 13! debería ser 6,227,020,800 pero int lo convierte en un número negativo.

        Console.WriteLine("\n=== Factorial con BigInteger ===");
        BigInteger resultado = FactorialProfesional(100);
        Console.WriteLine($"100! = {resultado}");
        // Este resultado tiene 158 dígitos y se imprime con precisión absoluta.
    }
}

