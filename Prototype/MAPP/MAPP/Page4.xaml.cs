using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace MAPP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page4 : ContentPage
	{
    	public Page4()
    	{
        	InitializeComponent();

            // buttons on page
        	var backButton = BackButtonLayout;
        	backButton.IsVisible = false;
        	Button fresh = FreshButton;
        	fresh.Clicked += Fresh_Clicked;
        	Button salt = SaltButton;
        	salt.Clicked += Salt_Clicked;
        	Button licenses = LicensesButton;
        	licenses.Clicked += Snapper_Clicked;
        	Button back = BackButton;
        	back.Clicked += Back_Clicked;
    	}
    	private void Snapper_Clicked(object sender, EventArgs e)
    	{
            // set information when snapper button is clicked 
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = RegulationsTextLayout;
            RegulationsTextLayout.IsVisible = true;
            layout.Children.Clear();
            var header1 = new Label { Text = "Snapper Check", TextColor = Color.Black, FontSize = 26, FontAttributes = FontAttributes.Bold };
            var text1 = new Label { Text = "Species with MANDATORY reporting:", TextColor = Color.Black, FontSize = 16 };
            var text2 = new Label { Text = "1. Red Snapper", TextColor = Color.Black, FontSize = 16 };
            var text3 = new Label { Text = "Note: Only one report per vessel trip \n", TextColor = Color.Black, FontSize = 16 };
            var text4 = new Label { Text = "Species with VOLUNTARY  Reporting", TextColor = Color.Black, FontSize = 16 };
            var text5 = new Label { Text = "1. Gray Triggerfish", TextColor = Color.Black, FontSize = 16 };
            var text6 = new Label { Text = "2. Greater AmberJack", TextColor = Color.Black, FontSize = 16 };
            var text7 = new Label { Text = "Note: Only one report per vessel trip", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "Download the Outdoor AL App for Game Check and Snapper Check", TextColor = Color.Black, FontSize = 16 };
            var disc4 = new Label { Text = "**Only avaliable for IOS**", TextColor = Color.Black, FontSize = 16 };
            var disc5 = new Label { Text = "https://apps.apple.com/us/app/outdoor-al/id1381147009", TextColor = Color.Blue, FontSize = 16 };
            layout.Children.Add(disc3);
            layout.Children.Add(disc4);
            layout.Children.Add(disc5);

            // tap gesture recognizers to go to websites when link is clicked
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://apps.apple.com/us/app/outdoor-al/id1381147009";
                OnAlertYesNoClicked(s, f, url);
            };
            var header2 = new Label { Text = "Saltwater Fishing Licenses", TextColor = Color.Black, FontSize = 26, FontAttributes = FontAttributes.Bold };
            var text8 = new Label { Text = "A Saltwater Fishing License is required for all persons fishing or possessing fish in saltwater areas of Alabama.", TextColor = Color.Black, FontSize = 16 };
            var text9 = new Label { Text = "Click here to purchase a Saltwater Fishing License", TextColor = Color.Red, FontSize = 16 };
            var text9Gesture = new TapGestureRecognizer();
            text9Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/licenses/saltwater-recreational-licenses";
                OnAlertYesNoClicked(s, f, url);
            };
            var header3 = new Label { Text = "Freshwater Fishing Licenses", TextColor = Color.Black, FontSize = 26, FontAttributes = FontAttributes.Bold };
            var text10 = new Label { Text = "To support fish management and aquatic resources, purchase a fishing license.", TextColor = Color.Black, FontSize = 16 };
            var text11 = new Label { Text = "Click here to purchase a Freshwater Fishing License", TextColor = Color.Red, FontSize = 16 };
            var text11Gesture = new TapGestureRecognizer();
            text11Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/licenses/freshwater-fishing-licenses";
                OnAlertYesNoClicked(s, f, url);
            };
            layout.Children.Add(header1);
            layout.Children.Add(text1);
            layout.Children.Add(text2);
            layout.Children.Add(text3);
            layout.Children.Add(text4);
            layout.Children.Add(text5);
            layout.Children.Add(text6);
            layout.Children.Add(text7);
            layout.Children.Add(header2);
            layout.Children.Add(text8);
            layout.Children.Add(text9);
            layout.Children.Add(header3);
            layout.Children.Add(text10);
            layout.Children.Add(text11);
            var rsimage = new Image { Aspect = Aspect.AspectFit };
            rsimage.Source = ImageSource.FromFile("CitRedSnapper.png");
            layout.Children.Add(rsimage);
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();
            var disc6 = new Label { Text = "Last Updated: 11/13/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc7 = new Label { Text = "For current safety information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc8 = new Label { Text = "https://research.dcnr.alabama.gov/Snapper/", TextColor = Color.Blue, FontSize = 16 };
            layout.Children.Add(disc3);
            layout.Children.Add(disc4);
            layout.Children.Add(disc5);
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://apps.apple.com/us/app/outdoor-al/id1381147009";
                OnAlertYesNoClicked(s, f, url);
            };
            disc5.GestureRecognizers.Add(tapGestureRecognizer);
            var disc9 = new Label { Text = "Download the Outdoor AL App for Game Check and Snapper Check", TextColor = Color.Black, FontSize = 16 };
            var disc10 = new Label { Text = "**Only avaliable for IOS**", TextColor = Color.Black, FontSize = 16 };
            var disc11 = new Label { Text = "https://apps.apple.com/us/app/outdoor-al/id1381147009", TextColor = Color.Blue, FontSize = 16 };
            layout.Children.Add(disc6);
            layout.Children.Add(disc7);
            layout.Children.Add(disc8);
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://apps.apple.com/us/app/outdoor-al/id1381147009";
                OnAlertYesNoClicked(s, f, url);
            };
            disc8.GestureRecognizers.Add(tapGestureRecognizer);

        

       
        	
        	
    	}
    	private void Salt_Clicked(object sender, EventArgs e)
    	{
        	var buttons = ButtonLayout;
        	buttons.IsVisible = false;
        	var backButton = BackButtonLayout;
        	backButton.IsVisible = true;
        	var layout = RegulationsTextLayout;
        	RegulationsTextLayout.IsVisible = true;
        	layout.Children.Clear();
            var header1 = new Label { Text = "Saltwater Recreational Size & Creel Limits ", TextColor = Color.Black, FontSize = 26, FontAttributes = FontAttributes.Bold };
            var subheader1 = new Label { Text = "Click Below to go to Alabama recreational fishing document: ", TextColor = Color.Black, FontSize = 16, FontAttributes = FontAttributes.Bold };
            var text1 = new Label { Text = "Saltwater Recreation Size & Creel Limits Document", TextColor = Color.Red, FontSize = 16 };
            var text1Gesture = new TapGestureRecognizer();
            text1Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/sites/default/files/PDF%20documents/Creel%20Limits%20B&W%20for%20printing.pdf";
                OnAlertYesNoClicked(s, f, url);
            };
            text1.GestureRecognizers.Add(text1Gesture);
            var rsimage = new Image { Aspect = Aspect.AspectFit };
            rsimage.Source = ImageSource.FromFile("saltwaterCobia.png");
            var subheader2 = new Label { Text = "Click below to go to 2019 Alabama Marine Information Calendar", TextColor = Color.Black, FontSize = 16, FontAttributes = FontAttributes.Bold };
            var text2 = new Label { Text = "2019 Alabama Marine Information Calendar", TextColor = Color.Red, FontSize = 16 };
            var text2Gesture = new TapGestureRecognizer();
            text2Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/sites/default/files/fishing/Saltwater/2019%20MRD%20Calendar%20%28Revised%2002-25-19%29.pdf";
                OnAlertYesNoClicked(s, f, url);
            };
            text2.GestureRecognizers.Add(text2Gesture);

            var rsimage1 = new Image { Aspect = Aspect.AspectFit };
            rsimage1.Source = ImageSource.FromFile("saltwaterSpottedSeaTrout.png");
            var subheader3 = new Label { Text = "Saltwater Contacts", TextColor = Color.Black, FontSize = 16, FontAttributes = FontAttributes.Bold };
            var text3 = new Label { Text = "Click here to go to the Saltwater Contacts page ", TextColor = Color.Red, FontSize = 16 };
            var text3Gesture = new TapGestureRecognizer();
            text3Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/saltwater-fishing/saltwater-contacts";
                OnAlertYesNoClicked(s, f, url);
            };
            text3.GestureRecognizers.Add(text3Gesture);
            var rsimage2 = new Image { Aspect = Aspect.AspectFit };
            rsimage2.Source = ImageSource.FromFile("saltwaterFlounder.png");
            var header2 = new Label { Text = "\n Hook Requirements", TextColor = Color.Black, FontSize = 26, FontAttributes = FontAttributes.Bold };
            var text4 = new Label { Text = "Anglers fishing for retaining, possessing, or landing gulf reef species (as defined in Rule 220-3-46) must use non-stainless steel circle hooks when using natural bait.", TextColor = Color.Black, FontSize = 16 };
            var text5 = new Label { Text = "Anglers fishing for retaining, possessing, or landing sharks must use non-offset, non-stainless steel circle hooks when using natural bait.", TextColor = Color.Black, FontSize = 16 };
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();
            var disc1 = new Label { Text = "Please visit www.alabamainteractive.org/dcnr_hf_license/welcome.action?sp=OA2AI", TextColor = Color.Black, FontSize = 13 };
            var disc5 = new Label { Text = "www.alabamainteractive.org/dcnr_hf_license/welcome.action?sp=OA2AI", TextColor = Color.Blue, FontSize = 13 };
            
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc5);
            layout.Children.Add(header1);
            layout.Children.Add(subheader1);
            layout.Children.Add(text1);
            layout.Children.Add(rsimage);
            layout.Children.Add(subheader2);
            layout.Children.Add(text2);
            layout.Children.Add(text3);
            layout.Children.Add(rsimage1);
            layout.Children.Add(subheader3);
            layout.Children.Add(header2);
            layout.Children.Add(text4);
            layout.Children.Add(text5);
            layout.Children.Add(rsimage2);

            var disclaimer1 = DisclaimerTextLayout;
            disclaimer.Children.Clear();
            var disc2 = new Label { Text = "Last Updated: 11/13/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 13 };
            var disc3 = new Label { Text = "For current regulations information, please visit", TextColor = Color.Black, FontSize = 13 };
            var disc6 = new Label { Text = "www.outdooralabama.com/fishing/saltwater-fishing", TextColor = Color.Blue, FontSize = 13 };
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);
            disclaimer.Children.Add(disc6);
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/fishing/saltwater-fishing";
                OnAlertYesNoClicked(s, f, url);
            };
            disc6.GestureRecognizers.Add(tapGestureRecognizer);

        }
        private void Fresh_Clicked(object sender, EventArgs e)
    	{
            // sets page info when freshwater button is clicked
        	var buttons = ButtonLayout;
        	buttons.IsVisible = false;
        	var backButton = BackButtonLayout;
        	backButton.IsVisible = true;
        	var layout = RegulationsTextLayout;
        	RegulationsTextLayout.IsVisible = true;
        	layout.Children.Clear();
        	var text1 = new Label { Text = "Click on a link below to view its information: ", TextColor = Color.Black, FontSize = 17 };
            var text2 = new Label { Text = "Sliver /Jumping carp urgency", TextColor = Color.Black, TextDecorations = TextDecorations.Underline, FontSize = 16 };
        	var text2Gesture = new TapGestureRecognizer();
            text2Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/silverjumping-carp-urgency";
                OnAlertYesNoClicked(s, f, url);
            };
            text2.GestureRecognizers.Add(text2Gesture);
       	
        	var text3 = new Label { Text = "Where to fish", TextColor = Color.Black, TextDecorations = TextDecorations.Underline, FontSize = 16 };
        	
        	var text3Gesture = new TapGestureRecognizer();
            text3Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/fishattractors";
                OnAlertYesNoClicked(s, f, url);
            };
            text3.GestureRecognizers.Add(text3Gesture);
        	var text4 = new Label { Text = "Learn to Freshwater Fish", TextColor = Color.Black, TextDecorations = TextDecorations.Underline, FontSize = 16 };
        	var text4Gesture = new TapGestureRecognizer();
            text4Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/learn-freshwater-fish";
                OnAlertYesNoClicked(s, f, url);
            };
            text4.GestureRecognizers.Add(text4Gesture);
        	var text5 = new Label { Text = "Freshwater Game fish", TextColor = Color.Black, TextDecorations = TextDecorations.Underline, FontSize = 16 };
        	var text5Gesture = new TapGestureRecognizer();
            text5Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/game-fish";
                OnAlertYesNoClicked(s, f, url);
            };
            text5.GestureRecognizers.Add(text5Gesture);
        	var rsimage = new Image { Aspect = Aspect.AspectFit };
        	rsimage.Source = ImageSource.FromFile("freshwaterGameFish.jpg");
        	var text6 = new Label { Text = "Freshwater non-game fish ", TextColor = Color.Black, TextDecorations = TextDecorations.Underline, FontSize = 16 };
        	var text6Gesture = new TapGestureRecognizer();
            text6Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/non-game-fish";
                OnAlertYesNoClicked(s, f, url);
            };
            text6.GestureRecognizers.Add(text6Gesture);
        	var text7 = new Label { Text = "Freshwater fishing creel and size limits ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text7Gesture = new TapGestureRecognizer();
            text7Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/fishing/freshwater-fishing-creel-and-size-limits";
                OnAlertYesNoClicked(s, f, url);
            };
            text7.GestureRecognizers.Add(text7Gesture);
        	var text8 = new Label { Text = "Reporting freshwater fish kills ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text8Gesture = new TapGestureRecognizer();
            text8Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/reporting-freshwater-fish-kills";
                OnAlertYesNoClicked(s, f, url);
            };
            text8.GestureRecognizers.Add(text8Gesture);
        	var text9 = new Label { Text = "Aquatic plants of Alabama  ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text9Gesture = new TapGestureRecognizer();
            text9Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/aquatic-plants-alabama";
                OnAlertYesNoClicked(s, f, url);
            };
            text9.GestureRecognizers.Add(text9Gesture);
        	var rsimage1 = new Image { Aspect = Aspect.AspectFit };
        	rsimage1.Source = ImageSource.FromFile("freshwaterAquaticPlants.jpg");
        	var text10 = new Label { Text = "Aquatic Nuisance species ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text10Gesture = new TapGestureRecognizer();
            text10Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/aquatic-nuisance-species";
                OnAlertYesNoClicked(s, f, url);
            };
            text10.GestureRecognizers.Add(text10Gesture);
        	var text11 = new Label { Text = "Pond Management ", TextColor = Color.Black, TextDecorations = TextDecorations.Underline, FontSize = 16 };
        	var text11Gesture = new TapGestureRecognizer();;
            text11Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/where-fish-alabama/ponds";
                OnAlertYesNoClicked(s, f, url);
            };
            text11.GestureRecognizers.Add(text11Gesture);
        	var text12 = new Label { Text = "Public water fishing stockings ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text12Gesture = new TapGestureRecognizer();
            text12Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/public-water-fish-stockings";
                OnAlertYesNoClicked(s, f, url);
            };
            text12.GestureRecognizers.Add(text12Gesture);
        	var text13 = new Label { Text = "Licenses ", TextColor = Color.Black, TextDecorations = TextDecorations.Underline, FontSize = 16 };
        	var text13Gesture = new TapGestureRecognizer();
            text13Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/licenses/freshwater-fishing-licenses";
                OnAlertYesNoClicked(s, f, url);
            };
            text13.GestureRecognizers.Add(text13Gesture);
        	var text14 = new Label { Text = "State Records/Angler Recognition ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text14Gesture = new TapGestureRecognizer();
            text14Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/state-record-angler-recognition";
                OnAlertYesNoClicked(s, f, url);
            };
            text14.GestureRecognizers.Add(text14Gesture);
        	var text15 = new Label { Text = "Freshwater Fishing tips ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text15Gesture = new TapGestureRecognizer();
            text15Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/fishing-tips";
                OnAlertYesNoClicked(s, f, url);
            };
            text15.GestureRecognizers.Add(text15Gesture);
        	var text16 = new Label { Text = "Fishing courtesy card ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text16Gesture = new TapGestureRecognizer();
            text16Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/sites/default/files/fishing/Freshwater%20Fishing/fishingcourtesycard.pdf";
                OnAlertYesNoClicked(s, f, url);
            };
            text16.GestureRecognizers.Add(text16Gesture);
        	var text17 = new Label { Text = "First fish certificate ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text17Gesture = new TapGestureRecognizer();
            text17Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/sites/default/files/fishing/Freshwater%20Fishing/First%20Fish.pdf";
                OnAlertYesNoClicked(s, f, url);
            };
            text17.GestureRecognizers.Add(text17Gesture);
        	var text18 = new Label { Text = "Contacts - Freshwater fishing ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text18Gesture = new TapGestureRecognizer();
            text18Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing/fisheries-section-technical-staff";
                OnAlertYesNoClicked(s, f, url);
            };
            text18.GestureRecognizers.Add(text18Gesture);
        	var text19 = new Label { Text = "Freshwater Fishing license plate ", TextDecorations = TextDecorations.Underline, TextColor = Color.Black, FontSize = 16 };
        	var text19Gesture = new TapGestureRecognizer();
            text19Gesture.Tapped += (s, f) =>
            {
                string url = "https://www.outdooralabama.com/freshwater-fishing-license/freshwater-fishing-license-plate";
                OnAlertYesNoClicked(s, f, url);
            };            
        	text19.GestureRecognizers.Add(text19Gesture);
        	var rsimage2 = new Image { Aspect = Aspect.AspectFit };
        	rsimage2.Source = ImageSource.FromFile("freshwaterLicensePlate.jpg");
      	
        	layout.Children.Add(text1);
        	layout.Children.Add(text2);
        	layout.Children.Add(text3);
        	layout.Children.Add(text4);
        	layout.Children.Add(text5);
        	layout.Children.Add(rsimage);
        	layout.Children.Add(text6);
        	layout.Children.Add(text7);
        	layout.Children.Add(text8);
        	layout.Children.Add(text9);
        	layout.Children.Add(rsimage1);
        	layout.Children.Add(text10);
        	layout.Children.Add(text11);
        	layout.Children.Add(text12);
        	layout.Children.Add(text13);
        	layout.Children.Add(text14);
        	layout.Children.Add(text15);
        	layout.Children.Add(text16);
        	layout.Children.Add(text17);
        	layout.Children.Add(text18);
        	layout.Children.Add(text19);
        	layout.Children.Add(rsimage2);

        	var disclaimer = DisclaimerTextLayout;
        	disclaimer.Children.Clear();
        	var disc1 = new Label { Text = "Last Updated: 11/13/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
        	var disc2 = new Label { Text = "For current safety information, please visit", TextColor = Color.Black, FontSize = 16 };
        	var disc6 = new Label { Text = "www.outdooralabama.com/fishing/freshwater-fishing", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };
        	disclaimer.Children.Add(disc1);
        	disclaimer.Children.Add(disc2);
        	disclaimer.Children.Add(disc6);
        	var tapGestureRecognizer = new TapGestureRecognizer();
        	tapGestureRecognizer.Tapped += (s, f) =>
        	{
                string url = "https://www.outdooralabama.com/fishing/freshwater-fishing";
                OnAlertYesNoClicked(s, f, url);
        	};

            

        	disc6.GestureRecognizers.Add(tapGestureRecognizer);
    	}
    	private void Back_Clicked(object sender, EventArgs e)
    	{
            // changes layout to home page when user clicks back button
        	var layout = RegulationsTextLayout;
        	layout.IsVisible = false;
        	var buttons = ButtonLayout;
        	buttons.IsVisible = true;
        	var backButton = BackButtonLayout;
        	backButton.IsVisible = false;
    	}

        // allows user to determine whether or not they want to exit the application and open a website 
        async void OnAlertYesNoClicked(object sender, EventArgs e, string url)
        {
            bool answer = await DisplayAlert("Leave Marine Application Platform?", "The app is trying to open an app outside of Marine Application Platform. Are you sure you want to open it?", "Yes", "No");

            if (answer == true)
            {

                await Launcher.OpenAsync(new System.Uri(url));
            }
            else
            {

            }
        }
    }



}


