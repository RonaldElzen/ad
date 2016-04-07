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

        private void buttonDequeue_Click(object sender, RoutedEventArgs e)
        {

            queue.dequeue();
            updateQueue();
        }

        private void buttonEnqueue_Click(object sender, RoutedEventArgs e)
        {

            queue.enqueue(int.Parse(textBoxPriority.Text),textBoxQueue.Text);
            updateQueue();
        }

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

        private void textBoxQueue_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
