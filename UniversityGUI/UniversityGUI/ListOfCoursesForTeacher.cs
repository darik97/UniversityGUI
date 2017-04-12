using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityGUI
{
    class ListOfCoursesForTeacher
    {
        public string[] Courses;
        string path = "C:\\Users\\Daria\\Source\\Repos\\UniversityGUI\\UniversityGUI\\UniversityGUI\\TCourses.txt";

        public ListOfCoursesForTeacher()
        {
            if (File.Exists(path))
            {
                Courses = File.ReadAllLines(path);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
    }
}
