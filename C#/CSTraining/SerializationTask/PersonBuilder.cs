using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SerializationTask
{
    public class PersonBuilder
    {
        protected Person? _person;
        protected HumanBuilder? _humanBuilder;
        protected Object? _fromObject;

        public PersonBuilder(HumanBuilder? humanBuilder = null)
        {
            _humanBuilder = humanBuilder ?? new HumanBuilder();
        }
        public Person Build(Object? FromObject = null)
        {
            _fromObject = FromObject;
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
            _person.TransportId = guid ?? Guid.NewGuid();
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
        protected Random rand = new Random();
        public RandomPersonBuilder(HumanBuilder? humanBuilder = null) : base(new RandomHumanBuilder())
        {
        }

        protected override void SetChildren(Human[]? children = null)
        {
            Human[] randomChildren = new Human[rand.Next(0,Person.MAX_CHILDREN)];
            for (int c = 0; c < randomChildren.Length; c++)
            {
                _humanBuilder.Human = new Human();
                _humanBuilder.Build(_fromObject);
                randomChildren[c] = _humanBuilder.Human;
            }
            base.SetChildren(randomChildren);
        }
    }
}
