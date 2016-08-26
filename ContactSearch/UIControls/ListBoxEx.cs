using System;
using System.Collections.Generic;
using System.Linq;
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

namespace UIControls
{

    /// <summary>
    /// The ListBoxEx class for holding search field items.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.ListBox" />
    public class ListBoxEx : ListBox
    {
        #region Enum

        /// <summary>
        /// The ItemStyles enumeration.
        /// </summary>
        public enum ItemStyles
        {
            NormalStyle,
            CheckBoxStyle,
            RadioBoxStyle
        }

        #endregion Enum

        #region Fields

        /// <summary>
        /// The extended style.
        /// </summary>
        private ItemStyles extendedStyle;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the extended style.
        /// </summary>
        /// <value>The extended style.</value>
        /// <exception cref="System.SystemException"></exception>
        public ItemStyles ExtendedStyle
        {
            get { return extendedStyle; }
            set {
                extendedStyle = value;

                // load resources
                ResourceDictionary resDict = new ResourceDictionary();
                resDict.Source = new Uri("pack://application:,,,/SearchTextBox;component/Themes/ListBoxEx.xaml");
                if (resDict.Source == null)
                    throw new SystemException();
 
                switch (value)
                {
                case ItemStyles.NormalStyle:
                    this.Style = (Style)resDict["NormalListBox"];
            	    break;
                case ItemStyles.CheckBoxStyle:
                    this.Style = (Style)resDict["CheckListBox"];
                    break; 
                case ItemStyles.RadioBoxStyle:
                    this.Style = (Style)resDict["RadioListBox"];
                    break;
                }
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes the <see cref="ListBoxEx"/> class.
        /// </summary>
        static ListBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListBoxEx), new FrameworkPropertyMetadata(typeof(ListBoxEx)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBoxEx"/> class.
        /// </summary>
        /// <param name="style">The style.</param>
        public ListBoxEx(ItemStyles style)
            : base()
        {
            ExtendedStyle = style;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListBoxEx"/> class.
        /// </summary>
        public ListBoxEx(): base(){
            ExtendedStyle = ItemStyles.NormalStyle;
        }

        #endregion Constructors
    }
}

