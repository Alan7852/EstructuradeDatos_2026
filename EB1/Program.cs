using System;

class Program
{
    static void Main()
    {
        int lados = SeleccionarPoligono();

        double lado, apotema;
        PedirDatos(out lado, out apotema);

        double area = CalcularArea(lados, lado, apotema);

        Console.WriteLine($"\nEl área del polígono es: {area:F2}");
    }

    static int SeleccionarPoligono()
    {
        Console.WriteLine("=== SELECCIÓN DE POLÍGONO ===");
        Console.WriteLine("1. Pentágono");
        Console.WriteLine("2. Hexágono");
        Console.WriteLine("3. Heptágono");
        Console.WriteLine("4. Octágono");

        Console.Write("Seleccione una opción: ");
        int opcion = int.Parse(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                return 5;
            case 2:
                return 6;
            case 3:
                return 7;
            case 4:
                return 8;
            default:
                Console.WriteLine("Opción no válida. Se usará Pentágono.");
                return 5;
        }
    }

    static void PedirDatos(out double lado, out double apotema)
    {
        Console.Write("\nIngrese la medida del lado: ");
        lado = double.Parse(Console.ReadLine());

        Console.Write("Ingrese la apotema: ");
        apotema = double.Parse(Console.ReadLine());
    }

    static double CalcularArea(int lados, double lado, double apotema)
    {
        double perimetro = lados * lado;
        double area = (perimetro * apotema) / 2;

        return area;
    }
}
