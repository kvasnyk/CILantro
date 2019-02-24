using Irony.Parsing;
using System;

namespace CILantro.Utils
{
    public abstract class AstChildrenBase
    {
        private readonly int _count;

        private readonly Type[] _types;

        protected readonly string[] _keys;

        protected object[] Children { get; private set; }

        protected AstChildrenBase(int count, string[] keys, params Type[] types)
        {
            if (count != types.Length)
                throw new ArgumentException($"{types} length does not match {count}.");
            if (count != keys.Length)
                throw new ArgumentException($"{keys} length does not match {count}.");
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            _count = count;
            _types = types;
            _keys = keys;
        }

        public bool PopulateWith(ParseTreeNode parseNode)
        {
            if (parseNode.ChildNodes.Count != _count)
                return false;

            Children = new object[_count];

            var i = 0;
            foreach (var child in parseNode.ChildNodes)
            {
                if (_types[i] == typeof(string))
                {
                    if (child.AstNode != null)
                        return false;

                    if (child.Term.Name != _keys[i])
                        return false;

                    Children[i] = _keys[i];

                    i++;
                    continue;
                }

                if (child.AstNode == null)
                    return false;

                if (child.AstNode.GetType() != _types[i])
                    return false;

                Children[i] = child.AstNode;
                i++;
            }

            return true;
        }

        protected static string[] MergeKeys(string[] keys, string key)
        {
            var result = new string[keys.Length + 1];
            Array.Copy(keys, result, keys.Length);
            result[keys.Length] = key;
            return result;
        }
    }

    public class AstChildren : AstChildrenBase
    {
        private AstChildren()
            : base(0, new string[] { })
        {
        }

        public static AstChildren Empty()
        {
            return new AstChildren();
        }

        public AstChildren1<T1> Add<T1>()
            where T1 : class
        {
            return new AstChildren1<T1>(MergeKeys(_keys, null));
        }

        public AstChildren1<string> Add(string key)
        {
            return new AstChildren1<string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren1<T1> : AstChildrenBase
        where T1 : class
    {
        public T1 Child1 => Children[0] as T1;

        public AstChildren1(string[] keys)
            : base(1, keys, typeof(T1))
        {
        }

        public AstChildren2<T1, T2> Add<T2>()
            where T2 : class
        {
            return new AstChildren2<T1, T2>(MergeKeys(_keys, null));
        }

        public AstChildren2<T1, string> Add(string key)
        {
            return new AstChildren2<T1, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren2<T1, T2> : AstChildrenBase
        where T1 : class
        where T2 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;

        public AstChildren2(string[] keys)
            : base(2, keys, typeof(T1), typeof(T2))
        {
        }

        public AstChildren3<T1, T2, T3> Add<T3>()
            where T3 : class
        {
            return new AstChildren3<T1, T2, T3>(MergeKeys(_keys, null));
        }

        public AstChildren3<T1, T2, string> Add(string key)
        {
            return new AstChildren3<T1, T2, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren3<T1, T2, T3> : AstChildrenBase
        where T1 : class
        where T2 : class
        where T3 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;
        public T3 Child3 => Children[2] as T3;

        public AstChildren3(string[] keys)
            : base(3, keys, typeof(T1), typeof(T2), typeof(T3))
        {
        }

        public AstChildren4<T1, T2, T3, T4> Add<T4>()
            where T4 : class
        {
            return new AstChildren4<T1, T2, T3, T4>(MergeKeys(_keys, null));
        }

        public AstChildren4<T1, T2, T3, string> Add(string key)
        {
            return new AstChildren4<T1, T2, T3, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren4<T1, T2, T3, T4> : AstChildrenBase
        where T1 : class
        where T2 : class
        where T3 : class
        where T4 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;
        public T3 Child3 => Children[2] as T3;
        public T4 Child4 => Children[3] as T4;

        public AstChildren4(string[] keys)
            : base(4, keys, typeof(T1), typeof(T2), typeof(T3), typeof(T4))
        {
        }

        public AstChildren5<T1, T2, T3, T4, T5> Add<T5>()
            where T5 : class
        {
            return new AstChildren5<T1, T2, T3, T4, T5>(MergeKeys(_keys, null));
        }

        public AstChildren5<T1, T2, T3, T4, string> Add(string key)
        {
            return new AstChildren5<T1, T2, T3, T4, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren5<T1, T2, T3, T4, T5> : AstChildrenBase
        where T1 : class
        where T2 : class
        where T3 : class
        where T4 : class
        where T5 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;
        public T3 Child3 => Children[2] as T3;
        public T4 Child4 => Children[3] as T4;
        public T5 Child5 => Children[4] as T5;

        public AstChildren5(string[] keys)
            : base(5, keys, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5))
        {
        }

        public AstChildren6<T1, T2, T3, T4, T5, T6> Add<T6>()
            where T6 : class
        {
            return new AstChildren6<T1, T2, T3, T4, T5, T6>(MergeKeys(_keys, null));
        }

        public AstChildren6<T1, T2, T3, T4, T5, string> Add(string key)
        {
            return new AstChildren6<T1, T2, T3, T4, T5, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren6<T1, T2, T3, T4, T5, T6> : AstChildrenBase
        where T1 : class
        where T2 : class
        where T3 : class
        where T4 : class
        where T5 : class
        where T6 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;
        public T3 Child3 => Children[2] as T3;
        public T4 Child4 => Children[3] as T4;
        public T5 Child5 => Children[4] as T5;
        public T6 Child6 => Children[5] as T6;

        public AstChildren6(string[] keys)
            : base(6, keys, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6))
        {
        }

        public AstChildren7<T1, T2, T3, T4, T5, T6, T7> Add<T7>()
            where T7 : class
        {
            return new AstChildren7<T1, T2, T3, T4, T5, T6, T7>(MergeKeys(_keys, null));
        }

        public AstChildren7<T1, T2, T3, T4, T5, T6, string> Add(string key)
        {
            return new AstChildren7<T1, T2, T3, T4, T5, T6, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren7<T1, T2, T3, T4, T5, T6, T7> : AstChildrenBase
        where T1 : class
        where T2 : class
        where T3 : class
        where T4 : class
        where T5 : class
        where T6 : class
        where T7 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;
        public T3 Child3 => Children[2] as T3;
        public T4 Child4 => Children[3] as T4;
        public T5 Child5 => Children[4] as T5;
        public T6 Child6 => Children[5] as T6;
        public T7 Child7 => Children[6] as T7;

        public AstChildren7(string[] keys)
            : base(7, keys, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7))
        {
        }

        public AstChildren8<T1, T2, T3, T4, T5, T6, T7, T8> Add<T8>()
            where T8 : class
        {
            return new AstChildren8<T1, T2, T3, T4, T5, T6, T7, T8>(MergeKeys(_keys, null));
        }

        public AstChildren8<T1, T2, T3, T4, T5, T6, T7, string> Add(string key)
        {
            return new AstChildren8<T1, T2, T3, T4, T5, T6, T7, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren8<T1, T2, T3, T4, T5, T6, T7, T8> : AstChildrenBase
        where T1 : class
        where T2 : class
        where T3 : class
        where T4 : class
        where T5 : class
        where T6 : class
        where T7 : class
        where T8 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;
        public T3 Child3 => Children[2] as T3;
        public T4 Child4 => Children[3] as T4;
        public T5 Child5 => Children[4] as T5;
        public T6 Child6 => Children[5] as T6;
        public T7 Child7 => Children[6] as T7;
        public T8 Child8 => Children[7] as T8;

        public AstChildren8(string[] keys)
            : base(8, keys, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8))
        {
        }

        public AstChildren9<T1, T2, T3, T4, T5, T6, T7, T8, T9> Add<T9>()
            where T9 : class
        {
            return new AstChildren9<T1, T2, T3, T4, T5, T6, T7, T8, T9>(MergeKeys(_keys, null));
        }

        public AstChildren9<T1, T2, T3, T4, T5, T6, T7, T8, string> Add(string key)
        {
            return new AstChildren9<T1, T2, T3, T4, T5, T6, T7, T8, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren9<T1, T2, T3, T4, T5, T6, T7, T8, T9> : AstChildrenBase
        where T1 : class
        where T2 : class
        where T3 : class
        where T4 : class
        where T5 : class
        where T6 : class
        where T7 : class
        where T8 : class
        where T9 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;
        public T3 Child3 => Children[2] as T3;
        public T4 Child4 => Children[3] as T4;
        public T5 Child5 => Children[4] as T5;
        public T6 Child6 => Children[5] as T6;
        public T7 Child7 => Children[6] as T7;
        public T8 Child8 => Children[7] as T8;
        public T9 Child9 => Children[8] as T9;

        public AstChildren9(string[] keys)
            : base(9, keys, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9))
        {
        }

        public AstChildren10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Add<T10>()
            where T10 : class
        {
            return new AstChildren10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(MergeKeys(_keys, null));
        }

        public AstChildren10<T1, T2, T3, T4, T5, T6, T7, T8, T9, string> Add(string key)
        {
            return new AstChildren10<T1, T2, T3, T4, T5, T6, T7, T8, T9, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : AstChildrenBase
        where T1 : class
        where T2 : class
        where T3 : class
        where T4 : class
        where T5 : class
        where T6 : class
        where T7 : class
        where T8 : class
        where T9 : class
        where T10 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;
        public T3 Child3 => Children[2] as T3;
        public T4 Child4 => Children[3] as T4;
        public T5 Child5 => Children[4] as T5;
        public T6 Child6 => Children[5] as T6;
        public T7 Child7 => Children[6] as T7;
        public T8 Child8 => Children[7] as T8;
        public T9 Child9 => Children[8] as T9;
        public T10 Child10 => Children[9] as T10;

        public AstChildren10(string[] keys)
            : base(10, keys, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10))
        {
        }

        public AstChildren11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Add<T11>()
            where T11 : class
        {
            return new AstChildren11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(MergeKeys(_keys, null));
        }

        public AstChildren11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, string> Add(string key)
        {
            return new AstChildren11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, string>(MergeKeys(_keys, key));
        }
    }

    public class AstChildren11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : AstChildrenBase
        where T1 : class
        where T2 : class
        where T3 : class
        where T4 : class
        where T5 : class
        where T6 : class
        where T7 : class
        where T8 : class
        where T9 : class
        where T10 : class
        where T11 : class
    {
        public T1 Child1 => Children[0] as T1;
        public T2 Child2 => Children[1] as T2;
        public T3 Child3 => Children[2] as T3;
        public T4 Child4 => Children[3] as T4;
        public T5 Child5 => Children[4] as T5;
        public T6 Child6 => Children[5] as T6;
        public T7 Child7 => Children[6] as T7;
        public T8 Child8 => Children[7] as T8;
        public T9 Child9 => Children[8] as T9;
        public T10 Child10 => Children[9] as T10;
        public T11 Child11 => Children[10] as T11;

        public AstChildren11(string[] keys)
            : base(11, keys, typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11))
        {
        }
    }
}