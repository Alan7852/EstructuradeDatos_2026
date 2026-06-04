using System;

class Program
{
    static void Main()
    {
        int numero = 10;
        int[] arreglo = { 1, 2, 3, 4, 5 };

        Console.WriteLine("ANTES DE LLAMAR A LAS FUNCIONES");
        Console.WriteLine("Valor de numero: " + numero);
        Console.WriteLine("Primer elemento del arreglo: " + arreglo[0]);

        CambiarValor(numero);
        CambiarReferencia(arreglo);

        Console.WriteLine("\nDESPUÉS DE LLAMAR A LAS FUNCIONES");
        Console.WriteLine("Valor de numero: " + numero);
        Console.WriteLine("Primer elemento del arreglo: " + arreglo[0]);
    }

    static void CambiarValor(int x)
    {
        x = 100;
        Console.WriteLine("\nDentro de CambiarValor:");
        Console.WriteLine("x = " + x);
    }

    static void CambiarReferencia(int[] arr)
    {
        arr[0] = 100;
        Console.WriteLine("\nDentro de CambiarReferencia:");
        Console.WriteLine("arr[0] = " + arr[0]);
    }
}
