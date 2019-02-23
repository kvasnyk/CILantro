using Irony.Parsing;
using System.Collections.Generic;
using System.Linq;

namespace CILantro.Extensions
{
    public static class ParseTreeNodeExtensions
    {
        public static TAstNode FindChild<TAstNode>(this ParseTreeNode parseNode)
            where TAstNode : class
        {
            return parseNode.ChildNodes.FirstOrDefault(cn => cn.AstNode is TAstNode)?.AstNode as TAstNode;
        }

        public static List<TAstNode> FindChildrenList<TAstNode>(this ParseTreeNode parseNode)
            where TAstNode : class
        {
            return parseNode.ChildNodes.Where(cn => cn.AstNode is TAstNode).Select(cn => cn.AstNode as TAstNode).ToList();
        }

        public static TAstNode[] FindChildrenArray<TAstNode>(this ParseTreeNode parseNode)
            where TAstNode : class
        {
            return parseNode.ChildNodes.Where(cn => cn.AstNode is TAstNode).Select(cn => cn.AstNode as TAstNode).ToArray();
        }

        public static bool HasKeyChild(this ParseTreeNode parseNode, string key)
        {
            return parseNode.ChildNodes.Any(cn => cn.AstNode == null && cn.Term.Name == key);
        }
    }
}