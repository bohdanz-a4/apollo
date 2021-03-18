using GraphQL.Types;
using GraphQlApi.Models;
using System.Collections.Generic;

namespace GraphQlApi.Queries
{
    public class DroidQuery : ObjectGraphType<Droid>
    {
        public DroidQuery() // todo: service injected here
        {
            Name = "DroidQuery";
            Field<ListGraphType<DroidType>>("droids", resolve: ctx => new List<Droid>
            {
                new Droid { Name = "first", AppearsIn = new List<Episodes> { Episodes.EMPIRE, Episodes.NEWHOPE }},
                new Droid { Name = "second", AppearsIn = new List<Episodes> { Episodes.NEWHOPE, Episodes.PHANTOMMENACE}},
                new Droid { Name = "third", AppearsIn = new List<Episodes> { Episodes.JEDI }}
            });
        }
    }
}
