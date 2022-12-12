using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowerAssistant.Droid
{
    [BroadcastReceiver(Enabled = true, Label = "Reboot complete receiver")]
    public class BootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == "android.intent.action.BOOT_COMPLETED")
            {
                // Recreate alarms
            }
        }
    }
}