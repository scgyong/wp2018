using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmSharp {
    class Song {
        public string title;
        public string fileName;
        public List<Note> notes;

        public Song(string file)
        {
            notes = new List<Note>();
            try {
                StreamReader reader = new StreamReader(file);
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    string[] arr = line.Split(null);
                    if (arr.Length < 3) {
                        continue;
                    }
                    Note note = new Note();
                    note.type = Note.Type.Tap;

                    if (!int.TryParse(arr[1], out note.line)) {
                        continue;
                    }
                    if (!float.TryParse(arr[2], out note.seconds)) {
                        continue;
                    }
                    notes.Add(note);
                }
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
    }
}
