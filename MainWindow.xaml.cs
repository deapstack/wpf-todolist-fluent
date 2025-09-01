using System.Collections.ObjectModel;
using System.Windows;
using TodoList.View;

namespace TodoList
{
    public partial class MainWindow : Window
    {

        static List<object> MQTTClientsList = new List<object>();
        
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

            //MQTTClientsList.
            
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

        private void btnOpenModalWindow_Click(object sender, RoutedEventArgs e)
        {
            ModalWindow modalWindow = new ModalWindow(this);
            Opacity = 0.4;
            modalWindow.ShowDialog();
            Opacity = 1.0;
            if (modalWindow.Success == true)
            {
                txtInput.Text = modalWindow.Input;
            }
        }
        
        private void btnOpenNormalWindow_Click(Object sender, RoutedEventArgs e)
        {
            NormalWindow normalWindow = new NormalWindow();
            normalWindow.Show();
        }
    }
}