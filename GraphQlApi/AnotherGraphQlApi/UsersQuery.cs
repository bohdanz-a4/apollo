using GraphQL.Types;

namespace AnotherGraphQlApi
{
    public class UsersQuery : ObjectGraphType<User>
    {
        public UsersQuery()
        {
            Name = "UsersQuery";
            Field<UserType>("user", arguments: new QueryArguments
            {
                new QueryArgument<IntGraphType>
                {
                    Name = "id"
                }
            },
            resolve: context => new User
            {
                Id = (int)context.Arguments["id"].Value,
                Name = $"Name {(int)context.Arguments["id"].Value}"
            }
            );
        }
    }
}
