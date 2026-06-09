# Recursividad

## ¿Qué es la recursividad?

La **recursividad** es una técnica de programación en la que una función se llama a sí misma para resolver un problema. Consiste en dividir un problema grande en versiones más pequeñas del mismo problema hasta llegar a una condición que pueda resolverse directamente.

La recursividad es útil cuando un problema puede expresarse de forma natural en términos de sí mismo.

---

## Caso base y caso recursivo

Toda función recursiva debe tener dos elementos fundamentales:

### Caso base
Es la condición que detiene las llamadas recursivas. Sin un caso base, la función se llamaría indefinidamente y provocaría un error por desbordamiento de pila (Stack Overflow).

### Caso recursivo
Es la parte donde la función se llama a sí misma con un problema más pequeño o más simple.

### Ejemplo

```csharp
int Contar(int n)
{
    if (n == 0) // Caso base
        return 0;

    return Contar(n - 1); // Caso recursivo
}
```

---

## Diferencia entre recursividad e iteración

| Recursividad | Iteración |
|-------------|-----------|
| Utiliza llamadas a funciones. | Utiliza bucles (`for`, `while`, `do-while`). |
| Requiere un caso base para detenerse. | Requiere una condición de salida del ciclo. |
| Puede ser más fácil de entender en algunos problemas. | Generalmente consume menos memoria. |
| Utiliza la pila de llamadas (stack). | No genera nuevas llamadas de función. |
| Puede ser menos eficiente. | Suele ser más eficiente en rendimiento. |

### Ejemplo iterativo

```csharp
for(int i = 1; i <= 5; i++)
{
    Console.WriteLine(i);
}
```

### Ejemplo recursivo

```csharp
void Mostrar(int n)
{
    if(n > 5)
        return;

    Console.WriteLine(n);
    Mostrar(n + 1);
}
```

---

# Ejemplos de recursividad

## 1. Factorial

El factorial de un número se define como:

n! = n × (n - 1) × (n - 2) × ... × 1

### Definición recursiva

- Caso base: 0! = 1
- Caso recursivo: n! = n × (n - 1)!

### Código

```csharp
int Factorial(int n)
{
    if (n == 0)
        return 1;

    return n * Factorial(n - 1);
}
```

### Ejemplo

```
Factorial(4)
= 4 * Factorial(3)
= 4 * 3 * Factorial(2)
= 4 * 3 * 2 * Factorial(1)
= 4 * 3 * 2 * 1
= 24
```

---

## 2. Fibonacci

La sucesión de Fibonacci es:

```
0, 1, 1, 2, 3, 5, 8, 13...
```

Cada número es la suma de los dos anteriores.

### Definición recursiva

- Caso base:
  - F(0) = 0
  - F(1) = 1
- Caso recursivo:
  - F(n) = F(n-1) + F(n-2)

### Código

```csharp
int Fibonacci(int n)
{
    if (n <= 1)
        return n;

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```

### Ejemplo

```
Fibonacci(5)
= Fibonacci(4) + Fibonacci(3)
= 3 + 2
= 5
```

---

## 3. Búsqueda Binaria

La búsqueda binaria permite encontrar un elemento en un arreglo ordenado dividiendo repetidamente el rango de búsqueda a la mitad.

### Funcionamiento

1. Se calcula el elemento central.
2. Si es el valor buscado, termina.
3. Si el valor buscado es menor, se busca en la mitad izquierda.
4. Si es mayor, se busca en la mitad derecha.
5. El proceso se repite recursivamente.

### Código

```csharp
int BusquedaBinaria(int[] arreglo, int inicio, int fin, int valor)
{
    if (inicio > fin)
        return -1;

    int medio = (inicio + fin) / 2;

    if (arreglo[medio] == valor)
        return medio;

    if (valor < arreglo[medio])
        return BusquedaBinaria(arreglo, inicio, medio - 1, valor);

    return BusquedaBinaria(arreglo, medio + 1, fin, valor);
}
```

### Ejemplo

```csharp
int[] numeros = {1, 3, 5, 7, 9, 11};

BusquedaBinaria(numeros, 0, numeros.Length - 1, 7);
```

Resultado:

```
Índice 3
```

---

## Ventajas de la recursividad

- Código más corto y elegante.
- Facilita la solución de problemas que tienen una estructura repetitiva.
- Muy útil para árboles, grafos y algoritmos de división y conquista.

## Desventajas de la recursividad

- Consume más memoria debido a la pila de llamadas.
- Puede ser más lenta que la iteración.
- Un caso base incorrecto puede provocar recursión infinita.