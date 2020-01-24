using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.Portal;
using Esri.ArcGISRuntime.UI.Controls;
using Esri.ArcGISRuntime.Xamarin.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Android.OS;
using System.IO;
using Esri.ArcGISRuntime.Ogc;
using Android.Content;

namespace MAPP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        // Declare map variables
        Esri.ArcGISRuntime.Mapping.Map myMap = new Esri.ArcGISRuntime.Mapping.Map(BasemapType.LightGrayCanvasVector, 25.3043, -90.0659, 4);
        MapViewModel _mapViewModel = new MapViewModel();
        MapView _mapView;

        // Declare wms layer variables
        private readonly List<string> wmsLayerNames = new List<string> { "1" };
        private readonly List<string> r3 = new List<string> { "19" };
        private readonly List<string> c1 = new List<string> { "Land"};
        private readonly List<string> c2 = new List<string> { "Coastlines" };
        private readonly List<string> c3 = new List<string> { "LakesAndRivers" };
        private readonly List<string> c4 = new List<string> { "Nations" };
        private readonly List<string> c5 = new List<string> { "States" };
        private readonly List<string> c6 = new List<string> { "erdVH2018chla1day:chla" };
        private readonly List<string> c7 = new List<string> { "LandMask" };


        public Page1()
        {
            InitializeComponent();

            // Get MapView from the view and assign map from view-model
            _mapView = MyMapView;
            _mapView.Map = myMap;

            // Listen for changes on the view model
            _mapViewModel.PropertyChanged += MapViewModel_PropertyChanged;
            
            // Declare and initialize functions for when buttons are clicked
            Button wind = WindButton;
            wind.Clicked += Wind_Clicked;

            Button water = WaterButton;
            water.Clicked += Water_Clicked;

            Button chlorophyll = ChlorophyllButton;
            chlorophyll.Clicked += Chlorophyll_Clicked;

            Button reef = ReefButton;
            reef.Clicked += Reef_Clicked;

            Button wave = WaveButton;
            wave.Clicked += Wave_Clicked;


            // Declare and initialize functions for when menu option is selected
            Picker optionPicker = MapOptionsLayout;
            var optionsList = new List<string>();
            optionsList.Add("NDBC Buoys");
            optionsList.Add("Tide Predictions");
            optionsList.Add("No Overlays");
            optionPicker.ItemsSource = optionsList;

            optionPicker.SelectedIndexChanged += OnPickerSelectedIndexChanged;

        }



        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            _mapView.GraphicsOverlays.Clear();
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            // call functions based on picker selection
            if(selectedIndex == 0)
            {
                _mapView.GraphicsOverlays.Clear();
                BuoySelected();
            }

            else if(selectedIndex == 1)
            {
                _mapView.GraphicsOverlays.Clear();
                WaveSelected();
            }

            else if (selectedIndex == 2)
            {
                _mapView.GraphicsOverlays.Clear();
                ClearSelected();
            }
        }

        public void ClearSelected()
        {
            //clear all map overlays
            _mapView.GraphicsOverlays.Clear();
        }

        public void BuoySelected()
        {
            // clear all existing map overlays
            _mapView.GraphicsOverlays.Clear();
            
            //get Buoy Data
            string buoyData = " ";
            buoyData = getBuoyData();
            InitializeMarkers(buoyData);

            // get buoy information every five minutes
            Device.StartTimer(TimeSpan.FromMinutes(5), () =>
            {
                InitializeMarkers(buoyData);

                return true;
            });

        }


        private void LaunchSelected()
        {
            _mapView.GraphicsOverlays.Clear();
        }

        private async void WaveSelected()
        {
            
            // clear existing overlays
            _mapView.GraphicsOverlays.Clear();
            
            //tide prediction array
            string[,] tidePrediction = new string[,]{
                            //Alabama
                            {"30.2786", "-87.5550", "8730667" },
                            {"30.2333", "-88.0200", "8734635" },
                            {"30.2799", "-87.6843", "8731439" },
                            {"30.3033", "-87.7350", "8731952"},
                            {"30.2500", "-88.0750", "8735180" },
                            {"30.4436", "-88.1139", "8735523" },
                            {"30.3766", "-88.1586", "8738043" },
                            {"30.4866", "-87.9345", "8733821" },
                            {"30.5652", "-88.0880", "8735391" },
                            {"30.6483", "-88.0583", "8736897" },
                            {"30.6672", "-87.9364", "8733839" },
                            {"30.7083", "-88.0433", "8737048" },
                            {"30.7819", "-88.0736", "8737138" },
                            {"30.8183", "-87.9150", "8737182" },
                            {"30.3717", "-88.2750", "8739051" },
                            {"30.4057", "-88.2477", "8739803" },

                            //Mississippi
                            {"30.4132", "-88.4029", "8740166" },
                            {"30.3867", "-88.4400", "8740448" },
                            {"30.3867", "-88.7733", "8743081" },
                            {"30.2033", "-88.4417", "8740405" },
                            {"30.2133", "-88.9717", "8740405" },
                            {"30.2383", "-88.6667", "8742221" },
                            {"30.3478", "-88.5058", "8741041" },
                            {"30.3400", "-88.5333", "8741196" },
                            {"30.3617", "-88.6633", "8742205" },
                            {"30.3600", "-89.0817", "8745557" },
                            {"30.3900", "-88.8567", "8743735" },
                            {"30.4267", "-89.0533", "8745375" },
                            {"30.4067", "-89.0267", "8745101" },
                            {"30.2317", "-89.1167", "8745799" },
                            {"30.3100", "-89.2450", "8746819" },
                            {"30.3583", "-89.2733", "8748038" },
                            {"30.3250", "-89.3250", "8747437" },
                            {"30.2817", "-89.3667", "8747766" },
                            {"30.2400", "-89.6150", "8749704" },

                            //Louisiana
                            {"30.1667", "-89.7367", "8761402" },
                            {"30.2717", "-89.7933", "8761473" },
                            {"30.3783", "-90.1600", "8761993" },
                            {"30.0272", "-90.1133", "8761927" },
                            {"30.0650", "-89.8000", "8761487" },
                            {"30.0067", "-89.9367", "8761678" },
                            {"29.8681", "-89.6732", "8761305" },
                            {"30.1267", "-89.2217", "8760668" },
                            {"30.0483", "-88.8717", "8760172" },
                            {"29.8233", "-89.2700", "8760742" },
                            {"29.5983", "-89.6183", "8761108" },
                            {"29.4933", "-89.1733", "8760595" },
                            {"29.3667", "-89.3450", "8760841" },
                            {"29.2283", "-89.0500", "8760424" },
                            {"29.3866", "-89.3801", "8760889" },
                            {"30.0000", "-89.9333", "8760412"},
                            {"29.2633", "-89.9567", "8761724"},
                            {"29.2667", "-89.9667", "TEC4455"},
                            {"29.3100", "-89.9383", "8761677"},
                            {"29.3183", "-89.9800", "8761742"},
                            {"29.4267", "-89.9767", "8761732"},
                            {"29.6667", "-90.1117", "8761899"},
                            {"29.2100", "-90.0400", "8761826"},
                            {"29.1142", "-90.1993", "8762075"},
                            {"29.2483", "-90.2117", "8762084"},
                            {"29.3733", "-90.2650", "8762184"},
                            {"29.0867", "-90.5267", "8762675"},
                            {"29.0767", "-90.2850", "8762223"},
                            {"29.1283", "-90.4233", "8762481"},
                            {"29.0783", "-90.5867", "8762850"},
                            {"29.2450", "-90.6617", "8762928"},
                            {"29.0717", "-90.6400", "8762888"},
                            {"29.0633", "-90.8067", "8763206"},
                            {"29.0633", "-90.9617", "8763506"},
                            {"29.1748", "-90.9764", "8763535"},
                            {"29.3675", "-91.3839", "8764314"},
                            {"29.3333", "-91.3533", "8764256"},
                            {"29.4733", "-91.3050", "8764165"},
                            {"29.7433", "-91.2300", "8764025"},
                            {"29.5183", "-91.5550", "8764634"},
                            {"29.4200", "-91.5933", "8764706"},
                            {"29.4850", "-91.7633", "8765026"},
                            {"29.5233", "-92.0433", "8765568"},
                            {"28.9150", "-91.0717", "8763719"},
                            {"29.7350", "-91.7133", "8764931"},
                            {"29.5800", "-92.0350", "8765551"},
                            {"29.7134", "-91.8800", "8765251"},
                            {"29.8372", "-91.8375", "8765148"},
                            {"29.5517", "-92.3052", "8766072"},
                            {"29.7500", "-93.1000", "TEC4495"},
                            {"29.7682", "-93.3429", "8768094"},
                            {"30.1902", "-93.3008", "8767961"},
                            {"30.2236", "-93.2217", "8767816"},

                            //Texas

                            {"29.7284", "-93.8701", "8770570"},
                            {"29.6894", "-93.8419", "8770822"},
                            {"29.8671", "-93.9310", "8770475"},
                            {"29.9800", "-93.8817", "8770520"},
                            {"29.3573", "-94.7248", "8771341"},
                            {"29.3267", "-94.6933", "8771416"},
                            {"29.3100", "-94.7933", "8771450"},
                            {"29.3650", "-94.7800", "8771328"},
                            {"29.3833", "-94.8833", "TEC4513"},
                            {"29.4800", "-94.9183", "8771013"},
                            {"29.5633", "-95.0667", "8770933"},
                            {"29.6817", "-94.9850", "8770613"},
                            {"29.7649", "-95.0789", "8770733"},
                            {"29.7262", "-95.2658", "8770777"},
                            {"29.7133", "-94.6900", "8770559"},
                            {"29.6800", "-94.8683", "8770625"},
                            {"29.7400", "-94.8317", "8770557"},
                            {"29.5156", "-94.5106", "8770971"},
                            {"29.5947", "-94.3903", "8770808"},
                            {"29.5167", "-94.4833", "TEC4525"},
                            {"29.3026", "-94.8971", "8771486"},
                            {"29.2000", "-94.9850", "8771721"},
                            {"29.1667", "-95.1250", "8771801"},
                            {"29.0810", "-95.1313", "8771972"},
                            {"29.0417", "-95.1750", "8772132"},
                            {"29.2853", "-94.7894", "8771510"},
                            {"28.7714", "-95.6172", "8772985"},
                            {"28.9357", "-95.2942", "8772471"},
                            {"28.9483", "-95.3083", "8772440"},
                            {"28.7101", "-95.9140", "8773146"},
                            {"28.4269", "-96.3301", "8773767"},
                            {"28.4069", "-96.7124", "8773037"},
                            {"28.2283", "-96.7950", "8774230"},
                            {"28.1144", "-97.0244", "8774513"},
                            {"28.4459", "-96.3956", "8773701"},
                            {"28.6406", "-96.6098", "8773259"},
                            {"27.8328", "-97.4859", "8775244"},
                            {"27.8366", "-97.0391", "8775241"},
                            {"27.8397", "-97.0725", "8775237"},
                            {"27.5800", "-97.2167", "8775870"},
                            {"27.8149", "-97.3892", "8775296"},
                            {"27.6333", "-97.2367", "8775792"},
                            {"26.0674", "-97.1548", "8779749"},
                            {"26.0683", "-97.1567", "8779750"},
                            {"26.0783", "-97.1700", "8779724"},
                            {"26.0717", "-97.1917", "8779739"},
                            {"26.0612", "-97.2155", "8779770"},
                            {"26.0517", "-97.1817", "8779768"},
                          };

            // Create simple marker symbol for tide predictions
            SimpleMarkerSymbol tideMarker = new SimpleMarkerSymbol()
            {
                Color = Color.Blue,
                Size = 10,
                Style = SimpleMarkerSymbolStyle.Circle

            };

            // create graphics overlay
            GraphicsOverlay tideLayer = new GraphicsOverlay();

            // create graphics for each tide location
            int tideLength = tidePrediction.Length / 3;
            for (int i = 0; i < tideLength; i++)
            {
                string latLon = tidePrediction[i, 0].ToString() + " " + tidePrediction[i, 1].ToString();
                MapPoint tide = CoordinateFormatter.FromLatitudeLongitude(latLon, SpatialReferences.Wgs84);
                Graphic tideGraphic = new Graphic(tide, tideMarker);
                tideLayer.Graphics.Add(tideGraphic);
            }

            // add layer to map
            _mapView.GraphicsOverlays.Add(tideLayer);

            // method for when tide point is clicked
            _mapView.GeoViewTapped += async (s, e) =>
            {

                try
                {
                    //identify tide overlay
                    IdentifyGraphicsOverlayResult identifyResults = await _mapView.IdentifyGraphicsOverlayAsync(
                        tideLayer,
                        e.Position,
                        10d,
                        false,
                        1

                        );

                    // get user tap point
                    Geometry myGeo = GeometryEngine.Project(e.Location, SpatialReferences.Wgs84);
                    MapPoint projection = (MapPoint)myGeo;
                    CalloutDefinition myCallout;
                    int latitidueFinal = 0;

                    // compare user point to map points
                    if (identifyResults.Graphics.Count > 0)
                    {

                        string description = " ";
                        for (int i = 0; i < tideLength; i++)
                        {


                            for (int j = 1; j < 3; j++)
                            {
                                double latNDBC = Convert.ToDouble(tidePrediction[i, 0]);
                                double latNDBCRounded = Math.Round(latNDBC, 1);

                                double latClick = Convert.ToDouble(projection.Y);
                                double latClickRounded = Math.Round(latClick, 1);

                                double lowerLat = latClickRounded - .1;
                                double upperLat = latClickRounded + .1;

                                double lonNDBC = Convert.ToDouble(tidePrediction[i, 1]);
                                double lonNDBCRounded = Math.Round(lonNDBC, 1);

                                double lonClick = Convert.ToDouble(projection.X);
                                double lonClickRounded = Math.Round(lonClick, 1);

                                double lowerLon = lonClickRounded - .1;
                                double upperLon = lonClickRounded + .1;



                                if (lowerLat <= latNDBCRounded && upperLat >= latNDBCRounded && lowerLon <= lonNDBCRounded && upperLon >= lonNDBCRounded)
                                {
                                    latitidueFinal = i;

                                }
                            }

                        }



                        // create callout 
                        string title = tidePrediction[latitidueFinal, 2];
                        string latLonDescription = "Latitude: " + tidePrediction[latitidueFinal, 0] + "\n" + "Longitude: " + tidePrediction[latitidueFinal, 1] + "\n";
                        string url = "https://tidesandcurrents.noaa.gov/noaatidepredictions.html?id=" + tidePrediction[latitidueFinal, 2];
                       
                        description += latLonDescription;


                        myCallout = new CalloutDefinition(title, description);
                        _mapView.ShowCalloutAt(e.Location, myCallout);
                        

                    }
                    // if user does not click on a tide point, get rid of any existing callouts 
                    else
                    {
                        _mapView.DismissCallout();

                    }
                }
                catch (Exception ex)
                {

                }
                
            };

           

        }

        private void PullUpTide(object sender, PropertyChangedEventArgs e)
        {
            //get tide prediction information
        }

        private void MapViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Update the map view with the view model's new map
            if (e.PropertyName == "Map" && _mapView != null)
                _mapView.Map = _mapViewModel.Map;
        }

        private async void InitializeMarkers(string buoyData)
        {

            // create 2d array from buoy data string
            string newResults = Regex.Replace(buoyData, " {4,}", " ");
            string newResultsTwo = Regex.Replace(newResults, " {2,}", " ");
            char delimiter = '\n';

            String[] data = newResultsTwo.Split(delimiter);

            int length = data.Length;


            String[,] dataParsed = new String[length, 22];

            char delimiterTwo = ' ';

            for (int i = 0; i < data.Length; i++)
            {
                String[] fields = data[i].Split(delimiterTwo);

                for (int j = 0; j < fields.Length; j++)
                {
                    dataParsed[i, j] = fields[j];
                }
            }



            // Create simple marker symbol for user location
            SimpleMarkerSymbol userMarker = new SimpleMarkerSymbol()
            {
                Color = Color.Red,
                Size = 10,
                Style = SimpleMarkerSymbolStyle.Diamond

            };

            // Create simple marker symbol for buoy locations
            SimpleMarkerSymbol buoyMarker = new SimpleMarkerSymbol()
            {
                Color = Color.Black,
                Size = 10,
                Style = SimpleMarkerSymbolStyle.Circle

            };

            // Create graphics overlay for buoys
            GraphicsOverlay buoys = new GraphicsOverlay();
            buoys.Id = "BuoyLayer";

            //get user location 
            string userLat = "";
            string userLon = "";

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var userLocation = await Geolocation.GetLocationAsync(request);

                if (userLocation != null)
                {
                    userLat = userLocation.Latitude.ToString();
                    userLon = userLocation.Longitude.ToString();

                    string userLocationFormatted = userLat + " " + userLon;
                    MapPoint userMapPoint = CoordinateFormatter.FromLatitudeLongitude(userLocationFormatted, SpatialReferences.Wgs84);
                    Graphic userGraphic = new Graphic(userMapPoint, userMarker);

                    buoys.Graphics.Add(userGraphic);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception

            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            //MapPoint startingLocation;
            length = data.Length - 1;

            // create buoy marker for each location from buoy array
            for (int i = 3; i < length; i++)
            {
                if(Convert.ToDouble(dataParsed[i, 2]) > -100 && Convert.ToDouble(dataParsed[i, 2]) < -80)
                {
                    if(Convert.ToDouble(dataParsed[i, 1]) > 17 && Convert.ToDouble(dataParsed[i, 1]) < 31)
                    {
                        string location = dataParsed[i, 1] + " " + dataParsed[i, 2];
                        MapPoint startingLocation = CoordinateFormatter.FromLatitudeLongitude(location, SpatialReferences.Wgs84);

                        Graphic graphicWithBuoy = new Graphic(startingLocation, buoyMarker);
                        buoys.Graphics.Add(graphicWithBuoy);
                    }
                }

            }

            // add overlay to map
            _mapView.GraphicsOverlays.Add(buoys);

            // method for when user clicks on buoy
            _mapView.GeoViewTapped += async (s, e) =>
            {

                try
                {
                    // identify buoy layer
                    IdentifyGraphicsOverlayResult identifyResults = await _mapView.IdentifyGraphicsOverlayAsync(
                        buoys,
                        e.Position,
                        10d,
                        false,
                        1

                        );

                    Geometry myGeo = GeometryEngine.Project(e.Location, SpatialReferences.Wgs84);
                    MapPoint projection = (MapPoint)myGeo;
                    CalloutDefinition myCallout;
                    int latitidueFinal = 0;


                   //compare user click point to buoy locations from array 
                    if (identifyResults.Graphics.Count > 0)
                    {

                        string description = " ";
                        for (int i = 3; i < length; i++)
                        {


                            for (int j = 1; j < 3; j++)
                            {
                                double latNDBC = Convert.ToDouble(dataParsed[i, 1]);
                                double latNDBCRounded = Math.Round(latNDBC, 1);

                                double latClick = Convert.ToDouble(projection.Y);
                                double latClickRounded = Math.Round(latClick, 1);

                                double lowerLat = latClickRounded - .1;
                                double upperLat = latClickRounded + .1;

                                double lonNDBC = Convert.ToDouble(dataParsed[i, 2]);
                                double lonNDBCRounded = Math.Round(lonNDBC, 1);

                                double lonClick = Convert.ToDouble(projection.X);
                                double lonClickRounded = Math.Round(lonClick, 1);

                                double lowerLon = lonClickRounded - .1;
                                double upperLon = lonClickRounded + .1;


                                // find the line in the array for the buoy the user clicked on
                                if (lowerLat <= latNDBCRounded && upperLat >= latNDBCRounded && lowerLon <= lonNDBCRounded && upperLon >= lonNDBCRounded)
                                {
                                    latitidueFinal = i;

                                }
                            }

                        }


                        // translate degree number into NSWE 
                        string degrees = "";

                        double degreesDouble = Convert.ToDouble(dataParsed[latitidueFinal, 8]);
                        if(degreesDouble > 349 && degreesDouble <= 360)
                        {
                            degrees = "N";
                        }
                        else if (degreesDouble >= 0 && degreesDouble <= 11)
                        {
                            degrees = "N";
                        }
                        else if (degreesDouble > 11 && degreesDouble <= 34)
                        {
                            degrees = "NNE";
                        }
                        else if (degreesDouble > 34 && degreesDouble <=56)
                        {
                            degrees = "NE";
                        }
                        else if (degreesDouble > 56 && degreesDouble <= 79)
                        {
                            degrees = "ENE";
                        }
                        else if (degreesDouble > 79 && degreesDouble <= 101)
                        {
                            degrees = "E";
                        }
                        else if (degreesDouble > 101 && degreesDouble <= 124)
                        {
                            degrees = "ESE";
                        }
                        else if (degreesDouble > 124 && degreesDouble <= 146)
                        {
                            degrees = "SE";
                        }
                        else if (degreesDouble > 146 && degreesDouble <= 169)
                        {
                            degrees = "SSE";
                        }
                        else if (degreesDouble > 169 && degreesDouble <= 191)
                        {
                            degrees = "S";
                        }
                        else if (degreesDouble > 191 && degreesDouble <= 214)
                        {
                            degrees = "SSW";
                        }
                        else if (degreesDouble > 214 && degreesDouble <= 236)
                        {
                            degrees = "SW";
                        }
                        else if (degreesDouble > 236 && degreesDouble <= 259)
                        {
                            degrees = "WSW";
                        }
                        else if (degreesDouble > 259 && degreesDouble <= 281)
                        {
                            degrees = "W";
                        }
                        else if (degreesDouble > 281 && degreesDouble <= 304)
                        {
                            degrees = "WNW";
                        }
                        else if (degreesDouble > 304 && degreesDouble <= 326)
                        {
                            degrees = "NW";
                        }
                        else if (degreesDouble > 326 && degreesDouble <= 349)
                        {
                            degrees = "NNW";
                        }


                        

                        
                        

                        // create callout 
                        string title = dataParsed[latitidueFinal, 0];
                        string location = "Location: " + dataParsed[latitidueFinal, 1] + "N " + dataParsed[latitidueFinal, 2] + "W" + "\n";
                        string date = " Date: " + dataParsed[latitidueFinal, 3] + "/" + dataParsed[latitidueFinal, 4] + "/" + dataParsed[latitidueFinal, 5] + " " + dataParsed[latitidueFinal, 6] + ":" + dataParsed[latitidueFinal, 7] + ":00 UTC" + "\n";
                        string winds = "";

                        description += location;
                        description += date;
                        description += winds;

                        string airTemp = "";
                        string waterTemp = "";
                        string dewpoint = "";

                        if (dataParsed[latitidueFinal, 10] != "MM")
                        {
                            winds = " Winds: " + degrees + "(" + dataParsed[latitidueFinal, 8] + ") at " + dataParsed[latitidueFinal, 9] + " kt gusting to " + dataParsed[latitidueFinal, 10] + " kt" + "\n";
                            description += winds;
                        }

                        else if(dataParsed[latitidueFinal, 10] == "MM")
                        {
                            winds = " Winds: " + degrees + "(" + dataParsed[latitidueFinal, 8] + ") at " + dataParsed[latitidueFinal, 9] + " kt \n";
                            description += winds;
                        }

                        if (dataParsed[latitidueFinal, 17] != "MM") {  
                            airTemp = " Air Temperature: " + dataParsed[latitidueFinal, 17] + " F" + "\n";
                            description += airTemp;
                        }
                        if (dataParsed[latitidueFinal, 18] != "MM") { 
                            waterTemp = " Water Temperature: " + dataParsed[latitidueFinal, 18] + " F" + "\n";
                            description += waterTemp;
                        }
                        if (dataParsed[latitidueFinal, 19] != "MM") { 
                            dewpoint = " Dew Point: " + dataParsed[latitidueFinal, 19] + " F" + "\n";
                            description += dewpoint;
                        }
                        

                        myCallout = new CalloutDefinition(title, description);
                        _mapView.ShowCalloutAt(e.Location, myCallout);

                        latitidueFinal = 0;

                    }
                    else
                    {
                        _mapView.DismissCallout();

                    }
                }
                catch (Exception ex)
                {

                }
            };


        }
        private void Wave_Clicked(object sender, EventArgs e)
        {
            // Set Button Colors
            WaveButton.BackgroundColor = Color.FromHex("#5d7772");
            WaveButton.BorderColor = Color.FromHex("#5d7772");
            WaveButton.TextColor = Color.White;

            ReefButton.BackgroundColor = Color.White;
            ReefButton.BorderColor = Color.FromHex("#5d7772");
            ReefButton.TextColor = Color.FromHex("#5d7772");

            WindButton.BackgroundColor = Color.White;
            WindButton.BorderColor = Color.FromHex("#5d7772");
            WindButton.TextColor = Color.FromHex("#5d7772");

            WaterButton.BackgroundColor = Color.White;
            WaterButton.BorderColor = Color.FromHex("#5d7772");
            WaterButton.TextColor = Color.FromHex("#5d7772");

            ChlorophyllButton.BackgroundColor = Color.White;
            ChlorophyllButton.BorderColor = Color.FromHex("#5d7772");
            ChlorophyllButton.TextColor = Color.FromHex("#5d7772");

            //get rid of any existing map layers
            myMap.OperationalLayers.Clear();

            // Get MapView from the view and assign map from view-model
            _mapView = MyMapView;
            _mapView.Map = myMap;

            // Create Wave WMS layer
            WmsLayer wave = new WmsLayer(new Uri("https://nowcoast.noaa.gov/arcgis/services/nowcoast/forecast_meteoceanhydro_sfc_ndfd_signwaveht_offsets/MapServer/WMSServer?request=GetCapabilities&service=WMS"), wmsLayerNames);
            myMap.OperationalLayers.Add(wave);

            //Set Legend
            LegendLabel.Text = "   Significant Wave Height";
            LegendMetricLabel.Text = "   feet";
            Box1.Color = Color.Lavender;
            Box2.Color = Color.MediumPurple;
            Box3.Color = Color.Purple;
            Box4.Color = Color.BlueViolet;
            Box5.Color = Color.Blue;
            MetricLabel1.Text = "1";
            MetricLabel2.Text = "2";
            MetricLabel3.Text = "3";
            MetricLabel4.Text = "4";
            MetricLabel5.Text = "5";


        }

        private void Reef_Clicked(object sender, EventArgs e)
        {

            // Set Button Colors
            WaveButton.BackgroundColor = Color.White;
            WaveButton.BorderColor = Color.FromHex("#5d7772");
            WaveButton.TextColor = Color.FromHex("#5d7772");

            ReefButton.BackgroundColor = Color.FromHex("#5d7772");
            ReefButton.BorderColor = Color.FromHex("#5d7772");
            ReefButton.TextColor = Color.White;

            WindButton.BackgroundColor = Color.White;
            WindButton.BorderColor = Color.FromHex("#5d7772");
            WindButton.TextColor = Color.FromHex("#5d7772");

            WaterButton.BackgroundColor = Color.White;
            WaterButton.BorderColor = Color.FromHex("#5d7772");
            WaterButton.TextColor = Color.FromHex("#5d7772");

            ChlorophyllButton.BackgroundColor = Color.White;
            ChlorophyllButton.BorderColor = Color.FromHex("#5d7772");
            ChlorophyllButton.TextColor = Color.FromHex("#5d7772");
            //get rid of any existing map layers
            myMap.OperationalLayers.Clear();

            // Get MapView from the view and assign map from view-model
            _mapView = MyMapView;
            _mapView.Map = myMap;

            // Create Reef WMS layer
            WmsLayer reefThree = new WmsLayer(new Uri("https://coast.noaa.gov/arcgis/services/MarineCadastre/PhysicalOceanographicAndMarineHabitat/MapServer/WMSServer?request=GetCapabilities&service=WMS"), r3);
            myMap.OperationalLayers.Add(reefThree);

            LegendLabel.Text = "   Artificial Reefs";
            LegendMetricLabel.Text = "   Artificial Reef Location";
            Box1.Color = Color.White;
            Box2.Color = Color.White;
            Box3.Color = Color.LightSalmon;
            Box4.Color = Color.White;
            Box5.Color = Color.White;
            MetricLabel1.Text = "";
            MetricLabel2.Text = "";
            MetricLabel3.Text = "";
            MetricLabel4.Text = "";
            MetricLabel5.Text = "";

        }

        private async void Chlorophyll_Clicked(object sender, EventArgs e)
        {
            // Set Button Colors
            WaveButton.BackgroundColor = Color.White;
            WaveButton.BorderColor = Color.FromHex("#5d7772");
            WaveButton.TextColor = Color.FromHex("#5d7772");

            ReefButton.BackgroundColor = Color.White;
            ReefButton.BorderColor = Color.FromHex("#5d7772");
            ReefButton.TextColor = Color.FromHex("#5d7772");

            WindButton.BackgroundColor = Color.White;
            WindButton.BorderColor = Color.FromHex("#5d7772");
            WindButton.TextColor = Color.FromHex("#5d7772");

            WaterButton.BackgroundColor = Color.White;
            WaterButton.BorderColor = Color.FromHex("#5d7772");
            WaterButton.TextColor = Color.FromHex("#5d7772");

            ChlorophyllButton.BackgroundColor = Color.FromHex("#5d7772");
            ChlorophyllButton.BorderColor = Color.FromHex("#5d7772");
            ChlorophyllButton.TextColor = Color.White;



            // set wms layers 
            WmsLayer chlorophyll = new WmsLayer(new Uri("https://coastwatch.pfeg.noaa.gov/erddap/wms/nesdisVHNSQchlaDaily/request?service=WMS&request=GetCapabilities&version=1.3.0"), c1);
            WmsLayer chlorophylla = new WmsLayer(new Uri("https://coastwatch.pfeg.noaa.gov/erddap/wms/erdVH2018chla1day/request?service=WMS&request=GetCapabilities&version=1.3.0"), c2);
            WmsLayer chlorophyllb = new WmsLayer(new Uri("https://coastwatch.pfeg.noaa.gov/erddap/wms/erdVH2018chla1day/request?service=WMS&request=GetCapabilities&version=1.3.0"), c3);
            WmsLayer chlorophyllc = new WmsLayer(new Uri("https://coastwatch.pfeg.noaa.gov/erddap/wms/erdVH2018chla1day/request?service=WMS&request=GetCapabilities&version=1.3.0"), c4);
            WmsLayer chlorophylld = new WmsLayer(new Uri("https://coastwatch.pfeg.noaa.gov/erddap/wms/erdVH2018chla1day/request?service=WMS&request=GetCapabilities&version=1.3.0"), c5);
            WmsLayer chlorophylle = new WmsLayer(new Uri("https://coastwatch.pfeg.noaa.gov/erddap/wms/erdVH2018chla1day/request?service=WMS&request=GetCapabilities&version=1.3.0"), c6);
            WmsLayer chlorophyllf = new WmsLayer(new Uri("https://coastwatch.pfeg.noaa.gov/erddap/wms/erdVH2018chla1day/request?service=WMS&request=GetCapabilities&version=1.3.0"), c7);

            //create new map and basemap because the wms has a different coordinate projection system
            var myBasemap = new Basemap();
            myBasemap.BaseLayers.Add(chlorophylle);
            myBasemap.BaseLayers.Add(chlorophylla);
            myBasemap.BaseLayers.Add(chlorophyllb);
            myBasemap.BaseLayers.Add(chlorophyllc);
            myBasemap.BaseLayers.Add(chlorophylld);
            myBasemap.BaseLayers.Add(chlorophyllf);
            myBasemap.BaseLayers.Add(chlorophyll);
      
            Esri.ArcGISRuntime.Mapping.Map myMapTwo = new Esri.ArcGISRuntime.Mapping.Map(myBasemap);


            // Get MapView from the view and assign map from view-model
            _mapView = MyMapView;
            _mapView.Map = myMapTwo;

            // start map zoomed in on the gulf
            string startingLatLon = "25.3043 -90.0659";
            MapPoint startingPoint = CoordinateFormatter.FromLatitudeLongitude(startingLatLon, SpatialReferences.Wgs84);
            Viewpoint startingViewpoint = new Viewpoint(startingPoint, 1);

            // Set Viewpoint so that it is centered on the coordinates defined above
            await MyMapView.SetViewpointCenterAsync(startingPoint);

            //Set Legend
            LegendLabel.Text = "   Chlorophyll Concentration";
            LegendMetricLabel.Text = "   mg m-3";
            Box1.Color = Color.MediumPurple;
            Box2.Color = Color.Blue;
            Box3.Color = Color.LimeGreen;
            Box4.Color = Color.Orange;
            Box5.Color = Color.Red;
            MetricLabel1.Text = "0.1";
            MetricLabel2.Text = "0.2";
            MetricLabel3.Text = "1.0";
            MetricLabel4.Text = "7.0";
            MetricLabel5.Text = "20.0";


        }

        private void Water_Clicked(object sender, EventArgs e)
        {

            // Set Button Colors
            WaveButton.BackgroundColor = Color.White;
            WaveButton.BorderColor = Color.FromHex("#5d7772");
            WaveButton.TextColor = Color.FromHex("#5d7772");

            ReefButton.BackgroundColor = Color.White;
            ReefButton.BorderColor = Color.FromHex("#5d7772");
            ReefButton.TextColor = Color.FromHex("#5d7772");

            WindButton.BackgroundColor = Color.White;
            WindButton.BorderColor = Color.FromHex("#5d7772");
            WindButton.TextColor = Color.FromHex("#5d7772");

            WaterButton.BackgroundColor = Color.FromHex("#5d7772");
            WaterButton.BorderColor = Color.FromHex("#5d7772");
            WaterButton.TextColor = Color.White;

            ChlorophyllButton.BackgroundColor = Color.White;
            ChlorophyllButton.BorderColor = Color.FromHex("#5d7772");
            ChlorophyllButton.TextColor = Color.FromHex("#5d7772");

            //get rid of any existing map layers
            myMap.OperationalLayers.Clear();

            // Get MapView from the view and assign map from view-model
            _mapView = MyMapView;
            _mapView.Map = myMap;

            // Create Water Temperature WMS layer
            WmsLayer waterTemp = new WmsLayer(new Uri("https://gis.ngdc.noaa.gov/arcgis/services/GulfDataAtlas/NODC_SST/MapServer/WMSServer?request=GetCapabilities&service=WMS"), wmsLayerNames);
            myMap.OperationalLayers.Add(waterTemp);

            //Set Legend
            LegendLabel.Text = "   Sea Surface Temperature";
            LegendMetricLabel.Text = "   degrees Fahrenheit";
            Box1.Color = Color.LightBlue;
            Box2.Color = Color.Yellow;
            Box3.Color = Color.Orange;
            Box4.Color = Color.OrangeRed;
            Box5.Color = Color.Red;
            MetricLabel1.Text = "68";
            MetricLabel2.Text = "75";
            MetricLabel3.Text = "78";
            MetricLabel4.Text = "82";
            MetricLabel5.Text = "86";

        }

        private void Wind_Clicked(object sender, EventArgs e)
        {
            // Set Button Colors
            WaveButton.BackgroundColor = Color.White;
            WaveButton.BorderColor = Color.FromHex("#5d7772");
            WaveButton.TextColor = Color.FromHex("#5d7772");

            ReefButton.BackgroundColor = Color.White;
            ReefButton.BorderColor = Color.FromHex("#5d7772");
            ReefButton.TextColor = Color.FromHex("#5d7772");

            WindButton.BackgroundColor = Color.FromHex("#5d7772");
            WindButton.BorderColor = Color.FromHex("#5d7772");
            WindButton.TextColor = Color.White;

            WaterButton.BackgroundColor = Color.White;
            WaterButton.BorderColor = Color.FromHex("#5d7772");
            WaterButton.TextColor = Color.FromHex("#5d7772");

            ChlorophyllButton.BackgroundColor = Color.White;
            ChlorophyllButton.BorderColor = Color.FromHex("#5d7772");
            ChlorophyllButton.TextColor = Color.FromHex("#5d7772");

            //get rid of any existing map layers
            myMap.OperationalLayers.Clear();

            // Get MapView from the view and assign map from view-model
            _mapView = MyMapView;
            _mapView.Map = myMap;

            // Create Wind WMS layer
            WmsLayer wind = new WmsLayer(new Uri("https://gis.ngdc.noaa.gov/arcgis/services/GulfDataAtlas/NCDC_SeaWinds/MapServer/WMSServer?request=GetCapabilities&service=WMS"), wmsLayerNames);
            myMap.OperationalLayers.Add(wind);

           

            //Set Legend
            LegendLabel.Text = "   Wind Speeds";
            LegendMetricLabel.Text = "   meters per second";
            Box1.Color = Color.Blue;
            Box2.Color = Color.Aqua;
            Box3.Color = Color.SeaGreen;
            Box4.Color = Color.YellowGreen;
            Box5.Color = Color.LightGoldenrodYellow;
            MetricLabel1.Text = "4";
            MetricLabel2.Text = "5";
            MetricLabel3.Text = "6";
            MetricLabel4.Text = "7";
            MetricLabel5.Text = "8";

            // Get MapView from the view and assign map from view-model
            _mapView = MyMapView;
            _mapView.Map = myMap;



        }
        public string getBuoyData()
        {
            //create web client 
            WebClient client = new WebClient();
            string results = client.DownloadString("https://www.ndbc.noaa.gov/data/latest_obs/latest_obs.txt");

            return results;
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