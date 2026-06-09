class Program
{
    static void Main()
    {
        Console.Write("Introduce un número positivo: ");
        string entrada = Console.ReadLine();

        if (Validador.EsNumeroValido(entrada, out int numero))
        {
            SimuladorStack.ImprimirCuentaRegresiva(numero);
            int resultado = SimuladorStack.SumarHasta(numero);
            Console.WriteLine($"La suma de 1 hasta {numero} es: {resultado}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Solo se aceptan enteros positivos.");
            Console.ResetColor();
        }
    }
}

