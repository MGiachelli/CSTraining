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

        public PersonBuilder(HumanBuilder? humanBuilder = null)
        {
            _humanBuilder = humanBuilder ?? new HumanBuilder();
        }
        public Person Build(Object? FromObject = null)
        {
            _person = new Person();
            _humanBuilder.Human = _person;
            _humanBuilder.Build(FromObject);

            SetTransportId();
            SetSalary();
            SetIsMarried();
            SetChildren();
            SetCreditCardNumbers();
            
            return _person;
        }

        protected virtual void SetTransportId(Guid? guid = null) 
        { 
            if (guid == null) _person.TransportId = Guid.NewGuid();
            else _person.TransportId = (Guid) guid; 
        }
        protected virtual void SetSequenceId(Int32 id = 0) { _person.SequenceId = id; }
        protected virtual void SetCreditCardNumbers(String[]? cards = null) { _person.CreditCardNumbers = cards; }
        protected virtual void SetPhones(String[]? phones = null) { _person.Phones = phones;}
        protected virtual void SetSalary(Double salary = 0) { _person.Salary = salary; }
        protected virtual void SetIsMarried(Boolean isMarried = false) { _person.IsMarried = isMarried; }
        protected virtual void SetChildren(Human[]? children = null) { _person.Children = children; }
    }

    public class RandomPersonBuilder : PersonBuilder
    {
        public RandomPersonBuilder(HumanBuilder? humanBuilder = null) : base(new RandomHumanBuilder())
        {
        }
    }
}
