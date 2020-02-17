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
using System.Web;
using Xamarin.Essentials;
using System.IO;
using Android.Content.Res;
using Android.Content;
using Xamarin.Android;
using Xamarin.Android.Net;
using Esri.ArcGISRuntime.Ogc;
using System.Collections.ObjectModel;

namespace MAPP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        // Declare map variables
        Esri.ArcGISRuntime.Mapping.Map myMap = new Esri.ArcGISRuntime.Mapping.Map(BasemapType.LightGrayCanvasVector, 25.3043, -90.0659, 4);
        MapViewModel _mapViewModel = new MapViewModel();
        MapView _mapView;

        // Declare string lists for WMS layer
        private readonly List<string> layerOne = new List<string> { "4" };
        private readonly List<string> layerTwo = new List<string> { "5" };
        private readonly List<string> layerThree = new List<string> { "6" };

        public Page2()
        {
            InitializeComponent();

            // Get MapView from the view and assign map from view-model
            _mapView = MyMapView;
            _mapView.Map = myMap;

            // Listen for changes on the view model
            _mapViewModel.PropertyChanged += MapViewModel_PropertyChanged;

            // Call function to initialize map markers
            InitializeMarkers();      
                        
        }

        private void MapViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Update the map view with the view model's new map
            if (e.PropertyName == "Map" && _mapView != null)
                _mapView.Map = _mapViewModel.Map;

        }

        async void InitializeMarkers()
        {

            // Get MapView from the view and assign map from view-model
            _mapView = MyMapView;
            _mapView.Map = myMap;

            //add nearshore and offshore marine zones that correspond with the marine point forecasts
            WmsLayer zoneLayerOne = new WmsLayer(new Uri("https://nowcoast.noaa.gov/arcgis/services/nowcoast/forecast_meteoceanhydro_pts_zones_geolinks/MapServer/WMSServer?request=GetCapabilities&service=WMS&version=1.3.0"), layerOne);
            WmsLayer zoneLayerTwo = new WmsLayer(new Uri("https://nowcoast.noaa.gov/arcgis/services/nowcoast/forecast_meteoceanhydro_pts_zones_geolinks/MapServer/WMSServer?request=GetCapabilities&service=WMS&version=1.3.0"), layerTwo);
            WmsLayer zoneLayerThree = new WmsLayer(new Uri("https://nowcoast.noaa.gov/arcgis/services/nowcoast/forecast_meteoceanhydro_pts_zones_geolinks/MapServer/WMSServer?request=GetCapabilities&service=WMS&version=1.3.0"), layerThree);
            myMap.OperationalLayers.Add(zoneLayerOne);
            myMap.OperationalLayers.Add(zoneLayerTwo);
            myMap.OperationalLayers.Add(zoneLayerThree);

            var legendInfo = await zoneLayerTwo.GetLegendInfosAsync();

            // Create graphics overlay
            GraphicsOverlay userClick = new GraphicsOverlay();
            GraphicsOverlay userLocationLayer = new GraphicsOverlay();

            // Create simple marker symbol for user location
            SimpleMarkerSymbol userMarker = new SimpleMarkerSymbol()
            {
                Color = Color.Red,
                Size = 10,
                Style = SimpleMarkerSymbolStyle.Diamond

            };
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

                    userLocationLayer.Graphics.Add(userGraphic);
                    _mapView.GraphicsOverlays.Add(userLocationLayer);
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


            // Create simple marker symbol for where the user clicks on the map
            SimpleMarkerSymbol userClickMarker = new SimpleMarkerSymbol()
            {
                Color = Color.Black,
                Size = 10,
                Style = SimpleMarkerSymbolStyle.X

            };

            Graphic userClickGraphic = new Graphic();
            userClickGraphic.Symbol = userClickMarker;

            _mapView.GraphicsOverlays.Add(userClick);

            // add symbol where user has tapped on the map
            _mapView.GeoViewTapped +=  (s, e) =>
            {
                // get rid of any current markers from previous map taps
               userClick.Graphics.Clear();
                
                Geometry myGeo = GeometryEngine.Project(e.Location, SpatialReferences.Wgs84);
                MapPoint projection = (MapPoint)myGeo;

                double latClick = Convert.ToDouble(projection.Y);
                double lonClick = Convert.ToDouble(projection.X);


                string location = latClick.ToString() + " " + lonClick.ToString();
                MapPoint startingLocation = CoordinateFormatter.FromLatitudeLongitude(location, SpatialReferences.Wgs84);

                userClickGraphic.Geometry = startingLocation;
                userClick.Graphics.Add(userClickGraphic);

                GetWeather(latClick, lonClick);
            };
        }

   
        private void GetWeather(double lat, double lon)
        {

            var layout = WeatherResultsLayout;
                        
            string urlLon = lon.ToString();
            string urlLat = lat.ToString();


            string results = "";
            WebClient client = new WebClient();

            // create url based on user map click lat and lon 
            string goToUrl = "https://marine.weather.gov/MapClick.php?lon=" + urlLon + "&lat=" + urlLat;

            // add header so request is allowed 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(goToUrl);


            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.31 Safari/537.36";

            // allow redirect because nearshore will redirect  
            request.AllowAutoRedirect = true;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Uri responseUri = response.ResponseUri;

            string redirect = response.Headers["location"];

            string responseString = responseUri.ToString();

            response.Close();




            // get the header to find actual url
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.31 Safari/537.36");
            results = client.DownloadString(responseString);

            //strip html to get better readability
            string resultsEdited = StripHTML(results);
            resultsEdited = resultsEdited.Replace("'", "");

            char[] responseArray = resultsEdited.ToCharArray();
            string site = "";
            int startingPoint = 0;
            bool canStart = true;

            // if line starts with "htt" meaning it will be an http:// or https:// address
            for (int i = 0; i < responseArray.Length; i++)
            {
                if (responseArray[i] == 'h' && responseArray[i + 1] == 't' && responseArray[i + 2] == 't')
                {
                    startingPoint += i;
                }

            }

            // set bool to false if no line starts with "htt" meaning it is a nearshore forecast
            if(startingPoint == 0)
            {
                canStart = false;
            }


            // get offshore forecast if bool variable is true
            if (canStart == true)
            {
                // get url 
                if (responseArray != null)
                {
                    for (int i = startingPoint; i < responseArray.Length; i++)
                    {
                        site += responseArray[i];

                    }
                }

                if (site != "")
                {
                    client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.31 Safari/537.36");
                    
                    // download forecast as string
                    string resultsNew = client.DownloadString(site);

                    //strip html for readability
                    string newResults = StripHTML(resultsNew);

                    //regex to strip weird characters and odd spaces
                    string newResultsTwo = Regex.Replace(newResults, @"([.])([A-Z])", "$2");
                    string newResultsThree = Regex.Replace(newResultsTwo, @"[.]{2,}", " ");
                    string newResultsFour = Regex.Replace(newResultsThree, "&nbsp;", " ");

                    // declare variable for splitting by each line and split into 1d array   
                    char delimiter = '\n';
                    String[] data = newResultsFour.Split(delimiter);

                    int length = data.Length;
                    int line = 0;
                    int warning = 0;
                    string warningText = "";
                    int subtraction = 3;

                    char delimiterTwo = ' ';

                    int synopsisLine = 0;

                    String[,] dataParsed = new String[length, 22];


                    //create 2d array of forecast
                    for (int i = 0; i < data.Length; i++)
                    {


                        String[] fields = data[i].Split(delimiterTwo);


                        // determine various things
                        for (int j = 0; j < fields.Length; j++)
                        {

                            dataParsed[i, j] = fields[j];

                            //see if there is a warning in the forecast
                            if (dataParsed[i, j] == "WARNING")
                            {
                                warning += i;
                            }

                            //see if forecast has a synopsis
                            if (dataParsed[i, j] == "SYNOPSIS" || dataParsed[i, j] == " SYNOPSIS" || dataParsed[i, j] == ".SYNOPSIS")
                            {
                                synopsisLine += i;
                            }

                            // determine whether the forecast is for today or tonight and then make that the starting line 
                            if (dataParsed[i, j] == "TODAY")
                            {
                                line += i;
                            }
                            else if (dataParsed[i, j] == "TONIGHT" && line == 0)
                            {
                                line += i;
                            }

                        }
                    }


                    // if there is a warning, display it
                    if (warning > 0)
                    {
                        warningText += data[warning];
                        Warning.IsVisible = true;
                        Warning.Text = warningText;
                        subtraction += 3;
                    }


                    // if there is a synopsis, display it
                    string synopsis = "";
                    if (synopsisLine != 0)
                    {

                        String[] SynopsisOneArray = data[synopsisLine].Split(delimiterTwo);
                        for (int i = 1; i < SynopsisOneArray.Length; i++)
                        {
                            synopsis += SynopsisOneArray[i];
                        }
                        synopsisLine++;

                        while (dataParsed[synopsisLine, 1] != null)
                        {
                            synopsis += data[synopsisLine];
                            synopsisLine++;
                        }

                        SynopsisHeader.IsVisible = true;

                    }
                    else
                    {
                        SynopsisHeader.IsVisible = false;
                        SynopsisText.IsVisible = false;
                    }

                    // create "last updated" line
                    int timeLine = line - subtraction;
                    Console.WriteLine(timeLine);

                    char[] timeArray = dataParsed[timeLine, 1].ToCharArray();
                    string time = timeArray[0] + ":" + timeArray[1] + timeArray[2];
                    string amPm = dataParsed[timeLine, 2].ToLower();

                    // create strings for every title and content for the forecasts
                    // try-catch in case the forecast is unavailable or in a weird format for an unknown reason
                    try
                    {

                        string titleOne = data[line];
                        string contentOne = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentOne += data[line];
                            line++;
                        }

                        line++;


                        string titleTwo = data[line];
                        string contentTwo = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentTwo += data[line];
                            line++;
                        }

                        line++;

                        string titleThree = data[line];
                        string contentThree = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentThree += data[line];
                            line++;
                        }

                        line++;

                        string titleFour = data[line];
                        string contentFour = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentFour += data[line];
                            line++;
                        }

                        line++;

                        string titleFive = data[line];
                        string contentFive = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentFive += data[line];
                            line++;
                        }

                        line++;

                        string titleSix = data[line];
                        string contentSix = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentSix += data[line];
                            line++;
                        }

                        line++;

                        string titleSeven = data[line];
                        string contentSeven = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentSeven += data[line];
                            line++;
                        }

                        line++;

                        string titleEight = data[line];
                        string contentEight = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentEight += data[line];
                            line++;
                        }

                        line++;

                        string titleNine = data[line];
                        string contentNine = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentNine += data[line];
                            line++;
                        }

                        line++;

                        string titleTen = data[line];
                        string contentTen = "";
                        line++;

                        while (dataParsed[line, 1] != null)
                        {
                            contentTen += data[line];
                            line++;
                        }

                        ForecastHeader.IsVisible = true;

                        TitleOne.Text = titleOne;
                        TitleTwo.Text = titleTwo;
                        TitleThree.Text = titleThree;
                        TitleFour.Text = titleFour;
                        TitleFive.Text = titleFive;
                        TitleSix.Text = titleSix;
                        TitleSeven.Text = titleSeven;
                        TitleEight.Text = titleEight;
                        TitleNine.Text = titleNine;

                        ContentOne.Text = contentOne;
                        ContentTwo.Text = contentTwo;
                        ContentThree.Text = contentThree;
                        ContentFour.Text = contentFour;
                        ContentFive.Text = contentFive;
                        ContentSix.Text = contentSix;
                        ContentSeven.Text = contentSeven;
                        ContentEight.Text = contentEight;
                        ContentNine.Text = contentNine;


                        string update = "Last Update: " + time + " " + amPm + " " + dataParsed[timeLine, 3] + " " + dataParsed[timeLine, 4] + " " + dataParsed[timeLine, 5] + ", " + dataParsed[timeLine, 6];


                        LastUpdated.Text = update;
                        SynopsisText.Text = synopsis;
                        MoreInfoURL.Text = goToUrl;
                        MoreInfoText.IsVisible = true;
                    }


                    // if forecast is in an unexpected format or missing, plain text forecast from the downloaded string will be shown instead
                    catch (Exception ex)
                    {
                      
                        ContentOne.Text = newResultsFour;
                        TitleOne.Text = "Formatting Error. Plain Text Forecast Shown.";
                    }
                }





            }

            // nearshore forecast 
            else
            {
                SynopsisHeader.IsVisible = false;
                SynopsisText.IsVisible = false;


                //initialize web client 
                string resultsElse = "";

                // download as string 
                string urlTwo = "https://marine.weather.gov/MapClick.php?lat=" + urlLat + "&lon=" + urlLon + "&unit=0&lg=english&FcstType=text&TextType=1";
                MoreInfoURL.Text = urlTwo;
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.31 Safari/537.36");
                resultsElse = client.DownloadString(urlTwo);
                string resultsElseTwo = StripHTML(resultsElse);

                //split into 1d array
                char delimiter = '\n';
                String[] dataTwo = resultsElseTwo.Split(delimiter);
                int start = 0;

                int lengthTwo = dataTwo.Length;
                char delimiterTwo = ' ';


                string titleOne = "";
                string contentOne = "";
                string titleTwo = "";
                string contentTwo = "";
                string titleThree = "";
                string contentThree = "";
                string titleFour = "";
                string contentFour = "";
                string titleFive = "";
                string contentFive = "";
                string titleSix = "";
                string contentSix = "";
                string titleSeven = "";
                string contentSeven = "";
                string titleEight = "";
                string contentEight = "";

                String[,] dataParsed = new String[lengthTwo, 1000];

                //create 2d array 
                for (int i = 0; i < dataTwo.Length; i++)
                {


                    String[] fields = dataTwo[i].Split(delimiterTwo);

                    //determine starting line for forecast
                    for (int j = 0; j < fields.Length; j++)
                    {

                        dataParsed[i, j] = fields[j];

                        if (dataParsed[i, j] == "Today" || dataParsed[i, j] == "Today:")
                        {
                            start += i;
                            string today = "its today";
                            titleOne = today;
                            contentOne = i.ToString();

                        }
                        else if (dataParsed[i, j] == "Afternoon" && start == 0)
                        {
                            start += i;
                            string today = "its this afternoon";
                            titleOne = today;
                            contentOne = i.ToString();
                        }
                        else if (dataParsed[i, j] == "Tonight" || dataParsed[i, j] == "Tonight:" && start == 0)
                        {
                            start += i;
                            string today = "its tonight";
                            titleOne = today;
                            contentOne = i.ToString();
                        }
                        //there were issues with the else statement where it would default to else even if an if or else if was true
                        else
                        {
                            /*string error = "ERROR";
                            string errorMessage = "A forecast for this location is not currently available.";
                            titleOne = error;
                            contentOne = errorMessage;*/


                        }

                    }
                }

                String[] ArrayOne = dataTwo[start].Split(delimiterTwo);

                //create strings for titles and contents for all forecasts
                try
                {
                    // Forecast One
                    if (dataParsed[start, 1] == "Afternoon:" || dataParsed[start, 1] == "Evening:" || dataParsed[start, 1] == "Eve:" || dataParsed[start, 1] == "Day:")
                    {
                        titleOne = dataParsed[start, 0] + " " + dataParsed[start, 1];
                        for (int i = 2; i < ArrayOne.Length; i++)
                        {
                            contentOne += dataParsed[start, i];
                            contentOne += " ";
                        }
                        start++;





                    }
                    else
                    {
                        titleOne = dataParsed[start, 0];
                        for (int i = 1; i < ArrayOne.Length; i++)
                        {
                            contentOne += dataParsed[start, i];
                            contentOne += " ";
                        }

                        start++;
                    }
                    start++;


                    String[] ArrayTwo = dataTwo[start].Split(delimiterTwo);
                    //Forecast Two
                    if (dataParsed[start, 1] == "Afternoon:" || dataParsed[start, 1] == "Evening:" || dataParsed[start, 1] == "Eve:" || dataParsed[start, 1] == "Day:")
                    {
                        titleTwo = dataParsed[start, 0] + " " + dataParsed[start, 1];


                        for (int i = 2; i < ArrayTwo.Length; i++)
                        {
                            contentTwo += dataParsed[start, i];
                            contentTwo += " ";
                        }
                        start++;

                    }
                    else
                    {
                        titleTwo = dataParsed[start, 0];
                        for (int i = 1; i < ArrayTwo.Length; i++)
                        {
                            contentTwo += dataParsed[start, i];
                            contentTwo += " ";
                        }

                        start++;
                    }
                    start++;


                    String[] ArrayThree = dataTwo[start].Split(delimiterTwo);

                    //Forecast Three
                    if (dataParsed[start, 1] == "Afternoon:" || dataParsed[start, 1] == "Evening:" || dataParsed[start, 1] == "Eve:" || dataParsed[start, 1] == "Day:")
                    {
                        titleThree = dataParsed[start, 0] + " " + dataParsed[start, 1];
                        for (int i = 2; i < ArrayThree.Length; i++)
                        {
                            contentThree += dataParsed[start, i];
                            contentThree += " ";
                        }
                        start++;

                    }
                    else
                    {
                        titleThree = dataParsed[start, 0];
                        for (int i = 1; i < ArrayThree.Length; i++)
                        {
                            contentThree += dataParsed[start, i];
                            contentThree += " ";
                        }

                        start++;
                    }
                    start++;


                    String[] ArrayFour = dataTwo[start].Split(delimiterTwo);

                    //Forecast Four
                    if (dataParsed[start, 1] == "Afternoon:" || dataParsed[start, 1] == "Evening:" || dataParsed[start, 1] == "Eve:" || dataParsed[start, 1] == "Day:")
                    {
                        titleFour = dataParsed[start, 0] + " " + dataParsed[start, 1];
                        for (int i = 2; i < ArrayFour.Length; i++)
                        {
                            contentFour += dataParsed[start, i];
                            contentFour += " ";
                        }
                        start++;

                    }
                    else
                    {
                        titleFour = dataParsed[start, 0];
                        for (int i = 1; i < ArrayFour.Length; i++)
                        {
                            contentFour += dataParsed[start, i];
                            contentFour += " ";
                        }

                        start++;
                    }
                    start++;

                    String[] ArrayFive = dataTwo[start].Split(delimiterTwo);

                    //Forecast Five
                    if (dataParsed[start, 1] == "Afternoon:" || dataParsed[start, 1] == "Evening:" || dataParsed[start, 1] == "Eve:" || dataParsed[start, 1] == "Day:")
                    {
                        titleFive = dataParsed[start, 0] + " " + dataParsed[start, 1];
                        for (int i = 2; i < ArrayFive.Length; i++)
                        {
                            contentFive += dataParsed[start, i];
                            contentFive += " ";
                        }
                        start++;

                    }
                    else
                    {
                        titleFive = dataParsed[start, 0];
                        for (int i = 1; i < ArrayFive.Length; i++)
                        {
                            contentFive += dataParsed[start, i];
                            contentFive += " ";
                        }

                        start++;
                    }
                    start++;

                    String[] ArraySix = dataTwo[start].Split(delimiterTwo);

                    //Forecast Six
                    if (dataParsed[start, 1] == "Afternoon:" || dataParsed[start, 1] == "Evening:" || dataParsed[start, 1] == "Eve:" || dataParsed[start, 1] == "Day:")
                    {
                        titleSix = dataParsed[start, 0] + " " + dataParsed[start, 1];
                        for (int i = 2; i < ArraySix.Length; i++)
                        {
                            contentSix += dataParsed[start, i];
                            contentSix += " ";
                        }
                        start++;

                    }
                    else
                    {
                        titleSix = dataParsed[start, 0];
                        for (int i = 1; i < ArraySix.Length; i++)
                        {
                            contentSix += dataParsed[start, i];
                            contentSix += " ";
                        }

                        start++;
                    }
                    start++;

                    String[] ArraySeven = dataTwo[start].Split(delimiterTwo);

                    //Forecast Seven
                    if (dataParsed[start, 1] == "Afternoon:" || dataParsed[start, 1] == "Evening:" || dataParsed[start, 1] == "Eve:" || dataParsed[start, 1] == "Day:")
                    {
                        titleSeven = dataParsed[start, 0] + " " + dataParsed[start, 1];
                        for (int i = 2; i < ArraySeven.Length; i++)
                        {
                            contentSeven += dataParsed[start, i];
                            contentSeven += " ";
                        }
                        start++;

                    }
                    else
                    {
                        titleSeven = dataParsed[start, 0];
                        for (int i = 1; i < ArraySeven.Length; i++)
                        {
                            contentSeven += dataParsed[start, i];
                            contentSeven += " ";
                        }

                        start++;
                    }
                    start++;

                    String[] ArrayEight = dataTwo[start].Split(delimiterTwo);

                    //Forecast Eight
                    if (dataParsed[start, 1] == "Afternoon:" || dataParsed[start, 1] == "Evening:" || dataParsed[start, 1] == "Eve:" || dataParsed[start, 1] == "Day:")
                    {
                        titleEight = dataParsed[start, 0] + " " + dataParsed[start, 1];
                        for (int i = 2; i < ArrayEight.Length; i++)
                        {
                            contentEight += dataParsed[start, i];
                            contentEight += " ";
                        }
                        start++;

                    }
                    else
                    {
                        titleEight = dataParsed[start, 0];
                        for (int i = 1; i < ArrayThree.Length; i++)
                        {
                            contentEight += dataParsed[start, i];
                            contentEight += " ";
                        }

                        start++;
                    }
                    start++;


                    TitleOne.Text = titleOne;
                    TitleTwo.Text = titleTwo;
                    TitleThree.Text = titleThree;
                    TitleFour.Text = titleFour;
                    TitleFive.Text = titleFive;
                    TitleSix.Text = titleSix;
                    TitleSeven.Text = titleSeven;
                    TitleEight.Text = titleEight;


                    ContentOne.Text = contentOne;
                    ContentTwo.Text = contentTwo;
                    ContentThree.Text = contentThree;
                    ContentFour.Text = contentFour;
                    ContentFive.Text = contentFive;
                    ContentSix.Text = contentSix;
                    ContentSeven.Text = contentSeven;
                    ContentEight.Text = contentEight;





                }
                // if forecast is in an unexpected format or missing, plain text forecast from downloaded string will show
                catch(Exception ex)
                {
                    TitleOne.Text = "Formatting Error. Plaint Text Forecast Shown.";
                    ContentOne.Text = resultsElseTwo;
                }
            }

            MoreInfoText.IsVisible = true;
        }

        public static string StripHTML(string htmlString)
        {
            // pattern for html characters
            string pattern = @"<(.|\n)*?>";

            //get rid of html characters
            return Regex.Replace(htmlString, pattern, string.Empty);
        }


    }
}
