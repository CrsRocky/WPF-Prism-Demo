using Prism.Events;

namespace Prism.EventAggregator
{
    /// <summary>
    /// send str message
    /// </summary>
    internal class SendMessageEvent : PubSubEvent<string>
    { }
}