using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.UserInterface
{
    internal interface IUI
    {
        void Print(string text);

        string GetInput();
    }
}
