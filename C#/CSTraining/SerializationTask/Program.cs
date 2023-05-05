using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace SerializationTask;
class Program
{
    private const Int32 PERSON_NUM = 10000;
    private static string exportFile = "Persons.json";
    static void Main(string[] args)
    {
        PersonBuilder personBuilder = new RandomPersonBuilder(new RandomHumanBuilder());

        List<Person> personList = GeneratePersonsList(personBuilder, PERSON_NUM);

        string exportPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + exportFile;

        SerializeToJsonFile(personList, exportPath );

        ClearPersonList(personList);

        DeserializeFromJsonFile(personList, exportPath);

        DisplayStatistics(personList);
    }

    public static List<Person> GeneratePersonsList(PersonBuilder personBuilder, Int32 personNum = 1)
    {
        List<Person> list = new List<Person>();
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Generating persons with " + personBuilder.GetType().Name);
        for (Int32 i = 0; i < personNum; i++)
        {
            Person person = personBuilder.Build();
            person.SequenceId = i;
            list.Add(person);
            Console.WriteLine(person.ToString());
        };
        return list;
    }

    public static void SerializeToJsonFile(List<Person> personList, string filePath)
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Serializing persons to file: " + filePath);

    }

    public static void ClearPersonList(List<Person> personList)
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Clearing person list...");
        personList.Clear();
    }

    public static void DeserializeFromJsonFile(List<Person> personList, string filePath)
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Loading persons from file: " + filePath);
    }

    public static void DisplayStatistics(List<Person> personList)
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Persons count: " + personList.Count);
    }
}
