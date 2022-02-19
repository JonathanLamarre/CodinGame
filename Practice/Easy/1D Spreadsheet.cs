using System;
using System.Collections.Generic;

namespace Solution
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var values = new List<Value>();

            for (int i = 0; i < N; i++)
            {
                string[] inputs = Console.ReadLine()?.Split(' ') ?? throw new InvalidOperationException();
                values.Add(new Value(inputs[0], inputs[1], inputs[2]));
            }

            foreach (Value value in values)
            {
                Console.WriteLine(value.GetActualValue(values));
            }
        }

        private class Value
        {
            private readonly string m_operation;
            private readonly bool m_arg1IsRef;
            private readonly bool m_arg2IsRef;
            private readonly int m_arg1;
            private readonly int m_arg2;

            private int m_actualValue;
            private bool m_hasValue;

            public Value(string operation, string arg1, string arg2)
            {
                m_operation = operation;
                m_arg1IsRef = arg1[0] == '$';
                m_arg1 = int.Parse(arg1[0] == '$' ? arg1.Substring(1) : arg1);

                if (m_operation == "VALUE") return;

                m_arg2IsRef = arg2[0] == '$';
                m_arg2 = int.Parse(arg2[0] == '$' ? arg2.Substring(1) : arg2);
            }

            public int GetActualValue(IReadOnlyList<Value> values)
            {
                if (m_hasValue) return m_actualValue;

                int operand1 = m_arg1IsRef ? values[m_arg1].GetActualValue(values) : m_arg1;
                int operand2 = m_arg2IsRef ? values[m_arg2].GetActualValue(values) : m_arg2;

                switch (m_operation)
                {
                    case "VALUE": m_actualValue = operand1; break;
                    case "ADD": m_actualValue = operand1 + operand2; break;
                    case "SUB": m_actualValue = operand1 - operand2; break;
                    case "MULT": m_actualValue = operand1 * operand2; break;
                }

                m_hasValue = true;

                return m_actualValue;
            }
        }
    }
}