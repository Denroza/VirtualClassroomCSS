using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetEmu.Views.Custom.RgPopUp.Control
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuForms : ContentView
    {
        private readonly static MenuForms instance = new MenuForms();

        public static MenuForms Instance {
            get { return instance; }
        }
        public MenuForms()
        {
            InitializeComponent();
            this.InputTransparent = true;
            this.Opacity = 0;
        }

      
    }
}