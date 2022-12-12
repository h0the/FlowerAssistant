using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlowerAssistant.Models;
using FlowerAssistant.Controls;

namespace FlowerAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlowersPage : ContentPage
    {
        INotificationManager notificationManager;
        int notificationNumber = 0;
        int k = 0;

        public FlowersPage()
        {
            InitializeComponent();

            Control.Init();

            img.Source = "orh1.jpg";
            //Creating TapGestureRecognizers    
            var tapImage = new TapGestureRecognizer();
            //Binding events    
            tapImage.Tapped += tapImage_Tapped;
            //Associating tap events to the image buttons    
            img.GestureRecognizers.Add(tapImage);

            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
            };
        }

        void tapImage_Tapped(object sender, EventArgs e)
        {
            // handle the tap    
            DisplayAlert("Сообщение", "Вы выбрали другой цветок", "OK");
            if (k == 0)
            {
                img.Source = "cactus.jpg";
                namfl.Text = "Кактус";
                k = 1;
            }
            else
            {
                img.Source = "orh1.jpg";
                namfl.Text = "Орхидея";
                k = 0;
            }
        }

        void OnSendClick(object sender, EventArgs e)
        {
            notificationNumber++;
            string title = $"Flower Assistant напоминает";
            string message = $"Вам нужно полить цветок!";
            notificationManager.SendNotification(title, message);
        }

        void OnScheduleClick(object sender, EventArgs e)
        {
            notificationNumber++;
            string title = $"Flower Assistant напоминает";
            string message = $"Вам нужно полить цветок!";
            notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10));
        }

        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
                // StackLayout.Children.Add(msg);
            });
        }
    }
}