using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlowerAssistant.Data;
using FlowerAssistant.Models;

namespace FlowerAssistant.Views
{
    [QueryProperty(nameof(NameInf), "name")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfDetailPage : ContentPage
    {
        public string NameInf
        {
            set
            {
                LoadFlowerInf(value);
            }
        }

        public InfDetailPage()
        {
            InitializeComponent();
            //BindingContext = new InfDetailPage();
        }

        void LoadFlowerInf(string name)
        {
            try
            {
                FlowerInf flowerinf = InfData.Infs.FirstOrDefault(a => a.NameInf == name);
                BindingContext = flowerinf;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load information.");
            }
        }
    }
}