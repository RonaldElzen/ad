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
    /// Interaction logic for BucketHasWindow.xaml
    /// </summary>
    public partial class BucketHasWindow : Window
    {
        ad.BucketHash bucketHash;

        public BucketHasWindow(ad.BucketHash bucketHash)
        {
            this.bucketHash = bucketHash;
            InitializeComponent();
        }

        private void buttonAddToHash_Click(object sender, RoutedEventArgs e)
        {
            bucketHash.Insert(TextboxAddHash.Text);
            listBoxHash.Items.Add(bucketHash.getBucketHash());
            show();
        }




        private void buttonRemoveFromHash_Click(object sender, RoutedEventArgs e)
        {
            bucketHash.Remove(textBoxRemoveHash.Text);
            show();
        }

        private void show()
        {
            ArrayList[] hash = bucketHash.getBucketHash();
            for (int i = 0; i <= hash.GetUpperBound(0); i++)
            {


                if (hash[i] != null)
                {
                    var innerHash = hash[i];

                    for (int j = 0; j < innerHash.Count; j++)
                        listBoxHash.Items.Add(innerHash[j]);
                }

            }
        }
    }
}
