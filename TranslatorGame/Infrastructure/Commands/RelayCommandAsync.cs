using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorGame.Infrastructure.Commands.AsyncBaseCommand;

namespace TranslatorGame.Infrastructure.Commands
{
    public class RelayCommandAsync : AsyncCommandBase
    {
        private readonly Func<Task> _callBack;
        public RelayCommandAsync(Func<Task> callBack)
        {
            _callBack = callBack; 
        }
        protected override async Task ExecuteAsync(object? parameter)
        {
            await _callBack();
        }
    }
}

