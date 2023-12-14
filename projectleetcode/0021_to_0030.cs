using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class Program
{
    #region exercise 21
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode temp = new ListNode(-101, null);
        ListNode p1, p2;
        if(list1 != null && (list2 == null || list1.val < list2.val)){
            p1 = list1;
            p2 = list2;
        }
        else
        {
            p2 = list1;
            p1 = list2;
        }
        ListNode result = new ListNode();
        result = p1;
        temp.next = result;
        if(p1 != null)
            p1 = p1.next;
        while (p1 != null || p2 != null) {
            if (p1 != null && ((p2 != null && p1.val < p2.val) || (p2 == null)))
            {
                result.next = p1;
                p1 = p1.next;
                result = result.next;
            }
            else// if (p2 != null && ((p1 != null && p2.val < p1.val) || (p1 == null)))
            {
                result.next = p2;
                p2 = p2.next;
                result = result.next;
            }
        }
        return temp.next;
    }
    public static void Exercise0021()
	{
		ListNode result = new ListNode();
        ListNode l1 = new ListNode(1, null);
		ListNode l2 = new ListNode(5, null);
        ListNode l3 = new ListNode(7, null);
        ListNode l4 = new ListNode(3, null);
        ListNode l5 = new ListNode(4, null);
        ListNode l6 = new ListNode(4, null);
        l1.next = l2;
        l2.next = l3;
        l4.next = l5;
        l5.next = l6;

		PrintList(MergeTwoLists(l1, l4));
    }
    #endregion
    private static  void GenerateParenthesisRecursive(List<string> result, string current, int open, int close, int n)
    {
        if (current.Length == n * 2)
        {
            result.Add(current);
            return;
        }

        if (open < n)
        {
            GenerateParenthesisRecursive(result, current + "(", open + 1, close, n);
        }
        if (close < open)
        {
            GenerateParenthesisRecursive(result, current + ")", open, close + 1, n);
        }
    }
    
	public static void Exercise0022()
	{
		int n = 5;
        List<string> result = new List<string>();
        GenerateParenthesisRecursive(result, "", 0, 0, n);
		result.ForEach(Console.WriteLine);
    }
    public static void Exercise0023()
	{
	}

    #region 0024
    static void PrintList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + " ");
            head = head.next;
        }
        Console.WriteLine();
    }
    public static ListNode SwapPairs(ListNode head)
    {
        ListNode newNode = new ListNode(0, head);
		ListNode pos = newNode;
		
        while (pos.next != null && pos.next.next != null)
        {
			ListNode temp1 = pos.next;
            ListNode temp2 = pos.next.next;
            ListNode temp3 = pos.next.next.next;
            pos.next = temp2;
            pos.next.next = temp1;
            pos.next.next.next = temp3;
            pos = pos.next.next;
        }
        return newNode.next;
    }
    public static void Exercise0024()
	{
		ListNode head = new ListNode(1);
        ListNode node2 = new ListNode(2);
        ListNode node3 = new ListNode(3);
        ListNode node4 = new ListNode(4);
        head.next = node2;
        head.next.next = node3;
        head.next.next.next = node4;
		PrintList(head);
		ListNode newHead = SwapPairs(head);
        PrintList(newHead);
    }
    #endregion

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