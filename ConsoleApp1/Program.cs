
using System.Runtime.Intrinsics.X86;
using System;

class Calculadora
{
    static double Sumar(double numOne, double numTwo)
    {
        return numOne + numTwo;
    }

    static double Restar(double numOne, double numTwo)
    {
        return numOne - numTwo;
    }

    static double Multiplicar(double numOne, double numTwo)
    {
        return numOne * numTwo;
    }

    static double Dividir(double numOne, double numTwo)
    {
        if (numTwo == 0)
        {
            Console.WriteLine("ERROR: No se puede dividir por 0.");
            return double.NaN;
        }
        return numOne / numTwo;
    }
    static bool JugarDeNuevo()
    {
        string respuesta = "";
        do
        {
            Console.WriteLine("\n¿Quieres realizar otra operación? (SI/NO): ");
            respuesta = Console.ReadLine()!.ToUpper().Trim();
        } while (respuesta != "SI" && respuesta != "NO");
        return respuesta == "SI";
    }

    static void Main()
    {
        double numOne, numTwo, resultado;
        char operador;
        bool usarAgain = true;
        int count = 0;

        while (usarAgain)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("          CALCULADORA BÁSICA");
            Console.WriteLine("========================================\n");

            Console.Write("Ingrese el primer número: ");
            while (!double.TryParse(Console.ReadLine()!, out numOne))
            {
                Console.Write("Entrada inválida. Ingrese un número válido: ");
            }

            Console.Write("\nIngrese el operador (+, -, *, /): ");
            while (!char.TryParse(Console.ReadLine()!, out operador) ||
                   (operador != '+' && operador != '-' && operador != '*' && operador != '/'))
            {
                Console.Write("\nOperador inválido. Ingrese un operador válido (+, -, *, /): ");
            }

            Console.Write("\nIngrese el segundo número: ");
            while (!double.TryParse(Console.ReadLine()!, out numTwo))
            {
                Console.Write("Entrada inválida. Ingrese un número válido: ");
            }

            Console.WriteLine("\nProcesando operación...");
            Thread.Sleep(800);

            switch (operador)
            {
                case '+':
                    resultado = Sumar(numOne, numTwo);
                    Console.WriteLine($"Resultado: {numOne} + {numTwo} = {resultado}");
                    break;
                case '-':
                    resultado = Restar(numOne, numTwo);
                    Console.WriteLine($"Resultado: {numOne} - {numTwo} = {resultado}");
                    break;
                case '*':
                    resultado = Multiplicar(numOne, numTwo);
                    Console.WriteLine($"Resultado: {numOne} * {numTwo} = {resultado}");
                    break;
                case '/':
                    resultado = Dividir(numOne, numTwo);
                    Console.WriteLine($"Resultado: {numOne} / {numTwo} = {resultado}");
                    break;
            }

            count++;
            usarAgain = JugarDeNuevo();
        }

        Console.WriteLine("\nGracias mi pequeña y humilde calculadora :) ");
        Console.WriteLine($"Total de operaciones realizadas: {count}");
    }
}
