using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmSharp {
    class Note {
        public enum Type {
            Tap, Long, Slide, Flick
        };
        public Type type;
        public int line; // 1=s,2=d,3=f,4=j,5=k,6=l
        public float seconds; 
    }
}
