using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourseExercise
{
    public class Word
    {
        public string Name { get; set; }
        public int Line { get; set; }
        public int Position { get; set; }

        public Word(string name, int lineCounter, int positionCounter)
        {
            Name = name;
            Line = lineCounter;
            Position = positionCounter;
        }
        public override string ToString()
        {
            return "Word: " + Name + " Line: " + Line + " Position: " + Position;
        }

    }
}
