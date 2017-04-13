using System;
using System.IO;

namespace UniversityGUI
{
    class InfoList
    {
        public Tuple<string, float>[] Info;

        public InfoList(string path)
        {
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                string[] temp = new string[2];
                Info = new Tuple<string, float>[readText.Length];
                for (int i = 0; i < readText.Length; i++)
                {
                    temp = readText[i].Split(':');
                    Info[i] = Tuple.Create(temp[0], float.Parse(temp[1]));
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void ChangeGrade(int position, float newGrade, string path)
        {
            string[] text = new string[Info.Length];
            Info[position] = Tuple.Create(Info[position].Item1, newGrade);
            for (int i = 0; i < Info.Length; i++)
            {
                text[i] = Info[i].Item1.ToString() + ": " + Info[i].Item2.ToString();
            }
            File.WriteAllLines(path, text);
        }
    }
}
