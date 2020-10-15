using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Parsers
{
    public class StackOperationsParser
    {
        /// <summary>
        /// Parse from text to stack operations.
        /// </summary>
        /// <remarks>
        /// Example: 3 1,56 1,cat convert to
        /// (StackCommand.Top, null), (StackCommand.Push, 56) etc
        /// </remarks>
        public List<StackOperation> Parse(string[] input)
        {
            throw new Exception();
        }
    }

    public class StackOperation
    { 
        public StackCommand Command { get; set; }
        public object Object { get; set; }

        public StackOperation(StackCommand command, object obj = null)
        {
            Command = command;
            Object = obj;
        }
    }

    public enum StackCommand
    {
        Push = 1,
        Pop = 2,
        Top = 3,
        isEmpty = 4,
        Print = 5
    }
}
