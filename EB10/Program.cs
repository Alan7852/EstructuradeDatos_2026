using System;

readonly struct CoordenadaGPS
{
    public double Latitud { get; }
    public double Longitud { get; }

    public CoordenadaGPS(double lat, double lon)
    {
        // Validación de rangos
        if (lat < -90 || lat > 90)
            throw new ArgumentOutOfRangeException(nameof(lat), "Latitud fuera de rango [-90, 90]");
        if (lon < -180 || lon > 180)
            throw new ArgumentOutOfRangeException(nameof(lon), "Longitud fuera de rango [-180, 180]");

        Latitud = lat;
        Longitud = lon;
    }

    public void ImprimirUbicacion()
    {
        Console.WriteLine($"Ubicación: Latitud={Latitud}, Longitud={Longitud}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Ejemplo de copia por valor
            CoordenadaGPS c1 = new CoordenadaGPS(19.4326, -99.1332); // Ciudad de México
            CoordenadaGPS c2 = c1; // Copia por valor en el Stack

            // Reasignamos c2 -> Berlín
            c2 = new CoordenadaGPS(52.5200, 13.4050);

            Console.WriteLine(" --- c1 --- ");
            c1.ImprimirUbicacion();
            Console.WriteLine(" --- c2 --- ");
            c2.ImprimirUbicacion();

            // Captura de datos desde consola
            Console.WriteLine("\nIngresa coordenadas personalizadas:");
            Console.Write("Latitud: ");
            double lat = double.Parse(Console.ReadLine());
            Console.Write("Longitud: ");
            double lon = double.Parse(Console.ReadLine());

            var coord = new CoordenadaGPS(lat, lon);
            coord.ImprimirUbicacion();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Ingresa valores numéricos válidos.");
        }
    }
}

