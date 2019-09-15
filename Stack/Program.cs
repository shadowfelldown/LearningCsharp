using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack
    {
        private IList<Object> stackList;
        public Stack()
        {
            stackList = new List<Object>();
        }
        public void Push(object obj)
        {
            try
            {
                if (obj == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    stackList.Add(obj);
                    Console.WriteLine("Pushed {0} to the stack.", obj.ToString());
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("ERROR: cannot push null value to the stack.");
                Program.PromptContinue();
            }
        }
        public void Push(object obj, bool logAfter)
        {
                if (logAfter == true)
                {
                    Push(obj);
                Console.WriteLine("===============");
                Console.WriteLine(getStackString());
                }
                else
                {
                    Push(obj);
                }
        }
        public Object Pop()
        {
            try
            {
                 var returnedObj = new Object();
                var stacklength = stackList.Count()-1;
                if (stacklength < 0)
                {
                    throw new ArgumentOutOfRangeException("stacklength", stacklength as Object, "Stack is empty, you must Push one or more items to the stack before popping.");
                }
                else
                {
                    returnedObj = stackList[stacklength];
                    stackList.RemoveAt(stacklength);
                    return returnedObj;
                }
            }
            catch (ArgumentOutOfRangeException e) when (e.ParamName == "stacklength")
            {
                Console.WriteLine("ERROR: Popping Failed. Index " + e.ActualValue + "does not contain an object");
                Console.WriteLine("The stack is empty, you must Push one or more items to the stack before popping.");
                Program.PromptContinue();
                return "";

            }
        }
        public Object Pop(bool logAfter)
        {
            var original = Pop();
            StringBuilder sb = new StringBuilder(original.ToString());
            if (logAfter == true)
            {
                sb.Append("\n ===============\n");
                sb.Append(getStackString());
                return sb;
            }
                else
                {
                return original;
                }
        }
        public void Clear()
        {

            stackList.Clear();
        }
        public String getStackString()
        {
            StringBuilder sb = new StringBuilder("Current contents of the stack Format: [(Type1) Value1,]:\n");
            int totIndex = stackList.Count() - 1;
            if (totIndex >= 0)
            {
                for (int i = totIndex; i >= 0; i--)
                {
                    if (i == totIndex)
                    {
                        sb.AppendFormat("[({0}) {1}", stackList[i].GetType().Name, stackList[i].ToString());
                    }
                    else
                    {
                        sb.AppendFormat(", ({0}) {1}", stackList[i].GetType().Name, stackList[i].ToString());
                    }
                }
                sb.AppendFormat(" ]\nThere are currently {0} Total items", stackList.Count());
            }
            else
            {
                sb.Append("The Stacklist is empty.");
            }
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3,true);
            PromptContinue();
            stack.Push(null);
            Console.WriteLine(stack.getStackString());
            PromptContinue(true);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop(true));
            PromptContinue();
        }
        public static void PromptContinue(bool clearOnExit = false)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            if (clearOnExit)
            {
                Console.Clear();
            }
        }
    }
}
