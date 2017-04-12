using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UniversityGUI
{
    class ListOfCoursesForStudent
    {
        public List<string> Courses = new List<string>();
        public List<string> Grades = new List<string>();
        string path = "C:\\Users\\Daria\\Source\\Repos\\UniversityGUI\\UniversityGUI\\UniversityGUI\\SCourses.txt";

        public ListOfCoursesForStudent()
        {
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                string[] temp;
                for (int i = 0; i < readText.Length; i++)
                {
                    temp = readText[i].Split(':');
                    Courses.Add(temp[0]);
                    Grades.Add(temp[1]);
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
