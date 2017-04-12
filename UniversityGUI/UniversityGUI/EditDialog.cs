using System.Windows.Forms;

namespace UniversityGUI
{
    class EditDialog : Form
    {
        public TextBox Grade;

        public EditDialog(string name, float grade)
        {
            Label nameLabel = new Label
            {
                Text = name,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                AutoSize = true,
                Location = new System.Drawing.Point(23, 22)
            };
            Grade = new TextBox
            {
                Text = grade.ToString(),
                Location = new System.Drawing.Point(26, 38)
            };
            Button okButton = new Button
            {
                Text = "Сохранить",
                Location = new System.Drawing.Point(166, 90),
                DialogResult = DialogResult.OK
            };
            Button cancelButton = new Button
            {
                Text = "Отмена",
                Location = new System.Drawing.Point(31, 90),
                DialogResult = DialogResult.Cancel
            };
            ClientSize = new System.Drawing.Size(270, 130);
            Controls.Add(nameLabel);
            Controls.Add(Grade);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
        }
    }
}
