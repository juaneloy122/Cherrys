using KQ.Xamarin.Controls.Fuentes;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KQ.Xamarin.Views
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
        public Color ColorIcono { get; set; }
        public double SizeIcono { get; set; }
    }
}
