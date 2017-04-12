using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UniversityGUI
{
    class ListOfStudents
    {
        public List<string> Students = new List<string>();
        public List<float> Grades = new List<float>();
        string path = "C:\\Users\\Daria\\Source\\Repos\\UniversityGUI\\UniversityGUI\\UniversityGUI\\Students.txt";

        public ListOfStudents()
        {
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                string[] temp = new string[2];
                for (int i = 0; i < readText.Length; i++)
                {
                    temp = readText[i].Split(';');
                    Students.Add(temp[0]);
                    Grades.Add(float.Parse(temp[1]));
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void ChangeGrade(List<string> name, List<float> grade)
        {
            string[] text = new string[name.Count];
            for (int i = 0; i < name.Count; i++)
            {
                text[i] = name[i] + "; " + grade[i];
            }
            File.WriteAllLines(path, text);
        }
    }
}
