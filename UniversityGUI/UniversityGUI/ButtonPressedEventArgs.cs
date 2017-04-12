using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityGUI
{
    public class ButtonPressedEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Grade { get; set; }
        public int Position { get; set; }
    }
}
