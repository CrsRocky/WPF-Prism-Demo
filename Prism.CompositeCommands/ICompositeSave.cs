using Prism.Commands;

namespace Prism.CompositeCommands
{
    internal interface ICompositeSave
    {
        CompositeCommand SaveCommand { get; }
    }
}