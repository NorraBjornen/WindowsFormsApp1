using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Source.Model {
    class Order {
        private static readonly Form1 form = Form1.form;
        private static List<Order> Orders = new List<Order>();
        private readonly String OrderNumber;

        public String From, To, Price, Phone, Description, CallSign, DriverInfo, City, DriverId, Status;

        public DataGridViewRow Row;

        public Order(String order) {
            String[] elements = order.Split('$');

            OrderNumber = elements[0];
            From = elements[1];

            City = From.Split(',')[0];
            if(City == "КОСТАНАЙ") {
                From = From.Split(',')[1];
            }

            To = elements[2];
            Price = elements[3];
            Phone = elements[4];
            Description = elements[5];
            CallSign = elements[7];
            Status = elements[8];
            String time = elements[9];

            switch (Status) {
                case "0":
                    Status = "-";
                    break;
                case "1":
                    Status = "ВБР";
                    break;
                case "2":
                    Status = "ПРН";
                    break;
                case "3":
                    Status = "ТРП";
                    break;
                case "4":
                    Status = "ОК";
                    break;
            }

            DriverInfo = "";

            if(CallSign != "-") {
                DriverId = Driver.GetDriverIdByCallSign(CallSign);
                DriverInfo = Driver.GetDriver(DriverId).Description + " " + Driver.GetDriver(DriverId).CarNumber;
            } else {
                CallSign = "-";
            }

            order = time + "$" + From + "$" + CallSign + "$" + Price + "$" + Status + "$" + OrderNumber;

            Orders.Add(this);

            form.AddRow(order);
        }

        public void UpdateOrder(String order) {
            String[] elements = order.Split('$');

            From = elements[1];

            City = From.Split(',')[0];
            if (City == "КОСТАНАЙ") {
                From = From.Split(',')[1];
            }

            To = elements[2];
            Price = elements[3];
            Phone = elements[4];
            Description = elements[5];
            CallSign = elements[7];
            Status = elements[8];
            String time = elements[9];

            switch (Status) {
                case "0":
                    Status = "-";
                    break;
                case "1":
                    Status = "ВБР";
                    break;
                case "2":
                    Status = "ПРН";
                    break;
                case "3":
                    Status = "ТРП";
                    break;
                case "4":
                    Status = "ОК";
                    break;
            }

            DriverInfo = "";

            if (CallSign != "-") {
                DriverId = Driver.GetDriverIdByCallSign(CallSign);
                DriverInfo = Driver.GetDriver(DriverId).Description + " " + Driver.GetDriver(DriverId).CarNumber;
            } else {
                CallSign = "-";
            }

            try {
                Row.Cells["Time"].Value = time;
                Row.Cells["Address"].Value = From;
                Row.Cells["CallSign"].Value = CallSign;
                Row.Cells["OrderPrice"].Value = Price;
                Row.Cells["Status"].Value = Status;
            } catch (Exception) {
                FillNeeded();
                Row.Cells["Time"].Value = time;
                Row.Cells["Address"].Value = From;
                Row.Cells["CallSign"].Value = CallSign;
                Row.Cells["OrderPrice"].Value = Price;
                Row.Cells["Status"].Value = Status;
            }

            if (form.selectedOrder == OrderNumber)
                form.SetLabel(From + "\n" + Description + "\n" + Price + "\n" + To + "\n" + DriverInfo + "\n" + Phone);
            FillNeeded();
            Form1.form.Sort("kek");
        }

        public static void FillNeeded() {
            if (form.label1.Text == "Висяк") {
                foreach (Order order in Orders) {
                    if(order.Status != "ОК") {
                        if (!form.JournalOperative.Rows.Contains(order.Row)) {
                            form.Add(order.Row);
                        }
                    } else {
                        if (form.JournalOperative.Rows.Contains(order.Row)) {
                            form.RemoveRow(order.Row);
                        }
                    }
                }
            } else {
                foreach (Order order in Orders) {
                    if (order.Status == "ОК") {
                        if (!form.JournalOperative.Rows.Contains(order.Row)) {
                            form.Add(order.Row);
                        }
                    } else {
                        if (form.JournalOperative.Rows.Contains(order.Row)) {
                            form.RemoveRow(order.Row);
                        }
                    }
                }
            }
            if(form.JournalOperative.Rows.Count == 0) {
                form.ClearMarket("kek");
                form.SetLabel("");
            }
        }

        public void DeleteOrder() {
            form.RemoveRow(Row);
            Orders.Remove(this);
        }

        public static Order GetOrder(String orderNumber) {
            foreach(Order order in Orders) {
                if(order.OrderNumber == orderNumber) {
                    return order;
                }
            }
            return null;
        }

        public static List<Order> GetOrders() {
            return Orders;
        }

        public static void ClearOrders() {
            Orders.Clear();
            form.ClearJournal("kek");
        }

    }
}
