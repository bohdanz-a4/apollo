using GraphQL.Types;

namespace AnotherGraphQlApi
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "User";
            Field(u => u.Id);
            Field(u => u.Name);
        }
    }
}
