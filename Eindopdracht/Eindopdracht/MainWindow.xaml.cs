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
        ad.BinarySearchTree<String> bst = new ad.BinarySearchTree<String>();

        int[] randomIntArray;

        public int stackIndex = -1;
        Timing timing = new Timing();

        public MainWindow()
        {
            iterator = new ad.Iterator<string>(Iter);

            InitializeComponent();

        }
        
        /// <summary>
        /// Sorts an int array
        /// </summary>
        /// <param name="sortingMethod"></param>
        public void sort(string sortingMethod)
        {
            // creating new Timing
            var timeUnit = Timing.TimeUnit.Miliseconds;
            Timing.Result<Timing.NoReturn> result = null;

            if (textBoxArraySize.Text != "" && Int32.Parse(textBoxArraySize.Text) > 0)
            {
                int size = Int32.Parse(textBoxArraySize.Text);

                randomIntArray = new int[size];

                // creating new randomintarray. Random ints in this array
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


        /// <summary>
        /// metod to select right sorting method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBubble_Click(object sender, RoutedEventArgs e)
        {
            sort("bubblesort");
        }

        /// <summary>
        /// metod to select right sorting method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertion_Click(object sender, RoutedEventArgs e)
        {
            sort("smartbubblesort");

        }

        /// <summary>
        /// metod to select right sorting method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSmart_Click(object sender, RoutedEventArgs e)
        {
            sort("insertionsort");
        }

        /// <summary>
        /// metod to clear textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxOld.Text = "";
            textBoxNew.Text = "";
            labelTime.Content = "";
        }

        /// <summary>
        /// method to run binary search.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchBinary_Click(object sender, RoutedEventArgs e)
        {
            //check if the textboxes arent empty
            if(textBoxSearch.Text != "" && textBoxArraySize.Text != "")
            {
                // making new timing
                var timeUnit = Timing.TimeUnit.Miliseconds;
                Timing.Result<int> timeResult = null;

                int result;
                // getting values from textboxes
                int key = int.Parse(textBoxSearch.Text);
                int maxSize = int.Parse(textBoxArraySize.Text);

                // getting the results to show in the messagebox
                result = Search.binarySearch(randomIntArray, key, 0, maxSize);
                int max = Search.highestValue(randomIntArray);
                int min = Search.lowestValue(randomIntArray);

                // Timing
                timeResult = Timing.GetTime(() => Search.binarySearch(randomIntArray, key, 0, maxSize), timeUnit);

                labelMin.Content = min.ToString();
                labelMax.Content = max.ToString();
                label8.Content = timeResult.Time.ToString();

                MessageBox.Show("Found at " + result.ToString() + "  Highest value: " + max + " Lowest value " + min + "\r\n At a time of " + timeResult.Time.ToString());
            }
        }

        /// <summary>
        /// Method to run sequential search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSequential_Click(object sender, RoutedEventArgs e)
        {
            // check if the texboxes arent empty
            if (textBoxSearch.Text != "" && textBoxArraySize.Text != "")
            {
                var timeUnit = Timing.TimeUnit.Miliseconds;
                Timing.Result<int> timeResult = null;

                // getting values from textboxes
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

                MessageBox.Show("Found at " + result.ToString() + "  Highest value: " + max + " Lowest value " + min + "\r\n At a time of " + timeResult.Time.ToString());
            }
        }

        /// <summary>
        /// enqueue method for putting objects in Queue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnqueue_Click(object sender, RoutedEventArgs e)
        {
            queue.enqueue(textBoxQueue.Text);
            updateQueue();
        }

        /// <summary>
        /// update method for updating Queue in textbox
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

        /// <summary>
        /// Method to update Stack in the textbox
        /// </summary>
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

        /// <summary>
        /// Method to remove Objects from the queue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDequeue_Click(object sender, RoutedEventArgs e)
        {
            queue.dequeue();
            updateQueue();
        }

        /// <summary>
        /// Method to put an Object in Stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPush_Click(object sender, RoutedEventArgs e)
        {
            stack.push(textBoxStack.Text, stackIndex);
            updateStack();
            stackIndex++;
        }

        /// <summary>
        /// Method to remove an Object from Stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPop_Click(object sender, RoutedEventArgs e)
        {
            stack.pop(stackIndex);
            updateStack();
            stackIndex--;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Creates a new window for BucketHash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateHash_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int intSize = int.Parse(textBoxHashSize.Text);
                if (intSize > 0)
                {
                    var bucketWindow = new BucketHasWindow(intSize);
                    bucketWindow.Show();
                }
                else
                {
                    MessageBox.Show("Arraysize must be greater than zero.");
                }
            }
            catch
            {
                MessageBox.Show("input invalid");
            }
        }
        
        /// <summary>
        /// Creates a new window for LinearHash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLinearHash_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int intSize = int.Parse(textBoxHashSize.Text);
                if (intSize > 0)
                {
                    ad.LinearHash<string> linearHash = new ad.LinearHash<string>(int.Parse(textBoxHashSize.Text));
                    var linearWindow = new LinearHashWindow(linearHash);
                    linearWindow.Show();
                }
                else
                {
                    MessageBox.Show("Arraysize must be greater than zero.");
                }
            }
            catch
            {
                MessageBox.Show("input invalid");
            }
       
        }

        /// <summary>
        /// Creates a new window for QuadraticHash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuadraticHash_Click(object sender, RoutedEventArgs e)
        {
            ad.QuadraticHash<string> quadraticHash = new ad.QuadraticHash<string>(int.Parse(textBoxHashSize.Text));
            var quadraticWindow = new QuadraticHashWindow(quadraticHash);
            quadraticWindow.Show();
        }

        /// <summary>
        /// Creates a new window for LinkedList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLinkedList_Click(object sender, RoutedEventArgs e)
        {
            LinkedListWindow linkedWindow = new LinkedListWindow();
            linkedWindow.Show();
        }

        /// <summary>
        /// Update the new ArrayList
        /// </summary>
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

        /// <summary>
        /// Method to add item to ArrayList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddArr_Click(object sender, RoutedEventArgs e)
        {
            arrList.Add(textBoxArrayItem.Text);
            updateArrayList();
        }

        /// <summary>
        /// Method to remove from ArrayList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonArrRemove_Click(object sender, RoutedEventArgs e)
        {
            arrList.Remove(textBoxArrayItem.Text);
            updateArrayList();
        }

        /// <summary>
        /// Clearing the ArrayList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearArray_Click(object sender, RoutedEventArgs e)
        {
            arrList.Clear();
            updateArrayList();
        }

        /// <summary>
        /// Get the item from the ArrayList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string result = arrList.Get(int.Parse(textBoxGetItem.Text));
                MessageBox.Show(result);
            }
            catch (FormatException)
            {
                MessageBox.Show("No item to get");
            }
        }

        /// <summary>
        /// Check if a item exists in the ArrayList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// creating new window for doublylinkedlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDoublyList_Click(object sender, RoutedEventArgs e)
        {
          var  doublyList = new DoublyLinkedList();
            doublyList.Show();
        }

        /// <summary>
        /// method for iterator: goes to the next node in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNextIt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ad.LNode<string> lNode = new LNode<string>();
                lNode = iterator.getCurrent();
                iterator.next();
                string val = lNode.getValue();
                labelNextIt.Content = val;
            }
            catch(NullReferenceException)
            {

            }
            
        }

        /// <summary>
        /// inserts node after the current node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsertAfter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                iterator.insertAfter(textBoxValueIt.Text);
            }
            catch (NullReferenceException) { };
        }

        /// <summary>
        /// inserts node befoer the current node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsertBefore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                iterator.insertBefore(textBoxValueIt.Text);
            }
            catch (NullReferenceException) { };
        }

        /// <summary>
        /// method to show the current node.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCurrentIt_Click(object sender, RoutedEventArgs e)
        {
            ad.LNode<string> lNode = new LNode<string>();
            lNode = iterator.getCurrent();
            string val = lNode.getValue();
            MessageBox.Show(val);
        }

        /// <summary>
        /// Removes current node from the list in the iterator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveIt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                iterator.remove();
            }
            catch(NullReferenceException)
            {

            }
        }

        /// <summary>
        /// clears the list in the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearIt_Click(object sender, RoutedEventArgs e)
        {
            iterator.clear();
        }
        
        /// <summary>
        /// displays the updated iterator in the textbox
        /// </summary>
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

        /// <summary>
        /// new window for priority queue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPriorityQueue_Click(object sender, RoutedEventArgs e)
        {
            var pQueueWindow = new PriorityQueueWindow();
            pQueueWindow.Show();
        }

        /// <summary>
        /// new window for circulairlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var circulairWindow = new CircularyListWindow();
            circulairWindow.Show();
        }

        /// <summary>
        /// adds a new node to the binary search tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            bst.add(textBoxAdd.Text);
        }

        /// <summary>
        /// MessageBox pops up to get the value of the root node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetRoot_Click(object sender, RoutedEventArgs e)
        {
            // try to get the value of the rootnode
            try
            {
                MessageBox.Show(bst.getRoot().getValue().ToString());
            }
            // catches if rootnode is null
            catch (NullReferenceException)
            {
                MessageBox.Show("Nothing in array");
            }
        }

        /// <summary>
        /// delete from the binary search tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            bst.Delete(textBoxDelete.Text);
        }

        /// <summary>
        /// Checks if the binary search tree contains the value that was given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            var timeUnit = Timing.TimeUnit.Miliseconds;
            Timing.Result<bool> timeResult = null;
            String key = textBoxS.Text;

            timeResult = Timing.GetTime(() => bst.search(key), timeUnit);
            MessageBox.Show(bst.search(textBoxS.Text).ToString() + "\r\n timeResult: " + timeResult.Time.ToString());
        }

        /// <summary>
        /// Sets all node values to the listbox in order of the tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInOrder_Click(object sender, RoutedEventArgs e)
        {
            bstListBox.Items.Clear();
            String[] arr = bst.getInOrder();
            for(int i = 0; i < arr.Length; i++)
            {
                bstListBox.Items.Add(arr[i]);
            }
        }

        /// <summary>
        /// Sets all node values to the listbox pre order of the tree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPreOrder_Click(object sender, RoutedEventArgs e)
        {
            bstListBox.Items.Clear();
            String[] arr = bst.getPreOrder();
            for (int i = 0; i < arr.Length; i++)
            {
                bstListBox.Items.Add(arr[i]);
            }
        }

        /// <summary>
        /// Sets all node values to the listbox in post order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPostOrder_Click(object sender, RoutedEventArgs e)
        {
            bstListBox.Items.Clear();
            String[] arr = bst.getPostOrder();
            for (int i = 0; i < arr.Length; i++)
            {
                bstListBox.Items.Add(arr[i]);
            }
        }
    }
}


