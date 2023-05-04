using System;
namespace SerializationTask;
class Program
{
    public const Int32 PERSON_NUM = 10;//000;
    static void Main(string[] args)
    {
        PersonBuilder Builder = new PersonBuilder().SetHumanBuilder(new RandomHumanBuilder());

        Console.WriteLine("Generating persons...");
        for (Int32 i = 0; i < PERSON_NUM; i++)
        {
            Person person = Builder.Build();
            person.SequenceId = i;
            Console.WriteLine(person.ToString());
        };
    }
}
