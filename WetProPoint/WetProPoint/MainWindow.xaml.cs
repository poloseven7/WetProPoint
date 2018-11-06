using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using WetProPointData;

namespace WetProPoint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
                        
            this.DataContext = viewModel = new MainWindowViewModel();

            viewModel.Utilisateur = new Utilisateur() { Nom = "Manon", Poids = 58, TotalPointsJourDispo = 29 , Journee = new Journee() { Date = DateTime.Now } };
            viewModel.Database = new Database();
            viewModel.Database.ChargerBase(@"D:\Personnel - privé\Projects\database\ingredients.xml");

            ingredientListView.SelectedIndex = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Database dataBase = new Database();
            dataBase.ConvertBase(@"D:\Personnel - privé\Projects\database\ingredients.xlsx", @"D:\Personnel - privé\Projects\database\ingredients.xml", @"D:\Personnel - privé\Projects\database\categories.xml");

        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                this.WindowState = (this.WindowState == System.Windows.WindowState.Normal) ? System.Windows.WindowState.Maximized : System.Windows.WindowState.Normal;
            }
            else
            {
                base.OnMouseLeftButtonDown(e);
                // Begin dragging the window
                this.DragMove();
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.Database.Filter(textBox.Text);
            ingredientListView.SelectedIndex = 0;
        }

        private void ingredientListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            quantiteCombo.SelectedIndex = 0;
        }

        //public void ingredientListViewCollectionChanged(object sender, System.EventArgs e)
        //{
        //    AutoSizeGridViewColumns(ingredientListView);
        //}

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var dpd = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(ListView));
        //    if (dpd != null)
        //    {
        //        dpd.AddValueChanged(ingredientListView, ingredientListViewCollectionChanged);
        //    }                      
        //}

        //public void AutoSizeGridViewColumns(ListView listView)
        //{
        //    GridView gridView = listView.View as GridView;
        //    if (gridView != null)
        //    {
        //        foreach (var column in gridView.Columns)
        //        {
        //            if (double.IsNaN(column.Width))
        //                column.Width = column.ActualWidth;
        //            column.Width = double.NaN;
        //        }
        //    }
        //}
    }
}