using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using System.Threading.Tasks;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using Esri.ArcGISRuntime.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using Esri.ArcGISRuntime.Security;




namespace test3
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        // Declare buttons
        Button windWMSButton;
        Button waterTempWMSButton;
        Button reefWMSButton;
        Button waveWMSButton;
        Button chlorophyllWMSButton;

        // Create Map View
        MapView mapView;

        // Hold a list of uniquely-identifying WMS layer names to display.
        private readonly List<string> wmsLayerNames = new List<string> { "1" };
        private readonly List<string> reefLayerNames = new List<string> { "0" };
        private readonly List<string> chlorophyllLayerNames = new List<string> { "0", "1", "3", "4", "5", "6" };

      
        

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            // Set the view from the "Main" layout resource
            SetContentView(Resource.Layout.Main);

            windWMSButton = FindViewById<Button>(Resource.Id.windButton);
            this.FindViewById<Button>(Resource.Id.windButton).Click += this.showWindWMS;
            //this.FindViewById<Button>(Resource.Id.windButton).Click += this.ButtonClickedChangeColor;
            
            waterTempWMSButton = FindViewById<Button>(Resource.Id.waterButton);
            this.FindViewById<Button>(Resource.Id.waterButton).Click += this.showWaterTempWMS;
            //this.FindViewById<Button>(Resource.Id.waveButton).Click += this.ButtonClickedChangeColor;

            reefWMSButton = FindViewById<Button>(Resource.Id.reefButton);
            this.FindViewById<Button>(Resource.Id.reefButton).Click += this.showReefWMS;

            waveWMSButton = FindViewById<Button>(Resource.Id.waveButton);
            this.FindViewById<Button>(Resource.Id.waveButton).Click += this.showWaveWMS;
            //this.FindViewById<Button>(Resource.Id.waveButton).Click += this.ButtonClickedChangeColor;

            chlorophyllWMSButton = FindViewById<Button>(Resource.Id.chlorophyllButton);
            this.FindViewById<Button>(Resource.Id.chlorophyllButton).Click += this.showChlorophyllWMS;
           // this.FindViewById<Button>(Resource.Id.chlorophyllButton).Click += this.ButtonClickedChangeColor;

            SetOAuthInfo();

            //InitializeMarkers();

        }

        void ButtonClickedChangeColor(object sender, EventArgs e)
        {
            Button button = sender as Button;                   
            button.SetBackgroundColor(Android.Graphics.Color.White);            
        }

        void ButtonClickedChangeColorBack(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.SetBackgroundColor(Android.Graphics.Color.Rgb(93,119,114));
        }

        #region Authentication
        private void SetOAuthInfo()
        {

            Esri.ArcGISRuntime.Security.ServerInfo serverInfo = new Esri.ArcGISRuntime.Security.ServerInfo
            {
                ServerUri = new Uri("https://www.arcgis.com/sharing/rest"),
                TokenAuthenticationType = Esri.ArcGISRuntime.Security.TokenAuthenticationType.OAuthImplicit,
                OAuthClientInfo = new Esri.ArcGISRuntime.Security.OAuthClientInfo { ClientId = "ziK1BQKtaMNJ3DkO", RedirectUri = new Uri("https://developers.arcgis.com") }
            };

            Esri.ArcGISRuntime.Security.AuthenticationManager.Current.RegisterServer(serverInfo);
            AuthenticationManager.Current.ChallengeHandler = new ChallengeHandler(CreateCredentialAsync);

            
            
           // Esri.ArcGISRuntime.Security.AuthenticationManager.Current.ChallengeHandler = new ChallengeHandler(CreateCredentialAsync);

        }

        // ChallengeHandler function that will be called whenever access to a secured resource is attempted.
        public async Task<Credential> CreateCredentialAsync(CredentialRequestInfo info)
        {
            Credential credential = null;

            try
            {
                // IOAuthAuthorizeHandler will challenge the user for OAuth credentials.
                credential = await AuthenticationManager.Current.GenerateCredentialAsync(info.ServiceUri);
            }
            catch (TaskCanceledException) { return credential; }
            catch (Exception)
            {
                // Exception will be reported in calling function.
                throw;
            }

            return credential;
        }

        #endregion


        private void InitializeMarkers()
        {
            // Create initial map location
            // Define coordinates
            string markerCoordinates = "25.3043 90.0659";

            //define MapPoint
            MapPoint startingLocation;
            startingLocation = CoordinateFormatter.FromLatitudeLongitude(markerCoordinates, SpatialReferences.Wgs84);

            // Create graphics overlay
            GraphicsOverlay buoys = new GraphicsOverlay();
            mapView.GraphicsOverlays.Add(buoys);

            // Create simple marker symbol
            SimpleMarkerSymbol buoyMarker = new SimpleMarkerSymbol()
            {
                Color = Color.Black,
                Size = 10,
                Style = SimpleMarkerSymbolStyle.Circle
            };

            // Add a new graphic with the point created previously
            Graphic graphicWithBuoy = new Graphic(startingLocation, buoyMarker);
            buoys.Graphics.Add(graphicWithBuoy);
        }


        public void showWindWMS(object sender, EventArgs e)
        {
            // Create new map
            Map myMap = new Map(Basemap.CreateDarkGrayCanvasVector());

            //get rid of any existing map layers
            myMap.OperationalLayers.Clear();

            // Get MapView from the view and assign map from view-model
            mapView = FindViewById<MapView>(Resource.Id.MyMapView);

            mapView.Map = myMap;

          

            // Create Wind WMS layer
            WmsLayer wind = new WmsLayer(new Uri("https://gis.ngdc.noaa.gov/arcgis/services/GulfDataAtlas/NCDC_SeaWinds/MapServer/WMSServer?request=GetCapabilities&service=WMS"), wmsLayerNames);

            myMap.OperationalLayers.Add(wind);
        }

        public void showWaterTempWMS(object sender, EventArgs e)
        {
            // Create new map
            Map myMap = new Map(Basemap.CreateDarkGrayCanvasVector());

            // Get MapView from the view and assign map from view-model
            mapView = FindViewById<MapView>(Resource.Id.MyMapView);

            //get rid of any existing map layers
            myMap.OperationalLayers.Clear();

            mapView.Map = myMap;

            // Create Water Temperature WMS layer
            WmsLayer waterTemp = new WmsLayer(new Uri("https://gis.ngdc.noaa.gov/arcgis/services/GulfDataAtlas/NODC_SST/MapServer/WMSServer?request=GetCapabilities&service=WMS"), wmsLayerNames);

            myMap.OperationalLayers.Add(waterTemp);


        }

        public void showChlorophyllWMS(object sender, EventArgs e)
        {
            // Create new map
            Map myMap = new Map();
            //Map myMap = new Map(Basemap.CreateDarkGrayCanvasVector());
       
            
           // Get MapView from the view and assign map from view-model
           mapView = FindViewById<MapView>(Resource.Id.MyMapView);

            //get rid of any existing map layers
            myMap.OperationalLayers.Clear();

            mapView.Map = myMap;

            // Create Chlorophyll WMS layer
            WmsLayer chlorophyll = new WmsLayer(new Uri("https://coastwatch.pfeg.noaa.gov/erddap/wms/nesdisVHNSQchlaDaily/request?service=WMS&request=GetCapabilities&version=1.3.0"), wmsLayerNames);
            //WmsLayer chlorophyllTwo = new WmsLayer(new Uri("http://coastwatch.pfeg.noaa.gov/erddap/wms/erdMOchlahday_LonPM180/request?service=WMS&version=1.3.0&request=GetCapabilities"), reefLayerNames);
            //WmsLayer chlorophyllThree = new WmsLayer(new Uri("https://gibs.earthdata.nasa.gov/wms/epsg4326/best/wms.cgi?request=GetCapabilities&service=WMS"), wmsLayerNames);
            //ArcGISMapImageLayer chlorophyllLayer = new ArcGISMapImageLayer(new Uri(""))

            //myMap.OperationalLayers.Add(chlorophyll);

            // Create a new basemap layer
            myMap.Basemap.BaseLayers.Add(chlorophyll);
            

        }

        public void showWaveWMS(object sender, EventArgs e)
        {
            // Create new map
            Map myMap = new Map(Basemap.CreateDarkGrayCanvasVector());

            // Get MapView from the view and assign map from view-model
            mapView = FindViewById<MapView>(Resource.Id.MyMapView);

            //get rid of any existing map layers
            myMap.OperationalLayers.Clear();

            mapView.Map = myMap;

            // Create Wave WMS layer
            WmsLayer wave = new WmsLayer(new Uri("https://nowcoast.noaa.gov/arcgis/services/nowcoast/forecast_meteoceanhydro_sfc_ndfd_signwaveht_offsets/MapServer/WMSServer?request=GetCapabilities&service=WMS"), wmsLayerNames);
            myMap.OperationalLayers.Add(wave);


        }

        public void showReefWMS(object sender, EventArgs e)
        {
            // Create new map
            Map myMap = new Map(Basemap.CreateDarkGrayCanvasVector());

            // Get MapView from the view and assign map from view-model
            mapView = FindViewById<MapView>(Resource.Id.MyMapView);

            //get rid of any existing map layers
            myMap.OperationalLayers.Clear();

            mapView.Map = myMap;

            // Create Reef WMS layer
            WmsLayer reefWms = new WmsLayer(new Uri("https://gis.ngdc.noaa.gov/arcgis/services/deep_sea_corals/MapServer/WMSServer?request=GetCapabilities&service=WMS"), reefLayerNames);
            WmsLayer reef = new WmsLayer(new Uri("https://gis.ngdc.noaa.gov/arcgis/services/deep_sea_corals/MapServer/WMSServer?request=GetCapabilities&service=WMS"), wmsLayerNames);
            myMap.OperationalLayers.Add(reefWms);


        }

    }


}