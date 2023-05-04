namespace SerializationTask;
class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        PersonBuilder RandomPerson = new RandomPersonBuilder();
        Person person = RandomPerson.BuildPerson();
        Console.WriteLine(person.ToString());
    }
}
