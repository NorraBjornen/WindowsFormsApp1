using System;
using System.Net.Http;
using System.Collections.Generic;
using WindowsFormsApp1.Source.Model;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using System.ComponentModel;

namespace WindowsFormsApp1{
    public partial class Form1 : Form{
        public static Form1 form;
        private List<TextBox> list = new List<TextBox>();
        private String stringTo = "";
        public String selectedOrder = "0";

        public Form1(){
            form = this;
            InitializeComponent();
            LoadList();


            List<AutoCompleteStringCollection> list = new DataBase().GetStreets();

            Street.AutoCompleteMode = AutoCompleteMode.Suggest;
            Street.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Street.AutoCompleteCustomSource = list[0];

            To.AutoCompleteMode = AutoCompleteMode.Suggest;
            To.AutoCompleteSource = AutoCompleteSource.CustomSource;
            To.AutoCompleteCustomSource = list[1];
        }

        private void Form1_Load(object sender, EventArgs e){
            DriverGroup.Visible = false;
            Ok.ReadOnly = true;

            Monitor.Visible = false;
            OrderEnter.Visible = true;

            Monitor.KeyDown += Switch_Scene;
            JournalOperative.KeyDown += JournalOperative_KeyDown;

            JournalOperative.ClearSelection();
            Market.ClearSelection();

            new Thread(NetWork.Get().StartConnection).Start();
        }

        private void DriversTable_KeyDown(object sender, KeyEventArgs e) {
            try {
                switch (e.KeyCode) {
                    case Keys.Left:
                        JournalOperative.Focus();
                        if (JournalOperative.Rows.Count != 0) {
                        }
                        DriversTable.CurrentCell.Selected = false;
                        break;
                    case Keys.Enter:
                        int index = DriversTable.CurrentCell.RowIndex;
                        String driverId = DriversTable.Rows[index].Cells["DriverIdD"].Value.ToString();
                        NetWork.Get().Send("[go~" + selectedOrder + "$" + driverId + "$1]");
                        JournalOperative.Focus();
                        DriversTable.CurrentCell.Selected = false;
                        break;
                    case Keys.Delete:
                        index = DriversTable.CurrentCell.RowIndex;
                        driverId = DriversTable.Rows[index].Cells["DriverIdD"].Value.ToString();
                        NetWork.Get().Send("[deldrv~" + driverId + "]");
                        break;
                    default:

                        break;
                }
            } catch (Exception) { }
        }

        private void JournalOperative_KeyDown(object sender, KeyEventArgs e) {
            try {
                switch (e.KeyCode) {
                    case Keys.Tab:
                        Order order = Order.GetOrder(JournalOperative.Rows[JournalOperative.CurrentCell.RowIndex].Cells["Id"].Value.ToString());
                        City.Text = order.City;
                        Phone.Text = order.Phone;
                        Street.Text = order.From;
                        Description.Text = order.Description;
                        To.Text = order.To;
                        Price.Text = order.Price;
                        Ok.Text = "UP";
                        Monitor.Visible = false;
                        OrderEnter.Visible = true;
                        Phone.Focus();
                        break;
                    case Keys.Left:
                        if(label1.Text == "Рабочие") {
                            label1.Text = "Висяк";
                        } else {
                            label1.Text = "Рабочие";
                        }
                        Order.FillNeeded();
                        Form1.form.Sort("kek");
                        break;
                    case Keys.Delete:
                        int index = JournalOperative.CurrentCell.RowIndex;
                        String orderNumber = JournalOperative.Rows[index].Cells["Id"].Value.ToString();
                        NetWork.Get().Send("[del~" + orderNumber + "]");
                        break;
                    case Keys.Back:
                        index = JournalOperative.CurrentCell.RowIndex;
                        orderNumber = JournalOperative.Rows[index].Cells["Id"].Value.ToString();
                        String callSign = JournalOperative.Rows[index].Cells["CallSign"].Value.ToString();
                        NetWork.Get().Send("[takeoff~" + orderNumber + "$" + Driver.GetDriverIdByCallSign(callSign) + "]");
                        break;
                    case Keys.F3:
                        if (DriverGroup.Visible) {
                            DriverGroup.Visible = false;
                            OfferedPrice.Visible = true;
                        } else {
                            DriverGroup.Visible = true;
                            OfferedPrice.Visible = false;
                            order = Order.GetOrder(selectedOrder);
                            foreach (Driver driver in Driver.Drivers) {
                                if (order.From != "")
                                    driver.SetDistance(order.From);
                            }
                        }
                        break;
                    case Keys.Right:
                        if (DriverGroup.Visible) {
                            if (DriversTable.Rows.Count != 0) {
                                DriversTable.Focus();
                                DriversTable.Rows[0].Selected = true;
                            }
                        } else {
                            if (Market.Rows.Count != 0) {
                                Market.Focus();
                                Market.Rows[0].Selected = true;
                            }
                        }
                        break;
                    case Keys.ShiftKey:
                        orderNumber = JournalOperative.Rows[JournalOperative.CurrentCell.RowIndex].Cells["Id"].Value.ToString();
                        NetWork.Get().Send("[trp~" + Driver.GetDriverIdByCallSign(JournalOperative.Rows[JournalOperative.CurrentCell.RowIndex].Cells["CallSign"].Value.ToString()) + "$" + orderNumber + "]");
                        break;
                    default:

                        break;
                }
            } catch (Exception) { }
        }

        private void Market_KeyDown(object sender, KeyEventArgs e) {
            try {
                switch (e.KeyCode) {
                    case Keys.Left:
                        JournalOperative.Focus();
                        if (JournalOperative.Rows.Count != 0) {
                            JournalOperative.Rows[0].Selected = true;
                        }
                        Market.CurrentCell.Selected = false;
                        break;
                    case Keys.Enter:
                        String driverId = Market.Rows[Market.CurrentCell.RowIndex].Cells["DriverIdOP"].Value.ToString();
                        String orderNumber = Market.Rows[Market.CurrentCell.RowIndex].Cells["IdOP"].Value.ToString();
                        JournalOperative.Focus();
                        Market.CurrentCell.Selected = false;
                        NetWork.Get().Send("[go~" + orderNumber + "$" + driverId + "$1]");
                        break;
                    default:

                        break;
                }
            } catch (Exception) { }
        }

        private void Street_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    Street.Text = new DataBase().GetCorrect(Street.Text);
                    House.Focus();
                    break;
                case Keys.Left:
                    Phone.Focus();
                    break;
            }
        }

        private void To_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    if (To.Text == "") {
                        Price.Focus();
                        To.Text = stringTo;
                        stringTo = "";
                        LabelTo.Text = stringTo;
                        new Thread(GetPrice).Start();
                    } else {
                        String le = "";
                        String route = To.Text;
                        if (route.Any(char.IsDigit)) {
                            string[] elements = route.Split(' ');
                            if (elements.Length > 1) {
                                String lastElement = elements[elements.Length - 1];
                                if (lastElement.Any(char.IsDigit)) {
                                    le = lastElement;
                                    route = "";
                                    for (int i = 0; i < elements.Length; i++) {
                                        if (elements[i] != lastElement) {
                                            route = route + " " + elements[i];
                                        }
                                    }
                                    if (route != "") {
                                        route = route.Substring(1);
                                    }
                                }
                            }
                        }

                        To.Text = new DataBase().GetCorrect(route) + " " + le;

                        if (stringTo == "") {
                            stringTo = To.Text;
                            To.Clear();
                        } else {
                            if (stringTo.Split('>').Length != 3) {
                                stringTo = stringTo + " -->" + To.Text;
                                To.Clear();
                            } else {
                                To.Text = "ПОВРЕМЕННАЯ";
                                stringTo = "";
                                LabelTo.Text = "";
                                Price.Focus();
                                new Thread(GetPrice).Start();
                            }
                        }
                        LabelTo.Text = stringTo;
                    }
                    break;
                case Keys.Back:
                    if (To.Text == "") {
                        if (stringTo.Contains(">")) {
                            String[] routes = stringTo.Split('>');
                            stringTo = "";
                            for (int i = 0; i < routes.Length - 1; i++) {
                                stringTo = stringTo + routes[i] + ">";
                            }
                            if (stringTo != "") {
                                stringTo = stringTo.Substring(0, stringTo.Length - 4);
                            }
                            LabelTo.Text = stringTo;
                        } else {
                            stringTo = "";
                            LabelTo.Text = "";
                        }
                    }
                    break;
                case Keys.Left:
                    Description.Focus();
                    break;
            }
        }

        private void LoadList() {
            list.Add(City);
            list.Add(Phone);
            list.Add(Street);
            list.Add(House);
            list.Add(Apartment);
            list.Add(Entrance);
            list.Add(Description);
            list.Add(To);
            list.Add(Price);
            list.Add(Ok);
            foreach (TextBox textBox in list) {
                textBox.CharacterCasing = CharacterCasing.Upper;
                textBox.GotFocus += GotFocus;
                textBox.KeyDown += Switch_Scene;
            }
        }

        private new void GotFocus(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            textBox.SelectAll();
        }

        private void GetPrice() {
            AppendTextBox(new Valuer(City.Text, Street.Text, House.Text, To.Text).GetPrice().ToString());
        }

        private void AppendTextBox(string value) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            Price.Text = value;
        }

        private void Ok_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    String city, phone, description, to, price, from;

                    if (City.Text.Length == 0) City.Text = "КОСТАНАЙ";
                    city = City.Text;
                    if (Phone.Text.Length == 0) Phone.Text = "-";
                    phone = Phone.Text;
                    if (Description.Text.Length == 0) Description.Text = "-";
                    description = Description.Text;
                    if (To.Text.Length == 0) To.Text = "-";
                    to = To.Text;
                    if (Price.Text.Length == 0) Price.Text = "-";
                    price = Price.Text;

                    from = City.Text + "," + Street.Text;
                    if (House.Text.Length != 0) from = from + " " + House.Text;
                    if (Apartment.Text.Length != 0) from = from + " кв." + Apartment.Text;
                    if (Entrance.Text.Length != 0) from = from + " п." + Entrance.Text;

                    String message;
                    if (Ok.Text == "OK") {
                        message = "[new~" + from + "$" + to + "$" + price + "$" + phone + "$" + description + "]";
                    } else {
                        message = "[upd~"+ Form1.form.selectedOrder + "|" + from + "$" + to + "$" + price + "$" + phone + "$" + description + "]";
                    }
                    NetWork.Get().Send(message);

                    Phone.Clear();
                    Street.Clear();
                    House.Clear();
                    Apartment.Clear();
                    Entrance.Clear();
                    Description.Clear();
                    To.Clear();
                    Price.Clear();
                    Ok.Text = "OK";

                    Phone.Focus();

                    Monitor.Visible = true;
                    OrderEnter.Visible = false;
                    JournalOperative.Focus();

                    break;
                case Keys.Left:
                    Price.Focus();
                    break;
                default:
                    Ok.Text = "OK";
                    break;
            }
        }

        private void NextFocus(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    int position = list.IndexOf((TextBox)sender) + 1;
                    if (position >= list.Count)
                        position = 1;
                    TextBox textBox = list[position];
                    textBox.Focus();
                    break;
                case Keys.Left:
                    position = list.IndexOf((TextBox)sender) - 1;
                    if (position < 0)
                        position = list.Count - 1;
                    textBox = list[position];
                    textBox.Focus();
                    break;
                default:

                    break;
            }

        }

        private void Switch_Scene(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.ControlKey) {
                if(Monitor.Visible) {
                    Monitor.Visible = false;
                    OrderEnter.Visible = true;
                    Phone.Focus();
                } else {
                    OrderEnter.Visible = false;
                    Monitor.Visible = true;
                    JournalOperative.Focus();
                }
                City.Text = "КОСТАНАЙ";
                Phone.Clear();
                Street.Clear();
                House.Clear();
                Apartment.Clear();
                Entrance.Clear();
                Description.Clear();
                To.Clear();
                Price.Clear();
                Ok.Text = "OK";
            }
        }

        public void AddDriver(String source) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(AddDriver), new object[] { source });
                return;
            }
            String[] elements = source.Split('$');


            String[] row = new string[] {
                elements[0], elements[1], elements[2], elements[3], elements[4]
            };

            int index = DriversTable.Rows.Add(row);
            DataGridViewRow Row = DriversTable.Rows[index];
            Driver.GetDriver(elements[3]).Row = Row;
            Row.Selected = false;
        }

        public void RemoveDriver(DataGridViewRow row) {
            if (InvokeRequired) {
                this.Invoke(new Action<DataGridViewRow>(RemoveDriver), new object[] { row });
                return;
            }
            DriversTable.Rows.Remove(row);
        }

        public void Add(DataGridViewRow row) {
            if (InvokeRequired) {
                this.Invoke(new Action<DataGridViewRow>(Add), new object[] { row });
                return;
            }
            try {
                JournalOperative.Rows.Add(row);
            } catch (Exception) { }
        }

        public void AddRow(String source) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(AddRow), new object[] { source });
                return;
            }
            String[] elements = source.Split('$');


            String[] row = new string[] {
                elements[0], elements[1], elements[2], elements[3], elements[4], elements[5]
            };

            int index = JournalOperative.Rows.Add(row);
            DataGridViewRow Row = JournalOperative.Rows[index];
            Order.GetOrder(elements[5]).Row = Row;
            selectedOrder = JournalOperative.Rows[JournalOperative.CurrentCell.RowIndex].Cells["Id"].Value.ToString();
        }

        public void RemoveRow(DataGridViewRow row) {
            if (InvokeRequired) {
                this.Invoke(new Action<DataGridViewRow>(RemoveRow), new object[] { row });
                return;
            }
            try {
                int index = JournalOperative.CurrentCell.RowIndex;
                JournalOperative.Rows.Remove(row);
                if (JournalOperative.Rows.Count != 0) {
                    if (JournalOperative.Rows.Count > index) {
                        JournalOperative.Rows[index].Selected = true;
                        selectedOrder = JournalOperative.Rows[index].Cells["Id"].Value.ToString();
                        Source.Model.OfferedPrice.FillCurrentData();
                    } else {
                        JournalOperative.Rows[index - 1].Selected = true;
                        selectedOrder = JournalOperative.Rows[index - 1].Cells["Id"].Value.ToString();
                        Source.Model.OfferedPrice.FillCurrentData();
                    }
                } else {
                    ClearMarket("kek");
                }
            } catch (Exception) {
                ClearMarket("kek");
            }
        }

        public void ClearJournal(String row) {
            if (InvokeRequired) {
                this.Invoke(new Action<String>(ClearJournal), new object[] { row });
                return;
            }
            JournalOperative.Rows.Clear();
        }

        public void AddCurrent(DataGridViewRow row) {
            if (InvokeRequired) {
                this.Invoke(new Action<DataGridViewRow>(AddCurrent), new object[] { row });
                return;
            }
            Market.Rows.Add(row);
            row.Selected = false;
        }

        public void ClearMarket(String row) {
            if (InvokeRequired) {
                this.Invoke(new Action<String>(ClearMarket), new object[] { row });
                return;
            }
            Market.Rows.Clear();
        }

        public void ClearDrivers(String row) {
            if (InvokeRequired) {
                this.Invoke(new Action<String>(ClearDrivers), new object[] { row });
                return;
            }
            DriversTable.Rows.Clear();
        }

        public void AddOfferedPrice(String source) {
            if (InvokeRequired) {
                this.Invoke(new Action<string>(AddOfferedPrice), new object[] { source });
                return;
            }
            String[] elements = source.Split('$');

            String[] row = new string[] {
                elements[4], elements[2], elements[3], elements[1], elements[0]
            };

            int index = Market.Rows.Add(row);
            DataGridViewRow Row = Market.Rows[index];
            Source.Model.OfferedPrice.GetOfferedPrice(elements[1], elements[0]).Row = Row;
            if (elements[1] != selectedOrder) {
                Market.Rows.Remove(Row);
            }
            Row.Selected = false;
        }

        public void RemoveOfferedPrice(DataGridViewRow row) {
            if (InvokeRequired) {
                this.Invoke(new Action<DataGridViewRow>(RemoveOfferedPrice), new object[] { row });
                return;
            }
            Market.Rows.Remove(row);
        }

        public void Sort(String str) {
            if (InvokeRequired) {
                this.Invoke(new Action<String>(Sort), new object[] { str });
                return;
            }
            JournalOperative.Sort(JournalOperative.Columns["Status"], ListSortDirection.Descending);
            foreach(DataGridViewRow row in JournalOperative.Rows) {
                if(row.Cells["Id"].Value.ToString() == selectedOrder) {
                    row.Selected = true;
                }
            }
        }

        private void JournalOperative_SelectionChanged(object sender, EventArgs e) {
            try {
                selectedOrder = JournalOperative.Rows[JournalOperative.CurrentCell.RowIndex].Cells["Id"].Value.ToString();
                Order order = Order.GetOrder(selectedOrder);
                label3.Text = order.From + "\n" + order.Description + "\n" + order.Price + "\n" + order.To + "\n" + order.DriverInfo + "\n" + order.Phone;
                Source.Model.OfferedPrice.FillCurrentData();
                if (DriverGroup.Visible) {
                    foreach(Driver driver in Driver.Drivers) {
                        if(order.From != "")
                        driver.SetDistance(order.From);
                    }
                }
            } catch (Exception) {
                Market.Rows.Clear();
            }
        }

        public void SetName(String name) {
            if (InvokeRequired) {
                this.Invoke(new Action<String>(SetName), new object[] { name });
                return;
            }
            this.Text = name;
        }

        public void SetLabel (String text) {
            if (InvokeRequired) {
                this.Invoke(new Action<String>(SetLabel), new object[] { text });
                return;
            }
            label3.Text = text;
        }

        public void SetPercents(String text) {
            if (InvokeRequired) {
                this.Invoke(new Action<String>(SetPercents), new object[] { text });
                return;
            }
            Percents.Text = text;
        }

        public void SetCount(String text) {
            if (InvokeRequired) {
                this.Invoke(new Action<String>(SetCount), new object[] { text });
                return;
            }
            Count.Text = text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            NetWork.Get().Close();
            Application.Exit();
        }

        private void Monitor_Enter(object sender, EventArgs e)
        {

        }
    }
}
