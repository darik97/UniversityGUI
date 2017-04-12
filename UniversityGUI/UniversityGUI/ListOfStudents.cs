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
        public List<string> Grades = new List<string>();
        string path = "C:\\Users\\Daria\\Source\\Repos\\UniversityGUI\\UniversityGUI\\UniversityGUI\\Students.txt";

        public ListOfStudents()
        {
            try
            {
                string[] readText = File.ReadAllLines(path);
                string[] temp = new string[3];
                for (int i = 0; i < readText.Length; i++)
                {
                    temp = readText[i].Split(' ');
                    Students.Add(temp[0] + ' ' + temp[1]);
                    Grades.Add(temp[2]);
                }
            }
            catch (FileNotFoundException)
            { }
        }

        public void ChangeGrade(string newGrade, int position)
        {
            string[] readText = File.ReadAllLines(path);
            readText[position] = newGrade;
            File.WriteAllLines(path, readText);
        }
    }    
}
