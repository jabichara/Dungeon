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
        /// Example: 
        /// Input: "3 1,56 1,cat" 
        /// Returns: { (StackCommand.Top, null), 
        /// (StackCommand.Push, 56), (StackCommand.Push, "cat") }
        /// </remarks>
        public List<StackOperation> Parse(string[] input)
        {
            var list = new List<string>();
            var res = new List<StackOperation>();
            foreach (var e in input)
                list.AddRange(e.Split());
            foreach(var e in list)
            {
                switch(e[0])
                {
                    case '1':
                        res.Add(new StackOperation(StackCommand.Push, e.Substring(2)));
                        break;
                    case '2':
                        res.Add(new StackOperation(StackCommand.Pop));
                        break;
                    case '3':
                        res.Add(new StackOperation(StackCommand.Top));
                        break;
                    case '4':
                        res.Add(new StackOperation(StackCommand.isEmpty));
                        break;
                    case '5':
                        res.Add(new StackOperation(StackCommand.Print));
                        break;
                    default: throw new Exception("Ты пиздабол");
                }
            }
            return res;
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
