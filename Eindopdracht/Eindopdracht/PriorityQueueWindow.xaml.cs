using System;
using System.Collections;
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
    /// Interaction logic for PriorityQueueWindow.xaml
    /// </summary>
    public partial class PriorityQueueWindow : Window
    {
        ad.PriorityQueue<String> queue = new ad.PriorityQueue<string>();
        public PriorityQueueWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// removes item with highest priority from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDequeue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                queue.dequeue();
                updateQueue();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("No items in queue");
            }
        }

        /// <summary>
        /// removes item with lowest priority from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnqueue_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxPriority.Text != "" && textBoxQueue.Text != "")
            {
                queue.enqueue(int.Parse(textBoxPriority.Text), textBoxQueue.Text);
                updateQueue();
            }
        }

        /// <summary>
        /// updates the textbox to the new priority queue
        /// </summary>
        private void updateQueue()
        {
            ArrayList arrList;
            arrList = queue.getQueue();

            textBoxShowQueue.Clear();
            for (int i = 0; i < arrList.Count; i++)
            {
                textBoxShowQueue.Text += arrList[i] + "\r\n";
            }
        }
    }
}
