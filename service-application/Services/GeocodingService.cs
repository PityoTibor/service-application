using Newtonsoft.Json.Linq;

namespace service_application.Services
{
    public class GeocodingService
    {
        private readonly string _apiKey = "AIzaSyDh6l7iOIJwNQPRW9TBOaHOSi_X-_6TCc0"; 

        public GeocodingService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<(double latitude, double longitude)> GetCoordinatesAsync(string address)
        {
            using var httpClient = new HttpClient();
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";
            var response = await httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            if (json["status"].ToString() == "OK")
            {
                var location = json["results"][0]["geometry"]["location"];
                double latitude = location["lat"].Value<double>();
                double longitude = location["lng"].Value<double>();
                return (latitude, longitude);
            }
            else
            {
                throw new Exception("Geocoding request failed: " + json["status"]);
            }
        }

        public async Task<string> GetAddressAsync(double latitude, double longitude)
        {
            var latlng = $"{latitude.ToString().Replace(",", ".")},{longitude.ToString().Replace(",", ".")}";
            var encodedLatLng = Uri.EscapeDataString(latlng);


            var url = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={encodedLatLng}&key={_apiKey}&result_type=street_address&location_type=ROOFTOP";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();



            // HTTP kérést küldünk az URL-re
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(responseBody);



            if (json["status"].ToString() == "OK")
            {
                var address = json["results"][0]["formatted_address"].ToString();
                return address;
            }
            else
            {
                throw new Exception("Reverse geocoding request failed: " + json["status"]);
            }
        }


        //static async Task Main(string[] args)
        //{
        //    var apiKey = "AIzaSyDh6l7iOIJwNQPRW9TBOaHOSi_X"; // Itt add meg az API kulcsot
        //    var service = new GeocodingService(apiKey);

        //    try
        //    {
        //        var (latitude, longitude) = await service.GetCoordinatesAsync("Budapest, Hungary");
        //        Console.WriteLine($"Latitude: {latitude}, Longitude: {longitude}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}

        //static async Task Main(string[] args)
        //{
        //    var apiKey = "AIzaSyDh6l7iOIJwNQPRW9TBOaHOSi_X-_6TCc0"; // Itt add meg az API kulcsot
        //    var service = new GeocodingService(apiKey);

        //    try
        //    {
        //        var address = await service.GetAddressAsync(47.4986, 19.0706);
        //        Console.WriteLine($"Address: {address}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //}
    }
}
