using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlowerAssistant.Models;

namespace FlowerAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfsPage : ContentPage
    {
        public InfsPage()
        {
            InitializeComponent();
        }

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string infName = (e.CurrentSelection.FirstOrDefault() as FlowerInf).NameInf;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"infdetails?name={infName}");
        }
    }
}