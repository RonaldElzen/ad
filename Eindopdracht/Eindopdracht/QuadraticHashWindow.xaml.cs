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
    /// Interaction logic for QuadraticHashWindow.xaml
    /// </summary>
    public partial class QuadraticHashWindow : Window
    {
        ad.QuadraticHash<string> quadraticHash;
        public QuadraticHashWindow(ad.QuadraticHash<string> hash)
        {
            quadraticHash = hash;
            InitializeComponent();
        }

        /// <summary>
        /// adds new value to the QuadraticHash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddToHash_Click(object sender, RoutedEventArgs e)
        {
            quadraticHash.insert(TextboxAddHash.Text);
            show();
        }

        /// <summary>
        /// Removes item with the value of the textbox from the quadratic hash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveFromHash_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                quadraticHash.remove(int.Parse(textBoxRemoveHash.Text));
                show();
            }
            catch
            {
                MessageBox.Show("input invalid");
            }
        }

        /// <summary>
        /// updates the listbox with the new QuadraticHash item values
        /// </summary>
        private void show()
        {
            listBoxHash.Items.Clear();
            string[] hash = quadraticHash.getArray();
            for (int i = 0; i <= hash.GetUpperBound(0); i++)
            {
                if (hash[i] != null)
                {
                    listBoxHash.Items.Add("Key " + i + " Value " + hash[i]);
                }
            }
        }
    }
}
