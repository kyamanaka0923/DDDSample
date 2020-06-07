using System;
namespace DDDSample.DomainModel
{
    public class Id : ValueObject<Id>
    {
        public Id (string value)
        {
            Validate (value);
            Value = value;
        }

        public string Value { get; }

        private void Validate (string value)
        {
            if (value.Length != 3)
            {
                throw new ArgumentException ("Idは3文字でないといけません");
            }
        }

        protected override bool EqualsCore (Id other)
        {
            return this.Value == other.Value;
        }
    }
}