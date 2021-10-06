using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace GraphqlSubscriptions
{
    public class Mutation : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("ping")
                .Type<NonNullType<StringType>>()
                .Argument("payload", des => des.Type<NonNullType<StringType>>())
                .Resolve(
                    async ctx =>
                    {
                        var input = ctx.ArgumentValue<string>("payload");

                        await ctx.Service<ITopicEventSender>().SendAsync("onPing", input);
                        return input;
                    });
        }
    }
}
