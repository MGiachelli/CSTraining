namespace SerializationTask.Models
{
    [Serializable]
    public class Human
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int64? BirthDate { get; set; }
        public Int32? Age { get; set; }
        public Gender? Gender { get; set; }

        public override String ToString()
        {
            UInt16? test = new();

            return $"Human: {FirstName} {LastName} {test.HasValue}";
        }
    }
    public enum Gender : Byte
    {
        Male,
        Female
    }
}