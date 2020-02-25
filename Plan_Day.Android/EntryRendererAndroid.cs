using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plan_Day;
using Plan_Day.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ClearEntryRenderer), typeof(EntryRendererAndroid))]

namespace Plan_Day.Droid
{
    public class EntryRendererAndroid : EntryRenderer
    {
        public EntryRendererAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                Control.SetBackground(gd);
                Control.SetPadding(0, 0, 0, 0);
                Control.SetHintTextColor(Android.Graphics.Color.Gray);
            }
        }
    }
}