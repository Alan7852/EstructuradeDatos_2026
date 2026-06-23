// Proyecto: SimulacroExamen
// Archivo: Program.cs

using System;

namespace SimulacroExamen
{
    

    public class Usuario
    .
    {
        public string nombre;
        public int edad;
    }

    

    public class Empleado : Usuario
    {
        public void CalcularSalario()
        {
            
            Console.WriteLine("El salario siempre es 5000");
        }
    }

    

    public class Reporte
    {
        private Empleado empleado;

        public Reporte(Empleado e)
        {
            empleado = e;
        }

        public void Generar()
        {

            
            Console.WriteLine($"Generando reporte para {empleado.nombre}, edad {empleado.edad}");
            empleado.CalcularSalario();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        
            Empleado emp = new Empleado();
            emp.nombre = "Alan";
            emp.edad = 25;

            Reporte reporte = new Reporte(emp);
            reporte.Generar();
        }
    }
}


Errores incluidos

- Encapsulamiento roto → atributos públicos en Usuario.

- Herencia mal aplicada → Empleado hereda de Usuario pero añade lógica fija.

- Violación del principio abierto/cerrado (OCP) → salario codificado en la clase.

- Acoplamiento excesivo → Reporte depende directamente de Empleado.

- Uso directo de atributos públicos → rompe la abstracción.

- Instanciación rígida → Program crea dependencias sin interfaces ni inyección.