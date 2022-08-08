using Prism.Commands;

namespace Prism.CompositeCommands.Models
{
    internal class CompositeSave : ICompositeSave
    {
        public CompositeCommand SaveCommand { get; private set; }

        public CompositeSave()
        {
            SaveCommand = new CompositeCommand(true);
        }
    }
}