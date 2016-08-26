using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace UIControls
{

    /// <summary>
    /// The SearchEventArgs class.
    /// </summary>
    /// <seealso cref="System.Windows.RoutedEventArgs" />
    public class SearchEventArgs : RoutedEventArgs
    {
        #region Fields

        /// <summary>
        /// The keyword.
        /// </summary>
        private string keyword = "";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the keyword.
        /// </summary>
        /// <value>The keyword.</value>
        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }

        private List<string> sections = new List<string>();
        /// <summary>
        /// Gets or sets the sections.
        /// </summary>
        /// <value>The sections.</value>
        public List<string> Sections
        {
            get { return sections; }
            set { sections = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchEventArgs"/> class.
        /// </summary>
        public SearchEventArgs() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchEventArgs"/> class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the <see cref="T:System.Windows.RoutedEventArgs" /> class.</param>
        public SearchEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }

        #endregion Constructors
    }

    /// <summary>
    /// The SearchTextBox class.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.TextBox" />
    /// <seealso cref="System.Windows.Input.ICommandSource" />
    public class SearchTextBox : TextBox, ICommandSource
    {

        #region Enum

        /// <summary>
        /// The SectionsStyles enumeration.
        /// </summary>
        public enum SectionsStyles
        {
            NormalStyle,
            CheckBoxStyle,
            RadioBoxStyle
        }

        #endregion Enum

        #region Dependancy Properties

        /// <summary>
        /// The label text property.
        /// </summary>
        public static DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(SearchTextBox));

        /// <summary>
        /// The label text color property.
        /// </summary>
        public static DependencyProperty LabelTextColorProperty =
            DependencyProperty.Register(
                "LabelTextColor",
                typeof(Brush),
                typeof(SearchTextBox));

        /// <summary>
        /// The has text property key.
        /// </summary>
        private static DependencyPropertyKey HasTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "HasText",
                typeof(bool),
                typeof(SearchTextBox),
                new PropertyMetadata());
        public static DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

        /// <summary>
        /// The is mouse left button down property key.
        /// </summary>
        private static DependencyPropertyKey IsMouseLeftButtonDownPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "IsMouseLeftButtonDown",
                typeof(bool),
                typeof(SearchTextBox),
                new PropertyMetadata());
        public static DependencyProperty IsMouseLeftButtonDownProperty = IsMouseLeftButtonDownPropertyKey.DependencyProperty;

        /// <summary>
        /// The search event
        /// </summary>
        public static readonly RoutedEvent SearchEvent =
            EventManager.RegisterRoutedEvent("Search",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(SearchTextBox));

        #endregion Properties

        #region Construcotrs

        /// <summary>
        /// Initializes the <see cref="SearchTextBox"/> class.
        /// </summary>
        static SearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(SearchTextBox),
                new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchTextBox"/> class.
        /// </summary>
        public SearchTextBox()
            : base()
        {
        }

        #endregion Construcotrs

        #region Events

        /// <summary>
        /// Is called when content in this editing control changes.
        /// </summary>
        /// <param name="e">The arguments that are associated with the <see cref="E:System.Windows.Controls.Primitives.TextBoxBase.TextChanged" /> event.</param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            HasText = Text.Length != 0;
            HidePopup();
        }

        /// <summary>
        /// Invoked whenever an unhandled <see cref="E:System.Windows.Input.Mouse.MouseDown" /> attached routed event reaches an element derived from this class in its route. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">Provides data about the event.</param>
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            // if users click on the editing area, the pop up will be hidden
            Type sourceType = e.OriginalSource.GetType();
            if (sourceType != typeof(Image))
                HidePopup();
        }

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets or sets the label text.
        /// </summary>
        /// <value>
        /// The label text.
        /// </value>
        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of the label text.
        /// </summary>
        /// <value>
        /// The color of the label text.
        /// </value>
        public Brush LabelTextColor
        {
            get { return (Brush)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has text.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has text; otherwise, <c>false</c>.
        /// </value>
        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
            private set { SetValue(HasTextPropertyKey, value); }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is mouse left button down.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is mouse left button down; otherwise, <c>false</c>.
        /// </value>
        public bool IsMouseLeftButtonDown
        {
            get { return (bool)GetValue(IsMouseLeftButtonDownProperty); }
            private set { SetValue(IsMouseLeftButtonDownPropertyKey, value); }
        }

        /// <summary>
        /// Occurs when [on search].
        /// </summary>
        public event RoutedEventHandler OnSearch
        {
            add { AddHandler(SearchEvent, value); }
            remove { RemoveHandler(SearchEvent, value); }
        }

        /// <summary>
        /// The sections list property
        /// </summary>
        public static DependencyProperty SectionsListProperty =
            DependencyProperty.Register(
                "SectionsList",
                typeof(List<string>),
                typeof(SearchTextBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None)
             );

        /// <summary>
        /// Gets or sets the sections list.
        /// </summary>
        /// <value>
        /// The sections list.
        /// </value>
        public List<string> SectionsList
        {
            get { return (List<string>)GetValue(SectionsListProperty); }
            set
            {
                SetValue(SectionsListProperty, value);
            }
        }

        /// <summary>
        /// The selected items property
        /// </summary>
        public static DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register(
                "SelectedItems",
                typeof(List<string>),
                typeof(SearchTextBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None)
             );

        /// <summary>
        /// Gets or sets the selected items.
        /// </summary>
        /// <value>
        /// The selected items.
        /// </value>
        public List<string> SelectedItems
        {
            get { return (List<string>)GetValue(SelectedItemsProperty); }
            set
            {
                SetValue(SelectedItemsProperty, value);

            }
        }

        private bool showSectionButton = true;
        /// <summary>
        /// Gets or sets a value indicating whether [show section button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show section button]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowSectionButton
        {
            get { return showSectionButton; }
            set
            {
                showSectionButton = value;
            }
        }

        private SectionsStyles m_itemStyle = SectionsStyles.CheckBoxStyle;
        /// <summary>
        /// Gets or sets the sections style.
        /// </summary>
        /// <value>
        /// The sections style.
        /// </value>
        public SectionsStyles SectionsStyle
        {
            get { return m_itemStyle; }
            set { m_itemStyle = value; }
        }

        #endregion  Properties

        #region ICommandSource Implementation

        /// <summary>
        /// The command property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
    DependencyProperty.Register(
        "Command",
        typeof(ICommand),
        typeof(SearchTextBox),
        new PropertyMetadata((ICommand)null,
        new PropertyChangedCallback(CommandChanged)));

        /// <summary>
        /// Gets the command that will be executed when the command source is invoked.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        /// <summary>
        /// Represents a user defined data value that can be passed to the command when it is executed.
        /// </summary>
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


        /// <summary>
        /// The command parameter property
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(SearchTextBox), new UIPropertyMetadata(null));

        /// <summary>
        /// The object that the command is being executed on.
        /// </summary>
        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }

        /// <summary>
        /// The command target property
        /// </summary>
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(SearchTextBox), new UIPropertyMetadata(null));

        /// <summary>
        /// Commands the changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void CommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var cs = (SearchTextBox)d;
            cs.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }

        /// <summary>
        /// Hooks up command.
        /// </summary>
        /// <param name="oldCommand">The old command.</param>
        /// <param name="newCommand">The new command.</param>
        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            // If oldCommand is not null, then we need to remove the handlers.
            if (oldCommand != null)
            {
                RemoveCommand(oldCommand, newCommand);
            }
            AddCommand(oldCommand, newCommand);
        }

        /// <summary>
        /// Removes the command.
        /// </summary>
        /// <param name="oldCommand">The old command.</param>
        /// <param name="newCommand">The new command.</param>
        private void RemoveCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = CanExecuteChanged;
            oldCommand.CanExecuteChanged -= handler;
        }

        /// <summary>
        /// Adds the command.
        /// </summary>
        /// <param name="oldCommand">The old command.</param>
        /// <param name="newCommand">The new command.</param>
        private void AddCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = new EventHandler(CanExecuteChanged);
            if (newCommand != null)
            {
                newCommand.CanExecuteChanged += handler;
            }
        }

        /// <summary>
        /// Determines whether this instance [can execute changed] the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CanExecuteChanged(object sender, EventArgs e)
        {

            if (this.Command != null)
            {
                RoutedCommand command = this.Command as RoutedCommand;

                // If a RoutedCommand.
                if (command != null)
                {
                    if (command.CanExecute(CommandParameter, CommandTarget))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
                // If a not RoutedCommand.
                else
                {
                    if (Command.CanExecute(CommandParameter))
                    {
                        this.IsEnabled = true;
                    }
                    else
                    {
                        this.IsEnabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Executes the search command.
        /// </summary>
        protected void ExecuteSearchCommand()
        {
            if (this.Command != null)
            {
                RoutedCommand command = Command as RoutedCommand;

                if (command != null)
                {
                    command.Execute(CommandParameter, CommandTarget);
                }
                else
                {
                    ((ICommand)Command).Execute(CommandParameter);
                }
            }
        }

        #endregion ICommandSource Implementation

        #region Methods
        
        /// <summary>
        /// Is called when a control template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.MouseLeave += new MouseEventHandler(SearchTextBox_MouseLeave);
            Border iconBorder = GetTemplateChild("PART_SearchIconBorder") as Border;
            if (iconBorder != null)
            {
                iconBorder.MouseLeftButtonDown += new MouseButtonEventHandler(IconBorder_MouseLeftButtonDown);
                iconBorder.MouseLeftButtonUp += new MouseButtonEventHandler(IconBorder_MouseLeftButtonUp);
                iconBorder.MouseLeave += new MouseEventHandler(IconBorder_MouseLeave);
                iconBorder.MouseDown += new MouseButtonEventHandler(SearchIcon_MouseDown);
            }

            int size = 0;
            if (ShowSectionButton)
            {
                iconBorder = GetTemplateChild("PART_SpecifySearchType") as Border;
                if (iconBorder != null)
                {
                    iconBorder.MouseDown += new MouseButtonEventHandler(ChooseSection_MouseDown);
                }
                size = 15;
            }
            Image iconChoose = GetTemplateChild("SpecifySearchType") as Image;
            if (iconChoose != null)
                iconChoose.Width = iconChoose.Height = size;

            iconBorder = GetTemplateChild("PART_PreviousItem") as Border;
            if (iconBorder != null)
                iconBorder.MouseDown += new MouseButtonEventHandler(PreviousItem_MouseDown);

        }

        /// <summary>
        /// Handles the MouseDown event of the SearchIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void SearchIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HidePopup();
        }

        /// <summary>
        /// Handles the MouseLeave event of the SearchTextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void SearchTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!listPopup.IsMouseOver)
                HidePopup();
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the IconBorder control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void IconBorder_MouseLeftButtonDown(object obj, MouseButtonEventArgs e)
        {
            IsMouseLeftButtonDown = true;

        }

        /// <summary>
        /// Handles the MouseLeftButtonUp event of the IconBorder control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void IconBorder_MouseLeftButtonUp(object obj, MouseButtonEventArgs e)
        {
            if (!IsMouseLeftButtonDown) return;

            if (HasText)
            {
                RaiseSearchEvent();
            }

            IsMouseLeftButtonDown = false;
        }

        /// <summary>
        /// Handles the MouseLeave event of the IconBorder control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void IconBorder_MouseLeave(object obj, MouseEventArgs e)
        {
            IsMouseLeftButtonDown = false;

        }

        /// <summary>
        /// Invoked whenever an unhandled <see cref="E:System.Windows.Input.Keyboard.KeyDown" /> attached routed event reaches an element derived from this class in its route. Implement this method to add class handling for this event.
        /// </summary>
        /// <param name="e">Provides data about the event.</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Text = "";
            }
            else if ((e.Key == Key.Return || e.Key == Key.Enter))
            {
                RaiseSearchEvent();
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        /// <summary>
        /// Raises the search event.
        /// </summary>
        private void RaiseSearchEvent()
        {
            if (this.Text == "")
                return;
            if (!listPreviousItem.Items.Contains(this.Text))
                listPreviousItem.Items.Add(this.Text);


            SearchEventArgs args = new SearchEventArgs(SearchEvent);
            args.Keyword = this.Text;
            if (listSection != null)
            {
                args.Sections = (List<string>)listSection.SelectedItems.Cast<string>().ToList();
                SelectedItems = args.Sections;
            }
            RaiseEvent(args);
            ExecuteSearchCommand();
        }
        
        private Popup listPopup = new Popup();
        private ListBoxEx listSection = null;
        private ListBoxEx listPreviousItem = null;

        /// <summary>
        /// Builds the popup.
        /// </summary>
        private void BuildPopup()
        {
            // initialize the pop up
            listPopup.PopupAnimation = PopupAnimation.Fade;
            listPopup.Placement = PlacementMode.Relative;
            listPopup.PlacementTarget = this;
            listPopup.PlacementRectangle = new Rect(0, this.ActualHeight, 30, 30);
            listPopup.Width = this.ActualWidth;
            // initialize the sections' list
            if (ShowSectionButton)
            {
                listSection = new ListBoxEx((int)m_itemStyle + ListBoxEx.ItemStyles.NormalStyle);

                listSection.Items.Clear();
                if (SectionsList != null)
                {
                    foreach (string item in SectionsList)
                    {
                        listSection.Items.Add(item);
                    }
                }

                listSection.Width = this.Width;
                listSection.MouseLeave += new MouseEventHandler(ListSection_MouseLeave);

            }

            // initialize the previous items' list
            listPreviousItem = new ListBoxEx();
            listPreviousItem.MouseLeave += new MouseEventHandler(ListPreviousItem_MouseLeave);
            listPreviousItem.SelectionChanged += new SelectionChangedEventHandler(ListPreviousItem_SelectionChanged);
            listPreviousItem.Width = this.Width;
        }

        /// <summary>
        /// Hides the popup.
        /// </summary>
        private void HidePopup()
        {
            listPopup.IsOpen = false;
        }

        /// <summary>
        /// Shows the popup.
        /// </summary>
        /// <param name="item">The item.</param>
        private void ShowPopup(UIElement item)
        {
            listPopup.StaysOpen = true;

            listPopup.Child = item;
            listPopup.IsOpen = true;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the ListPreviousItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        void ListPreviousItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // fetch the previous keyword into the text box
            this.Text = listPreviousItem.SelectedItems[0].ToString();
            // close the pop up
            HidePopup();

            this.Focus();
            this.SelectionStart = this.Text.Length;
        }

        /// <summary>
        /// Handles the MouseLeave event of the ListPreviousItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void ListPreviousItem_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePopup();
        }

        /// <summary>
        /// Handles the MouseDown event of the PreviousItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        void PreviousItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (listPreviousItem.Items.Count != 0)
            {
                ShowPopup(listPreviousItem);
            }
        }

        /// <summary>
        /// Handles the MouseLeave event of the ListSection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        void ListSection_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePopup();
        }

        /// <summary>
        /// Handles the MouseDown event of the ChooseSection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        void ChooseSection_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (SectionsList == null)
            {
                return;
            }
            if (SectionsList.Count != 0)
            {
                ShowPopup(listSection);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.UIElement.LostFocus" /> event (using the provided arguments).
        /// </summary>
        /// <param name="e">Provides data about the event.</param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (!HasText)
                this.LabelText = "Search";

            listPopup.StaysOpen = false;
        }

        /// <summary>
        /// Invoked whenever an unhandled <see cref="E:System.Windows.UIElement.GotFocus" /> event reaches this element in its route.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs" /> that contains the event data.</param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            if (!HasText)
            {
                this.LabelText = "";
            }
            listPopup.StaysOpen = true;
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.FrameworkElement.SizeChanged" /> event, using the specified information as part of the eventual event data.
        /// </summary>
        /// <param name="sizeInfo">Details of the old and new size involved in the change.</param>
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            BuildPopup();
        }

        #endregion Methods
    }
}
