using System;

public class Nodo
{
    // Identificador único para ordenar el árbol
    public int ID { get; set; }

    // Información que almacena el nodo
    public string Dato { get; set; } = string.Empty;

    // Referencias recursivas a los hijos
    public Nodo? HijoIzquierdo { get; set; }
    public Nodo? HijoDerecho { get; set; }

    // Constructor
    public Nodo(int id, string dato)
    {
        ID = id;
        Dato = dato;
    }
}

public class ArbolBinario
{
    // Insertar nodo recursivo
    public static Nodo InsertarNodo(Nodo? raiz, Nodo nuevoNodo)
    {
        // Caso base: posición vacía
        if (raiz == null)
            return nuevoNodo;

        // Caso recursivo: decidir dirección
        if (nuevoNodo.ID < raiz.ID)
        {
            raiz.HijoIzquierdo = InsertarNodo(raiz.HijoIzquierdo, nuevoNodo);
        }
        else if (nuevoNodo.ID > raiz.ID)
        {
            raiz.HijoDerecho = InsertarNodo(raiz.HijoDerecho, nuevoNodo);
        }
        // Si ID == raiz.ID, el nodo ya existe (ignorar)

        return raiz;
    }

    // Buscar nodo recursivo
    public static string? BuscarNodo(Nodo? raiz, int idTarget)
    {
        // Caso base 1: posición vacía
        if (raiz == null)
            return null;

        // Caso base 2: encontrado
        if (idTarget == raiz.ID)
            return raiz.Dato;

        // Caso recursivo: decidir dirección
        if (idTarget < raiz.ID)
        {
            return BuscarNodo(raiz.HijoIzquierdo, idTarget);
        }
        else
        {
            return BuscarNodo(raiz.HijoDerecho, idTarget);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Árbol Binario de Búsqueda (BST) ===\n");

        // Crear raíz
        Nodo raiz = new Nodo(5, "Raíz");

        // Insertar nodos
        raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(3, "Izquierda"));
        raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(7, "Derecha"));
        raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(2, "Nodo 2"));
        raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(4, "Nodo 4"));
        raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(6, "Nodo 6"));
        raiz = ArbolBinario.InsertarNodo(raiz, new Nodo(8, "Nodo 8"));

        // Buscar nodos
        Console.Write("Ingresa un ID para buscar en el árbol: ");
        if (int.TryParse(Console.ReadLine(), out int idBuscar))
        {
            string? resultado = ArbolBinario.BuscarNodo(raiz, idBuscar);
            Console.WriteLine(resultado != null
                ? $"Nodo encontrado: {resultado}"
                : "Nodo no encontrado");
        }
        else
        {
            Console.WriteLine("Entrada inválida.");
        }
    }
}
