using System;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using WindowsFormsApp1.Source.Model;
using System.Collections.Generic;

namespace WindowsFormsApp1 {
    class NetWork: Constants {
        private static NetWork netWork;
        private static readonly String IP_HOST = "83.166.242.161";
        private static readonly String IP_LOCAL = "192.168.1.151";
        private static readonly String IPL = "127.0.0.1";
        private static readonly String IP = IP_HOST;
        private static readonly int Port = 1489;

        private bool already_reconnecting = false;
        private bool pingReceived = false;

        private List<String> messagesToSend = new List<string>();

        private Socket socket;

        public static NetWork Get() {
            if (netWork == null) {
                netWork = new NetWork();
            }
            return netWork;
        }

        private void Listen() {
            byte[] bytes = new byte[128 * 1024];
            while (true) {
                try {
                    Array.Clear(bytes, 0, bytes.Length);
                    socket.Receive(bytes);
                    //Adapt(Encoding.UTF8.GetString(bytes));
                    Adapt(Encoding.GetEncoding(1251).GetString(bytes));
                } catch (Exception) {
                    break;
                }
            }
            Reconnect();
        }

        private void Reconnect() {
            if (!already_reconnecting) {
                already_reconnecting = true;
                new Thread(StartConnection).Start();
            }
        }

        private void CheckingConnection() {
            while (pingReceived) {
                pingReceived = false;
                Thread.Sleep(5000);
            }
            Reconnect();
        }

        public void StartConnection() {
            while (!Connect()) {
                Thread.Sleep(1000);
            }
        }

        private bool Connect() {
            try {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(IP, Port);
                already_reconnecting = false;
                pingReceived = true;
                new Thread(Listen).Start();
                new Thread(CheckingConnection).Start();
                String message = "[ping~ok]";
                if (messagesToSend.Count != 0) {
                    message = "";
                    foreach(String msg in messagesToSend) {
                        message += msg;
                    }
                }
                Send(message);
                Form1.form.SetName("ПОДКЛЮЧЕН");
                return true;
            } catch (Exception) {
                Form1.form.SetName("НЕТ СОЕДИНЕНИЯ");
                return false;
            }
        }

        public void Send(String message) {
            messagesToSend.Add(message);
            byte[] msg = Encoding.UTF8.GetBytes(message);
            try {
                socket.Send(msg);
            } catch (Exception) {
                Reconnect();
            }
        }

        private void Adapt(String message) {
            pingReceived = true;
            Console.WriteLine(message);
            String[] messages = message.Split(']');
            foreach (String str in messages) {
                if (str.Contains("~")) {
                    String part = str.Substring(1);
                    Identify(part);
                }
            }
        }

        private void Identify(String message) {
            try {
                String command = message.Split(COMMAND_DELIMITER)[0];
                String command_text = message.Split(COMMAND_DELIMITER)[1];
                switch (command) {
                    case COMMAND_GET:
                        Order.ClearOrders();
                        if (command_text != "NULL") {
                            List<String> orderNumbers = new List<String>();
                            String[] ordersTexts = command_text.Split(TOKEN_DELIMITER);
                            foreach (String str in ordersTexts) {
                                new Order(str);
                            }
                            Order.FillNeeded();
                        }
                        Form1.form.Sort("kek");
                        break;
                    case COMMAND_NEW:
                        new Order(command_text);
                        Order.FillNeeded();
                        break;
                    case COMMAND_UPDATE:
                        Order.GetOrder(command_text.Split(ELEMENT_DELIMITER)[0]).UpdateOrder(command_text);
                        break;
                    case COMMAND_GET_DRIVERS:
                        Driver.ClearDrivers();
                        if (command_text != "NULL") {
                            String[] str = command_text.Split(TOKEN_DELIMITER);
                            foreach (String dr in str) {
                                new Driver(dr);
                            }
                        }
                        break;
                    case COMMAND_GET_OFFERED_PRICES:
                        OfferedPrice.ClearOfferedPrices();
                        if (command_text != "NULL") {
                            String[] offeredPricesTexts;
                            if (command_text.Contains("|")) {
                                offeredPricesTexts = command_text.Split(TOKEN_DELIMITER);
                            } else {
                                offeredPricesTexts = new String[] { command_text };
                            }
                            foreach (String str in offeredPricesTexts) {
                                new OfferedPrice(str);
                            }
                        }
                        break;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case COMMAND_ONLINE:
                        Driver driver = new Driver(command_text);
                        break;
                    case COMMAND_OFFER:
                        OfferedPrice offeredPrice = new OfferedPrice(command_text);
                        break;
                    case COMMAND_UPDATE_PRICE:
                        String[] elements = command_text.Split(ELEMENT_DELIMITER);
                        OfferedPrice.GetOfferedPrice(elements[1], elements[0]).UpdatePrice(elements[2]);
                        break;
                    case COMMAND_GEO:
                        String driverId = command_text.Split(TOKEN_DELIMITER)[0];
                        String position = command_text.Split(TOKEN_DELIMITER)[1];
                        Driver.GetDriver(driverId).SetPosition(position);
                        break;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case COMMAND_ACCEPT:
                        driverId = command_text.Split(ELEMENT_DELIMITER)[0];
                        String orderNumber = command_text.Split(ELEMENT_DELIMITER)[1];
                        Order order = Order.GetOrder(orderNumber);
                        if (order != null) {
                            order.Row.Cells["Status"].Value = "ПРН";
                            order.Row.Cells["CallSign"].Value = Driver.GetCallSignByDriverId(driverId);
                        }
                        break;
                    case COMMAND_REFUSE:
                        driverId = command_text.Split(ELEMENT_DELIMITER)[0];
                        orderNumber = command_text.Split(ELEMENT_DELIMITER)[1];
                        OfferedPrice.GetOfferedPrice(orderNumber, driverId).DeletePrice();
                        break;
                    case COMMAND_COMPLETED:
                        driverId = command_text.Split(ELEMENT_DELIMITER)[0];
                        orderNumber = command_text.Split(ELEMENT_DELIMITER)[1];
                        String price = Order.GetOrder(orderNumber).Price;
                        Order.GetOrder(orderNumber).DeleteOrder();
                        Double perc = (Double.Parse(price) * 0.1 * 0.3) + (Double.Parse(Form1.form.Percents.Text));
                        Form1.form.SetPercents(Math.Floor(perc).ToString());
                        Form1.form.SetCount((Int32.Parse(Form1.form.Count.Text) + 1).ToString());
                        break;
                    case COMMAND_HURRY:
                        orderNumber = command_text.Split(ELEMENT_DELIMITER)[1];
                        order = Order.GetOrder(orderNumber);
                        if (order != null) {
                            order.Status = "ТРП";
                            Order.FillNeeded();
                            try {
                                order.Row.Cells["Status"].Value = "ТРП";
                                Form1.form.Sort("kek");
                            } catch (Exception) { }
                        }
                        break;
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case COMMAND_EXIT:
                        driverId = command_text;
                        Driver driver1 = Driver.GetDriver(driverId);
                        driver1.Exit();
                        break;
                    case "clr":
                        messagesToSend.Clear();
                        break;
                    case "time":
                        order = Order.GetOrder(command_text.Split(ELEMENT_DELIMITER)[0]);
                        if (order != null) {
                            order.Row.Cells["Time"].Value = command_text.Split(ELEMENT_DELIMITER)[1];
                        }
                        break;
                    case "sts":
                        driverId = command_text.Split(ELEMENT_DELIMITER)[0];
                        String status = command_text.Split(ELEMENT_DELIMITER)[1];
                        driver = Driver.GetDriver(driverId);
                        driver.SetStatus(status);
                        break;
                    case "del":
                        try {Order.GetOrder(command_text).DeleteOrder();} catch (Exception) { }
                        break;
                    case "perc":
                        Form1.form.SetPercents(command_text.Split(ELEMENT_DELIMITER)[0]);
                        Form1.form.SetCount(command_text.Split(ELEMENT_DELIMITER)[1]);
                        break;
                    default:
                        //System.out.println(message);
                        break;
                }
            } catch (Exception e) {
                //MessageBox.Show(e.ToString() + message);
            }
        }

        public void Close() {
            already_reconnecting = true;
            socket.Close();
        }

    }
}
