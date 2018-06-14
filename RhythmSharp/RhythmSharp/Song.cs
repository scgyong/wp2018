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

        public enum Judge {
            NOTHING, BAD, GOOD, PERFECT
        }
        public const double THRESHOULD_PERFECT = 0.01;
        public const double THRESHOULD_GOOD    = 0.05;
        public const double THRESHOULD_BAD     = 0.1;

        public void init()
        {
            foreach (Note note in notes) {
                note.valid = true;
            }
        }

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

        public void draw(Graphics g, double time)
        {
            foreach (Note note in notes) {
                if (!note.valid) {
                    continue;
                }
                int x = Coord.x(note.line);
                int y = Coord.y(note.seconds - time);
                g.FillRectangle(Brushes.White, x, y, Coord.NOTE_WIDTH, Coord.NOTE_HEIGHT);
            }
        }

        public Judge handleInput(int line, double time)
        {
            foreach (Note note in notes) {
                if (note.line != line) {
                    continue;
                }
                if (!note.valid) {
                    continue;
                }
                double diff = Math.Abs(note.seconds - time);
                //System.Diagnostics.Debug.Print("Diff = " + diff);
                Judge judge = Judge.NOTHING;
                if (diff <= THRESHOULD_PERFECT) {
                    judge = Judge.PERFECT;
                } else if (diff <= THRESHOULD_GOOD) {
                    judge = Judge.GOOD;
                } else if (diff <= THRESHOULD_BAD) {
                    judge = Judge.BAD;
                } else {
                    continue;
                }
                System.Diagnostics.Debug.Print(judge + " Diff = " + diff);
                note.valid = false;
                return judge;
            }
            return Judge.NOTHING;
        }
    }
}
