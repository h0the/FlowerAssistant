using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FlowerAssistant.Controls
{
    class HeadingLabel : Label
    {
        public HeadingLabel()
        {
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            FontAttributes = FontAttributes.Bold;
            HorizontalOptions = LayoutOptions.Center;
        }
    }
}
