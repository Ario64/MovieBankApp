using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MovieBankApp.UserControls
{
    /// <summary>
    /// Interaction logic for ucImageBorder.xaml
    /// </summary>
    public partial class ucImageBorder : UserControl
    {
        #region  DP Properties


        //ImageSource Dependency Property
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register
                   (
                    "Source",
                    typeof(ImageSource),
                    typeof(ucImageBorder),
                    new PropertyMetadata(null)
                    );




        //ValueSource Dependencyproperty For Imagesource 
        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }


        // Using a DependencyProperty as the backing store for value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register
               (
                "Value",
                typeof(object),
                typeof(ucImageBorder),
                new PropertyMetadata(null)
                );

        #endregion

        public ucImageBorder()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
