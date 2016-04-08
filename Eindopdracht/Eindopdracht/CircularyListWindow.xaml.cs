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
    /// Interaction logic for CircularyListWindow.xaml
    /// </summary>
    public partial class CircularyListWindow : Window
    {
        ad.CircularyLinkedList<string> circularyList = new ad.CircularyLinkedList<string>();
        
        public CircularyListWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When button is clicked, it should go find the value of the textBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFind_Click(object sender, RoutedEventArgs e)
        {
            LNode<string> lNode;
            lNode = circularyList.find(textBoxFind.Text);
            string item = lNode.getValue();
            MessageBox.Show(item);
        }

        /// <summary>
        /// When button is clicked, it adds the value of the textBox to the CircularyList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            circularyList.add(textBoxAdd.Text);
            updateList();
        }

        /// <summary>
        /// When button is clicked, the listbox is updated with new values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateList()
        {
            string[] arr = circularyList.getList();
            listBoxList.Items.Clear();
            labelSize.Content = circularyList.getCount();
            foreach (string item in arr)
            {

                listBoxList.Items.Add(item);
            }
        }

        /// <summary>
        /// finds previous node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindPrevious_Click(object sender, RoutedEventArgs e)
        {
            LNode<string> lNode;
            lNode = circularyList.findPrevious(textBoxFindPrevious.Text);
            string item = lNode.getValue();
            MessageBox.Show(item);

        }

        /// <summary>
        /// When button is clicked, it deletes the value of the textBox from the CircularyList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            circularyList.remove(textBoxDelete.Text);
            updateList();
        }

        /// <summary>
        /// Clears the CirclurayList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            circularyList.makeEmpty();
        }

        /// <summary>
        /// inserts value from textbox after the value of the second textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsert_Click(object sender, RoutedEventArgs e)
        {
            circularyList.insert(textBoxInsert.Text, textBoxAfter.Text);
            updateList();
        }
    }
}
