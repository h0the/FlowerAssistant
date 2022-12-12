using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Xamarin.Forms;
using FlowerAssistant.Data;
using FlowerAssistant.Models;

namespace FlowerAssistant.ViewModels
{
    class InfDetailViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public FlowerInf Inf { get; private set; }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            // Only a single query parameter is passed, which needs URL decoding.
            string name = HttpUtility.UrlDecode(query["name"]);
            LoadFlowerInf(name);
        }

        void LoadFlowerInf(string name)
        {
            try
            {
                Inf = InfData.Infs.FirstOrDefault(a => a.NameInf == name);
                OnPropertyChanged("Inf");
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load information.");
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
