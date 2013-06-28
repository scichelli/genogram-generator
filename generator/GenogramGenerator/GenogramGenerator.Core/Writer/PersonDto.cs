namespace GenogramGenerator.Core.Writer
{
    public class PersonDto
    {
        public PersonDto() { }

        public PersonDto(Person person)
        {
            Id = person.Id.ToString();
            Name = person.Name;
            Gender = person.Sex.ToString();
            XPosition = person.XPosition.ToString();
            YPosition = (600 - (person.Generation * 100)).ToString();
            DistanceToPrimaryLineage = person.DistanceToPrimaryLineage.ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string XPosition { get; set; }
        public string YPosition { get; set; }
        public string DistanceToPrimaryLineage { get; set; }
    }
}