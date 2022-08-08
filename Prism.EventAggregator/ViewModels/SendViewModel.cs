using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace Prism.EventAggregator.ViewModels
{
    internal class SendViewModel : BindableBase
    {
        private string message;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private readonly IEventAggregator _eventAggregator;

        public DelegateCommand SendCommand { get; private set; }

        public SendViewModel(IEventAggregator eventAggregator)
        {
            message = "Send Message";
            SendCommand = new DelegateCommand(Send);
            _eventAggregator = eventAggregator;
        }

        private void Send()
        {
            _eventAggregator.GetEvent<SendMessageEvent>().Publish(Message);
        }
    }
}