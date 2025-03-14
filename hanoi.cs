using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Pilas para representar las tres torres
    static Stack<int> torreOrigen = new Stack<int>();
    static Stack<int> torreDestino = new Stack<int>();
    static Stack<int> torreAuxiliar = new Stack<int>();

    // Método para mostrar el estado de las torres
    static void MostrarTorres()
    {
        Console.WriteLine("\nEstado actual de las torres:");
        Console.WriteLine("Origen: " + string.Join(", ", torreOrigen.ToArray()));
        Console.WriteLine("Auxiliar: " + string.Join(", ", torreAuxiliar.ToArray()));
        Console.WriteLine("Destino: " + string.Join(", ", torreDestino.ToArray()));
        Console.WriteLine();
    }

    // Método recursivo para resolver el problema de las Torres de Hanoi
    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nomOrigen, string nomDestino, string nomAuxiliar)
    {
        if (n == 1)
        {
            // Mover un solo disco
            destino.Push(origen.Pop());
            Console.WriteLine($"Mover disco de {nomOrigen} a {nomDestino}");
            MostrarTorres();
        }
        else
        {
            // Mover n-1 discos a la torre auxiliar
            ResolverHanoi(n - 1, origen, auxiliar, destino, nomOrigen, nomAuxiliar, nomDestino);

            // Mover el disco más grande a la torre destino
            destino.Push(origen.Pop());
            Console.WriteLine($"Mover disco de {nomOrigen} a {nomDestino}");
            MostrarTorres();

            // Mover los n-1 discos desde la torre auxiliar a la torre destino
            ResolverHanoi(n - 1, auxiliar, destino, origen, nomAuxiliar, nomDestino, nomOrigen);
        }
    }

    // Método principal
    static void Main(string[] args)
    {
        Console.Write("Ingrese el número de discos: ");
        int numDiscos;
        while (!int.TryParse(Console.ReadLine(), out numDiscos) || numDiscos <= 0)
        {
            Console.WriteLine("Por favor, ingrese un número entero positivo.");
            Console.Write("Ingrese el número de discos: ");
        }

        // Llenar la torre de origen con los discos
        for (int i = numDiscos; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        // Mostrar estado inicial de las torres
        MostrarTorres();

        // Resolver el problema usando recursión
        ResolverHanoi(numDiscos, torreOrigen, torreDestino, torreAuxiliar, "Origen", "Destino", "Auxiliar");

        Console.WriteLine("\n¡Juego completado con éxito!");
    }
}
