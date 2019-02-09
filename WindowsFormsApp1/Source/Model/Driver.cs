using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Source.Model {
    class Driver {
        private static readonly Form1 form = Form1.form;
        public static List<Driver> Drivers = new List<Driver>();
        public readonly String DriverId, CallSign, CarNumber, Description;
        public String Status, Position, StatusTime;
        public DataGridViewRow Row;

        private String From;

        public Driver(String driver) {
            String[] elements = driver.Split('$');

            DriverId = elements[0];
            CallSign = elements[1];
            CarNumber = elements[2];
            Description = elements[3];
            Status = elements[4];
            Position = elements[5];
            StatusTime = elements[6];

            DateTime dateTime = DateTime.ParseExact(StatusTime, "yyMMddHHmmss",   CultureInfo.InvariantCulture);
            DateTime now = DateTime.Now;

            StatusTime = Math.Round(now.Subtract(dateTime).TotalMinutes).ToString();

            String sts;
            if(Status == "1") {
                sts = "+";
            } else {
                sts = "Занят";
            }

            String row = CallSign + "$" + sts + "$" + " " + "$" + DriverId + "$" + StatusTime;

            Drivers.Add(this);
            form.AddDriver(row);
            new Thread(StartTime).Start();
        }

        public void StartTime() {
            while (Drivers.Contains(this)) {
                try {
                    Thread.Sleep(60000);
                    StatusTime = (Double.Parse(StatusTime) + 1).ToString();
                    Row.Cells["TimeD"].Value = StatusTime;
                } catch (Exception) { }
            }
        }

        public void SetStatus(String status) {
            Status = status;
            StatusTime = "0";
            Row.Cells["TimeD"].Value = StatusTime;

            String sts;
            if (Status == "1") {
                sts = "+";
            } else {
                sts = "Занят";
            }

            Row.Cells["StatusD"].Value = sts;
        }

        public void SetPosition(String position) {
            Position = position;
            SetDistance(Order.GetOrder(form.selectedOrder).From);
        }

        public void SetDistance(String from) {
            From = "КОСТАНАЙ," + from.Replace(' ', '+');
            new Thread(Set).Start();
        }

        private void Set() {
            Row.Cells["DistanceD"].Value = new DistanceMatrix(From, Position.Replace(' ','+')).GetDistance();
        }

        public void Exit() {
            Drivers.Remove(this);
            OfferedPrice.DeleteDriversPrices(DriverId);
            form.RemoveDriver(Row);
        }

        public static Driver GetDriver(String driverId) {
            foreach (Driver driver in Drivers) {
                if (driver.DriverId == driverId) {
                    return driver;
                }
            }
            return null;
        }

        public static String GetCallSignByDriverId(String driverId) {
            foreach (Driver driver in Drivers) {
                if (driver.DriverId == driverId) {
                    return driver.CallSign;
                }
            }
            return null;
        }

        public static String GetDriverIdByCallSign(String callsign) {
            foreach (Driver driver in Drivers) {
                if (driver.CallSign == callsign) {
                    return driver.DriverId;
                }
            }
            return null;
        }

        public static void ClearDrivers() {
            Drivers.Clear();
            form.ClearDrivers("kek");
        }
    }
}
