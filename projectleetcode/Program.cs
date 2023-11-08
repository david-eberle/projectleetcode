using System;
using System.Reflection;

public partial class Program
{
    static void Main(string[] args)
    {
        bool found = false;
        int number = 1;
        while (!found)
        {
            Type tipo = typeof(Program);
            MethodInfo metodo = tipo.GetMethod("current_Exercise" + number.ToString("0000"));
            if (metodo != null)
            {
                Console.WriteLine("Running exercise " + number.ToString());
                object instancia = Activator.CreateInstance(tipo);
                metodo.Invoke(instancia, null);
                found = true;
            }
            number++;
        }
    }
}
