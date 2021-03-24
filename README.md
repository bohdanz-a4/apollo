# apollo
apollo gateway and hotchocolate schema stitching demo

I did not manage to implement Apollo Federation due to requirements to schema compatibility. Probably it is possible but requires much more effort.
GraphQL APIs can be implemented using HotChocolate but in the examples we use graphql-dotnet (https://github.com/graphql-dotnet/server), so far we it's a proof that we are not bound to any particular framework.

Sample is based on `centralized` gateway, so far GraphQL services know nothing about their schemas being stitched.
https://github.com/ChilliCream/hotchocolate-examples/tree/master/misc/Stitching

Useful links:
https://chillicream.com/docs/hotchocolate/v10/stitching/

