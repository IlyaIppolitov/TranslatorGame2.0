using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TranslatorGame.Infrastructure.Commands.AsyncBaseCommand
{
    public abstract class AsyncCommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) => true;

        public async void Execute(object? parameter)
        {
            await ExecuteAsync(parameter);
        }

        protected abstract Task ExecuteAsync(object? parameter);
    }
}
