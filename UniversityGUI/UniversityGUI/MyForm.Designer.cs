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
            this.singInLabel = new System.Windows.Forms.Label();
            this.singInLabel.Text = "Войти в систему как";
            this.singInLabel.Dock = System.Windows.Forms.DockStyle.Fill;

            this.buttonStudent = new System.Windows.Forms.Button();
            this.buttonStudent.Text = "Студент";
            this.buttonStudent.Dock = System.Windows.Forms.DockStyle.Fill;

            this.buttonTeacher = new System.Windows.Forms.Button();
            this.buttonTeacher.Text = "Преподаватель";
            this.buttonTeacher.Dock = System.Windows.Forms.DockStyle.Fill;

            var table = new System.Windows.Forms.TableLayoutPanel();
            table.RowStyles.Clear();
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50));
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30));
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30));
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30));
            table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50));
            table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100));

            table.Controls.Add(new System.Windows.Forms.Panel(), 0, 0);
            table.Controls.Add(singInLabel, 0, 1);
            table.Controls.Add(buttonStudent, 0, 2);
            table.Controls.Add(buttonTeacher, 0, 3);
            table.Controls.Add(new System.Windows.Forms.Panel(), 0, 4);

            table.Dock = System.Windows.Forms.DockStyle.Fill;
            Controls.Add(table);
        }
    }
}