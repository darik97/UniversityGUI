using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UniversityGUI
{
    class ListOfCourses
    {
        public List<string> Courses = new List<string>();
        public List<string> Grades = new List<string>();

        public ListOfCourses(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string[] temp;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        temp = line.Split(':');
                        Courses.Add(temp[0]);
                        Grades.Add(temp[1]);
                    }
                }
            }
            catch (FileNotFoundException)
            { }
        }
    }
}
