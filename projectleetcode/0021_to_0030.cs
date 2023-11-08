using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class Program
{
	public static void Exercise0021()
	{
	}
	public static void Exercise0022()
	{
       
    }
    public static void Exercise0023()
	{
	}

	public static void Exercise0024()
	{
		
	}

	public static void Exercise0025()
	{	
		
	}

	public static void Exercise0026()
	{
		
	}

	public static void Exercise0027()
	{
		
	}
	public static void Exercise0028()
	{
		
	}

	public static void Exercise0029()
	{
		
	}

	public static IList<int> FindSubstring(string s, string[] words)
	{
		List<int> combinations = new List<int>();
		int step = words[0].Length;
		// Busco la primera posicion donde aparezca una palabra
		int pos = 0;
		List<string> lwords1 = words.ToList();
		List<string> lwords;
		if (step <= s.Length)
		{
			while (!words.Contains(s.Substring(pos, step)))
				pos++;
			// me desplazo de a bloques, de tamaño step
			while ((pos + (step * words.Length)) <= s.Length)
			{
				lwords = lwords1.ToList();
				for (int word = 0; word < words.Length; word++)
				{
					string current = s.Substring(pos + word * step, step);
					if (!lwords.Contains(current))
						break;
					lwords.Remove(current);
				}
				if (lwords.Count == 0)
					combinations.Add(pos);
				pos += 1;
			}
		}
		return combinations;
	}

	public static void Exercise0030()
	{
        string[] words = { "word", "good", "best", "good" };
        string s = "wordgoodgoodgoodbestword";

		// armar dict de las palabras words, y luego ir iterando en s usando la funcion replace
		// int count = s.Length - s.Replace(word, "").Length / step, e ir controlando palabra por palabra;

		Console.WriteLine(FindSubstring(s, words).Count);
    }
}