using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scenarios.Tree
{
    /*
     * Given a binary tree, return the values of its boundary in anti-clockwise direction starting from root. Boundary includes left boundary, leaves, and right boundary in order without duplicate nodes.

Left boundary is defined as the path from root to the left-most node. Right boundary is defined as the path from root to the right-most node. If the root doesn't have left subtree or right subtree, then the root itself is left boundary or right boundary. Note this definition only applies to the input binary tree, and not applies to any subtrees.

The left-most node is defined as a leaf node you could reach when you always firstly travel to the left subtree if exists. If not, travel to the right subtree. Repeat until you reach a leaf node.

The right-most node is also defined by the same way with left and right exchanged.

Example 1
Input:
  1
   \
    2
   / \
  3   4

Ouput:
[1, 3, 4, 2]

Explanation:
The root doesn't have left subtree, so the root itself is left boundary.
The leaves are node 3 and 4.
The right boundary are node 1,2,4. Note the anti-clockwise direction means you should output reversed right boundary.
So order them in anti-clockwise without duplicates and we have [1,3,4,2].
Example 2
Input:
    ____1_____
   /          \
  2            3
 / \          / 
4   5        6   
   / \      / \
  7   8    9  10  
       
Ouput:
[1,2,4,7,8,9,10,6,3]

Explanation:
The left boundary are node 1,2,4. (4 is the left-most node according to definition)
The leaves are node 4,7,8,9,10.
The right boundary are node 1,3,6,10. (10 is the right-most node).
So order them in anti-clockwise without duplicate nodes we have [1,2,4,7,8,9,10,6,3].
     */
    class L545BoundaryofBinaryTree
    {
        /*
         * [1,
         *  2,         3,
         *  4, 5,   6,    null,
         *  ,, 7,8  ,9,10]
         * Output:[1,2,4,7,8,9,10,3]
         * Expected:[1,2,4,7,8,9,10,6,3]
         * 
         * 
         * Input:[1,4,3,null,null,2,null,5]
         * Output:[1,4,2,5,3]
         * Expected:[1,4,5,2,3]
         */
        public void Test()
        {
            var t = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(8)
                    }
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6)
                    {
                        left = new TreeNode(9),
                        right = new TreeNode(10)
                    }
                }
            };

            // [1,4,3,null,null,2,null,5]
            //var t = new TreeNode(1)
            //{
            //    left = new TreeNode(4),
            //    right = new TreeNode(3)
            //    {
            //        left = new TreeNode(2)
            //        {
            //            right = new TreeNode(5)
            //        }
            //    }
            //};

            //var t = new TreeNode(1);

            var r = this.BoundaryOfBinaryTree(t);
            Console.WriteLine(String.Join(", ", r));
            r = this.BoundaryOfBinaryTree1(t);
            Console.WriteLine(String.Join(", ", r));
        }


        /*
         * We perform a single preorder traversal of the tree, keeping tracking of the left boundary and middle leaf nodes and the right boundary 
         * nodes in the process. 
         * A single flag is used to designate the type of node during the preorder traversal. 
         * Its values are:
         *  0 - root, 
         *  1 - left boundary node, 
         *  2 - right boundary node, 
         *  3 - middle node.
         */
        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            var left = new List<int>();
            if (root == null) return left;

            var mid = new List<int>();
            var right = new List<int>();

            this.Preorder(root, left, mid, right, 0);
            left.AddRange(mid);
            left.AddRange(right);
            return left;
        }

        public void Preorder(TreeNode root, List<int> left, List<int> mid, List<int> right, int flag)
        {
            if (root == null) return;
            if (flag <= 1)
            {
                left.Add(root.val);
            }
            else if (flag == 2)
            {
                right.Insert(0, root.val);
            }
            else if (root.left == null && root.right == null)
            {
                mid.Add(root.val);
            }
            Preorder(root.left, left, mid, right, flag <= 1 ? 1 : (flag == 2 && root.right == null) ? 2 : 3);
            Preorder(root.right, left, mid, right, flag % 2 == 0 ? 2 : (flag == 1 && root.left == null) ? 1 : 3);
        }

        public IList<int> BoundaryOfBinaryTree1(TreeNode root)
        {
            var result = new List<int>();

            if (root == null) return result;
            result.Add(root.val);
            AddLefts(root.left, ref result);
            //Console.WriteLine(String.Join(", ", result));
            if (root.left != null || root.right != null)
                AddLeafs(root, ref result);
            //Console.WriteLine(String.Join(", ", result));
            AddRights(root.right, ref result);
            //Console.WriteLine(String.Join(", ", result));
            return result;
        }

        private void AddLefts(TreeNode root, ref List<int> list)
        {
            if (root == null || (root.left == null && root.right == null)) return;

            list.Add(root.val);
            if (root.left == null)
                AddLefts(root.right, ref list);
            else
                AddLefts(root.left, ref list);
        }

        private void AddLeafs(TreeNode root, ref List<int> list)
        {
            if (root == null) return;
            if (root.left == null && root.right == null)
            {
                list.Add(root.val);
            }
            else
            {
                AddLeafs(root.left, ref list);
                AddLeafs(root.right, ref list);
            }
        }

        private void AddRights(TreeNode root, ref List<int> list)
        {
            if (root == null || (root.right == null && root.left == null)) return;
            if (root.right == null)
                AddRights(root.left, ref list);
            else
                AddRights(root.right, ref list);
            list.Add(root.val);
        }
    }
}
