using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesignPatternsDemo.Model
{
    public class IteratorModel : PageModel
    {
        public class Node<T>
        {
            public T Value;
            public Node<T> Left, Right;
            public Node<T> Parent;

            public Node(T value)
            {
                this.Value = value;
            }

            public Node(T value, Node<T> left, Node<T> right)
            {
                this.Value = value;
                this.Left = left;
                this.Right = right;

                left.Parent = right.Parent = this;
            }
        }

        public class BinaryTree<T>
        {
            private Node<T> root;

            public BinaryTree(Node<T> root)
            {
                this.root = root;
            }

            public IEnumerable<Node<T>> InOrder
            {
                get{
                    IEnumerable<Node<T>> Traverse(Node<T> curr)
                    {
                        if(curr.Left != null)
                        {
                            foreach(var left in Traverse(curr.Left))
                            {
                                yield return left;
                            }
                        }
                        yield return curr;
                        if (curr.Right != null)
                        {
                            foreach (var right in Traverse(curr.Right))
                            {
                                yield return right;
                            }
                        }
                    }

                    foreach (var node in Traverse(root))
                    {
                        yield return node;
                    }
                }
            }

            public IEnumerable<Node<T>> PreOrder
            {
                get
                {
                    IEnumerable<Node<T>> Traverse(Node<T> curr)
                    {
                        yield return curr;

                        if (curr.Left != null)
                        {
                            foreach (var left in Traverse(curr.Left))
                            {
                                yield return left;
                            }
                        }
                        
                        if (curr.Right != null)
                        {
                            foreach (var right in Traverse(curr.Right))
                            {
                                yield return right;
                            }
                        }
                    }

                    foreach (var node in Traverse(root))
                    {
                        yield return node;
                    }
                }
            }

            /*public IEnumerable<Node<T>> NaturalInOrder
            {
                get
                {
                    IEnumerable<Node<T>> TraverseInOrder(Node<T> current)
                    {
                        if (current.Left != null)
                        {
                            foreach (var left in TraverseInOrder(current.Left))
                                yield return left;
                        }
                        yield return current;
                        if (current.Right != null)
                        {
                            foreach (var right in TraverseInOrder(current.Right))
                                yield return right;
                        }
                    }
                    foreach (var node in TraverseInOrder(root))
                        yield return node;
                }
            }*/
        }

    }
}
