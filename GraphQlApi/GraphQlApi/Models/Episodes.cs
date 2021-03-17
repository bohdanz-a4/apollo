using GraphQL.Types;
using System.ComponentModel;

namespace GraphQlApi.Models
{
    [Description("The Star Wars movies.")]
    public enum Episodes
    {
        [Description("Episode 1: The Phantom Menace")]
        PHANTOMMENACE = 1,

        [Description("Episode 4: A New Hope")]
        NEWHOPE = 4,

        [Description("Episode 5: The Empire Strikes Back")]
        EMPIRE = 5,

        [Description("Episode 6: Return of the Jedi")]
        JEDI = 6
    }

    public class EpisodeEnum : EnumerationGraphType<Episodes>
    {
    }
}
