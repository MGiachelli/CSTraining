using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace SerializationTask
{
	class Program
	{
		private const Int32 PERSON_NUM = 100;//00;
		private const string exportFile = "Persons.json";
		
        static void Main(string[] args)
        {
			List<Person> personList = GeneratePersonsList(new RandomPersonBuilder(), PERSON_NUM);
			var exportPathAndFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\" + exportFile;
            SerializeToJsonFile(personList, exportPathAndFile);
			ClearPersonList(personList);
            personList = DeserializeFromJsonFile(exportPathAndFile);
			DisplayStatistics(personList);
        }

        public static List<Person> GeneratePersonsList(PersonBuilder personBuilder, Int32 personNum = 1)
		{
			Console.WriteLine("------------------------------------");
			Console.WriteLine("Generating persons with " + personBuilder.GetType().Name);
            List<Person> list = new();
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
			File.WriteAllText(filePath
								,JsonSerializer.Serialize<List<Person>>
									(personList
									, new JsonSerializerOptions 
										{ 
											PropertyNamingPolicy = JsonNamingPolicy.CamelCase
											, WriteIndented = true 
										}
									)
							 );
			Console.WriteLine($"Serialized {personList.Count()} persons.");
		}

		public static void ClearPersonList(List<Person> personList)
		{
			Console.WriteLine("------------------------------------");
			Console.WriteLine("Clearing person list...");
			personList.Clear();
		}

		public static List<Person> DeserializeFromJsonFile(string filePath)
		{
			Console.WriteLine("------------------------------------");
			Console.WriteLine("Deserializing persons from file: " + filePath);

            return JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(filePath)
															, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
															);
        }

		public static void DisplayStatistics(List<Person> personList)
		{
			Console.WriteLine("------------------------------------");
			Console.WriteLine("Persons count: " + personList.Count);
			Console.WriteLine($"Persons credit card count: {personList.Sum(p => p.CreditCardNumbers == null ? 0 : p.CreditCardNumbers.Length)}" +
				$"\taverage: {personList.Average(p => p.CreditCardNumbers == null ? 0 : p.CreditCardNumbers.Length)}");

			Console.WriteLine($"Persons children count: {personList.Sum(p => p.Children == null ? 0 : p.Children.Length)}" +
				$"\taverage: {personList.Average(p => p.Children == null ? 0 : p.Children.Length)}" +
                "\taverage child age: " + personList.Sum(p => p.Children == null ? 0 : p.Children.Sum(c => c.Age))
					/ personList.Sum(p => p.Children == null ? 1 : p.Children.Length));
		}
    }
}