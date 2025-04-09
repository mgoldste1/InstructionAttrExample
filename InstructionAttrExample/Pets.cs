using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionAttrExample
{
    internal class Pets
    {
        public string Dog1 { get; set; }
        public string Dog2 { get; set; }
        public string Cat1 { get; set; }
        public string Cat2 { get; set; }

        [Instruction(MODIFIERS.TOUPPER, MODIFIERS.TRIM)]
        public string Snek { get; set; }
    }
}
