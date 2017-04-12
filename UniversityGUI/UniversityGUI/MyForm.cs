using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UniversityGUI
{
    public partial class MyForm : Form
    {
        Label singInLabel;
        Button buttonStudent;
        Button buttonTeacher;
        TableLayoutPanel studentsTable;
        ListBox studentsList;
        ListBox gradesListT;
        ListBox edit;
        ListOfStudents students;
        ListOfCourses courses;

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
            courses = new ListOfCourses("C:\\Users\\Daria\\Source\\Repos\\UniversityGUI\\UniversityGUI\\UniversityGUI\\SCourses.txt");
            if (courses.Courses != null)
            {
                ListForm studentCourses = new ListForm(2, courses.Courses.Count);
                studentCourses.Table.Controls
                    .Add(new Label { Text = "Курс" }, 0, 0);
                studentCourses.Table.Controls
                    .Add(new Label { Text = "Балл" }, 1, 0);
                for (int i = 1; i <= courses.Courses.Count; i++)
                {
                    studentCourses.Table.Controls
                        .Add(new Label
                        {
                            Text = courses.Courses[i - 1],
                            MaximumSize = new Size(200, 0),
                            AutoSize = true
                        }, 0, i);
                    studentCourses.Table.Controls
                        .Add(new Label { Text = courses.Grades[i - 1] }, 1, i);
                }
                Controls.Add(studentCourses.Table);
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
            ListOfCourses courses = new ListOfCourses("C:\\Users\\Daria\\Source\\Repos\\UniversityGUI\\UniversityGUI\\UniversityGUI\\SCourses.txt");
            if (courses.Courses != null)
            {
                ListForm teacherCourses = new ListForm(1, courses.Courses.Count);
                teacherCourses.Table.Controls
                    .Add(new Label { Text = "Список курсов" }, 0, 0);

                LinkLabel[] links = new LinkLabel[courses.Courses.Count];
                for (int i = 0; i < courses.Courses.Count; i++)
                {
                    links[i] = new LinkLabel()
                    {
                        Text = courses.Courses[i],
                        MaximumSize = new Size(200, 0),
                        AutoSize = true
                    };
                    links[i].Links[0].LinkData = courses.Courses[i];
                    teacherCourses.Table.Controls
                        .Add(links[i], 0, i + 1);
                    links[i].LinkClicked += (sender, e) =>
                    {
                        string s = e.Link.LinkData as string;
                        TeacherCourse(s);
                    };
                }
                Controls.Add(teacherCourses.Table);
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


        public void TeacherCourse(string course)
        {
            Controls.Clear();
            Controls.Add(new Label
            {
                Text = course,
                Dock = DockStyle.Top
            });
            ListOfStudents studentsL = new ListOfStudents();
            if (studentsL.Students != null)
            {
                ListForm studentsOfCourse = new ListForm(3, studentsL.Students.Count);
                studentsOfCourse.Table.Controls
                    .Add(new Label { Text = "Студент" }, 0, 0);
                studentsOfCourse.Table.Controls
                    .Add(new Label { Text = "Балл" }, 1, 0);

                Button[] edit = new Button[studentsL.Students.Count];
                for (int i = 0; i < studentsL.Students.Count; i++)
                {
                    studentsOfCourse.Table.Controls
                        .Add(new Label
                        {
                            Text = studentsL.Students[i],
                            MaximumSize = new Size(200, 0),
                            AutoSize = true
                        }, 0, i + 1);
                    studentsOfCourse.Table.Controls
                        .Add(new Label { Text = studentsL.Grades[i] }, 1, i + 1);
                    studentsOfCourse.Table.Controls
                        .Add(edit[i] = new Button { Text = "Edit" }, 2, i + 1);
                    ButtonPressedEventArgs args = new ButtonPressedEventArgs();
                    args.Name = studentsL.Students[i];
                    args.Grade = studentsL.Grades[i];
                    args.Position = i;
                    //edit[i].Click += OnButtonPressed(this, args);
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

        public void EditGrages(ButtonPressedEventArgs student)
        {
            string newGrade;
            ListOfStudents list = new ListOfStudents();
            EditDialog dialog = new EditDialog(student.Name, student.Grade);

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                newGrade = dialog.Grade.Text;
                list.ChangeGrade(newGrade, student.Position);
            }
            dialog.Dispose();
        }


        private EventHandler OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (ButtonPressed != null)
            {
                string name = e.Name;
                SignInAsTeacher();
            }
            throw new NotImplementedException();
        }

        protected virtual void OnButtonPressed(ButtonPressedEventArgs e)
        {
            ButtonPressed?.Invoke(this, e);
        }

        public event EventHandler<ButtonPressedEventArgs> ButtonPressed;
        
    }
}

