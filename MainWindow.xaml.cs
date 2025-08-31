using Microsoft.VisualBasic;
using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TodoList
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lvEntries.Items.Add("Hello");
            lvEntries.Items.Add("Hello2");
            lvEntries.Items.Add("Hello3");
            lvEntries.Items.Add("Hello4");
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (tbItemToAdd.Text.Length > 0)
            {
                lvEntries.Items.Add(tbItemToAdd.Text);
                tbItemToAdd.Clear();
            }
        }
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            var items = lvEntries.SelectedItems;
            var result = MessageBox.Show($"Delete {items.Count} items ?", "Confirm action", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                List<string> itemsListCopy = items.OfType<string>().ToList();
                foreach (var item in itemsListCopy)
                {
                    lvEntries.Items.Remove(item);
                }
            }
        }
        private void btnClearAllItems_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Delete all items ?", "Confirm action", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                lvEntries.Items.Clear();
                }
        }
    }
}