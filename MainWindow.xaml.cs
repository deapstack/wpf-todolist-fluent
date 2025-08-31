using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.ObjectModel;
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
            DataContext = this;
            Entries = new ObservableCollection<string>();
            InitializeComponent();
            
        }

        private ObservableCollection<string> _entries;

        public ObservableCollection<string> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }


        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (tbItemToAdd.Text.Length > 0)
            {
                Entries.Add(tbItemToAdd.Text);
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
                    Entries.Remove(item);
                }
            }
        }
        private void btnClearAllItems_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Delete all items ?", "Confirm action", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Entries.Clear();
            }
        }
    }
}