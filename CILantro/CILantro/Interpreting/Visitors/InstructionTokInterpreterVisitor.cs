using CILantro.Instructions.Tok;
using CILantro.Interpreting.Memory;
using CILantro.Interpreting.State;
using CILantro.Interpreting.Values;
using CILantro.Structure;
using CILantro.Utils;
using CILantro.Visitors;
using System.Linq;

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
            if (instruction.TypeSpec != null)
            {
                if (_program.IsExternalType(instruction.TypeSpec.ClassName))
                {
                    var type = ReflectionHelper.GetExternalType(instruction.TypeSpec.ClassName);
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
            else if (!string.IsNullOrEmpty(instruction.FieldId))
            {
                if (_program.IsExternalType(instruction.FieldTypeSpec.ClassName))
                {
                    throw new System.NotImplementedException();
                }
                else
                {
                    var @class = _program.AllClasses.Single(c => c.Name.ToString() == instruction.FieldTypeSpec.ClassName.ToString());
                    var runtimeType = @class.BuildRuntimeType(_program, _managedMemory);

                    throw new System.NotImplementedException();

                    var runtimeHandle = runtimeType.TypeHandle;
                    var result = new CilValueExternal(runtimeHandle);

                    _state.EvaluationStack.PushValue(result);
                    _state.MoveToNextInstruction();
                }
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }
    }
}