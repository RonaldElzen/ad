using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ad;

namespace Eindopdracht
{
    /// <summary>
    /// Interaction logic for LinkedListWindow.xaml
    /// </summary>
    public partial class LinkedListWindow : Window
    {
        ad.LinkedList<string> linkedList = new ad.LinkedList<string>();

        public LinkedListWindow()
        {
            InitializeComponent();
            labelSize.Content = linkedList.getCount();

        }

        /// <summary>
        /// gets the header node of the linked list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetHeader_Click(object sender, RoutedEventArgs e)
        {
            LNode<string> Lnode;
            Lnode = linkedList.getHeader();
            string header = Lnode.getValue();
            MessageBox.Show(header);
        }

        /// <summary>
        /// looks if the given value is in the linked list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {
            LNode<string> lNode;
            lNode =  linkedList.find(textBoxFind.Text);
            string item = lNode.getValue();
            MessageBox.Show(item);
        }

        /// <summary>
        /// adds a new node to the list with the value of the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            linkedList.add(textBoxAdd.Text);
            updateList();
        }

        /// <summary>
        /// inserts a new node with the value of textBoxInsert after the node with value of textBoxAfter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            linkedList.insert(textBoxInsert.Text,textBoxAfter.Text);
            updateList();
        }

        /// <summary>
        /// updates the list in the listbox
        /// </summary>
        private void updateList()
        {
            string[] arr = linkedList.getList();
            listBoxList.Items.Clear();
            labelSize.Content = linkedList.getCount();
            foreach (string item in arr)
            {
               
                listBoxList.Items.Add(item);
            }
        }

        /// <summary>
        /// delete node from the linked list with the value of the textBoxDelete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            linkedList.remove(textBoxDelete.Text);
            updateList();
        }

        /// <summary>
        /// finds privious node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindPrevious_Click(object sender, RoutedEventArgs e)
        {
            LNode<string> lNode;
            lNode = linkedList.findPrevious(textBoxFindPrevious.Text);
            string item = lNode.getValue();
            MessageBox.Show(item);

        }
    }
}
