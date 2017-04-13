using System.IO;

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
