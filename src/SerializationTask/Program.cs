using SerializationTask.Models;
using SerializationTask.Services;
using System.Text.Json;
using Autofac;

namespace SerializationTask
{
    class Program
	{
		private const Int32 PERSON_NUM = 10;
		private static String exportFileName = "Persons.json";
        private static IContainer Container { get; set; }

        static void Main(String[] args)
        {
			RegisterComponents();

            var personList = GeneratePersonsList(PERSON_NUM);
   //         var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), exportFileName);

   //         SerializeToJsonFile(personList, filePath);
			//ClearPersonList(personList);
   //         personList = DeserializeFromJsonFile(exportFileName);
			//DisplayStatistics(personList);
        }

        private static void RegisterComponents()
        {
			var builder = new ContainerBuilder();
			builder.RegisterType<Human>().AsSelf();
            builder.RegisterType<Person>().As<Human>();
            builder.RegisterType<HumanBuilder>().AsSelf();
            builder.RegisterType<PersonBuilder>().AsSelf();
            builder.RegisterType<RandomHumanBuilder>().As<HumanBuilder>();
            builder.RegisterType<RandomPersonBuilder>().As<PersonBuilder>();
            Container = builder.Build();
        }

        public static List<Person> GeneratePersonsList(Int32 personNum = 1)
		{
            List<Person> list = new();

            using (var scope = Container.BeginLifetimeScope())
            {
                var personBuilder = scope.Resolve<PersonBuilder>();
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Generating persons with " + personBuilder.GetType().Name);

                for (var i = 0; i < personNum; i++)
				{
					var person = personBuilder.Build();
					person.SequenceId = i;
					list.Add(person);
					Console.WriteLine(person.ToString());
				}
            }

			return list;
		}
        public static void SerializeToJsonFile(List<Person> personList, String filePath)
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
        public static List<Person> DeserializeFromJsonFile(String filePath)
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

            Console.ReadKey();
        }
    }
}