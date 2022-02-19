using System;
using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        int numberOfPerson = int.Parse(Console.ReadLine());
        var nameToPerson = new Dictionary<string, Person>();

        for (int i = 0; i < numberOfPerson; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            var person = new Person
            (
                inputs[0],
                inputs[1],
                int.Parse(inputs[2]),
                inputs[3] == "-",
                inputs[4] == "Anglican",
                inputs[5] == "F"
            );

            nameToPerson.Add(person.Name, person);
        }

        foreach(Person person in nameToPerson.Values)
        {
            if (person.ParentName == "-") continue;

            nameToPerson[person.ParentName].AddChild(person);
        }

        nameToPerson.Values.First(x => x.ParentName == "-").OutputSuccession();
    }

    public class Person
    {
        private readonly HashSet<Person> m_children = new HashSet<Person>();

        public string Name { get; }

        public string ParentName { get; }

        public int YearOfBirth { get; }

        public bool IsAlive { get; }

        public bool IsAnglican { get; }

        public bool IsFemale { get; }

        public Person
        (
            string name,
            string parentName,
            int yearOfBirth,
            bool isAlive,
            bool isAnglican,
            bool isFemale
        )
        {
            Name = name;
            ParentName = parentName;
            YearOfBirth = yearOfBirth;
            IsAlive = isAlive;
            IsAnglican = isAnglican;
            IsFemale = isFemale;
        }

        public void AddChild(Person person) => m_children.Add(person);

        public void OutputSuccession()
        {
            if (IsAlive && IsAnglican)
            {
                Console.WriteLine(Name);
            }

            foreach(Person child in m_children.OrderBy(x => x.IsFemale).ThenBy(x => x.YearOfBirth))
            {
                child.OutputSuccession();
            }
        }
    }
}