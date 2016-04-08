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
using System.Windows.Shapes;

namespace Eindopdracht
{
    /// <summary>
    /// Interaction logic for LinearHashWindow.xaml
    /// </summary>
    public partial class LinearHashWindow : Window
    {
        ad.LinearHash<string> linearHash;

        public LinearHashWindow(ad.LinearHash<string> linearHash)
        {
            this.linearHash = linearHash;
            InitializeComponent();
        }

        /// <summary>
        /// removes textbox value from the linear hash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveFromHash_Click(object sender, RoutedEventArgs e)
        {
            linearHash.Remove(textBoxRemoveHash.Text);
            show();
        }

        /// <summary>
        /// adds textbox value to the linear hash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddToHash_Click(object sender, RoutedEventArgs e)
        {
            linearHash.Insert(TextboxAddHash.Text);
            show();
        } 

        /// <summary>
        /// shows the updated linear hash in the listbox
        /// </summary>
        private void show()
        {
            listBoxHash.Items.Clear();
            string[] hash = linearHash.GetLinearHash();
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
