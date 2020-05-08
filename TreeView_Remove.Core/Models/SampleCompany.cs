using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

namespace TreeView_Remove.Core.Models
{
    // TODO WTS: Remove this class once your pages/features are using your data.
    // This is used by the SampleDataService.
    // It is the model class we use to display data on pages like Grid, Chart, and Master Detail.
    public class SampleCompany : INotifyPropertyChanged
    {
        public string CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        private bool isSelected { get; set; }
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }        

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Exception in OnPropertyChanged: " + ex.Message);
            }
        }

        public ObservableCollection<SampleOrder> Orders { get; set; }
    }
}
