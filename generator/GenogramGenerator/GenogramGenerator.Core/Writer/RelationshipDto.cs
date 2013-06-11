namespace GenogramGenerator.Core.Writer
{
    public class RelationshipDto
    {
        public RelationshipDto() { }

        public RelationshipDto(Relationship relationship)
        {
            A = new PersonDto(relationship.A);
            B = new PersonDto(relationship.B);
            Type = relationship.Type.ToString();
        }

        public PersonDto A { get; set; }
        public PersonDto B { get; set; }
        public string Type { get; set; }
    }
}