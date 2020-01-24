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
    public partial class Page3 : ContentPage
    {


        public Page3()
        {
            InitializeComponent();

            //Sets back button to "false" because the back button isn't needed when safety tab is intitially clicked.
            var backButton = BackButtonLayout;
            backButton.IsVisible = false;

            Button pfd = PfdButton;
            pfd.Clicked += Pfd_Clicked;            

            Button emergency = CutOffButton;
            emergency.Clicked += Emergency_Clicked;

            Button ditch = DitchBagButton;
            ditch.Clicked += Ditch_Clicked;

            Button flame = FlameButton;
            flame.Clicked += Flame_Clicked;

            Button federal = FedButton;
            federal.Clicked += Federal_Clicked;

            Button fire = FireButton;
            fire.Clicked += Fire_Clicked;

            Button diver = DiverButton;
            diver.Clicked += Diver_Clicked;

            Button light = LightButton;
            light.Clicked += Light_Clicked;

            Button coast = CoastGuardButton;
            coast.Clicked += Coast_Clicked;

            Button distress = DistressButton;
            distress.Clicked += Distress_Clicked;

            Button back = BackButton;
            back.Clicked += Back_Clicked;

       
          

        }

        //Code to activate back button.
        private void Back_Clicked(object sender, EventArgs e)
        {
            var layout = TextLayout;
            layout.IsVisible = false;
            var buttons = ButtonLayout;
            buttons.IsVisible = true;
            var backButton = BackButtonLayout;
            backButton.IsVisible = false;

        }

        private void Distress_Clicked(object sender, EventArgs e)
        {
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            TextLayout.IsVisible = true;
            layout.Children.Clear();

            //This code links to Alabama Law Enforcement Agency's Boat Safety Checklist website.
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc2 = new Label { Text = "For current visual distress signals information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };
            //Code to display disclaimer information in footer.
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator.
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);


            //Visual Distress Signals information/content shown on VDS subtab
            var VDSHeader = new Label { Text = "Visual Distress Signals", TextColor = Color.Black, FontSize = 26 };
            var vds1 = new Label { Text = "Visual Distress Signals (VDSs) allow boat operators to signal for help in the event of an emergency.", TextColor = Color.Black, FontSize = 16 };
            var vds2 = new Label { Text = "VDSs are classified as day signals (visible in bright sunlight), night signals (visible at night) or both day and night signals.", TextColor = Color.Black, FontSize = 16 };
            var vds3 = new Label { Text = "VDSs are either pyrotechnic (smoke and flames) or non-pyrotechnic (non-combustible).", TextColor = Color.Black, FontSize = 16 };

            //Visual Distress Signal Image that has examples of Pyrotechnic and Non-Pyrotechnic VDS
            var vdsImage = new Image { Aspect = Aspect.AspectFit };
            vdsImage.Source = ImageSource.FromFile("USCoastGuardApprovedVisualDistressSignals.PNG");

            //Waving Arms Visual Distress Signal Image 
            var armVds = new Image { Aspect = Aspect.AspectFit };
            armVds.Source = ImageSource.FromFile("ArmSignalVisualDistressSignal.PNG");

            //Code to display VDS information/content and images.
            layout.Children.Add(VDSHeader);
            layout.Children.Add(vds1);
            layout.Children.Add(vds2);
            layout.Children.Add(vds3);
            layout.Children.Add(vdsImage);
            layout.Children.Add(armVds);

        }

        private void Coast_Clicked(object sender, EventArgs e)
        {
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            TextLayout.IsVisible = true;
            layout.Children.Clear();

            //This code links to Alabama Law Enforcement Agency's Boat Safety Checklist website.
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc2 = new Label { Text = "For current coast guard emergency contact information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "www.uscg.mil/home/Unit-Display/Article/1561446/southeast-d7/", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };
            
            //Code to display disclaimer information in footer.
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator.
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.uscg.mil/home/Unit-Display/Article/1561446/southeast-d7/";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);


            //Coast Guard Emergency Contact information/content shown on CGEC subtab
            var CGECHeader = new Label { Text = "Coast Guard Emergency Contact", TextColor = Color.Black, FontSize = 26 };
            var cgec1 = new Label { Text = "Seventh District Command Center Number: \n(305) 415-6800", TextColor = Color.Black, FontSize = 16 };
            var cgec2 = new Label { Text = "*For maritime emergency use only.*", TextColor = Color.Black, FontSize = 12 };

            //Code to display CGEC information/content and images.
            layout.Children.Add(CGECHeader);
            layout.Children.Add(cgec1);
            layout.Children.Add(cgec2);


        }


        private void Light_Clicked(object sender, EventArgs e)
        {

            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            TextLayout.IsVisible = true;
            layout.Children.Clear();

            //This code links to Alabama Law Enforcement Agency's Boat Safety Checklist website.
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc2 = new Label { Text = "For current light and sound devices information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };

            //Code to display disclaimer information in footer.
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator.
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);

            //Lights and Sound Devices information/content.
            var LightsHeader = new Label { Text = "Lights", TextColor = Color.Black, FontSize = 26 };
            var lights1 = new Label { Text = "All vessels must be equipped with prescribed navigation lights when operated at night in accordance with the Boating Safety Laws.", TextColor = Color.Black, FontSize = 16 };
            var lights2 = new Label { Text = "Operators of all vessels must comply with the requirements for the type and use of lights when anchored or underway from sunset to sunrise. \n", TextColor = Color.Black, FontSize = 16 };
           
            var SoundDevicesHeader = new Label { Text = "Sound Devices", TextColor = Color.Black, FontSize = 26 };
            var soundDevices1 = new Label { Text = "All vessels 4.9 meters (16 feet) or more in length must have on board the proper signal device for use during nighttime operation or inclement weather where visibility is greatly reduced.", TextColor = Color.Black, FontSize = 16 };

            //This code was used to add a blank space when needed.
            var space = new Label { Text = "\n" };

            //Navigation Lights Image
            var lightsImage = new Image { Aspect = Aspect.AspectFit };
            lightsImage.Source = ImageSource.FromFile("NavigationLights.jpg");

            //Sound Devices Image
            var sdImage = new Image { Aspect = Aspect.AspectFit };
            sdImage.Source = ImageSource.FromFile("SoundDevicesE.PNG");

            //Code to display Lights information/content and images.
            layout.Children.Add(LightsHeader);
            layout.Children.Add(lights1);
            layout.Children.Add(lights2);
            layout.Children.Add(lightsImage);
            layout.Children.Add(space);

            //Code to display Sound Devices information/content and images.
            layout.Children.Add(SoundDevicesHeader);
            layout.Children.Add(soundDevices1);
            layout.Children.Add(sdImage);


        }

        private void Diver_Clicked(object sender, EventArgs e)
        {
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            TextLayout.IsVisible = true;
            layout.Children.Clear();

            //This code links to Alabama Law Enforcement Agency's Boat Safety Checklist website.
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc2 = new Label { Text = "For current diver's flag information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };

            //Code to display disclaimer information in footer.
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);

            //Diver's Flag information/content.
            var DiversFlagHeader = new Label { Text = "Divers' Flag", TextColor = Color.Black, FontSize = 26 };
            var df1 = new Label { Text = "The diver's flag will be at least 300 mm (12 inches) square, colored red with a white 500 mm (2 inches) stripe running diagonally from the top staff corner to the bottom fly corner. Boat owners will stay at least 30.5 meters (100 feet) away from the displayed flag.", TextColor = Color.Black, FontSize = 16 };
            var df2 = new Label { Text = "Scuba divers and snorkelers should not place a flag in an area already occupied by other boaters or where their diving operation will impede the normal flow of waterway traffic. Divers also should follow all of the water safety rules themselves.", TextColor = Color.Black, FontSize = 16 };

            //This code was used to add a blank space when needed.
            var space = new Label { Text = "\n" };
            
            //Diver's Flags Image
            var diversFlagImage = new Image { Aspect = Aspect.AspectFit };
            diversFlagImage.Source = ImageSource.FromFile("DiversFlags.PNG");

            //Code to display Diver's Flag information/content and images.
            layout.Children.Add(DiversFlagHeader);
            layout.Children.Add(df1);
            layout.Children.Add(space);
            layout.Children.Add(diversFlagImage);
            layout.Children.Add(space);
            layout.Children.Add(df2);
            layout.Children.Add(space);

        }

        private void Fire_Clicked(object sender, EventArgs e)
        {
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            TextLayout.IsVisible = true;
            layout.Children.Clear();
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();

            // //This code links to Alabama Law Enforcement Agency's Boat Safety Checklist website
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc2 = new Label { Text = "For current fire extinguishers information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };

            //Code to display disclaimer information in footer.
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator.
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);

            //Fire extinguishers Signals information/content.
            var FireExtinguishersHeader = new Label { Text = "Fire Extinguishers", TextColor = Color.Black, FontSize = 26 };
            var fireExt1 = new Label { Text = "All vessels, as herein designated, must be equipped with a serviceable U. S. Coast Guard approved fire extinguisher of the type and capacity indicated:", TextColor = Color.Black, FontSize = 16 };
            var fireExt2 = new Label { Text = "1. All inboard and inboard/outboard vessels, regardless of size, and all motor vessels having closed compartments wherein portable fuel tanks are stored or having permanently installed fuel tanks shall have a hand portable or semi-portable fire extinguisher using carbon dioxide (CO2), foam, or other chemical ingredients such as is commonly used for extinguishing gasoline fires or petroleum product fires. Such fire extinguisher shall be approved by the U.S. Coast Guard.", TextColor = Color.Black, FontSize = 16 };
            var fireExt3 = new Label { Text = "2. All vessels equipped with any butane gas, propane gas, kerosene, gasoline or petroleum product consuming device except outboard motors, such as a stove or lantern shall have a hand portable or semi-portable fire extinguisher using carbon dioxide (CO2), foam, or other chemical ingredient such as is commonly used for extinguishing a fire produced by the use of such device. Such fire extinguisher shall be approved by the U.S. Coast Guard.", TextColor = Color.Black, FontSize = 16 }; 
            var fireExt4 = new Label { Text = "3. All motor vessels having closed or semi-closed cabins and any vessel with sleeping accommodations shall have a hand portable fire extinguisher or semi-portable fire extinguisher using carbon dioxide (CO2), foam, or other chemical ingredients such as is commonly used for extinguishing fires. Such fire extinguisher shall be approved by the U.S. Coast Guard. \n\n", TextColor = Color.Black, FontSize = 16 };
            var space = new Label { Text = "\n", FontSize = 16, TextColor = Color.Black };
            var fireExt5 = new Label { Text = "To check this style of extinguisher, depress the green button. If it is fully charged, the green button should pop back out immediately. ", FontSize = 16, TextColor = Color.Black};
            var fireExt6 = new Label { Text = "On this style of fire extinguisher, the needle indicator should be in the 'full' range." , TextColor = Color.Black, FontSize = 16};
           
            //Fire Extinguisher Images
            var fireExtImage1 = new Image { Aspect = Aspect.AspectFit };
            fireExtImage1.Source = ImageSource.FromFile("FireExtinguisher1.PNG");


            var fireExtImage2 = new Image { Aspect = Aspect.AspectFit };
            fireExtImage2.Source = ImageSource.FromFile("FireExtinguisher2.PNG");


            //Code to display Fire Extinguishers information/content and images.
            layout.Children.Add(FireExtinguishersHeader);
            layout.Children.Add(fireExt1);           
            layout.Children.Add(fireExt2);
            layout.Children.Add(fireExt3);
            layout.Children.Add(fireExt4);
            layout.Children.Add(space);
            
            layout.Children.Add(fireExtImage1);
            layout.Children.Add(fireExt5);
            layout.Children.Add(space);
            layout.Children.Add(space);
            layout.Children.Add(fireExtImage2);
            layout.Children.Add(fireExt6);
            layout.Children.Add(space);
        }

        private void Federal_Clicked(object sender, EventArgs e)
        {
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            layout.IsVisible = true;
            layout.Children.Clear();
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();

            //This code links to Alabama Law Enforcement Agency's Boat Safety Checklist website.
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc2 = new Label { Text = "For current federally controlled waters information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };

            //Code to display disclaimer information in footer.
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator.
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);

            //Federally Controlled Waters information/content.
            var FDWHeader = new Label { Text = "Federally Controlled Waters", TextColor = Color.Black, FontSize = 26 };
            var fdw1 = new Label { Text = "Boat and PWC operators must observe federal regulations when boating on:", TextColor = Color.Black, FontSize = 16 };
            var fdw2 = new Label { Text = "\t - Coastal Waters", TextColor = Color.Black, FontSize = 15 };
            var fdw3 = new Label { Text = "\t - The Great Lakes", TextColor = Color.Black, FontSize = 15 };
            var fdw4 = new Label { Text = "\t - Territorial Seas", TextColor = Color.Black, FontSize = 15 };
            var fdw5 = new Label { Text = "Waters which are two miles wide or wider and are connected to one of the above.", TextColor = Color.Black, FontSize = 16 };

            //Code to display FCW information/content and images.
            layout.Children.Add(FDWHeader);
            layout.Children.Add(fdw1);
            layout.Children.Add(fdw2);
            layout.Children.Add(fdw3);
            layout.Children.Add(fdw4);
            layout.Children.Add(fdw5);

        }

        private void Flame_Clicked(object sender, EventArgs e)
        {
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            TextLayout.IsVisible = true;
            layout.Children.Clear();
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();

            //This code links to Alabama Law Enforcement Agency's Boat Safety Checklist website.
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc2 = new Label { Text = "For current flame arrestors information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };

            //Code to display disclaimer information in footer.
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator.
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);


            //Flame Arrestors information/content.
            var FlameArrestorsHeader = new Label { Text = "Flame Arrestors", TextColor = Color.Black, FontSize = 26 };
            var fa1 = new Label { Text = "Every motorboat using gasoline as fuel, except outboard motors, shall have the carburetor or carburetors of every engine therein equipped with a U. S. Coast Guard approved flame arrestor or backfire trap.", TextColor = Color.Black, FontSize = 16 };


            //Flame Arrestor Image
            var faimage = new Image { Aspect = Aspect.AspectFit };
            faimage.Source = ImageSource.FromFile("FlameArrestor.PNG");

            layout.Children.Add(FlameArrestorsHeader);
            layout.Children.Add(fa1);
            layout.Children.Add(faimage);
        }

        private void Ditch_Clicked(object sender, EventArgs e)
        {
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            TextLayout.IsVisible = true;
            layout.Children.Clear();

            //This code links to United States Coast Guard - Boating Safety Ditch Bag website.
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 13 };
            var disc2 = new Label { Text = "For current ditch bag information, please visit", TextColor = Color.Black, FontSize = 13 };
            var disc3 = new Label { Text = "www.boatingsafetymag.com/boatingsafety/assembling-ditch-bag", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 13 };
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator.
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.boatingsafetymag.com/boatingsafety/assembling-ditch-bag";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);

            //Ditch Bag information/content.
            var DitchBagHeader = new Label { Text = "Ditch Bag Information", TextColor = Color.Black, FontSize = 26 };
            var db1 = new Label { Text = "When you prepare your ditch bag, here's what to look for: \n", TextColor = Color.Black, FontSize = 18 };
            var db2 = new Label { Text = "- VHF RADIO should be waterproof like the Lowrance unit at right above. \n", TextColor = Color.Black, FontSize = 16 };
            var db3 = new Label { Text = "- PLB such as the Aqualink View activates on command to communicate a position to appropriate rescuers.\n", TextColor = Color.Black, FontSize = 16 };
            var db4 = new Label { Text = "- FLARES should be part of your safety kit and are required by law in most federally patrolled water. If you leave the boat, take them with you.\n", TextColor = Color.Black, FontSize = 16 };
            var db5 = new Label { Text = "- STROBES like the ACR C-Strobe can save precious time when activated. \n", TextColor = Color.Black, FontSize = 16 };
            var db6 = new Label { Text = "- POWERFLARE SAFETY LIGHT and strobes like this (in red case, bottom right) emit SOS or flashing lights to alert rescue personnel.\n", TextColor = Color.Black, FontSize = 16 };
            var db7 = new Label { Text = "- SIGNAL MIRRORS can alert rescue personnel in bright daylight, cost practically nothing and are recommended by the USCG.\n", TextColor = Color.Black, FontSize = 16 };
            var db8 = new Label { Text = "- WHISTLES are great at attracting rescue personnel when visibility is poor.\n", TextColor = Color.Black, FontSize = 16 };
            var db9 = new Label { Text = "- ROPE can keep the crew together should a lifeboat not be available.\n", TextColor = Color.Black, FontSize = 16 };
            var db10 = new Label { Text = "- A GERBER HINDERER serrated blunt-point knife is less likely to puncture a life raft and will make quick work of slicing ropes or bandages.\n", TextColor = Color.Black, FontSize = 16 };
            var db11 = new Label { Text = "- FIRST AID KITS should include a ready supply of essential medications you may need on a frequent basis.\n", TextColor = Color.Black, FontSize = 16 };
            var db12 = new Label { Text = "- DRINKING WATER should be accompanied by a measuring device to carefully apportion it to maintain life and morale.\n", TextColor = Color.Black, FontSize = 16 };
            var db13 = new Label { Text = "- SUNSCREEN and Dramamine can ease discomfort adrift.\n", TextColor = Color.Black, FontSize = 16 };
            var db14 = new Label { Text = "- CASH and a copy of your passport in a sandwich bag can facilitate a return to America from foreign waters.\n", TextColor = Color.Black, FontSize = 16 };

            //Code for ditch bag image
            var ditchbag = new Image { Aspect = Aspect.AspectFit };
            ditchbag.Source = ImageSource.FromFile("ditchbag.jpg");

            //Code to display Ditch Bag information/content and images.
            layout.Children.Add(DitchBagHeader);
            layout.Children.Add(db1);
            layout.Children.Add(db2);
            layout.Children.Add(db3);
            layout.Children.Add(db4);
            layout.Children.Add(db5);
            layout.Children.Add(db6);
            layout.Children.Add(db7);
            layout.Children.Add(db8);
            layout.Children.Add(db9);
            layout.Children.Add(db10);
            layout.Children.Add(db11);
            layout.Children.Add(db12);
            layout.Children.Add(db13);
            layout.Children.Add(ditchbag);
        }

        private void Emergency_Clicked(object sender, EventArgs e)
        {
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            TextLayout.IsVisible = true;
            layout.Children.Clear();
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();

            //This code links to Alabama Law Enforcement Agency's Boat Safety Checklist website.
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc2 = new Label { Text = "For current emergency cut-off switch information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };

            //Code to display disclaimer information in footer.
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);

            //Emergency Cut-Off Switch information/content
            var ECOSHeader = new Label { Text = "Emergency Cut-Off Switch", TextColor = Color.Black, FontSize = 26 };
            var ecos1 = new Label { Text = "No person shall operate or give permission to operate any vessel less than 7.3 meters (24 feet) in length, having an open cockpit and having more than fifty (50) horsepower, unless the said vessel is equipped with an emergency engine or motor shut-off switch.", TextColor = Color.Black, FontSize = 16 };
            var ecos2 = new Label { Text = "The shut-off switch shall be a lanyard-type and shall be attached to the person, clothing, or personal flotation device of the operator. It shall be installed so that when any removal of the operator from the normal operating station will result in the immediate shut-off of the engine.", TextColor = Color.Black, FontSize = 16 };
            var ecos3 = new Label { Text = "Any person operating a personal watercraft that does not have self-circling capabilities must have a lanyard-type engine shut-off switch, which must be attached to the person, clothing, or personal flotation device of the operator. \n", TextColor = Color.Black, FontSize = 16 };

            //This code was used to add a blank space when needed.
            var space = new Label { Text = "\n", TextColor = Color.Black, FontSize = 12 };
            
            //Code for Emergency Cut-Off Switch image.
            var ecosimage = new Image { Aspect = Aspect.AspectFit };
            ecosimage.Source = ImageSource.FromFile("EmergencyCutOffSwitch.jpg");

            //Code to display Emergency Cut-Off Switch information/content and images.
            layout.Children.Add(ECOSHeader);
            layout.Children.Add(ecos1);
            layout.Children.Add(ecos2);
            layout.Children.Add(ecos3);
            layout.Children.Add(ecosimage);
        }

        private void Pfd_Clicked(object sender, EventArgs e)
        {
            var buttons = ButtonLayout;
            buttons.IsVisible = false;
            var backButton = BackButtonLayout;
            backButton.IsVisible = true;
            var layout = TextLayout;
            TextLayout.IsVisible = true;
            layout.Children.Clear();

            //This code links to Alabama Law Enforcement Agency's Boat Safety Checklist website.
            var disclaimer = DisclaimerTextLayout;
            disclaimer.Children.Clear();
            var disc1 = new Label { Text = "Last Updated: 11/18/2019", TextColor = Color.Black, FontAttributes = FontAttributes.Italic, FontSize = 16 };
            var disc2 = new Label { Text = "For current personal flotation devices information, please visit", TextColor = Color.Black, FontSize = 16 };
            var disc3 = new Label { Text = "www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama", TextDecorations = TextDecorations.Underline, TextColor = Color.Blue, FontSize = 16 };

            //Code to display disclaimer information in footer.
            disclaimer.Children.Add(disc1);
            disclaimer.Children.Add(disc2);
            disclaimer.Children.Add(disc3);

            //This code below activates the website link when tapped on emulator.
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, f) =>
            {
                string url = "https://www.alea.gov/dps/marine-patrol/boat-equipment-checklist-alabama";
                OnAlertYesNoClicked(s, f, url);
            };
            disc3.GestureRecognizers.Add(tapGestureRecognizer);


            //Personal Flotation Devices information/content.
            var PFDHeader = new Label { Text = "Personal Flotation Devices", TextColor = Color.Black, FontSize = 26 };

            var pfd1 = new Label { Text = "Vessels less than 4.9 meters (16 feet) in length will have aboard a type I, II, III, or V personal flotation device for each person.Vessels 4.9 meters (16 feet) and over in length shall have aboard a type I, II, III, or V personal flotation device for each person and at least one type IV on board as a throwable device. Each person operating, riding on, or being towed by a personal watercraft must wear a personal flotation device approved by the U.S.Coast Guard.\n", TextColor = Color.Black, FontSize = 16 };
            var pfd2 = new Label { Text = "All persons under eight (8) years of age, on any vessel, must, at all times, wear a U. S. Coast Guard approved personal flotation device that must be strapped, snapped, or zipped securely in place; except, that no personal flotation device should be required when inside an enclosed cabin or enclosed sleeping space. \n", TextColor = Color.Black, FontSize = 16 };

            var pfd3 = new Label { Text = "CAUTION: ", TextColor = Color.Red, FontSize = 16 };
            var pfd4 = new Label { Text = "Personal flotation devices must be accessible and of the proper size. Those that are torn, rotted, or damaged, lose their approval. \n", TextColor = Color.Black, FontSize = 16 };

            var pfd5 = new Label { Text = "CAUTION: ", TextColor = Color.Red, FontSize = 16 };
            var pfd6 = new Label { Text = "A type V personal flotation device is a PFD approved for restricted uses. Type V PFD's must be worn in open boats and when on the deck of larger boats in order to be classified as U. S. Coast Guard approved. \n", TextColor = Color.Black, FontSize = 16 };

            //Code for types of personal flotation devices images.
            var pfdImage = new Image { Aspect = Aspect.AspectFit };
            pfdImage.Source = ImageSource.FromFile("PFDTypes.jpg");

            //Code to display PFD information/content and images.
            layout.Children.Add(PFDHeader);
            layout.Children.Add(pfd1);
            layout.Children.Add(pfd2);
            layout.Children.Add(pfdImage);
            layout.Children.Add(pfd3);
            layout.Children.Add(pfd4);
            layout.Children.Add(pfd5);
            layout.Children.Add(pfd6);          
        }
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

