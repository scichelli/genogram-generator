namespace GenogramGenerator.Core.Writer
{
    public class PersonDto
    {
        public PersonDto() { }

        public PersonDto(Person person)
        {
            Id = person.Id.ToString();
            Name = person.Name;
            Gender = person.Gender.ToString();
            XPosition = person.XPosition.ToString();
            Generation = person.Generation.ToString();
            DistanceToPrimaryLineage = person.DistanceToPrimaryLineage.ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string XPosition { get; set; }
        public string Generation { get; set; }
        public string DistanceToPrimaryLineage { get; set; }
    }
}