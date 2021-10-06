using HotChocolate.Types;

namespace GraphqlSubscriptions
{
    public class Query : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("ping")
                .Type<NonNullType<StringType>>()
                .Resolve(
                    ctx => "pong");
        }
    }
}
