using SerializationTask.Models;

namespace SerializationTask.Services
{
    public class HumanBuilder
    {
        private Human? _human;

        public HumanBuilder(Human? human = null)
        {
            _human = human;
        }

        public virtual Human Human
        {
            get { return _human; }// _human ??= new Human(); return _human; }
            set { _human = value; }
        }

        public virtual Human Build(Object? FromObject = null)
        {
            SetFirstName();
            SetLastName();
            SetAge();
            SetGender();
            SetBirthDate();

            return Human;
        }
        protected virtual void SetFirstName(String? name = null) { Human.FirstName = name; }
        protected virtual void SetLastName(String? name = null) { Human.LastName = name; }
        protected virtual void SetAge(Int32 age = 0) { Human.Age = age; }
        protected virtual void SetBirthDate(Int64 birthDate = 0) { Human.BirthDate = birthDate; }
        protected virtual void SetGender(Gender gender = Gender.Male) { Human.Gender = gender; }
    }

    public class RandomHumanBuilder : HumanBuilder
    {
        private readonly static String[] FirstNames = { "Jack", "John", "Michael", "Maria", "Rachel"
                , "Dina", "Nick", "Ralf", "Isaac", "Peter", "Matt", "Scott", "Travis", "Rick", "Martin"
                , "Cecil", "Jean", "Debby", "Amanda", "Kelly", "Dick", "Patric", "Leonard", "Steven" };
        private readonly static String[] LastNames = { "Peterson", "Johnson", "Kilmer", "Shelly", "Helm"
                , "Martin", "Fowler", "Chris", "Beck", "Smith", "King", "Salomon", "Jordan", "Kent"
                , "Gosling", "Brin", "Stone", "Archibald", "Manning", "Kernigan", "Ritchie", "Bruce" };

        protected Random rand = new Random();

        protected override void SetAge(Int32 age = 0)
        {
            base.SetAge(rand.Next(0, 120));
        }

        protected override void SetBirthDate(Int64 birthDate = 0)
        {
            var date = DateTime.Today.AddYears((Human.Age ?? 0) * -1);
            date = date.AddDays(rand.Next(0, 365));
            birthDate = (new DateTimeOffset(date)).ToUnixTimeMilliseconds();
            base.SetBirthDate(birthDate);
        }

        protected override void SetFirstName(String? name = null)
        {
            base.SetFirstName(FirstNames[rand.Next(FirstNames.Length)]);
        }

        protected override void SetGender(Gender gender = Gender.Male)
        {
            base.SetGender((Gender) rand.Next(Enum.GetNames(typeof(Gender)).Length));
        }

        protected override void SetLastName(String? name = null)
        {
            base.SetLastName(LastNames[rand.Next(LastNames.Length)]);
        }

    }
}
