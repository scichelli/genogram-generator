namespace GenogramGenerator.Core.Writer
{
    public class PersonDto
    {
        public PersonDto() { }

        public PersonDto(Person person)
        {
            Name = person.Name;
        }

        public string Name { get; set; }
    }
}