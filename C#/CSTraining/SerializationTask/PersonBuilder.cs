using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTask
{
    public class PersonBuilder
    {
        private Person _person;

        protected Person Person 
        { 
            get { _person ??= new Person(); return _person; } 
        }
        
        public Person BuildPerson(Object? FromObject = null)
        {
            SetTransportId();
            SetFirstName();
            SetLastName();
            SetAge();
            SetGender();
            SetBirthDate();
            SetSalary();
            SetIsMarred();
            SetChildren();
            SetCreditCardNumbers();
            
            return Person;
        }

        protected void SetTransportId(Guid? guid = null) 
        { 
            if (guid == null) Person.TransportId = Guid.NewGuid();
            else Person.TransportId = (Guid) guid; 
        }
        protected void SetFirstName (String? name = null) { Person.FirstName = name;}
        protected void SetLastName(String? name = null) { Person.LastName = name; }
        protected void SetSequenceId(Int32 id = 0) { Person.SequenceId = id; }
        protected void SetCreditCardNumbers(String[]? cards = null) { Person.CreditCardNumbers = cards; }
        protected void SetAge(Int32 age = 0) { Person.Age = age; }
        protected void SetPhones(String[]? phones = null) { Person.Phones = phones;}
        protected void SetBirthDate(Int64 birthDate = 0) { Person.BirthDate = birthDate;}
        protected void SetSalary(Double salary = 0) { Person.Salary = salary; }
        protected void SetIsMarred(Boolean isMarried = false) { Person.IsMarred = isMarried; }
        protected void SetGender(Gender gender = Gender.Male) { Person.Gender = gender; }
        protected void SetChildren(Child[]? children = null) { Person.Children = children; }
    }

    public class RandomPersonBuilder: PersonBuilder
    {
        
        //Random rand = new Random();
    
    }
}
