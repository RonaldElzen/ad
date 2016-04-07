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

        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {
           
            dNode = doublyList.find(textBoxFind.Text);
            string item = dNode.getValue();
            MessageBox.Show(item);
        }

        private void buttonFindPrevious_Click(object sender, RoutedEventArgs e)
        {
            
            dNode = doublyList.findPrevious(textBoxFindPrevious.Text);
            string item = dNode.getValue();
            MessageBox.Show(item);

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            doublyList.add(textBoxAdd.Text);
            updateList();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            doublyList.insert(textBoxInsert.Text, textBoxAfter.Text);
            updateList();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            doublyList.remove(textBoxDelete.Text);
            updateList();
        }


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

        private void buttonFindLast_Click(object sender, RoutedEventArgs e)
        {
            dNode = doublyList.findLast();
            string item = dNode.getValue();
            MessageBox.Show(item);
        }

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
