using System;
using System.Collections.Generic;
using System.Linq;

namespace NotesStore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class NotesStore
    {
        private string[] validStates = new string[] { "completed", "active", "others" };
        private List<Note> notes;

        public NotesStore()
        {
            notes = new List<Note>();
        }

        public void AddNote(string state, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name cannot be empty");
            }

            if (!validStates.Contains(state))
            {
                throw new Exception($"Invalid state {state}");
            }

            notes.Add(new Note(state, name));
        }

        public List<string> GetNotes(string state)
        {
            if (!validStates.Contains(state))
            {
                throw new Exception($"Invalid state {state}");
            }

            return notes.Where(x => x.State.Equals(state)).Select(x => x.Name).ToList();
        }
    }

    public class Note
    {
        public string State { get; set; }
        public string Name { get; set; }

        public Note(string state, string name)
        {
            State = state;
            Name = name;
        }
    }
}