using ad;
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

namespace Eindopdracht
{
    /// <summary>
    /// Interaction logic for DoublyLinkedList.xaml
    /// </summary>
    public partial class DoublyLinkedList : Window
    {
        DoublyNode<string> dNode;
        ad.DoublyLinkedList<string> doublyList = new ad.DoublyLinkedList<string>();
        public DoublyLinkedList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Finds the object in the doublylinkedlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {
           
            dNode = doublyList.find(textBoxFind.Text);
            string item = dNode.getValue();
            MessageBox.Show(item);
        }

        /// <summary>
        /// finds the previous node of the current node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindPrevious_Click(object sender, RoutedEventArgs e)
        {
            
            dNode = doublyList.findPrevious(textBoxFindPrevious.Text);
            string item = dNode.getValue();
            MessageBox.Show(item);

        }

        /// <summary>
        /// adds the value of the textbox to the doublylinkedlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            doublyList.add(textBoxAdd.Text);
            updateList();
        }
        
        /// <summary>
        /// inserts a new value after the value of the second textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            doublyList.insert(textBoxInsert.Text, textBoxAfter.Text);
            updateList();
        }

        /// <summary>
        /// deletes the given value of the textbox from the doublylinkedlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            doublyList.remove(textBoxDelete.Text);
            updateList();
        }

        /// <summary>
        /// updates the list in the listbox
        /// </summary>
        private void updateList()
        {
            string[] arr = doublyList.getList();
            listBoxList.Items.Clear();
            labelSize.Content = doublyList.getCount();
            foreach (string item in arr)
            {

                listBoxList.Items.Add(item);
            }
        }

        /// <summary>
        /// finds the last node of the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindLast_Click(object sender, RoutedEventArgs e)
        {
            dNode = doublyList.findLast();
            string item = dNode.getValue();
            MessageBox.Show(item);
        }

        /// <summary>
        /// shows the doublylinkedlist node values in the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReverseList_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = doublyList.getReverseList();
            listBoxList.Items.Clear();
            labelSize.Content = doublyList.getCount();
            foreach (string item in arr)
            {

                listBoxList.Items.Add(item);
            }
        }
    }
}
