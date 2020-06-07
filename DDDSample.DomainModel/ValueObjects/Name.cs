using System;
namespace DDDSample.DomainModel
{
    public class Name : ValueObject<Name>
    {
        public Name (string name)
        {
            if (name.Length > 256)
            {
                throw new ArgumentException ("名前は256文字以下出ないといけません");
            }
            if (1 > name.Length)
            {
                throw new ArgumentException ("名前は2文字以下出ないといけません");
            }

            Value = name;
        }

        public string Value { get; }

        protected override bool EqualsCore (Name other)
        {
            return Value == other.Value;
        }
    }
}