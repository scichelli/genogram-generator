namespace GenogramGenerator.Core.Writer
{
    public class RelationshipDto
    {
        public RelationshipDto() { }

        public RelationshipDto(Relationship relationship)
        {
            A = relationship.A.Id.ToString();
            B = relationship.B.Id.ToString();
            Type = relationship.Type.ToString();
        }

        public string A { get; set; }
        public string B { get; set; }
        public string Type { get; set; }
    }
}