namespace DataCore
{
    public readonly struct RegistroDatos
    {
        public int Id { get; }
        public double Valor { get; }
        public string Etiqueta { get; }

        public RegistroDatos(int id, double valor, string etiqueta)
        {
            Id = id;
            Valor = valor;
            Etiqueta = etiqueta;
        }

        public override string ToString() => $"[{Id}] {Etiqueta}: {Valor}";
    }
}
