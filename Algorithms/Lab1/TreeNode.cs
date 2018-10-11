using System;
using System.Collections.Generic;

namespace Algorithms.Lab1
{
    public class TreeNode
    {
        public Student Student { get; private set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Parent { get; set; }

        public IEnumerable<TreeNode> Across(TreeNode node, Func<Student, bool> condition)
        {
            var queue = new Queue<TreeNode>();
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                if (queue.Peek().Left != null)
                {
                    queue.Enqueue(queue.Peek().Left);
                }

                if (queue.Peek().Right != null)
                {
                    queue.Enqueue(queue.Peek().Right);
                }

                var dequeue = queue.Dequeue();
                if (condition(dequeue.Student))
                    yield return dequeue;
            }
        }
        
        public void Insert(Student student)
        {
            if (student == null)
                return;
            
            if(Student == null)
                Student = student;
            
            if(Student.Card == student.Card)
                return;
            
            if (Student.Card > student.Card)
            {
                if (Left == null) Left = new TreeNode();
                Insert(student, Left, this);
            }
            else
            {
                if (Right == null) Right = new TreeNode();
                Insert(student, Right, this);
            }
        }

        private void Insert(Student student, TreeNode node, TreeNode parent)
        {
            if (node.Student == null || node.Student.Card == student.Card)
            {
                node.Student = student;
                node.Parent = parent;
                return;
            }

            if (node.Student.Card > student.Card)
            {
                if (node.Left == null) node.Left = new TreeNode();
                Insert(student, node.Left, node);
            }
            else
            {
                if (node.Right == null) node.Right = new TreeNode();
                Insert(student, node.Right, node);
            }
        }

        public void Remove(TreeNode node)
        {
            if (node == null) return;
            var me = MeForParent(node);
            if (node.Left == null && node.Right == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = null;
                }
                else
                {
                    node.Parent.Right = null;
                }
                return;
            }

            if (node.Left == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = node.Right;
                }
                else
                {
                    node.Parent.Right = node.Right;
                }

                node.Right.Parent = node.Parent;
                return;
            }

            if (node.Right == null)
            {
                if (me == BinSide.Left)
                {
                    node.Parent.Left = node.Left;
                }
                else
                {
                    node.Parent.Right = node.Left;
                }

                node.Left.Parent = node.Parent;
                return;
            }

            if (me == BinSide.Left)
            {
                node.Parent.Left = node.Right;
            }

            if (me == BinSide.Right)
            {
                node.Parent.Right = node.Right;
            }

            if (me == null)
            {
                var tmpLeft = node.Left;
                var tmpRightLeft = node.Right.Left;
                var tmpRightRight = node.Right.Right;
                node.Student = node.Right.Student;
                node.Right = tmpRightRight;
                node.Left = tmpRightLeft;
                Insert(tmpLeft.Student, node, node);
            }
            else
            {
                node.Right.Parent = node.Parent;
                Insert(node.Left.Student, node.Right, node.Right);
            }
        }

        private BinSide? MeForParent(TreeNode node)
        {
            if (node.Parent == null) return null;
            if (node.Parent.Left == node) return BinSide.Left;
            if (node.Parent.Right == node) return BinSide.Right;
            return null;
        }
    }
}