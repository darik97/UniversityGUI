using System.Windows.Forms;

namespace UniversityGUI
{
    partial class MyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            singInLabel = new Label
            {
                Text = "Войти в систему как",
                Dock = DockStyle.Fill
            };

            buttonStudent = new Button
            {
                Text = "Студент",
                Dock = DockStyle.Fill
            };

            buttonTeacher = new Button
            {
                Text = "Преподаватель",
                Dock = DockStyle.Fill
            };

            var table = new TableLayoutPanel();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            for (int i = 0; i < 3; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            }
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            table.Dock = DockStyle.Fill;

            table.Controls.Add(new System.Windows.Forms.Panel(), 0, 0);
            table.Controls.Add(singInLabel, 0, 1);
            table.Controls.Add(buttonStudent, 0, 2);
            table.Controls.Add(buttonTeacher, 0, 3);
            table.Controls.Add(new System.Windows.Forms.Panel(), 0, 4);

            Controls.Add(table);
        }
    }
}