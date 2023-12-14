using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class Program

{
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static bool isPrime(long value)
    {
        for (int i = 2; i < value / 2; i++)
        {
            if ((value % i) == 0)
            {
                return false;
            }
        }
        return true;
    }
    public static List<long> getDivisors(long value)
    {
        List<long> divisors = new() { };
        divisors.Add(value);
        for (int i = 1; i < (value / 2) + 1; i++)
        {
            if ((value % i) == 0)
            {
                divisors.Add(i);
            }
        }
        return divisors;
    }

    public static int getDivisorsCount(long number)
    {
        List<int> primes = new List<int> { };
        long temp = number;
        for (int i = 2; i <= number; i++)
        {
            while (number % i == 0)
            {
                primes.Add(i);
                number /= i;
            }
        }
        Dictionary<int, int> result = GroupAndCount(primes);
        int total = 1;
        foreach (var kvp in result.ToList())
        {
            total = total * (kvp.Value + 1);
        }
        return total;
    }

    public static Dictionary<int, int> GroupAndCount(List<int> numbers)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();
        foreach (int number in numbers)
        {
            if (result.ContainsKey(number))
            {
                result[number]++;
            }
            else
            {
                result[number] = 1;
            }
        }
        return result;
    }

    public static string ConvertNumberToWords(int number)
    {
        //if (number < 0 || number > 1000)
        //{
        //    throw new ArgumentOutOfRangeException("number", "Number must be between 0 and 1000.");
        //}

        //if (number < 20)
        //{
        //    return units[number];
        //}

        //if (number < 100)
        //{
        //    return tens[number / 10] + ((number % 10 != 0) ? " " + units[number % 10] : "");
        //}

        //if (number < 1000)
        //{
        //    return units[number / 100] + " hundred" + ((number % 100 != 0) ? " and " + ConvertNumberToWords(number % 100) : "");
        //}

        return "one thousand";
    }
    static string MultiplyStrings(string number, int multiplier)
    {
        StringBuilder sb = new StringBuilder();
        int carry = 0;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(number[i].ToString());
            int product = digit * multiplier + carry;
            int remainder = product % 10;
            carry = product / 10;
            sb.Insert(0, remainder.ToString());
        }

        if (carry > 0)
        {
            sb.Insert(0, carry.ToString());
        }

        return sb.ToString();
    }

    public static string GenerarCombinaciones(string input, int position)
    {
        char[] caracteres = input.ToCharArray();
        int longitud = caracteres.Length;
        Array.Sort(caracteres); // Ordenar el array de caracteres inicial
        int positionActual = 1;
        while (positionActual != position)
        {
            int i = longitud - 2;
            while (i >= 0 && caracteres[i] >= caracteres[i + 1])
            {
                i--;
            }
            if (i < 0)
            {
                break;
            }
            int j = longitud - 1;
            while (j > i + 1 && caracteres[j] <= caracteres[i])
            {
                j--;
            }
            char temp = caracteres[i];
            caracteres[i] = caracteres[j];
            caracteres[j] = temp;
            Array.Reverse(caracteres, i + 1, longitud - i - 1);
            positionActual++;
        }
        return new string(caracteres);
    }

    static string AddStringsNumbers(string number1, string number2)
    {
        StringBuilder sb = new StringBuilder();
        int carry = 0;
        int j = 0;
        if (number2.Length > number1.Length)
        {
            string temp = number2;
            number2 = number1;
            number1 = temp;
        }
        for (int i = number1.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(number1[i].ToString());
            int digit2 = ((j < number2.Length) ? int.Parse(number2[number2.Length - j - 1].ToString()) : 0);
            int product = digit + digit2 + carry;
            int remainder = product % 10;
            carry = product / 10;
            sb.Insert(0, remainder.ToString());
            j++;
        }

        if (carry > 0)
        {
            sb.Insert(0, carry.ToString());
        }

        return sb.ToString();
    }

    public static string Divide(string number, int divisor, int minDecimals)
    {
        StringBuilder quotient = new StringBuilder();
        StringBuilder decimalPart = new StringBuilder();
        int dividendIndex = 0;
        int dividend = 0;
        int quotientDigit;
        int remainder = 0;
        bool recurring = false;

        while (dividendIndex < number.Length || remainder != 0)
        {
            if (dividendIndex < number.Length)
                dividend = remainder * 10 + int.Parse(number[dividendIndex].ToString());
            else
                dividend = remainder * 10;

            quotientDigit = dividend / divisor;
            remainder = dividend % divisor;

            if (recurring)
            {
                decimalPart.Append(quotientDigit);
                if (decimalPart.Length >= minDecimals)
                    break;
            }
            else
            {
                quotient.Append(quotientDigit);
                if (dividendIndex > 0 && dividend == int.Parse(number[0].ToString()))
                {
                    recurring = true;
                    quotient.Length = 0; // Reiniciar el cociente antes de la parte periódica
                    decimalPart.Append(quotientDigit); // Agregar el dígito a la parte decimal
                }
            }

            dividendIndex++;
        }

        StringBuilder result = new StringBuilder();
        result.Append(quotient);

        if (recurring)
        {
            result.Append(".");
            result.Append(decimalPart);
            result.Insert(result.Length - minDecimals + 1, '(');
            result.Append(')');
        }

        result.Append($" / {divisor}");

        return result.ToString();
    }

    public static void printGrid(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                Console.Write(grid[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void printStringIList(IList<string> array)
    {
        for (int i = 0; i < array.Count; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}

