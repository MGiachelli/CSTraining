using SerializationLib.Services;
using SerializationTask.Models;

namespace SerializationTask.Services
{
    public class PersonBuilder
    {
        protected Person _person;
        protected HumanBuilder _humanBuilder;
        protected Object _fromObject;

        public PersonBuilder(HumanBuilder humanBuilder = null)
        {
            _humanBuilder = humanBuilder;
        }
        public Person Build(Object FromObject = null)
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
            SetPhones();

            return _person;
        }

        protected virtual void SetTransportId(Guid? guid = null)
        {
            _person.TransportId = guid ?? Guid.NewGuid();
        }
        protected virtual void SetSequenceId(Int32 id = 0) { _person.SequenceId = id; }
        protected virtual void SetCreditCardNumbers(String[] cards = null) { _person.CreditCardNumbers = cards; }
        protected virtual void SetPhones(String[] phones = null) { _person.Phones = phones; }
        protected virtual void SetSalary(Double salary = 0) { _person.Salary = salary; }
        protected virtual void SetIsMarried(Boolean isMarried = false) { _person.IsMarried = isMarried; }
        protected virtual void SetChildren(Human[] children = null) { _person.Children = children; }
    }

    public class RandomPersonBuilder : PersonBuilder
    {
        protected Random rand = new Random();
        public RandomPersonBuilder(HumanBuilder humanBuilder) : base(humanBuilder)
        {
        }

        protected override void SetChildren(Human[] children = null)
        {
            var randomChildren = new Human[rand.Next(0, Person.MAX_CHILDREN)];
            for (var c = 0; c < randomChildren.Length; c++)
            {
                _humanBuilder.Human = new Human();
                _humanBuilder.Build(_fromObject);
                randomChildren[c] = _humanBuilder.Human;
            }
            base.SetChildren(randomChildren);
        }

        protected override void SetCreditCardNumbers(String[] cards = null)
        {
            var cardsList = rand.GetCreditCardNumbers(RandomCreditCardNumberGenerator.BuildPrefixAndLengthArrayForVisaMasterCardAmex()
                                                      , rand.Next(0, Person.MAX_CARDS));

            base.SetCreditCardNumbers(cardsList.ToArray());
        }

        protected override void SetIsMarried(Boolean isMarried = false)
        {
            base.SetIsMarried(isMarried);
        }

        protected override void SetPhones(String[] phones = null)
        {
            var randomPhones = new String[rand.Next(0, Person.MAX_PHONES)];
            for (var p = 0; p < randomPhones.Length; p++)
            {
                randomPhones[p] = RandomPhoneNumberGenerator.GenerateRandomPhoneNumber();
            }
            base.SetPhones(randomPhones);
        }

        protected override void SetSalary(Double salary = 0)
        {
            base.SetSalary(salary);
        }
    }
}
