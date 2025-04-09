using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace InstructionAttrExample
{
    internal enum MODIFIERS { TRIM, TOUPPER, TOLOWER}
    //[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]//, Inherited =false)]
    internal class InstructionAttribute : Attribute
    {
        public MODIFIERS[] INSTRUCTIONS;
        internal InstructionAttribute(params MODIFIERS[] INSTRUCTIONS)
        {
            if (INSTRUCTIONS.Contains(MODIFIERS.TOUPPER) && INSTRUCTIONS.Contains(MODIFIERS.TOLOWER))
                throw new Exception("sigh");
            this.INSTRUCTIONS = INSTRUCTIONS;
        }
    }
}
