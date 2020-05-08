using System;

using TreeView_Remove.ViewModels;

using Windows.UI.Xaml.Controls;

namespace TreeView_Remove.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
