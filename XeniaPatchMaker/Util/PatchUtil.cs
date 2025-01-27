﻿using System.Drawing;
using System.Linq;

namespace XeniaPatchMaker.Util
{
    public static class PatchUtil
    {
        /// <summary>
        /// Condition checker.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(string s)
        {
            return (s == null || s == string.Empty) ? true : false;
        }

        /// <summary>
        /// Loads patch data back to textboxes.
        /// </summary>
        /// <param name="Placeholder"></param>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ReloadData(string Placeholder, string Start, string End, int length)
        {
            try
            {
                int x = Placeholder.LastIndexOf(Start/*"Title ID:"*/) + Start.Length + 1;
                length = Placeholder.IndexOf(End/*"Savegame ID:"*/) - x;
                string s = Placeholder.Substring(x, length);
                return string.Concat(s.Where(c => !char.IsWhiteSpace(c)));
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetTitleID(string Placeholder, string Start, string End, int length)
        {
            try
            {
                int x = Placeholder.LastIndexOf(Start) + Start.Length + 1;
                length = Placeholder.IndexOf(End) - x;
                string s = Placeholder.Substring(x, length);
                return string.Concat(s.Where(c => !char.IsWhiteSpace(c)));
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string GetHashKey(string Placeholder, string Start, string End, int length)
        {
            try
            {
                int x = Placeholder.LastIndexOf(Start) + Start.Length + 1;
                length = Placeholder.IndexOf(End);
                string s = Placeholder.Substring(x - 1, 16);
                return string.Concat(s.Where(c => !char.IsWhiteSpace(c)));
            }
            catch
            {
                return string.Empty;
            }
        }
        public static void CheckKeyword(string word, Color color, int startIndex)
        {
            string outsource = Program.MainForm.Output.Text;
            if (Program.MainForm.Output.Text.Contains(word))
            {
                int index = -1;
                int selectStart = Program.MainForm.Output.SelectionStart;

                while ((index = Program.MainForm.Output.Text.IndexOf(word, (index + 1))) != -1)
                {
                    Program.MainForm.Output.Select((index + startIndex), word.Length);
                    Program.MainForm.Output.SelectionColor = color;
                    Program.MainForm.Output.Select(selectStart, 0);
                    Program.MainForm.Output.SelectionColor = Color.White;
                }
            }
        }
    }
}
