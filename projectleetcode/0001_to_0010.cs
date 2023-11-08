using System;
using System.Collections.Generic;
using System.Linq;
public partial class Program
{
    public static void Exercise0001()
    {
        int[] nums = new int[] { 2, 7, 11, 15 };
        int target = 9;
        int[] result = new int[2];
        for (int x = 0; x < nums.Length; x++)
        {
            for (int y = x + 1; y < nums.Length; y++)
            {
                if (nums[x] + nums[y] == target)
                {
                    result[0] = x;
                    result[1] = y;
                    x = nums.Length;
                    y = nums.Length;
                }
            }
        }
        Console.WriteLine(result);
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public static void Exercise0002()
    {
        ListNode result = new ListNode();
        ListNode l1 = new ListNode();
        ListNode l2= new ListNode();
        ListNode current = result;
        int rest = 0;
        while (l1 != null || l2 != null)
        {

            int val = (l1 != null) ? l1.val : 0;
            val += (l2 != null) ? l2.val : 0;
            val += rest;
            rest = (val >= 10) ? 1 : 0;
            current.val = val - (rest * 10);
            l1 = (l1 != null) ? l1.next : null;
            l2 = (l2 != null) ? l2.next : null;
            if (l1 != null || l2 != null)
            {
                ListNode nextNode = new ListNode();
                current.next = nextNode;
                current = nextNode;
            }
        }
        if (rest > 0)
        {
            ListNode nextNode = new ListNode();
            current.next = nextNode;
            current = nextNode;
            current.val = rest;
        }
        Console.WriteLine(result);
    }
    public static void Exercise0003()
    {
        string s = "abcabcbb";
        int max = 0;
        string current = "";
        for (int positionInitial = 0; positionInitial < s.Length; positionInitial++)
        {
            current = s.Substring(positionInitial, 1);
            for (int next = positionInitial + 1; next < s.Length; next++)
            {
                if (current.Contains(s.Substring(next, 1)))
                {
                    next = s.Length;
                }
                else
                {
                    current += s.Substring(next, 1);
                }
            }
            if (current.Length > max)
                max = current.Length;
        }
        Console.WriteLine(max);
    }
    public static void Exercise0004()
    {

    }
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    public static void Exercise0005()
    {
        string s = "cstgvkbrxacmpxdxxktktvpdzcuxmnhvuxdgsmskgeeawzeikhtmhdvnccbrgifpzmiuytfmeyfoxsntrdtxeuxcqsndexbgfxnthqwveujqzemloooyddparbjcuiwpopjwvvmwblsamkhjhlnoxinkpsempexmipifsfwzxbetgvfnkngzxcpizwctpdlpngjpyovmjllxfiwktghkxvyelwjwdztujmunijfsfdvmhgqhlpouewgyznphlmccjmqaqncwbeqheohibafqfunfywmrvqvjygjwqoclijwkcfiuaiymeagdbwyejnvtosxylptbtyoahfzfmwzrkhzdamknleroffmsqcaryibamgdpcumlhrblypddzhaxfeztokgogzgvpfvlmetiwsamhdidmvxavleryfyakendwrbslcavlqkerrnvpuzhdgwzuyorxzbkzhxhpbvkflgxouvaavxrdzsjlgrmogzvlhhdidldsxqhrqlryaanffhxnutcycnczuedtrwcnfiqrtoafvdfnfhxhyjivzalozrbrajboecfyalisxxanduzraqdrbzsbkobaieqpzcawrunxucypqyjnmrlrlivrrwwhdpekeelsphhunzbhkkejvqfopjsuholutgmtnleqdrntbqgrobnuhqpdkbjtikijkdiwqvnxgajaaqgswrdamzv";
        string max = "";
        string current = "";
        if (s.Length >= 2 && s[0] == s[1])
            max = s.Substring(0, 2);
        if (s.Length == 1)
            max = s;
        else
            for (int middle = 1; middle < s.Length; middle++)
            {
                int ratio = max.Length / 2;
                Console.WriteLine("max: " + max + ", ratio: " + ratio.ToString());
                while (middle - ratio >=0 && middle + ratio < s.Length)
                {
                    current = s.Substring(middle, ratio + 1);
                    if (current == Reverse(current) && current.Length > max.Length)
                        max = current;
                    current = s.Substring(middle - ratio, 2 * ratio + 1);
                    if (current == Reverse(current) && current.Length > max.Length)
                        max = current;
                    
                    // add 1 to the left
                    if(middle - ratio - 1 >= 0)
                    {
                        current = s.Substring(middle - ratio -1, 1+2 * ratio + 1);
                        if (current == Reverse(current) && current.Length > max.Length)
                            max = current;
                    }

                    ratio++;

                }
            }
        Console.Write(max);
    }
    public static void Exercise0006()
    {
        string s = "PAYPALISHIRING";
        int numRows = 3;
        string result = "";
        if (numRows == 1 || s.Length == 1)
        {
            result = s;
        }
        else
        {
            int col = 0;
            int position = 0;
            // first row
            while (position < s.Length)
            {
                position = col * ((numRows * 2) - 2);
                if (position < s.Length)
                {
                    result = result + s.Substring(position, 1);
                }
                col++;
            }
            // middle rows
            for (int row = 1; row < numRows - 1; row++)
            {
                col = 0;
                position = 0;
                while (position < s.Length)
                {
                    // going down
                    position = row + col * (numRows * 2 - 2);
                    if (position < s.Length)
                    {
                        result = result + s.Substring(position, 1);
                    }
                    // going up
                    position += 2 * numRows - 2 - ((row * 2));
                    if (position < s.Length)
                    {
                        result = result + s.Substring(position, 1);
                    }
                    col++;
                }
            }
            // bottom row
            col = 0;
            position = 0;
            while (position < s.Length)
            {
                position = numRows - 1 + col * ((numRows * 2) - 2);
                if (position < s.Length)
                {
                    result = result + s.Substring(position, 1);
                }
                col++;
            }
        }
        Console.WriteLine(result);
    }
    public static void Exercise0007()
    {
        int reverse = 0;
        int x = 123;
        for (int i = 0; x != 0; i++)
        {
            if (i == 9 && reverse > int.MaxValue / 10 || reverse < int.MinValue / 10)
            {
                Console.WriteLine(0);
            }

            reverse = reverse * 10 + x % 10;
            x = x / 10;
        }
        Console.WriteLine(reverse);
    }
    public static void Exercise0008()
    {

    }
    public static void Exercise0009()
    {
        int x = -121;
        String s = Convert.ToString(x);
        if (s.Length == 1)
            Console.Write(true);
        int middle = Convert.ToInt32(Math.Round(Convert.ToDecimal(s.Length) / 2, 0));
        for (int i = 0; i <= middle; i++)
            if (s[i] != s[s.Length - 1 - i])
                Console.Write(false);
        Console.Write(true);
    }
    public static void Exercise0010()
    {

    }

}