using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BinaryTreeVisualizer;

namespace BTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string exeFile = Application.ExecutablePath;
            exeFile = exeFile.Substring(exeFile.LastIndexOf('\\') + 1);

            try
            {
                using (var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
        @"Software\WOW6432Node\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
        true))
                {
                    key.SetValue(exeFile, 11001, Microsoft.Win32.RegistryValueKind.DWord);
                    key.Close();
                }
            }
            catch
            {
                MessageBox.Show(@"Cannot access the registry, but the program may work.  If not, run " + exeFile + @" as Administrator or ensure registry setting Computer\HKEY_LOCAL_MACHINE\ SOFTWARE\WOW6432Node\Microsoft\ Internet Explorer\Main\ FeatureControl\FEATURE_BROWSER_EMULATION has a DWORD value for Name = " + exeFile + " with a value of 11001.  Otherwise the Web Browser features may not work.");
            }

            InitializeComponent();

            // give the BTree class objects access to Form1
            BTree.form1 = this;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // load a tree with random numbers
            BTree root = null;
            BTree node;
            Random random = new Random();

            this.richTextBox1.Clear();

            for (int i = 0; i < 10; ++i)
            {
                node = new BTree(random.Next(100), root);

                if (i == 0)
                {
                    root = node;
                }
            }

            this.richTextBox1.Text += "\n";

            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // load a tree in data-ascending order, 
            // which will cause it to be unbalanced and poor-performing
            BTree root = null;
            BTree node;

            this.richTextBox1.Clear();

            for (int i = 0; i < 10; ++i)
            {
                //BTree node = new BTree(random.Next(100), root);
                node = new BTree(i, root);

                if (i == 0)
                {
                    root = node;
                }
            }

            this.richTextBox1.Text += "\n";
            BTree.TraverseAscending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // Prime a tree to hold alphabetical information

            this.richTextBox1.Clear();

            BTree node = null;
            BTree root = null;
            
            node = new BTree("M", null);
            root = node;

            node = new BTree("F", root);
            node = new BTree("C", root);
            node = new BTree("B", root);
            node = new BTree("A", root);
            node = new BTree("E", root);
            node = new BTree("D", root);

            node = new BTree("J", root);
            node = new BTree("I", root);
            node = new BTree("H", root);
            node = new BTree("G", root);
            node = new BTree("L", root);
            node = new BTree("K", root);

            node = new BTree("P", root);
            node = new BTree("O", root);
            node = new BTree("N", root);
            node = new BTree("T", root);
            node = new BTree("S", root);
            node = new BTree("R", root);
            node = new BTree("Q", root);

            node = new BTree("W", root);
            node = new BTree("V", root);
            node = new BTree("U", root);
            node = new BTree("X", root);
            node = new BTree("Y", root);
            node = new BTree("Z", root);

            this.richTextBox1.Text += "\n";            
            BTree.TraverseAscending(root);

            this.richTextBox1.Text += "\n";
            BTree.TraverseDescending(root);

            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Exercise #1
            // insert 30 random numbers between 1 and 51

            // empty the textbox
            this.richTextBox1.Clear();

            // node references
            BTree node = null;
            BTree root = null;
            // create a new random
            Random random = new Random();
            // add 30 nodes to the tree
            for (int i = 0; i < 30; i++)
            {
                // assign the node data to a random number between 1 and 51
                node = new BTree(random.Next(1,52), root);
                // assign the first node to be the root
                if (i == 0)
                {
                    root = node;
                }
            }
            // add a newLine to seperate the any updates in the textbox
            this.richTextBox1.Text += "\n";
            // show the tree in thetextBox
            BTree.TraverseAscending(root);
            // send the tree to an external visualizer
            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            // Exercise #2
            // prime the tree for numbers between 1 and 51
            // with 7 optimally distributed data points setting isData = false 
            // then insert 30 random numbers between 1 and 51

            // empty the textbox
            this.richTextBox1.Clear();

            // node references
            BTree node = null;
            BTree root = null;
            // create a new random
            Random random = new Random();
            // assign the root
            root = new BTree(26,root);
            // set the type of data to seed
            root.isData = false;
            // assign evenly spaced seed nodes
            node = new BTree(32, root);
            node.isData = false;
            node = new BTree(39, root);
            node.isData = false;
            node = new BTree(45, root);
            node.isData = false;
            node = new BTree(20, root);
            node.isData = false;
            node = new BTree(13, root);
            node.isData = false;
            node = new BTree(7, root);
            node.isData = false;

            // add 30 nodes to the tree
            for (int i = 0; i < 30; i++)
            {
                // assign the node data to a random number between 1 and 51
                node = new BTree(random.Next(1, 52), root);
            }

            // add a newLine to seperate the any updates in the textbox
            this.richTextBox1.Text += "\n";
            // show the tree in thetextBox
            BTree.TraverseAscending(root);
            // send the tree to an external visualizer
            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            // Exercise #3
            // insert 15 random uppercase strings

            // empty the textbox
            this.richTextBox1.Clear();

            // node references
            BTree node = null;
            BTree root = null;
            // create a new random
            Random random = new Random();
            // add 15 nodes to the tree
            for (int i = 0; i < 15; i++)
            {
                // create a string to add to the 
                string sTemp = "" + (char)random.Next((int)'A', (int)'Z' + 1) + (char)random.Next((int)'A', (int)'Z' + 1) + (char)random.Next((int)'A', (int)'Z' + 1) + (char)random.Next((int)'A', (int)'Z' + 1);
                // add the string to the tree
                node = new BTree(sTemp, root);
                // assign the first node to be the root
                if (i == 0)
                {
                    root = node;
                }
            }
            // add a newLine to seperate the any updates in the textbox
            this.richTextBox1.Text += "\n";
            // show the tree in thetextBox
            BTree.TraverseAscending(root);
            // send the tree to an external visualizer
            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            // Exercise #4
            // prime the tree using the code in Button3_Click()
            // then insert the 15 random uppercase strings from Exercise #3

            // empty the textbox
            this.richTextBox1.Clear();

            // node references
            BTree node = null;
            BTree root = null;

            // assign the root to be M
            node = new BTree("M", null);
            root = node;
            // add all 26 letters to the tree
            node = new BTree("F", root);
            node = new BTree("C", root);
            node = new BTree("B", root);
            node = new BTree("A", root);
            node = new BTree("E", root);
            node = new BTree("D", root);

            node = new BTree("J", root);
            node = new BTree("I", root);
            node = new BTree("H", root);
            node = new BTree("G", root);
            node = new BTree("L", root);
            node = new BTree("K", root);

            node = new BTree("P", root);
            node = new BTree("O", root);
            node = new BTree("N", root);
            node = new BTree("T", root);
            node = new BTree("S", root);
            node = new BTree("R", root);
            node = new BTree("Q", root);

            node = new BTree("W", root);
            node = new BTree("V", root);
            node = new BTree("U", root);
            node = new BTree("X", root);
            node = new BTree("Y", root);
            node = new BTree("Z", root);
            // create a new random
            Random random = new Random();
            // add 15 nodes to the tree
            for (int i = 0; i < 15; i++)
            {
                // create a string to add to the 
                string sTemp = "" + (char)random.Next((int)'A', (int)'Z' + 1) + (char)random.Next((int)'A', (int)'Z' + 1) + (char)random.Next((int)'A', (int)'Z' + 1) + (char)random.Next((int)'A', (int)'Z' + 1);
                // add the string to the tree
                node = new BTree(sTemp, root);
            }

            // add a newLine to seperate the any updates in the textbox
            this.richTextBox1.Text += "\n";
            // show the tree in thetextBox
            BTree.TraverseAscending(root);
            // send the tree to an external visualizer
            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            // Exercise #5
            // use the code in Button3_Click to add the 26 letters to the tree
            // then remove nodes "C", "I" and "A" 
            // using this code to remove each node:
            //     // create new freestanding node for "C"
            //     nodeToDelete = new BTree("C", null);
            //     BTree.DeleteNode(nodeToDelete, root);
            // add the newline and call BTree.TraverseAscending() after each delete

            // empty the textbox
            this.richTextBox1.Clear();

            // node references
            BTree node = null;
            BTree nodeToDelete = null;
            BTree root = null;

            // assign the root to be M
            node = new BTree("M", null);
            root = node;

            // add all 26 letters to the tree
            node = new BTree("F", root);
            node = new BTree("C", root);
            node = new BTree("B", root);
            node = new BTree("A", root);
            node = new BTree("E", root);
            node = new BTree("D", root);

            node = new BTree("J", root);
            node = new BTree("I", root);
            node = new BTree("H", root);
            node = new BTree("G", root);
            node = new BTree("L", root);
            node = new BTree("K", root);

            node = new BTree("P", root);
            node = new BTree("O", root);
            node = new BTree("N", root);
            node = new BTree("T", root);
            node = new BTree("S", root);
            node = new BTree("R", root);
            node = new BTree("Q", root);

            node = new BTree("W", root);
            node = new BTree("V", root);
            node = new BTree("U", root);
            node = new BTree("X", root);
            node = new BTree("Y", root);
            node = new BTree("Z", root);

            // add a newLine to seperate the any updates in the textbox
            this.richTextBox1.Text += "\n";
            // create target data to remove
            nodeToDelete = new BTree("C", null);
            // remove the target data from the tree
            BTree.DeleteNode(nodeToDelete, root);

            // add a newLine to seperate the any updates in the textbox
            this.richTextBox1.Text += "\n";
            // create target data to remove
            nodeToDelete = new BTree("I", null);
            // remove the target data from the tree
            BTree.DeleteNode(nodeToDelete, root);

            // add a newLine to seperate the any updates in the textbox
            this.richTextBox1.Text += "\n";
            // create target data to remove
            nodeToDelete = new BTree("A", null);
            // remove the target data from the tree
            BTree.DeleteNode(nodeToDelete, root);

            // add a newLine to seperate the any updates in the textbox
            this.richTextBox1.Text += "\n";
            // show the tree in thetextBox
            BTree.TraverseAscending(root);
            // send the tree to an external visualizer
            VisualizeBinaryTree visualizeBinaryTree = new VisualizeBinaryTree(root);
        }
    }


    /// 
    ///  Our Binary Tree Class
    /// 
    public class BTree
    {
        //////////////////////////////////////////////////////////
        ///  The most important 3 fields of any Binary Search Tree
        
        // the "less than" branch off of this node
        public BTree ltChild;

        // the "greater than or equal to" branch off of this node
        public BTree gteChild;

        // the data contained in this node
        public object data;
        //////////////////////////////////////////////////////////


        // a boolean to indicate if this is actual data or seed data to prime the tree
        public bool isData;

        // internal counter which is needed by the visualizer
        public int id;

        // access to Form1 to write to the RichTextBox
        public static Form1 form1;

        // keep track of last counter to set this.id
        private static int nLastCntr;


        //////////////////////////////////////////////////////////
        // overload all operators to compare BTree nodes by int or string data
        public static bool operator ==(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data == (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data == (string)b.data);
                }
            }
            catch
            {
                returnVal = (a == (object)b);
            }

            return (returnVal);
        }

        public static bool operator !=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data != (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = ((string)a.data != (string)b.data);
                }
            }
            catch
            {
                returnVal = (a != (object)b);
            }

            return (returnVal);
        }

        public static bool operator <(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data < (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) < 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data > (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) > 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator >=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data >= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) >= 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }

        public static bool operator <=(BTree a, BTree b)
        {
            bool returnVal = false;

            try
            {
                if (a.data.GetType() == typeof(int))
                {
                    returnVal = ((int)a.data <= (int)b.data);
                }

                if (a.data.GetType() == typeof(string))
                {
                    returnVal = (((string)a.data).CompareTo((string)b.data) <= 0);
                }
            }
            catch
            {
                returnVal = false;
            }

            return (returnVal);
        }
        //////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////
        // The constructor which will add the new node to an existing tree
        // if a non-null root is passed in
        // isData defaults to true, but can be set to false if seed data is being added to prime the tree
        public BTree(object nData, BTree root, bool isData = true)
        {
            this.ltChild = null;
            this.gteChild = null;
            this.data = nData;
            this.isData = isData;

            // set internal id which is used by the visualizer
            this.id = nLastCntr;
            ++nLastCntr;

            form1.richTextBox1.Text += nData.ToString() + " ";

            // if a tree exists to add this node to
            if (root != null)
            {
                AddChildNode(this, root);
            }
        }
        //////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////
        /// Recursive AddChildNode method adds BTree nodes to an existing tree
        public static void AddChildNode(BTree newNode, BTree treeNode)
        {
            // if the new node >= the tree node (use the operator overrides)
            if(newNode >= treeNode)
            {
                // if there is not a child node greater than this tree node (ie. gteChild == null)
                if(treeNode.gteChild == null)
                {
                    // set this node's "greater than or equal to" child to this new node
                    treeNode.gteChild = newNode;
                }
                else
                {
                    // otherwise recursively add the new node to the "greater than or equal to" branch
                    AddChildNode(newNode, treeNode.gteChild);
                }
            }
            else
            {
                // the new node < this tree node
                // if there is not a child node less than this tree node (ie. ltChild == null)
                if(treeNode.ltChild == null)
                {
                    // set this node's "less than" child to this new node
                    treeNode.ltChild = newNode;
                }
                else
                {
                    // otherwise recursively add the new node to the "less than" branch
                    AddChildNode(newNode, treeNode.ltChild);
                }
            }
        }
        //////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////
        // Delete a node from a tree or branch
        public static BTree DeleteNode(BTree nodeToDelete, BTree treeNode)
        {
            // base case: we reached the end of the branch
            if (treeNode == null)
            {
                return treeNode;
            }

            // traverse the tree to find the target node
            if (nodeToDelete < treeNode)
            {
                treeNode.ltChild = DeleteNode(nodeToDelete, treeNode.ltChild);
            }
            else if (nodeToDelete > treeNode)
            {
                treeNode.gteChild = DeleteNode(nodeToDelete, treeNode.gteChild);
            }
            else
            {
                // this is the node to be deleted  

                // case #1: treeNode has no children
                // case #2: treeNode has one child
                // set treeNode to it's non-null child (if there is one)
                if (treeNode.ltChild == null)
                {
                    return treeNode.gteChild;
                }
                else if (treeNode.gteChild == null)
                {
                    return treeNode.ltChild;
                }

                // case #3: treeNode has two children
                // Get the in-order successor (smallest value  
                // in the "greater than or equal to" branch)  

                // step to the next greater value
                BTree nextValNode = treeNode.gteChild;

                // while not at the end of the branch
                while (nextValNode != null)
                {
                    // replace this "deleted" node with the next sequential data value
                    treeNode.data = nextValNode.data;

                    // walk to next lower value
                    nextValNode = nextValNode.ltChild;
                }

                // delete the in-order successor (which was copied to the "deleted" node)
                nodeToDelete.data = treeNode.data;
                DeleteNode(nodeToDelete, treeNode.gteChild);
            }

            return treeNode;
        }


        //////////////////////////////////////////////////////////
        // Print the tree in ascending order
        public static void TraverseAscending(BTree node)
        {
            if (node != null)
            {
                // handle "less than" children
                TraverseAscending(node.ltChild);

                if (node.isData)
                {
                    // handle current node
                    form1.richTextBox1.Text += " " + node.data.ToString();
                }

                // handle "greater than or equal to children"
                TraverseAscending(node.gteChild);
            }
        }


        //////////////////////////////////////////////////////////
        // Print the tree in descending order
        public static void TraverseDescending(BTree node)
        {
            // base case is node == null
            if (node != null)
            {
                TraverseDescending(node.gteChild);
                
                if (node.isData)
                {
                    form1.richTextBox1.Text += " " + node.data.ToString();
                }
                TraverseDescending(node.ltChild);
            }
        }
    }
}
