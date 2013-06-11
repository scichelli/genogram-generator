namespace GenogramGenerator.Core
{
    public class Person
    {
        public string Name { get; set; }
        public Family Family { get; set; }

        public Relationship Is { get { return Family.Add(this); } }

        public override string ToString()
        {
            return Name;
        }
    }
}