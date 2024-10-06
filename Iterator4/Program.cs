using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}
public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0)
        {
            result = string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
        return result;
    }
}
public class AgeComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        
        SortedSet<Person> nameSortedSet = new SortedSet<Person>(new NameComparator());
        SortedSet<Person> ageSortedSet = new SortedSet<Person>(new AgeComparator());

        for (int i = 0; i < n; i++)
        {
            string[] personData = Console.ReadLine().Split();
            string name = personData[0];
            int age = int.Parse(personData[1]);

            Person person = new Person(name, age);

            nameSortedSet.Add(person);
            ageSortedSet.Add(person);
        }
        foreach (Person person in nameSortedSet)
        {
            Console.WriteLine(person);
        }
        foreach (Person person in ageSortedSet)
        {
            Console.WriteLine(person);
        }
    }
}
