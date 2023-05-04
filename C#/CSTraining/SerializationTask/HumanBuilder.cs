using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using SerializationTask;

namespace SerializationTask
{
    public class HumanBuilder
    {
        private Human? _human;
        public virtual Human Human
        {
            get { this._human ??= new Human(); return this._human; }
            set { this._human = value; }
        }
        public virtual HumanBuilder SetHuman(Human? human = null)
        {
            this._human = human;
            return this;
        }

        public virtual Human Build(Object? FromObject = null)
        {
            SetFirstName();
            SetLastName();
            SetAge();
            SetGender();
            SetBirthDate();

            return this.Human;
        }
        protected virtual void SetFirstName(String? name = null) { this.Human.FirstName = name; }
        protected virtual void SetLastName(String? name = null) { this.Human.LastName = name; }
        protected virtual void SetAge(Int32 age = 0) { this.Human.Age = age; }
        protected virtual void SetBirthDate(Int64 birthDate = 0) { this.Human.BirthDate = birthDate; }
        protected virtual void SetGender(Gender gender = Gender.Male) { this.Human.Gender = gender; }
    }

    public class RandomHumanBuilder : HumanBuilder
    {
        private readonly static String[] FirstNames = { "Jack", "John", "Michael", "Maria", "Rachel"
                , "Dina", "Nick", "Ralf", "Isaac", "Peter", "Matt", "Scott", "Travis", "Rick", "Martin"
                , "Cecil", "Jean", "Debby", "Amanda", "Kelly", "Dick", "Patric", "Leonard", "Steven" };
        private readonly static String[] LastNames = { "Peterson", "Johnson", "Kilmer", "Shelly", "Helm"
                , "Martin", "Fowler", "Chris", "Beck", "Smith", "King", "Salomon", "Jordan", "Kent"
                , "Gosling", "Brin", "Stone", "Archibald", "Manning", "Kernigan", "Ritchie", "Bruce" };

        Random rand = new Random();

        protected override void SetFirstName(String? name = null)
        {
            this.Human.FirstName = FirstNames[rand.Next(FirstNames.Length)];
        }
        protected override void SetLastName(String? name = null)
        {
            this.Human.LastName = LastNames[rand.Next(LastNames.Length)];
        }

    }
}
