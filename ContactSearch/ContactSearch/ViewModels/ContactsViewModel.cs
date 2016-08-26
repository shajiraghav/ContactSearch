using ContactSearch.Commands;
using ContactSearch.ContactsService.Specifications;
using ContactSearch.DomainModel;
using ContactSearch.ScreenControllers;
using ContactSearch.Utilities;
using ContactsService.Constants;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactSearch.ViewModels
{
    /// <summary>
    /// The ContactsViewModel view model.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ContactSearch.ViewModels.IViewModel{ContactSearch.ScreenControllers.ContactsScreenController}" />
    public class ContactsViewModel : INotifyPropertyChanged, IViewModel<ContactsScreenController>
    {
        #region Fields

        /// <summary>
        /// The seed models
        /// </summary>
        private List<ContactModel> seedModels = new List<ContactModel>();

        /// <summary>
        /// The data available
        /// </summary>
        private bool dataAvailable = false;

        #endregion Fields

        #region constructors 

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsViewModel"/> class.
        /// </summary>
        public ContactsViewModel()
        {
            GenerateButtonCommand = new AsyncCommand(GenerateContacts, EnableGenerateButton);
            DeleteButtonCommand = new AsyncCommand(DeleteContacts, (p) => { return dataAvailable; });
            SearchCommand = new AsyncCommand(SearchContacts, (p) => { return true; });
            Contacts = new ObservableCollection<PersonViewModel>();

            Initialize();
        }

        #endregion constructors 

        #region Properties

        /// <summary>
        /// Gets or sets the contacts. The search result should be assigned to this.
        /// </summary>
        /// <value>The contacts.</value>
        public ObservableCollection<PersonViewModel> Contacts { get; set; }

        /// <summary>
        /// Gets the generate button command.
        /// </summary>
        /// <value>
        /// The generate button command.
        /// </value>
        public ICommand GenerateButtonCommand { get; }

        /// <summary>
        /// Gets the delete button command.
        /// </summary>
        /// <value>
        /// The delete button command.
        /// </value>
        public ICommand DeleteButtonCommand { get; }

        /// <summary>
        /// Gets the search command.
        /// </summary>
        /// <value>
        /// The search command.
        /// </value>
        public ICommand SearchCommand { get; }
        
        private bool loadAllData = true;
        /// <summary>
        /// Gets or sets a value indicating whether [load all data].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [load all data]; otherwise, <c>false</c>.
        /// </value>
        public bool LoadAllData
        {
            get
            {
                return loadAllData;
            }
            set
            {
                loadAllData = value;
                OnPropertyChanged("LoadAllData");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enable data count input].
        /// </summary>
        /// <value>
        /// <c>true</c> if [enable data count input]; otherwise, <c>false</c>.
        /// </value>
        public bool EnableDataCountInput
        {
            get
            {
                return !dataAvailable;
            }
            set
            {                
                OnPropertyChanged("EnableDataCountInput");
            }
        }

        private string searchKey;
        /// <summary>
        /// Gets or sets the search key.
        /// </summary>
        /// <value>
        /// The search key.
        /// </value>
        public string SearchKey
        {
            get
            {
                return searchKey;
            }
            set
            {
                searchKey = value;
                OnPropertyChanged("SearchKey");
            }
        }

        private bool uiEnable;
        /// <summary>
        /// Gets or sets a value indicating whether [UI enable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [UI enable]; otherwise, <c>false</c>.
        /// </value>
        public bool UiEnable
        {
            get
            {
                return uiEnable;
            }
            set
            {
                uiEnable = value;
                OnPropertyChanged("UiEnable");
            }
        }

        private List<string> searchFields;
        /// <summary>
        /// Gets or sets the search fields.
        /// </summary>
        /// <value>
        /// The search fields.
        /// </value>
        public List<string> SearchFields
        {
            get
            {
                return searchFields.Any() ? searchFields : new List<string> { ContactProperties.Name };
            }
            set
            {
                searchFields = value;
                OnPropertyChanged("SearchFields");
            }
        }

        private bool progressVisibility;
        /// <summary>
        /// Gets or sets a value indicating whether [progress visibility].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [progress visibility]; otherwise, <c>false</c>.
        /// </value>
        public bool ProgressVisibility
        {
            get
            {
                return progressVisibility;
            }
            set
            {
                progressVisibility = value;
                OnPropertyChanged("ProgressVisibility");
            }
        }

        private int dataCount;
        /// <summary>
        /// Gets or sets the data count.
        /// </summary>
        /// <value>
        /// The data count.
        /// </value>
        public int DataCount
        {
            get
            {
                return dataCount;
            }
            set
            {
                dataCount = value;
                OnPropertyChanged("DataCount");
            }
        }

        private ContactsScreenController controller = new ContactsScreenController();
        /// <summary>
        /// Gets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        public ContactsScreenController Controller
        {
            get
            {
                return controller;
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Properties

        #region Methods

        #region Privates

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            searchFields = new List<string> { ContactProperties.Name };
            dataCount = 250;
            PopulateAllData();
            EnableUI(true);
            EnableProgressBar(false);
        }

        /// <summary>
        /// Generates the contacts.
        /// </summary>
        /// <returns></returns>
        private async Task GenerateContacts()
        {
            EnterBusyState();
            var modelFactory = new ContactFactory();
            for (var i = 0; i < DataCount; i++)
            {
                seedModels.Add(modelFactory.CreateContact());
            }

            await Task.Run(() => Controller.SaveContacts(seedModels));

            PopulateAllData();

            ExitBusyState();
        }

        /// <summary>
        /// Deletes the contacts.
        /// </summary>
        /// <returns></returns>
        private async Task DeleteContacts()
        {
            EnterBusyState();
            await Task.Run(() => Controller.DeleteAllContacts());
            PopulateAllData();
            ExitBusyState();
        }

        /// <summary>
        /// Searches the contacts.
        /// </summary>
        /// <returns></returns>
        private async Task SearchContacts()
        {
            EnterBusyState();
            var spec = new ContactSpecification(SearchKey, SearchFields);           
            var contacts = await Task.Run(() => Controller.GetContacts(spec));
            RefreshView(contacts.ToList());
            ExitBusyState();
        }

        /// <summary>
        /// Refreshes the view.
        /// </summary>
        /// <param name="contacts">The contacts.</param>
        private void RefreshView(List<ContactModel> contacts)
        {
            Contacts.Clear();
            foreach (var model in contacts)
            {
                Contacts.Add(new PersonViewModel(model));
            }
            if (Contacts.Any())
            {
                SetDataavailability(true);
            }
        }

        /// <summary>
        /// Populates all data.
        /// </summary>
        private async void PopulateAllData()
        {
            EnterBusyState();
            var models = await Task.Run(() => Controller.GetAllContacts());
            Contacts.Clear();
            if (loadAllData)
            {
                foreach (var model in models)
                {
                    Contacts.Add(new PersonViewModel(model));
                }
            }

            dataAvailable = models.Any();
            ExitBusyState();      
        }

        /// <summary>
        /// Sets the dataavailability.
        /// </summary>
        /// <param name="available">if set to <c>true</c> [available].</param>
        private void SetDataavailability(bool available)
        {
            dataAvailable = available;
        }

        /// <summary>
        /// Enables the generate button.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private bool EnableGenerateButton(object obj)
        {
            return !dataAvailable;
        }

        /// <summary>
        /// Enables the delete button.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        private bool EnableDeleteButton(object obj)
        {
            return dataAvailable;
        }

        /// <summary>
        /// Enables the UI.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void EnableUI(bool state)
        {
            UiEnable = state;
        }

        /// <summary>
        /// Enables the progress bar.
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void EnableProgressBar(bool state)
        {
            ProgressVisibility = state;
        }

        /// <summary>
        /// Enters the state of the busy.
        /// </summary>
        private void EnterBusyState()
        {
            EnableProgressBar(true);
            EnableUI(false);
        }

        /// <summary>
        /// Exits the state of the busy.
        /// </summary>
        private void ExitBusyState()
        {
            EnableProgressBar(false);
            EnableUI(true);
        }

        #endregion Privates

        #region Protected

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="name">The name.</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion Protected

        #endregion Methods
    }
}
