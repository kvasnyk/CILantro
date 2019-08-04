using CILantro.Instructions;
using CILantro.Interpreting.Instances;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Interpreting.State
{
    public class CilControlState
    {
        public Stack<CilMethodState> CallStack { get; set; }

        #region Helper properties

        public CilMethodState MethodState => CallStack.Count > 0 ? CallStack.Peek() : null;

        public CilInstruction Instruction => MethodState?.Instruction;

        public CilEvaluationStack EvaluationStack => MethodState.EvaluationStack;

        public CilMethodInfo MethodInfo => MethodState.MethodInfo;

        public CilOrderedDictionary Locals => MethodState.Locals;

        public CilOrderedDictionary Arguments => MethodState.Arguments;
        
        // TODO: move it upper

        public Dictionary<string, CilClassStaticInstance> StaticInstances { get; set; }

        public int ProgramResult { get; set; }

        #endregion

        #region Constructors

        public CilControlState(CilProgram program)
        {
            CallStack = new Stack<CilMethodState>();
            CallStack.Push(new CilMethodState(program.EntryPoint, new List<CilSigArg>(), new List<IValue>(), program));

            var cctors = program.Classes
                .Select(c => c.Methods.FirstOrDefault(m => m.Name == ".cctor"))
                .Where(m => m != null)
                .ToList();

            foreach (var cctor in cctors)
            {
                CallStack.Push(new CilMethodState(cctor, new List<CilSigArg>(), new List<IValue>(), program));
            }

            StaticInstances = new Dictionary<string, CilClassStaticInstance>();
            foreach (var @class in program.Classes)
            {
                StaticInstances.Add(@class.Name.ToString(), new CilClassStaticInstance(@class, program));
            }
        }

        #endregion

        #region Helper methods

        public void MoveToNextInstruction()
        {
            MethodState.Instruction = MethodInfo.GetNextInstruction(Instruction);
        }

        public void Move(int offset, string label)
        {
            if (!string.IsNullOrEmpty(label))
                MethodState.Instruction = MethodInfo.GetInstructionByLabel(label);
            else
                MethodState.Instruction = MethodInfo.GetInstructionByOffset(Instruction, offset);
        }

        #endregion
    }
}