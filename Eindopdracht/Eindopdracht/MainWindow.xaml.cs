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
         ad.LinkedList<string> Iter = new ad.LinkedList<string>();
         ad.ArrayList<string> arrList = new ad.ArrayList<string>();
         ad.Iterator<string> iterator;
         ad.Stack<String> stack = new ad.Stack<string>();
         ad.Queue<String> queue = new ad.Queue<string>();
         

        int[] randomIntArray;

        public int stackIndex = -1;
        Timing timing = new Timing();
        public MainWindow()
        {
            iterator = new ad.Iterator<string>(Iter);

            InitializeComponent();

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

            var timeUnit = Timing.TimeUnit.Miliseconds;
            Timing.Result<int> timeResult = null;

            int result;
            int key = int.Parse(textBoxSearch.Text);
            int maxSize = int.Parse(textBoxArraySize.Text);

            Timing timing = new Timing();

            result = Search.binarySearch(randomIntArray, key, 0, maxSize);
            int max = Search.highestValue(randomIntArray);
            int min = Search.lowestValue(randomIntArray);

            timeResult = Timing.GetTime(() => Search.binarySearch(randomIntArray, key, 0, maxSize), timeUnit);

            labelMin.Content = min.ToString();
            labelMax.Content = max.ToString();
            label8.Content = timeResult.Time.ToString();
            MessageBox.Show("Found at " + result.ToString() + "  Highest value: " + max + " Lowest value " + min + "\r\n At a time of " + timeResult.Time.ToString());
        }

        private void buttonSequential_Click(object sender, RoutedEventArgs e)
        {
            var timeUnit = Timing.TimeUnit.Miliseconds;
            Timing.Result<int> timeResult = null;

            int result;
            int key = int.Parse(textBoxSearch.Text);
            int maxSize = int.Parse(textBoxArraySize.Text);
            
            result = Search.sequentialSearch(randomIntArray, key);
            int max = Search.highestValue(randomIntArray);
            int min = Search.lowestValue(randomIntArray);

            timeResult = Timing.GetTime(() => Search.binarySearch(randomIntArray, key, 0, maxSize), timeUnit);


            labelMin.Content = min.ToString();
            labelMax.Content = max.ToString();
            label8.Content = timeResult.Time.ToString();
            MessageBox.Show("Found at " + result.ToString() +  "  Highest value: " + max + " Lowest value " + min + "\r\n At a time of " + timeResult.Time.ToString());


        }

        private void buttonEnqueue_Click(object sender, RoutedEventArgs e)
        {
           
            queue.enqueue(textBoxQueue.Text);
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

        private void updateStack()
        {
            ArrayList arrList;
            arrList = stack.getStack();
            textBoxShowStack.Clear();
            for (int i = 0; i < arrList.Count; i++)
            {
                textBoxShowStack.Text += arrList[i] + "\r\n";
            }
        }


        private void buttonDequeue_Click(object sender, RoutedEventArgs e)
        {
            queue.dequeue();
            updateQueue();
        }

        private void buttonPush_Click(object sender, RoutedEventArgs e)
        {
            stack.push(textBoxStack.Text, stackIndex);
            updateStack();
            stackIndex++;
        }

        private void buttonPop_Click(object sender, RoutedEventArgs e)
        {
            stack.pop(stackIndex);
            updateStack();
            stackIndex--;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonCreateHash_Click(object sender, RoutedEventArgs e)
        {

            var bucketWindow = new BucketHasWindow(int.Parse(textBoxHashSize.Text));
            bucketWindow.Show();
        }



        private void buttonLinearHash_Click(object sender, RoutedEventArgs e)
        {
            ad.LinearHash linearHash = new ad.LinearHash(int.Parse(textBoxHashSize.Text));
            var linearWindow = new LinearHashWindow(linearHash);
            linearWindow.Show();
       
        }

        private void buttonQuadraticHash_Click(object sender, RoutedEventArgs e)
        {
            ad.QuadraticHash<string> quadraticHash = new ad.QuadraticHash<string>(int.Parse(textBoxHashSize.Text));
            var quadraticWindow = new QuadraticHashWindow(quadraticHash);
            quadraticWindow.Show();
        }

        private void buttonLinkedList_Click(object sender, RoutedEventArgs e)
        {
            LinkedListWindow linkedWindow = new LinkedListWindow();
            linkedWindow.Show();
        }


       private void updateArrayList()
        {
            string[] arrayList;
            listBoxArrayList.Items.Clear();
            arrayList = arrList.getArrayList();
            labelArrayLength.Content = arrList.Length();
            foreach (string value in arrayList)
            {
                listBoxArrayList.Items.Add(value);
            }
        }

        private void buttonAddArr_Click(object sender, RoutedEventArgs e)
        {
            arrList.Add(textBoxArrayItem.Text);
            updateArrayList();

        }

        private void buttonArrRemove_Click(object sender, RoutedEventArgs e)
        {
            arrList.Remove(textBoxArrayItem.Text);
            updateArrayList();
        }

        private void buttonClearArray_Click(object sender, RoutedEventArgs e)
        {
            arrList.Clear();
            updateArrayList();
        }

        private void buttonGetItem_Click(object sender, RoutedEventArgs e)
        {
          string result =  arrList.Get(int.Parse(textBoxGetItem.Text));
            MessageBox.Show(result);
        }

        private void buttonContains_Click(object sender, RoutedEventArgs e)
        {
            int index;
            bool contains = arrList.Contains(textBoxContains.Text);
            if (contains)
            {
                index = arrList.IndexOf(textBoxContains.Text);
                MessageBox.Show(textBoxContains.Text + " Found at: " + index);
            }
            else
            {
                MessageBox.Show(textBoxContains.Text + " Not found in Array");
            }
            
        }

        private void buttonDoublyList_Click(object sender, RoutedEventArgs e)
        {
          var  doublyList = new DoublyLinkedList();
            doublyList.Show();
        }


        private void buttonNextIt_Click(object sender, RoutedEventArgs e)
        {
            ad.LNode<string> lNode = new LNode<string>();
            lNode = iterator.getCurrent();
            iterator.next();
            string val = lNode.getValue();
            labelNextIt.Content = val;
        }

        private void buttonInsertAfter_Click(object sender, RoutedEventArgs e)
        {
            iterator.insertAfter(textBoxValueIt.Text);
        }

        private void buttonInsertBefore_Click(object sender, RoutedEventArgs e)
        {
            iterator.insertBefore(textBoxValueIt.Text);
        }

        private void buttonCurrentIt_Click(object sender, RoutedEventArgs e)
        {
            ad.LNode<string> lNode = new LNode<string>();
            lNode = iterator.getCurrent();
            string val = lNode.getValue();
            MessageBox.Show(val);
        }

        private void buttonRemoveIt_Click(object sender, RoutedEventArgs e)
        {
            iterator.remove();
        }

        private void buttonClearIt_Click(object sender, RoutedEventArgs e)
        {
            iterator.clear();
        }
        
        public void updateIterator()
        {
            ad.LinkedList<string> list;
            list = iterator.getIterator();
            string[] data = list.getList();

            foreach(string val in data)
            {
                listBoxIterator.Items.Add(val);
            }
        }

        private void buttonPriorityQueue_Click(object sender, RoutedEventArgs e)
        {
            var pQueueWindow = new PriorityQueueWindow();
            pQueueWindow.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var circulairWindow = new CircularyListWindow();
            circulairWindow.Show();
        }
        
    }
}


