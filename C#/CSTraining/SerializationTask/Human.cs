using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTask
{
    [Serializable]
    public class Human
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int64 BirthDate { get; set; }
        public Int32 Age { get; set; }
        public Gender Gender { get; set; }

        public override string? ToString()
        {
            return "Human: " + this.FirstName + " " + this.LastName;
        }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
