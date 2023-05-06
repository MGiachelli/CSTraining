using System;
namespace SerializationTask
{
    public class Person : Human
    {
        public const int MAX_CHILDREN = 5;
        public const int MAX_CARDS = 5;
        public const int MAX_PHONES = 5;

        public Guid TransportId { get; set; }
        public Int32 SequenceId { get; set; }
        public String[]? CreditCardNumbers { get; set; }
        public String[]? Phones { get; set; }
        public Double Salary { get; set; }
        public Boolean IsMarried { get; set; }
        public Human[]? Children { get; set; }

        public Int32 AverageChildrenAge 
        { get 
            {
                if (Children == null) return 0;
                if (Children.Length == 0) return 0;
                Int32 totalAge = 0;
                foreach (var child in Children) { totalAge += child.Age ?? 0; };
                return totalAge/Children.Length;
            } 
        }

        public override string? ToString()
        {
            return "Person[" + this.TransportId + "]: " + this.FirstName + " " + this.LastName;
        }
    }

};

