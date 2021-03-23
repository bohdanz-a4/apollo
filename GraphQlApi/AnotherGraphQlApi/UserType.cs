using GraphQL.Types;

namespace AnotherGraphQlApi
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(u => u.Id);
            Field(u => u.Name);
        }
    }
}
