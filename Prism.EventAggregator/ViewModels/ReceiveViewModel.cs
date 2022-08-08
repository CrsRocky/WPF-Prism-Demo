using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Prism.EventAggregator.ViewModels
{
    internal class ReceiveViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private SendMessageEvent sendMessageEvent;
        private SubscriptionToken token;

        private ObservableCollection<string> _messages;

        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public DelegateCommand SubscribeCommand { get; private set; }

        public DelegateCommand UnsubscribeCommand { get; private set; }

        public ReceiveViewModel(IEventAggregator eventAggregator)
        {
            SubscribeCommand = new DelegateCommand(Subscribe, CanSubscribe);
            UnsubscribeCommand = new DelegateCommand(Unsubscribe, CanUnsubscribe);
            Messages = new ObservableCollection<string>();
            _eventAggregator = eventAggregator;
            sendMessageEvent = _eventAggregator.GetEvent<SendMessageEvent>();
        }

        private bool CanSubscribe() => !IsSubscribe;

        private bool CanUnsubscribe() => IsSubscribe;

        private bool IsSubscribe => sendMessageEvent.Contains(Receive);

        private void Unsubscribe()
        {
            sendMessageEvent.Unsubscribe(token);
            SubscribeCommand.RaiseCanExecuteChanged();
            UnsubscribeCommand.RaiseCanExecuteChanged();
        }

        private void Subscribe()
        {
            token = sendMessageEvent.Subscribe(Receive);
            SubscribeCommand.RaiseCanExecuteChanged();
            UnsubscribeCommand.RaiseCanExecuteChanged();
        }

        private void Receive(string message)
        {
            Messages.Add(message);
        }
    }
}