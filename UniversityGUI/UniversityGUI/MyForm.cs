using System.Drawing;
using System.Windows.Forms;

namespace UniversityGUI
{
    public partial class MyForm : Form
    {
        Label singInLabel;
        Button buttonStudent;
        Button buttonTeacher;
        ListOfStudents students;
        ListOfCoursesForStudent courses;
        Button exitButton = new Button
        {
            Text = "Выход",
            Dock = DockStyle.Bottom
        };

        public MyForm()
        {
            InitializeComponent();

            buttonStudent.Click += (student, arg) => SignInAsStudent();
            buttonTeacher.Click += (teacher, arg) => SignInAsTeacher();
        }

        void SignInAsStudent()
        {
            Controls.Clear();
            courses = new ListOfCoursesForStudent();
            if (courses.Courses != null)
            {
                ListForm coursesForStudent = new ListForm(2, courses.Courses.Count);
                coursesForStudent.Table.Controls
                    .Add(new Label { Text = "Курс" }, 0, 0);
                coursesForStudent.Table.Controls
                    .Add(new Label { Text = "Балл" }, 1, 0);
                for (int i = 1; i <= courses.Courses.Count; i++)
                {
                    coursesForStudent.Table.Controls
                        .Add(new Label
                        {
                            Text = courses.Courses[i - 1],
                            MaximumSize = new Size(200, 0),
                            AutoSize = true
                        }, 0, i);
                    coursesForStudent.Table.Controls
                        .Add(new Label { Text = courses.Grades[i - 1] }, 1, i);
                }
                Controls.Add(coursesForStudent.Table);
                Controls.Add(exitButton);
            }
            else
            {
                Controls.Add(new Label
                {
                    Text = "Не удалось найти файл",
                    Dock = DockStyle.Fill
                });
                Controls.Add(exitButton);
            }
            exitButton.Click += (sender, args) =>
            {
                Controls.Clear();
                InitializeComponent();

                buttonStudent.Click += (student, arg) => SignInAsStudent();
                buttonTeacher.Click += (teacher, arg) => SignInAsTeacher();
            };
        }

        public void SignInAsTeacher()
        {
            Controls.Clear();
            ListOfCoursesForTeacher courses = new ListOfCoursesForTeacher();
            if (courses.Courses != null)
            {
                ListForm coursesForTeacher = new ListForm(1, courses.Courses.Length);
                coursesForTeacher.Table.Controls
                    .Add(new Label { Text = "Список курсов" }, 0, 0);

                LinkLabel[] links = new LinkLabel[courses.Courses.Length];
                for (int i = 0; i < courses.Courses.Length; i++)
                {
                    links[i] = new LinkLabel()
                    {
                        Text = courses.Courses[i],
                        MaximumSize = new Size(200, 0),
                        AutoSize = true
                    };
                    links[i].Links[0].LinkData = courses.Courses[i];
                    coursesForTeacher.Table.Controls
                        .Add(links[i], 0, i + 1);
                    links[i].LinkClicked += (sender, e) =>
                    {
                        SingleCourse(e.Link.LinkData as string);
                    };
                }
                Controls.Add(coursesForTeacher.Table);
                Controls.Add(exitButton);
            }
            else
            {
                Controls.Add(new Label
                {
                    Text = "Не удалось найти файл",
                    Dock = DockStyle.Fill
                });
                Controls.Add(exitButton);
            }
            exitButton.Click += (sender, args) =>
            {
                Controls.Clear();
                InitializeComponent();

                buttonStudent.Click += (student, arg) => SignInAsStudent();
                buttonTeacher.Click += (teacher, arg) => SignInAsTeacher();
            };
        }


        public void SingleCourse(string course)
        {
            Controls.Clear();
            Controls.Add(new Label
            {
                Text = course,
                Dock = DockStyle.Top
            });
            ListOfStudents students = new ListOfStudents();
            if (students.Students != null)
            {
                ListForm studentsOfCourse = new ListForm(3, students.Students.Count);
                studentsOfCourse.Table.Controls
                    .Add(new Label { Text = "Студент" }, 0, 0);
                studentsOfCourse.Table.Controls
                    .Add(new Label { Text = "Балл" }, 1, 0);

                Button[] edit = new Button[students.Students.Count];
                for (int i = 0; i < students.Students.Count; i++)
                {
                    studentsOfCourse.Table.Controls
                        .Add(new Label
                        {
                            Text = students.Students[i],
                            MaximumSize = new Size(200, 0),
                            AutoSize = true
                        }, 0, i + 1);
                    studentsOfCourse.Table.Controls
                        .Add(new Label { Text = students.Grades[i].ToString(".00") }, 1, i + 1);
                    studentsOfCourse.Table.Controls
                        .Add(edit[i] = new Button { Text = "Edit" }, 2, i + 1);
                    string name = students.Students[i];
                    float grade = students.Grades[i];
                    int position = i;
                    edit[i].Click += (sender, e) =>
                    {
                        EditDialog dialog = new EditDialog(name, grade);
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            students.Grades[position] = float.Parse(dialog.Grade.Text);
                            students.ChangeGrade(students.Students, students.Grades);
                            SingleCourse(course);
                        }
                        dialog.Dispose();
                    };
                }
                Controls.Add(studentsOfCourse.Table);
                Controls.Add(exitButton);
            }
            else
            {
                Controls.Add(new Label
                {
                    Text = "Не удалось найти файл",
                    Dock = DockStyle.Fill
                });
                Controls.Add(exitButton);
            }
            exitButton.Click += (sender, args) =>
            {
                Controls.Clear();
                SignInAsTeacher();
            };
        }
    }
}

