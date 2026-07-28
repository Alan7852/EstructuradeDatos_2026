namespace DataCore
{
    public class QuickSorter
    {
        public static void QuickSort(RegistroDatos[] datos, int izquierda, int derecha)
        {
            if (izquierda >= derecha) return;

            int indicePivote = Particionar(datos, izquierda, derecha);
            QuickSort(datos, izquierda, indicePivote);
            QuickSort(datos, indicePivote + 1, derecha);
        }

        private static int Particionar(RegistroDatos[] datos, int izquierda, int derecha)
        {
            var pivote = datos[(izquierda + derecha) / 2];
            int i = izquierda;
            int j = derecha;

            while (true)
            {
                while (datos[i].Valor < pivote.Valor) i++;
                while (datos[j].Valor > pivote.Valor) j--;

                if (i >= j) return j;

                (datos[i], datos[j]) = (datos[j], datos[i]); // swap con tuplas
                i++;
                j--;
            }
        }
    }
}
