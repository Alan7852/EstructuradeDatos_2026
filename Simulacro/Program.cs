// Proyecto: SimulacroExamen
// Archivo: Program.cs

using System;

namespace SimulacroExamen
{
    public class Usuario
    {
        // ✅ Inicialización directa para evitar warnings
        private string nombre = string.Empty;
        private int edad = 0;

        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }

        public int Edad
        {
            get => edad;
            set
            {
                if (value < 0) throw new ArgumentException("La edad no puede ser negativa");
                edad = value;
            }
        }
    }

    public interface ISalarioStrategy
    {
        decimal CalcularSalario();
    }

    public class SalarioFijo : ISalarioStrategy
    {
        public decimal CalcularSalario() => 5000m;
    }

    public class Empleado
    {
        private readonly Usuario usuario;
        private readonly ISalarioStrategy salarioStrategy;

        public Empleado(Usuario usuario, ISalarioStrategy salarioStrategy)
        {
            this.usuario = usuario;
            this.salarioStrategy = salarioStrategy;
        }

        public string Nombre => usuario.Nombre;
        public int Edad => usuario.Edad;

        public decimal ObtenerSalario() => salarioStrategy.CalcularSalario();
    }

    public interface IGeneradorReporte
    {
        void Generar(Empleado empleado);
    }

    public class ReporteConsola : IGeneradorReporte
    {
        public void Generar(Empleado empleado)
        {
            Console.WriteLine($"Generando reporte para {empleado.Nombre}, edad {empleado.Edad}");
            Console.WriteLine($"Salario calculado: {empleado.ObtenerSalario()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario { Nombre = "Alan", Edad = 25 };
            ISalarioStrategy salario = new SalarioFijo();
            Empleado empleado = new Empleado(usuario, salario);

            IGeneradorReporte reporte = new ReporteConsola();
            reporte.Generar(empleado);
        }
    }
}
