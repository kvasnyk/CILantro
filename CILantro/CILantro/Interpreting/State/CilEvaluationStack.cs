using CILantro.Interpreting.StackObjects;
using System;
using System.Collections.Generic;

namespace CILantro.Interpreting.State
{
    public class CilEvaluationStack
    {
        private readonly Stack<IStackObject> _stack;

        public CilEvaluationStack()
        {
            _stack = new Stack<IStackObject>();
        }

        public void Push(IStackObject obj)
        {
            _stack.Push(obj);
        }

        public IStackObject Pop()
        {
            return _stack.Pop();
        }

        public void Pop<T>(out T elem)
            where T : struct, IStackObject
        {
            if (_stack.Count == 0)
                throw new ArgumentException($"Cannot pop from empty evaluation stack.");

            var stackObject = _stack.Pop();
            var e = stackObject.As<T>();

            if (!e.HasValue)
                throw new ArgumentException($"Cannot pop evaluation stack value of type {nameof(T)}.");

            elem = e.Value;
        }

        public T Pop<T>()
            where T : struct, IStackObject
        {
            Pop(out T elem);
            return elem;
        }

        public void Pop<T1, T2>(out T1 elem1, out T2 elem2)
            where T1 : struct, IStackObject
            where T2 : struct, IStackObject
        {
            Pop(out elem2);
            Pop(out elem1);
        }

        public void Pop<T1, T2, T3>(out T1 elem1, out T2 elem2, out T3 elem3)
            where T1 : struct, IStackObject
            where T2 : struct, IStackObject
            where T3 : struct, IStackObject
        {
            Pop(out elem2, out elem3);
            Pop(out elem1);
        }
    }
}