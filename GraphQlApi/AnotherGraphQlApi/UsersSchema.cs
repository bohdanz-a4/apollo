using GraphQL.Types;

namespace AnotherGraphQlApi
{
    public class UsersSchema : Schema
    {
        public UsersSchema()
        {
            Query = new UsersQuery();
        }
    }
}
