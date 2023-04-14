using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorGame.ViewModels;

namespace TranslatorGame.Models
{
    public interface IObjectWindowMVVM
    {
        MainWindowViewModel Parent { get; set; }
    }
}
