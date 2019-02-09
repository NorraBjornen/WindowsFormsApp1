using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1.Source.Model {
    class DistanceMatrix {
        private readonly String Origins, Destinations;

        public DistanceMatrix(String cityFrom, String street, String house, String[] waypoints) {
            Origins = BuildOrigins(cityFrom, street, house, waypoints);
            Destinations = BuildDestinations(waypoints);
        }

        public DistanceMatrix(String from, String to) {
            Origins = from;
            Destinations = to;
        }

        public String GetDistance() {
            Dictionary<String, String> data = new Dictionary<String, String> {
                { "units" , "imperial" },
                { "origins" , Origins },
                { "destinations" , Destinations },
                { "key" , "AIzaSyAF5dK52k7_KVsmZO8-8sJJTRyF46gMM7U" }
            };

            try {
                JObject json = JObject.Parse(new HttpRequest("https://maps.googleapis.com/maps/api/distancematrix/json", data).GetResponse());

                JArray items = (JArray)json["rows"];
                int length = items.Count;

                int distanceInt = 0;

                for (int i = 0; i < length; i++) {
                    distanceInt += items[i]["elements"][i]["distance"]["value"].ToObject<int>();
                }

                String distance = distanceInt.ToString();

                return distance;
            } catch (Exception e){
                return "-";
            }
        }

        private String BuildOrigins(String cityFrom, String street, String house, String[] waypoints) {
            StringBuilder originsBuilder = new StringBuilder();

            originsBuilder.Append(cityFrom).Append(",").Append(street);

            if (house.Length != 0) originsBuilder.Append(" ").Append(house);

            if (waypoints.Length != 1) {
                for (int i = 0; i < waypoints.Length - 1; i++) {
                    originsBuilder.Append("|").Append(waypoints[i]);
                }
            }

            return originsBuilder.ToString().Replace(' ', '+');
        }

        private String BuildDestinations(String[] waypoints) {
            if (waypoints.Length != 1) {
                StringBuilder destinationsBuilder = new StringBuilder();
                destinationsBuilder.Append(waypoints[0]);
                for (int i = 1; i < waypoints.Length; i++) {
                    destinationsBuilder.Append("|").Append(waypoints[i]);
                }
                return destinationsBuilder.ToString().Replace(' ', '+');
            } else {
                return waypoints[0].Replace(' ', '+');
            }
        }
    }
}
