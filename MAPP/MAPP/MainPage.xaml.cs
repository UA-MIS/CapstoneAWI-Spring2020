using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

/* 
 * Marine Application Platform Prototype
 * Fall 2019 Capstone Team: Katy Sobodos, Adam Branan, Jessica Sifuentes, Courntey Wentz, and Ryan Waelde
*/

namespace MAPP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : Xamarin.Forms.TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
       



                Children.Add(new Page1() { Title = "Map View" } );
                Children.Add(new Page2() { Title = "Weather" });
                Children.Add(new Page3() { Title = "Safety" });
                Children.Add(new Page4() { Title = "Regulations" });

                Title = "MAPP";


        }
    }
}