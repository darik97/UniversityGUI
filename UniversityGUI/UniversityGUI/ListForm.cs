using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityGUI
{
    class ListForm : Form
    {
        public TableLayoutPanel Table;

        public ListForm(int columnNumber, int rowNumber)
        {
            Table = new TableLayoutPanel();
            Table.ColumnCount = columnNumber;
            Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80));
            for (int i = 1; i < columnNumber; i++)
            {
                Table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            }
            for (int i = 0; i <= rowNumber; i++)
            {
                Table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
            Table.Dock = DockStyle.Fill;
            Table.AutoScroll = true;
        }

    }
}
