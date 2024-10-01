using System;
using System.Collections.Generic;

public class Person : IComparable<Person>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string City { get; private set; }

    public Person(string name, int age, string city)
    {
        Name = name;
        Age = age;
        City = city;
    }

    public int CompareTo(Person other)
    {
        int result = Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = Age.CompareTo(other.Age);
            if (result == 0)
            {
                result = City.CompareTo(other.City);
            }
        }
        return result;
    }
}

public class Program
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            string[] data = input.Split();
            string name = data[0];
            int age = int.Parse(data[1]);
            string city = data[2];

            people.Add(new Person(name, age, city));
        }

        int targetIndex = int.Parse(Console.ReadLine()) - 1;
        Person targetPerson = people[targetIndex];

        int matches = 0;
        int nonMatches = 0;

        foreach (var person in people)
        {
            if (targetPerson.CompareTo(person) == 0)
            {
                matches++;
            }
            else
            {
                nonMatches++;
            }
        }

        if (matches == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{matches} {nonMatches} {people.Count}");
        }
    }
}