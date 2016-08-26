using ContactSearch.ViewModels;
using ContactsService.Constants;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UIControls;

namespace ContactSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ContactsViewModel();
            this.DataContext = vm;
            SearchResultGrid.ItemsSource = vm.Contacts;

            InitializeSearchOptions();
        }

        /// <summary>
        /// Initializes the search options.
        /// </summary>
        private void InitializeSearchOptions()
        {
            var sections = new List<string> {
                ContactProperties.Name,
                ContactProperties.City,
                ContactProperties.State,
                ContactProperties.PostalCode
            };
            searchBox.SectionsList = sections;
            searchBox.SectionsStyle = SearchTextBox.SectionsStyles.RadioBoxStyle;
        }

        /// <summary>
        /// Handles the AutoGeneratingColumn event of the SearchResultGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridAutoGeneratingColumnEventArgs"/> instance containing the event data.</param>
        private void SearchResultGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var name = e.Column.Header.ToString();
            var header = name;
            switch (name)
            {
                case "FirstName":
                    {
                        header = "First Name";
                        break;
                    }
                case "MiddleName":
                    {
                        header = "Middle Name";
                        break;
                    }
                case "LastName":
                    {
                        header = "Last Name";
                        break;
                    }
                case "Photo":
                    {
                        var column = new DataGridTemplateColumn();
                        column.Header = name;
                        column.CellTemplate = (DataTemplate)FindResource("tooltiptemplate");
                        e.Column = column;                        
                        break;
                    }
            };
            e.Column.Header = header;
        }
    }
}
