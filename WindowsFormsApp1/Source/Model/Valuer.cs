using System;

namespace WindowsFormsApp1.Source.Model {
    class Valuer {
        private static readonly String CityTo = "КОСТАНАЙ";
        private static readonly double coefficient = 32;
        private static readonly double landingPrice = 300;
        private static readonly double debarkationPrice = 100;

        private readonly String Distance;
        private readonly int Debarkations;
        private readonly int Price = 1;

        public Valuer(String cityFrom, String street, String house, String to) {
            if(to.Contains("ПОВРЕМЕННАЯ")) {
                Price = 700;
                return;
            }

            String[] waypoints = GetWaypoints(to);
            DistanceMatrix distanceMatrix = new DistanceMatrix(cityFrom, street, house, waypoints);
            Distance = distanceMatrix.GetDistance();
            if (Distance == "-") {
                Price = 0;
            }
            Debarkations = waypoints.Length;
        }

        public int GetPrice() {
            if ((Price == 700) || (Price == 0)) {
                return Price;
            }

            double originToDestinationDistance = Convert.ToDouble(Distance) / 1000;

            double price = (coefficient * 0.5) + landingPrice + (coefficient * originToDestinationDistance) + debarkationPrice * (Debarkations - 1);
            price = price / 10;

            if (price == (int)price) {
                price = (int)price;
            } else {
                price = (int)price;
                price++;
            }

            double roundPrice = price * 10;

            return (int) roundPrice;
        }

        private String[] GetWaypoints(String to) {
            String[] waypoints = new String[] {
                CityTo + "," + to
            };
            if (to.Contains(">")) {
                waypoints = to.Split('>');
                for (int i = 0; i < waypoints.Length; i++) {
                    if (waypoints[i].Contains(" --")) {
                        waypoints[i] = waypoints[i].Substring(0, waypoints[i].Length - 3);
                        Console.WriteLine(waypoints[i]);
                    }
                    waypoints[i] = CityTo + "," + waypoints[i];
                }
            }
            return waypoints;
        }
    }
}
