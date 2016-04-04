using ad;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Eindopdracht
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        //int[] testArray = new int[10] { 10, 15, 1, 2, 3, 5, 18, 19, 20, 21 };
        int[] randomIntArray;
        //Queue queue = new Queue();
        public ArrayList queue;
        public ArrayList stack;
        public int stackIndex = -1;
        Timing timing = new Timing();
        public MainWindow()
        {
            InitializeComponent();
            queue = new ArrayList();
            stack = new ArrayList();
        }

        public void sort(string sortingMethod)
        {
            var timeUnit = Timing.TimeUnit.Miliseconds;
            Timing.Result<Timing.NoReturn> result = null;


            if (Int32.Parse(textBoxArraySize.Text) > 0)
            {
                int size = Int32.Parse(textBoxArraySize.Text);
                
                randomIntArray = new int[size];

                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    randomIntArray[i] = rnd.Next(size * 2);
                    textBoxOld.Text += randomIntArray[i] + " ";
                }



                //Check to see which sorting method needs to be used

                if (sortingMethod.Equals("bubblesort"))
                {
                    result = Timing.GetTime(() => Sort.BubbleSortArrayList<int>(randomIntArray), timeUnit);
                }
                if (sortingMethod.Equals("smartbubblesort"))
                {
                    result = Timing.GetTime(() => Sort.SmartBubbleSortArrayList<int>(randomIntArray), timeUnit);
                }
                if (sortingMethod.Equals("insertionsort"))
                {
                    result = Timing.GetTime(() => Sort.InsertionSortArrayList<int>(randomIntArray), timeUnit);
                }


                labelTime.Content = result.Time.ToString();


            
                textBoxArr.Clear();
                for (int i = 0; i < randomIntArray.Length; i++)
                {

                    textBoxNew.Text += randomIntArray[i] + " ";
                    textBoxArr.Text += randomIntArray[i] + " ";
         


                }
            }
        }



        private void btnBubble_Click(object sender, RoutedEventArgs e)
        {
            sort("bubblesort");
        }

        private void btnInsertion_Click(object sender, RoutedEventArgs e)
        {
            sort("smartbubblesort");

        }

        private void btnSmart_Click(object sender, RoutedEventArgs e)
        {
            sort("insertionsort");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxOld.Text = "";
            textBoxNew.Text = "";
            labelTime.Content = "";
        }

        private void btnSearchBinary_Click(object sender, RoutedEventArgs e)
        {
            int result;
            int key = int.Parse(textBoxSearch.Text);
            int max = int.Parse(textBoxArraySize.Text);
            result =  Search.binarySearch(randomIntArray, key, 0, max);
            MessageBox.Show(result.ToString()); 
        }

        private void btnSearchSequential_Click(object sender, RoutedEventArgs e)
        {
            int result;
            int key = int.Parse(textBoxSearch.Text);
            int max = int.Parse(textBoxArraySize.Text);
            result = Search.sequentialSearch(randomIntArray, key);
            MessageBox.Show(result.ToString());
        }

        private void buttonEnqueue_Click(object sender, RoutedEventArgs e)
        {
    
            ad.Queue.enqueue(textBoxQueue.Text, queue);
            updateQueue();
        }

        private void updateQueue()
        {
            textBoxShowQueue.Clear();
            for (int i = 0; i < queue.Count; i++)
            {
                textBoxShowQueue.Text += queue[i] + "\r\n";
            }
        }

        private void updateStack()
        {
            textBoxShowStack.Clear();
            for (int i = 0; i < stack.Count; i++)
            {
                textBoxShowStack.Text += stack[i] + "\r\n";
            }
        }


        private void buttonDequeue_Click(object sender, RoutedEventArgs e)
        {
            ad.Queue.dequeue(queue);
            updateQueue();
        }
        
        private void buttonPush_Click(object sender, RoutedEventArgs e)
        {
            ad.Stack.push(textBoxStack.Text, stackIndex, stack);
            updateStack();
            stackIndex++;
        }

        private void buttonPop_Click(object sender, RoutedEventArgs e)
        {
            ad.Stack.pop(stackIndex, stack);
            updateStack();
            stackIndex--;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonCreateHash_Click(object sender, RoutedEventArgs e)
        { 
        
        }
    }
}


