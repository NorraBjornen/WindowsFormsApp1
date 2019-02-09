namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.City = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.TextBox();
            this.Street = new System.Windows.Forms.TextBox();
            this.House = new System.Windows.Forms.TextBox();
            this.Apartment = new System.Windows.Forms.TextBox();
            this.Entrance = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.TextBox();
            this.To = new System.Windows.Forms.TextBox();
            this.Price = new System.Windows.Forms.TextBox();
            this.Ok = new System.Windows.Forms.TextBox();
            this.LabelTo = new System.Windows.Forms.Label();
            this.OrderEnter = new System.Windows.Forms.GroupBox();
            this.Monitor = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Count = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Percents = new System.Windows.Forms.Label();
            this.DriverGroup = new System.Windows.Forms.GroupBox();
            this.DriversTable = new System.Windows.Forms.DataGridView();
            this.CallSignD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistanceD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverIdD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OfferedPrice = new System.Windows.Forms.GroupBox();
            this.Market = new System.Windows.Forms.DataGridView();
            this.CallSignOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OfferedPriceOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OfferedTimeOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriverIdOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.FreeOrders = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.JournalOperative = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CallSign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderEnter.SuspendLayout();
            this.Monitor.SuspendLayout();
            this.DriverGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriversTable)).BeginInit();
            this.OfferedPrice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Market)).BeginInit();
            this.FreeOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalOperative)).BeginInit();
            this.SuspendLayout();
            // 
            // City
            // 
            this.City.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.City.Location = new System.Drawing.Point(13, 26);
            this.City.Margin = new System.Windows.Forms.Padding(10);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(350, 32);
            this.City.TabIndex = 1;
            this.City.Text = "КОСТАНАЙ";
            this.City.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextFocus);
            // 
            // Phone
            // 
            this.Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Phone.Location = new System.Drawing.Point(383, 26);
            this.Phone.Margin = new System.Windows.Forms.Padding(10);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(350, 32);
            this.Phone.TabIndex = 0;
            this.Phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextFocus);
            // 
            // Street
            // 
            this.Street.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Street.Location = new System.Drawing.Point(13, 78);
            this.Street.Margin = new System.Windows.Forms.Padding(10);
            this.Street.Name = "Street";
            this.Street.Size = new System.Drawing.Size(454, 32);
            this.Street.TabIndex = 2;
            this.Street.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Street_KeyDown);
            // 
            // House
            // 
            this.House.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.House.Location = new System.Drawing.Point(487, 78);
            this.House.Margin = new System.Windows.Forms.Padding(10);
            this.House.Name = "House";
            this.House.Size = new System.Drawing.Size(86, 32);
            this.House.TabIndex = 4;
            this.House.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextFocus);
            // 
            // Apartment
            // 
            this.Apartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Apartment.Location = new System.Drawing.Point(593, 78);
            this.Apartment.Margin = new System.Windows.Forms.Padding(10);
            this.Apartment.Name = "Apartment";
            this.Apartment.Size = new System.Drawing.Size(60, 32);
            this.Apartment.TabIndex = 5;
            this.Apartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextFocus);
            // 
            // Entrance
            // 
            this.Entrance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Entrance.Location = new System.Drawing.Point(673, 78);
            this.Entrance.Margin = new System.Windows.Forms.Padding(10);
            this.Entrance.Name = "Entrance";
            this.Entrance.Size = new System.Drawing.Size(60, 32);
            this.Entrance.TabIndex = 6;
            this.Entrance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextFocus);
            // 
            // Description
            // 
            this.Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Description.Location = new System.Drawing.Point(13, 130);
            this.Description.Margin = new System.Windows.Forms.Padding(10);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(720, 32);
            this.Description.TabIndex = 7;
            this.Description.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextFocus);
            // 
            // To
            // 
            this.To.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.To.Location = new System.Drawing.Point(13, 182);
            this.To.Margin = new System.Windows.Forms.Padding(10);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(494, 32);
            this.To.TabIndex = 8;
            this.To.KeyDown += new System.Windows.Forms.KeyEventHandler(this.To_KeyDown);
            // 
            // Price
            // 
            this.Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Price.Location = new System.Drawing.Point(527, 182);
            this.Price.Margin = new System.Windows.Forms.Padding(10);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(126, 32);
            this.Price.TabIndex = 9;
            this.Price.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NextFocus);
            // 
            // Ok
            // 
            this.Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ok.Location = new System.Drawing.Point(673, 182);
            this.Ok.Margin = new System.Windows.Forms.Padding(10);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(60, 32);
            this.Ok.TabIndex = 10;
            this.Ok.Text = "OK";
            this.Ok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Ok.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ok_KeyDown);
            // 
            // LabelTo
            // 
            this.LabelTo.AutoSize = true;
            this.LabelTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelTo.Location = new System.Drawing.Point(19, 234);
            this.LabelTo.Margin = new System.Windows.Forms.Padding(10);
            this.LabelTo.Name = "LabelTo";
            this.LabelTo.Size = new System.Drawing.Size(0, 26);
            this.LabelTo.TabIndex = 11;
            // 
            // OrderEnter
            // 
            this.OrderEnter.Controls.Add(this.City);
            this.OrderEnter.Controls.Add(this.LabelTo);
            this.OrderEnter.Controls.Add(this.Phone);
            this.OrderEnter.Controls.Add(this.Ok);
            this.OrderEnter.Controls.Add(this.Street);
            this.OrderEnter.Controls.Add(this.Price);
            this.OrderEnter.Controls.Add(this.House);
            this.OrderEnter.Controls.Add(this.To);
            this.OrderEnter.Controls.Add(this.Apartment);
            this.OrderEnter.Controls.Add(this.Description);
            this.OrderEnter.Controls.Add(this.Entrance);
            this.OrderEnter.Location = new System.Drawing.Point(19, 19);
            this.OrderEnter.Margin = new System.Windows.Forms.Padding(10);
            this.OrderEnter.Name = "OrderEnter";
            this.OrderEnter.Size = new System.Drawing.Size(1246, 723);
            this.OrderEnter.TabIndex = 12;
            this.OrderEnter.TabStop = false;
            // 
            // Monitor
            // 
            this.Monitor.Controls.Add(this.label7);
            this.Monitor.Controls.Add(this.Count);
            this.Monitor.Controls.Add(this.label5);
            this.Monitor.Controls.Add(this.Percents);
            this.Monitor.Controls.Add(this.DriverGroup);
            this.Monitor.Controls.Add(this.label3);
            this.Monitor.Controls.Add(this.OfferedPrice);
            this.Monitor.Controls.Add(this.FreeOrders);
            this.Monitor.Location = new System.Drawing.Point(19, 19);
            this.Monitor.Margin = new System.Windows.Forms.Padding(10);
            this.Monitor.Name = "Monitor";
            this.Monitor.Size = new System.Drawing.Size(1246, 723);
            this.Monitor.TabIndex = 12;
            this.Monitor.TabStop = false;
            this.Monitor.Enter += new System.EventHandler(this.Monitor_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(1021, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Заявок:";
            // 
            // Count
            // 
            this.Count.AutoSize = true;
            this.Count.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Count.Location = new System.Drawing.Point(1134, 49);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(46, 17);
            this.Count.TabIndex = 7;
            this.Count.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1021, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Сумма:";
            // 
            // Percents
            // 
            this.Percents.AutoSize = true;
            this.Percents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Percents.Location = new System.Drawing.Point(1134, 22);
            this.Percents.Name = "Percents";
            this.Percents.Size = new System.Drawing.Size(46, 17);
            this.Percents.TabIndex = 5;
            this.Percents.Text = "label5";
            // 
            // DriverGroup
            // 
            this.DriverGroup.Controls.Add(this.DriversTable);
            this.DriverGroup.Controls.Add(this.label4);
            this.DriverGroup.Location = new System.Drawing.Point(741, 72);
            this.DriverGroup.Margin = new System.Windows.Forms.Padding(10);
            this.DriverGroup.Name = "DriverGroup";
            this.DriverGroup.Size = new System.Drawing.Size(492, 638);
            this.DriverGroup.TabIndex = 4;
            this.DriverGroup.TabStop = false;
            // 
            // DriversTable
            // 
            this.DriversTable.AllowUserToAddRows = false;
            this.DriversTable.AllowUserToDeleteRows = false;
            this.DriversTable.AllowUserToResizeColumns = false;
            this.DriversTable.AllowUserToResizeRows = false;
            this.DriversTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DriversTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CallSignD,
            this.StatusD,
            this.DistanceD,
            this.DriverIdD,
            this.TimeD});
            this.DriversTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DriversTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DriversTable.Location = new System.Drawing.Point(34, 60);
            this.DriversTable.Margin = new System.Windows.Forms.Padding(10);
            this.DriversTable.Name = "DriversTable";
            this.DriversTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DriversTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DriversTable.Size = new System.Drawing.Size(445, 558);
            this.DriversTable.TabIndex = 1;
            this.DriversTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DriversTable_KeyDown);
            // 
            // CallSignD
            // 
            this.CallSignD.HeaderText = "Позывной";
            this.CallSignD.Name = "CallSignD";
            // 
            // StatusD
            // 
            this.StatusD.HeaderText = "Статус";
            this.StatusD.Name = "StatusD";
            // 
            // DistanceD
            // 
            this.DistanceD.HeaderText = "Дистанция";
            this.DistanceD.Name = "DistanceD";
            // 
            // DriverIdD
            // 
            this.DriverIdD.HeaderText = "Column1";
            this.DriverIdD.Name = "DriverIdD";
            this.DriverIdD.Visible = false;
            // 
            // TimeD
            // 
            this.TimeD.HeaderText = "Время";
            this.TimeD.Name = "TimeD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(279, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Водители";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // OfferedPrice
            // 
            this.OfferedPrice.Controls.Add(this.Market);
            this.OfferedPrice.Controls.Add(this.label2);
            this.OfferedPrice.Location = new System.Drawing.Point(741, 72);
            this.OfferedPrice.Margin = new System.Windows.Forms.Padding(10);
            this.OfferedPrice.Name = "OfferedPrice";
            this.OfferedPrice.Size = new System.Drawing.Size(492, 638);
            this.OfferedPrice.TabIndex = 2;
            this.OfferedPrice.TabStop = false;
            // 
            // Market
            // 
            this.Market.AllowUserToAddRows = false;
            this.Market.AllowUserToDeleteRows = false;
            this.Market.AllowUserToResizeColumns = false;
            this.Market.AllowUserToResizeRows = false;
            this.Market.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Market.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CallSignOP,
            this.OfferedPriceOP,
            this.OfferedTimeOP,
            this.IdOP,
            this.DriverIdOP});
            this.Market.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Market.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Market.Location = new System.Drawing.Point(136, 60);
            this.Market.Margin = new System.Windows.Forms.Padding(10);
            this.Market.Name = "Market";
            this.Market.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Market.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Market.Size = new System.Drawing.Size(343, 558);
            this.Market.TabIndex = 1;
            this.Market.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Market_KeyDown);
            // 
            // CallSignOP
            // 
            this.CallSignOP.HeaderText = "Позывной";
            this.CallSignOP.Name = "CallSignOP";
            // 
            // OfferedPriceOP
            // 
            this.OfferedPriceOP.HeaderText = "Цена";
            this.OfferedPriceOP.Name = "OfferedPriceOP";
            // 
            // OfferedTimeOP
            // 
            this.OfferedTimeOP.HeaderText = "Время";
            this.OfferedTimeOP.Name = "OfferedTimeOP";
            // 
            // IdOP
            // 
            this.IdOP.HeaderText = "Id";
            this.IdOP.Name = "IdOP";
            this.IdOP.Visible = false;
            // 
            // DriverIdOP
            // 
            this.DriverIdOP.HeaderText = "DriverId";
            this.DriverIdOP.Name = "DriverIdOP";
            this.DriverIdOP.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(279, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Предложенные цены";
            // 
            // FreeOrders
            // 
            this.FreeOrders.Controls.Add(this.label1);
            this.FreeOrders.Controls.Add(this.JournalOperative);
            this.FreeOrders.Cursor = System.Windows.Forms.Cursors.Default;
            this.FreeOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FreeOrders.Location = new System.Drawing.Point(13, 249);
            this.FreeOrders.Margin = new System.Windows.Forms.Padding(10);
            this.FreeOrders.Name = "FreeOrders";
            this.FreeOrders.Padding = new System.Windows.Forms.Padding(10);
            this.FreeOrders.Size = new System.Drawing.Size(708, 461);
            this.FreeOrders.TabIndex = 1;
            this.FreeOrders.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(610, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Висяк";
            // 
            // JournalOperative
            // 
            this.JournalOperative.AllowUserToAddRows = false;
            this.JournalOperative.AllowUserToDeleteRows = false;
            this.JournalOperative.AllowUserToResizeColumns = false;
            this.JournalOperative.AllowUserToResizeRows = false;
            this.JournalOperative.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JournalOperative.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.Address,
            this.CallSign,
            this.OrderPrice,
            this.Status,
            this.Id});
            this.JournalOperative.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.JournalOperative.Location = new System.Drawing.Point(20, 68);
            this.JournalOperative.Margin = new System.Windows.Forms.Padding(10);
            this.JournalOperative.Name = "JournalOperative";
            this.JournalOperative.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.JournalOperative.Size = new System.Drawing.Size(668, 373);
            this.JournalOperative.TabIndex = 0;
            this.JournalOperative.SelectionChanged += new System.EventHandler(this.JournalOperative_SelectionChanged);
            this.JournalOperative.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Switch_Scene);
            // 
            // Time
            // 
            this.Time.HeaderText = "Врм";
            this.Time.Name = "Time";
            this.Time.Width = 60;
            // 
            // Address
            // 
            this.Address.HeaderText = "Адрес";
            this.Address.Name = "Address";
            this.Address.Width = 300;
            // 
            // CallSign
            // 
            this.CallSign.HeaderText = "Вд";
            this.CallSign.Name = "CallSign";
            this.CallSign.Width = 60;
            // 
            // OrderPrice
            // 
            this.OrderPrice.HeaderText = "Цена";
            this.OrderPrice.Name = "OrderPrice";
            // 
            // Status
            // 
            this.Status.HeaderText = "Стс";
            this.Status.Name = "Status";
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 761);
            this.Controls.Add(this.Monitor);
            this.Controls.Add(this.OrderEnter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Switch_Scene);
            this.OrderEnter.ResumeLayout(false);
            this.OrderEnter.PerformLayout();
            this.Monitor.ResumeLayout(false);
            this.Monitor.PerformLayout();
            this.DriverGroup.ResumeLayout(false);
            this.DriverGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriversTable)).EndInit();
            this.OfferedPrice.ResumeLayout(false);
            this.OfferedPrice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Market)).EndInit();
            this.FreeOrders.ResumeLayout(false);
            this.FreeOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalOperative)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox City;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.TextBox Street;
        private System.Windows.Forms.TextBox House;
        private System.Windows.Forms.TextBox Apartment;
        private System.Windows.Forms.TextBox Entrance;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.TextBox To;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.TextBox Ok;
        private System.Windows.Forms.Label LabelTo;
        private System.Windows.Forms.GroupBox OrderEnter;
        private System.Windows.Forms.GroupBox Monitor;
        private System.Windows.Forms.GroupBox FreeOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallSign;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.GroupBox OfferedPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallSignOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfferedPriceOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfferedTimeOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverIdOP;
        private System.Windows.Forms.DataGridView Market;
        public System.Windows.Forms.DataGridView JournalOperative;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox DriverGroup;
        private System.Windows.Forms.DataGridView DriversTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CallSignD;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistanceD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverIdD;
        public System.Windows.Forms.Label Percents;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label Count;
    }
}

