public static class Validador
{
    public static bool EsNumeroValido(string entrada, out int numero)
    {
        return int.TryParse(entrada, out numero) && numero > 0;
    }
}
