public static class SimuladorStack
{
    public static void ImprimirCuentaRegresiva(int numero)
    {
        if (numero < 1) return;

        Console.WriteLine($"APILANDO {numero}");
        ImprimirCuentaRegresiva(numero - 1);
        Console.WriteLine($"LIBERANDO {numero}");
    }

    public static int SumarHasta(int n)
    {
        if (n == 1) return 1;
        return n + SumarHasta(n - 1);
    }
}
