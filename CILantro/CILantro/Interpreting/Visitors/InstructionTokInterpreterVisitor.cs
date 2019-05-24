using CILantro.Instructions.Tok;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Visitors;
using System.Linq;
using System.Reflection;

namespace CILantro.Interpreting.Visitors
{
    public class InstructionTokInterpreterVisitor : InstructionTokVisitor
    {
        private readonly CilControlState _state;

        private readonly CilManagedMemory _managedMemory;

        private readonly CilProgram _program;

        public InstructionTokInterpreterVisitor(CilProgram program, CilControlState state, CilManagedMemory managedMemory)
        {
            _program = program;
            _state = state;
            _managedMemory = managedMemory;
        }

        protected override void VisitLoadTokenInstruction(LoadTokenInstruction instruction)
        {
            if (_program.IsExternalType(instruction.TypeSpec.ClassName))
            {
                var assembly = Assembly.Load(instruction.TypeSpec.ClassName.AssemblyName);
                var type = assembly.GetType(instruction.TypeSpec.ClassName.ClassName);
                var result = new CilValueExternal(type.TypeHandle);

                _state.EvaluationStack.PushValue(result);
                _state.MoveToNextInstruction();
            }
            else
            {
                var @class = _program.Classes.Single(c => c.Name.ToString() == instruction.TypeSpec.ClassName.ToString());
                var runtimeType = @class.BuildRuntimeType(_program, _managedMemory);
                var runtimeHandle = runtimeType.TypeHandle;
                var result = new CilValueExternal(runtimeHandle);

                _state.EvaluationStack.PushValue(result);
                _state.MoveToNextInstruction();
            }
        }
    }
}