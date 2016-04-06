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

        private void buttonGetHeader_Click(object sender, RoutedEventArgs e)
        {
            LNode<string> Lnode;
            Lnode = linkedList.getHeader();
            string header = Lnode.getValue();
            MessageBox.Show(header);
        }

        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {
            LNode<string> lNode;
          lNode =  linkedList.find(textBoxFind.Text);
            string item = lNode.getValue();
            MessageBox.Show(item);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            linkedList.add(textBoxAdd.Text);
            updateList();
        }

        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            linkedList.insert(textBoxInsert.Text,textBoxAfter.Text);
            updateList();
        }

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

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            linkedList.remove(textBoxDelete.Text);
            updateList();
        }

        private void buttonFindPrevious_Click(object sender, RoutedEventArgs e)
        {
            LNode<string> lNode;
            lNode = linkedList.findPrevious(textBoxFindPrevious.Text);
            string item = lNode.getValue();
            MessageBox.Show(item);

        }
    }
}
