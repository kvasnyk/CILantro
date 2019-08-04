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
        private readonly CilExecutionState _executionState;

        private readonly CilProgram _program;

        private CilControlState ControlState => _executionState.ControlState;

        private CilManagedMemory ManagedMemory => _executionState.ManagedMemory;

        public InstructionTokInterpreterVisitor(CilProgram program, CilExecutionState executionState)
        {
            _executionState = executionState;

            _program = program;
        }

        protected override void VisitLoadTokenInstruction(LoadTokenInstruction instruction)
        {
            if (instruction.TypeSpec != null)
            {
                if (_program.IsExternalType(instruction.TypeSpec.ClassName))
                {
                    var type = ReflectionHelper.GetExternalType(instruction.TypeSpec.ClassName);
                    var result = new CilValueExternal(type.TypeHandle);

                    ControlState.EvaluationStack.PushValue(result);
                    ControlState.MoveToNextInstruction();
                }
                else
                {
                    var @class = _program.Classes.Single(c => c.Name.ToString() == instruction.TypeSpec.ClassName.ToString());
                    var runtimeType = @class.BuildRuntimeType(_program, ManagedMemory);
                    var runtimeHandle = runtimeType.TypeHandle;
                    var result = new CilValueExternal(runtimeHandle);

                    ControlState.EvaluationStack.PushValue(result);
                    ControlState.MoveToNextInstruction();
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
                    var runtimeType = @class.BuildRuntimeType(_program, ManagedMemory);

                    throw new System.NotImplementedException();

                    var runtimeHandle = runtimeType.TypeHandle;
                    var result = new CilValueExternal(runtimeHandle);

                    ControlState.EvaluationStack.PushValue(result);
                    ControlState.MoveToNextInstruction();
                }
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }
    }
}