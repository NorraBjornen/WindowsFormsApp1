using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Source.Model {
    class OfferedPrice {
        private static readonly Form1 form = Form1.form;
        private static List<OfferedPrice> OfferedPrices = new List<OfferedPrice>();

        private readonly String DriverId, OrderNumber;
        public DataGridViewRow Row;

        public OfferedPrice(String offeredPrice) {
            String[] elements = offeredPrice.Split('$');

            DriverId = elements[0];
            OrderNumber = elements[1];

            offeredPrice = offeredPrice + "$" +Driver.GetCallSignByDriverId(DriverId);

            OfferedPrices.Add(this);
            form.AddOfferedPrice(offeredPrice);

            Order order = Order.GetOrder(OrderNumber);

            try {
                if (order.Row.Cells["Status"].Value.ToString() == "-") {
                    order.Row.Cells["Status"].Value = "ЦН";
                    Form1.form.Sort("kek");
                }
            } catch (Exception) {
                form.ClearMarket("ez");
            }
        }

        public void UpdatePrice(String offeredPrice) {
            Row.Cells["OfferedPriceOP"].Value = offeredPrice;
        }

        public static void DeleteDriversPrices(String driverId) {
            List<OfferedPrice> list = new List<OfferedPrice>();
            foreach (OfferedPrice offeredPrice in OfferedPrices) {
                if (offeredPrice.DriverId == driverId) {
                    list.Add(offeredPrice);
                }
            }
            foreach (OfferedPrice op in list) {
                OfferedPrices.Remove(op);
            }
            FillCurrentData();
        }

        public void DeletePrice() {
            OfferedPrices.Remove(this);
            FillCurrentData();
        }

        public static OfferedPrice GetOfferedPrice(String orderNumber, String driverId) {
            foreach (OfferedPrice offeredPrice in OfferedPrices) {
                if (offeredPrice.OrderNumber == orderNumber && offeredPrice.DriverId == driverId) {
                    return offeredPrice;
                }
            }
            return null;
        }

        public static void FillCurrentData() {
            form.ClearMarket("ez");
            foreach (OfferedPrice offeredPrice in OfferedPrices) {
                if (offeredPrice.OrderNumber == form.selectedOrder) {
                    form.AddCurrent(offeredPrice.Row);
                }
            }
        }

        public static void ClearOfferedPrices() {
            OfferedPrices.Clear();
            form.ClearMarket("kek");
        }
    }
}
