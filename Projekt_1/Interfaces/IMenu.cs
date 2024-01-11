using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Interfaces
{
    public interface IMenu
    {
        void Display();
        void Menuchoice(int choice);
        void Run();
        void PrintBanner();

        int PromptUser();
    }
}
