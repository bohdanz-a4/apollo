using GraphQL.Types;
using GraphQlApi.Queries;

namespace GraphQlApi.Schemas
{
    public class DroidSchema : Schema
    {
        public DroidSchema(DroidQuery query)
        {
            Query = query;
        }
    }
}
