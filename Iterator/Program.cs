using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> items;
    private int index;

    public ListyIterator(params T[] items)
    {
        this.items = new List<T>(items);
        this.index = 0;
    }

    public bool Move()
    {
        if (HasNext())
        {
            index++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        return index < items.Count - 1;
    }

    public void Print()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(items[index]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < items.Count; i++)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        ListyIterator<string> listyIterator = null;

        while (input != "END")
        {
            string[] commandParts = input.Split();
            string command = commandParts[0];

            switch (command)
            {
                case "Create":
                    listyIterator = new ListyIterator<string>(commandParts.Length > 1 ? commandParts[1..] : new string[0]);
                    break;
                case "Move":
                    Console.WriteLine(listyIterator.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(listyIterator.HasNext());
                    break;
                case "Print":
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "PrintAll":
                    foreach (var item in listyIterator)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                    break;
            }

            input = Console.ReadLine();
        }
    }
}
