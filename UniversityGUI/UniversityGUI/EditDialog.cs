using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityGUI
{
    class EditDialog : Form
    {
        public TextBox Grade;

        public EditDialog(string name, string grade)
        {
            Label nameLabel = new Label
            {
                Text = name
            };
            Grade = new TextBox
            {
                Text = grade
            };
            Controls.Add(nameLabel);
            Controls.Add(Grade);
        }
    }
}
