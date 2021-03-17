using GraphQL.Types;

namespace GraphQlApi.Models
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType()
        {
            Name = "Droid";
            Description = "A mechanical creature in the Star Wars universe.";
            Field(d => d.Name, nullable: true).Description("The name of the droid.");
            Field<ListGraphType<EpisodeEnum>>("appearsIn", "Which movie they appear in.");
        }
    }
}
