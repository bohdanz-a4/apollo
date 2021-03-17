using GraphQL.Types;
using GraphQlApi.Models;
using System.Collections.Generic;

namespace GraphQlApi.Queries
{
    public class DroidQuery : ObjectGraphType<object>
    {
        public DroidQuery() // todo: service injected here
        {
            Name = "Droid";
            Field<ListGraphType<DroidType>>("droids", resolve: ctx => new List<object>
            {
                new object(),
                new object()
            });
        }
    }
}
