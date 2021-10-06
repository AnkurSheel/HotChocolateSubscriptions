using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace GraphqlSubscriptions
{
    public class Subscription : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("onPing")
                .Type<NonNullType<StringType>>()
                .Resolve(ctx => ctx.GetEventMessage<string>())
                .Subscribe(async ctx => await ctx.Service<ITopicEventReceiver>().SubscribeAsync<string, string>("onPing", ctx.RequestAborted));
        }
    }
}
