using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Interfaces
{
    public interface IMenu
    {
        public string MenuName { get; }
        void Display();
        void Menuchoice();
        void Run();
        void PrintBanner();

        int? PromptUser();
    }
}
