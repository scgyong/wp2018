using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmSharp {
    class Song {
        public string title;
        public string fileName;
        public float duration;
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
                if (notes.Count > 0) {
                    duration = (float)(
                        notes[notes.Count - 1].seconds + 5.0
                    );
                }
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }

        const int NOTE_WIDTH = 80;
        const int NOTE_HEIGHT = 20;
        const int PRESS_Y = 500;
        const int PIXELS_PER_SEC = 100;

        public void draw(Graphics g, double time)
        {
            foreach (Note note in notes) {
                int x = note.line * NOTE_WIDTH;
                int y = (int)(PRESS_Y - PIXELS_PER_SEC * (note.seconds - time));
                g.FillRectangle(Brushes.White, x, y, NOTE_WIDTH, NOTE_HEIGHT);
            }
        }
    }
}
