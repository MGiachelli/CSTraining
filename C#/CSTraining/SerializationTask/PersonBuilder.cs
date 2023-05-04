using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTask
{
    public class PersonBuilder
    {
        private Person? _person;
        private HumanBuilder? _humanBuilder;

        public virtual Person Person 
        { 
            get { _person ??= new Person(); return _person; } 
            set { _person = value; }
        }
        public virtual PersonBuilder SetPerson(Person? person = null)
        {
            this._person = person;
            return this;
        }
        public virtual HumanBuilder HumanBuilder
        {
            get { _humanBuilder ??= new HumanBuilder(); return _humanBuilder; }
            set { _humanBuilder = value; }
        }
        public virtual PersonBuilder SetHumanBuilder(HumanBuilder? humanBuilder = null)
        {
            this._humanBuilder = humanBuilder;
            return this;
        }
        public Person Build(Object? FromObject = null)
        {
            this.HumanBuilder.Human = this.Person;
            this.HumanBuilder.Build(FromObject);

            SetTransportId();
            SetSalary();
            SetIsMarried();
            SetChildren();
            SetCreditCardNumbers();
            
            return this.Person;
        }

        protected virtual void SetTransportId(Guid? guid = null) 
        { 
            if (guid == null) Person.TransportId = Guid.NewGuid();
            else Person.TransportId = (Guid) guid; 
        }
        protected virtual void SetSequenceId(Int32 id = 0) { Person.SequenceId = id; }
        protected virtual void SetCreditCardNumbers(String[]? cards = null) { Person.CreditCardNumbers = cards; }
        protected virtual void SetPhones(String[]? phones = null) { Person.Phones = phones;}
        protected virtual void SetSalary(Double salary = 0) { Person.Salary = salary; }
        protected virtual void SetIsMarried(Boolean isMarried = false) { Person.IsMarried = isMarried; }
        protected virtual void SetChildren(Human[]? children = null) { Person.Children = children; }
    }

    public class RandomPersonBuilder: PersonBuilder
    {


    }
}
