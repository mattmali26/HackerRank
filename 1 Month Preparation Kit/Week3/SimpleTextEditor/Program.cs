using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stringBuilder = new StringBuilder();

            var textEditor = new TextEditor();
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int i = 0; i < q; i++)
            {
                var operation = Console.ReadLine().TrimEnd().Split(' ').ToList();
                switch (operation[0])
                {
                    case "1":
                        textEditor.Append(operation[1]);
                        break;

                    case "2":
                        textEditor.Delete(Convert.ToInt32(operation[1]));
                        break;

                    case "3":
                        stringBuilder.Append(textEditor.Print(Convert.ToInt32(operation[1])) + "\n");
                        break;

                    case "4":
                        textEditor.Undo();
                        break;
                }
            }

            Console.WriteLine(stringBuilder);

            Console.ReadLine();
        }
    }

    internal class TextEditor
    {
        private string text;
        private Stack<string> history;

        public TextEditor()
        {
            text = string.Empty;
            history = new Stack<string>();
            history.Push(text);
        }

        public void Append(string append)
        {
            text += append;
            history.Push(text);
        }

        public void Delete(int charNum)
        {
            if (charNum > text.Length)
            {
                text = string.Empty;
            }
            else
            {
                text = text.Substring(0, text.Length - charNum);
            }
            history.Push(text);
        }

        public char Print(int index)
        {
            return text[index - 1];
            //if (index <= text.Length)
            //{
            //    return text[index - 1];
            //}
        }

        public void Undo()
        {
            history.Pop();
            text = history.Peek();
        }
    }
}