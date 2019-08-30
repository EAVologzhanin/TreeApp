namespace TreeApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.structureComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.typeOfStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.currencyStripComboBox3 = new System.Windows.Forms.ToolStripComboBox();
            this.AddCircleMenu = new System.Windows.Forms.Button();
            this.DeleteMenu = new System.Windows.Forms.Button();
            this.label1WithInfo = new System.Windows.Forms.Label();
            this.ChangeMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Open = new System.Windows.Forms.Button();
            this.treeLabel = new System.Windows.Forms.Label();
            this.ReDownload = new System.Windows.Forms.Button();
            this.Total = new System.Windows.Forms.Button();
            this.SaveAsPicture = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.AddTriangle = new System.Windows.Forms.Button();
            this.AddSquare = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.AddCircle = new System.Windows.Forms.Button();
            this.CtrlzBack = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CopyMenu = new System.Windows.Forms.Button();
            this.PasteMenu = new System.Windows.Forms.Button();
            this.min = new System.Windows.Forms.CheckBox();
            this.max = new System.Windows.Forms.CheckBox();
            this.currencies = new System.Windows.Forms.CheckBox();
            this.price = new System.Windows.Forms.CheckBox();
            this.number = new System.Windows.Forms.CheckBox();
            this.Center = new System.Windows.Forms.Button();
            this.eventLabel = new System.Windows.Forms.Label();
            this.knotLabel = new System.Windows.Forms.Label();
            this.listLabel = new System.Windows.Forms.Label();
            this.deleteLabel = new System.Windows.Forms.Label();
            this.logoAdd = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.AddSquareMenu = new System.Windows.Forms.Button();
            this.AddTriangleMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(130, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(696, 386);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.structureComboBox1,
            this.toolStripLabel2,
            this.typeOfStripComboBox2,
            this.toolStripLabel3,
            this.currencyStripComboBox3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(95, 30);
            this.toolStripLabel1.Text = "Структура";
            // 
            // structureComboBox1
            // 
            this.structureComboBox1.Items.AddRange(new object[] {
            "Граф",
            "Дерево"});
            this.structureComboBox1.Name = "structureComboBox1";
            this.structureComboBox1.Size = new System.Drawing.Size(75, 33);
            this.structureComboBox1.SelectedIndexChanged += new System.EventHandler(this.TypeOfTree_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(106, 30);
            this.toolStripLabel2.Text = "   Расчет по";
            // 
            // typeOfStripComboBox2
            // 
            this.typeOfStripComboBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "Вероятности",
            "Стоимости"});
            this.typeOfStripComboBox2.Items.AddRange(new object[] {
            "Вероятности",
            "Стоимости",
            "Вероятностной стоимости"});
            this.typeOfStripComboBox2.Name = "typeOfStripComboBox2";
            this.typeOfStripComboBox2.Size = new System.Drawing.Size(150, 33);
            this.typeOfStripComboBox2.SelectedIndexChanged += new System.EventHandler(this.Total_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(81, 30);
            this.toolStripLabel3.Text = "  Валюта";
            // 
            // currencyStripComboBox3
            // 
            this.currencyStripComboBox3.Items.AddRange(new object[] {
            "$ - Доллар",
            "₽ - Рубль",
            "€ - Евро ",
            "£ - Фунт ",
            " ¥ - Юань "});
            this.currencyStripComboBox3.Name = "currencyStripComboBox3";
            this.currencyStripComboBox3.Size = new System.Drawing.Size(115, 33);
            this.currencyStripComboBox3.SelectedIndexChanged += new System.EventHandler(this.Currency_SelectedIndexChanged);
            // 
            // AddCircleMenu
            // 
            this.AddCircleMenu.AutoSize = true;
            this.AddCircleMenu.BackColor = System.Drawing.SystemColors.Window;
            this.AddCircleMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddCircleMenu.BackgroundImage")));
            this.AddCircleMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddCircleMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddCircleMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCircleMenu.Location = new System.Drawing.Point(478, 129);
            this.AddCircleMenu.Name = "AddCircleMenu";
            this.AddCircleMenu.Size = new System.Drawing.Size(40, 40);
            this.AddCircleMenu.TabIndex = 3;
            this.AddCircleMenu.UseVisualStyleBackColor = false;
            this.AddCircleMenu.Visible = false;
            this.AddCircleMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddCircle_MouseDown);
            // 
            // DeleteMenu
            // 
            this.DeleteMenu.BackColor = System.Drawing.SystemColors.Window;
            this.DeleteMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DeleteMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteMenu.Location = new System.Drawing.Point(478, 174);
            this.DeleteMenu.Name = "DeleteMenu";
            this.DeleteMenu.Size = new System.Drawing.Size(119, 40);
            this.DeleteMenu.TabIndex = 4;
            this.DeleteMenu.Text = "Удалить";
            this.DeleteMenu.UseVisualStyleBackColor = false;
            this.DeleteMenu.Visible = false;
            this.DeleteMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Delete_MouseDown);
            // 
            // label1WithInfo
            // 
            this.label1WithInfo.AutoSize = true;
            this.label1WithInfo.Location = new System.Drawing.Point(470, 83);
            this.label1WithInfo.Name = "label1WithInfo";
            this.label1WithInfo.Size = new System.Drawing.Size(51, 20);
            this.label1WithInfo.TabIndex = 8;
            this.label1WithInfo.Text = "label1";
            // 
            // ChangeMenu
            // 
            this.ChangeMenu.AutoSize = true;
            this.ChangeMenu.BackColor = System.Drawing.SystemColors.Window;
            this.ChangeMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ChangeMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeMenu.Location = new System.Drawing.Point(478, 219);
            this.ChangeMenu.Name = "ChangeMenu";
            this.ChangeMenu.Size = new System.Drawing.Size(119, 40);
            this.ChangeMenu.TabIndex = 9;
            this.ChangeMenu.Text = "Изменить";
            this.ChangeMenu.UseVisualStyleBackColor = false;
            this.ChangeMenu.Visible = false;
            this.ChangeMenu.Click += new System.EventHandler(this.Change_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.panel1.Controls.Add(this.Open);
            this.panel1.Controls.Add(this.treeLabel);
            this.panel1.Controls.Add(this.ReDownload);
            this.panel1.Controls.Add(this.Total);
            this.panel1.Controls.Add(this.SaveAsPicture);
            this.panel1.Controls.Add(this.Save);
            this.panel1.Controls.Add(this.AddTriangle);
            this.panel1.Controls.Add(this.AddSquare);
            this.panel1.Controls.Add(this.Delete);
            this.panel1.Controls.Add(this.AddCircle);
            this.panel1.Location = new System.Drawing.Point(0, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 425);
            this.panel1.TabIndex = 10;
            // 
            // Open
            // 
            this.Open.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(122)))), ((int)(((byte)(127)))));
            this.Open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Open.FlatAppearance.BorderSize = 0;
            this.Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Open.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Open.Image = ((System.Drawing.Image)(resources.GetObject("Open.Image")));
            this.Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Open.Location = new System.Drawing.Point(132, 252);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(227, 60);
            this.Open.TabIndex = 26;
            this.Open.Text = "Открыть";
            this.Open.UseVisualStyleBackColor = false;
            this.Open.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // treeLabel
            // 
            this.treeLabel.AutoSize = true;
            this.treeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.treeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.treeLabel.Location = new System.Drawing.Point(127, 198);
            this.treeLabel.Name = "treeLabel";
            this.treeLabel.Size = new System.Drawing.Size(112, 29);
            this.treeLabel.TabIndex = 25;
            this.treeLabel.Text = "- Дерево";
            this.treeLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownloadTree_MouseDown);
            // 
            // ReDownload
            // 
            this.ReDownload.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ReDownload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReDownload.BackgroundImage")));
            this.ReDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReDownload.FlatAppearance.BorderSize = 0;
            this.ReDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReDownload.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReDownload.Location = new System.Drawing.Point(0, 342);
            this.ReDownload.Name = "ReDownload";
            this.ReDownload.Size = new System.Drawing.Size(50, 50);
            this.ReDownload.TabIndex = 19;
            this.ReDownload.UseVisualStyleBackColor = false;
            this.ReDownload.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DownloadTree_MouseDown);
            // 
            // Total
            // 
            this.Total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(122)))), ((int)(((byte)(127)))));
            this.Total.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Total.FlatAppearance.BorderSize = 0;
            this.Total.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Total.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Total.Image = ((System.Drawing.Image)(resources.GetObject("Total.Image")));
            this.Total.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Total.Location = new System.Drawing.Point(77, 180);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(227, 60);
            this.Total.TabIndex = 18;
            this.Total.Text = "Расчет";
            this.Total.UseVisualStyleBackColor = false;
            this.Total.Click += new System.EventHandler(this.Total_Click);
            // 
            // SaveAsPicture
            // 
            this.SaveAsPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(122)))), ((int)(((byte)(127)))));
            this.SaveAsPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SaveAsPicture.FlatAppearance.BorderSize = 0;
            this.SaveAsPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAsPicture.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveAsPicture.Image = ((System.Drawing.Image)(resources.GetObject("SaveAsPicture.Image")));
            this.SaveAsPicture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveAsPicture.Location = new System.Drawing.Point(98, 20);
            this.SaveAsPicture.Name = "SaveAsPicture";
            this.SaveAsPicture.Size = new System.Drawing.Size(227, 60);
            this.SaveAsPicture.TabIndex = 17;
            this.SaveAsPicture.Text = " Изображение";
            this.SaveAsPicture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveAsPicture.UseVisualStyleBackColor = false;
            this.SaveAsPicture.Click += new System.EventHandler(this.SavePicter_Click);
            // 
            // Save
            // 
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(122)))), ((int)(((byte)(127)))));
            this.Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Save.FlatAppearance.BorderSize = 0;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save.Location = new System.Drawing.Point(111, 342);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(227, 60);
            this.Save.TabIndex = 15;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // AddTriangle
            // 
            this.AddTriangle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddTriangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddTriangle.BackgroundImage")));
            this.AddTriangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddTriangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddTriangle.FlatAppearance.BorderSize = 0;
            this.AddTriangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTriangle.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddTriangle.Location = new System.Drawing.Point(0, 257);
            this.AddTriangle.Name = "AddTriangle";
            this.AddTriangle.Size = new System.Drawing.Size(50, 50);
            this.AddTriangle.TabIndex = 14;
            this.AddTriangle.UseVisualStyleBackColor = false;
            this.AddTriangle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddTriangle_MouseDown);
            // 
            // AddSquare
            // 
            this.AddSquare.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddSquare.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddSquare.BackgroundImage")));
            this.AddSquare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddSquare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddSquare.FlatAppearance.BorderSize = 0;
            this.AddSquare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSquare.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddSquare.Location = new System.Drawing.Point(0, 171);
            this.AddSquare.Name = "AddSquare";
            this.AddSquare.Size = new System.Drawing.Size(50, 50);
            this.AddSquare.TabIndex = 13;
            this.AddSquare.UseVisualStyleBackColor = false;
            this.AddSquare.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddSquare_MouseDown);
            // 
            // Delete
            // 
            this.Delete.AllowDrop = true;
            this.Delete.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Delete.BackgroundImage")));
            this.Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Delete.FlatAppearance.BorderSize = 0;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete.Location = new System.Drawing.Point(0, 85);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(50, 50);
            this.Delete.TabIndex = 12;
            this.Delete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Delete_MouseDown);
            // 
            // AddCircle
            // 
            this.AddCircle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AddCircle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddCircle.BackgroundImage")));
            this.AddCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddCircle.FlatAppearance.BorderSize = 0;
            this.AddCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCircle.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddCircle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddCircle.Location = new System.Drawing.Point(0, 0);
            this.AddCircle.Margin = new System.Windows.Forms.Padding(0);
            this.AddCircle.Name = "AddCircle";
            this.AddCircle.Size = new System.Drawing.Size(50, 50);
            this.AddCircle.TabIndex = 11;
            this.AddCircle.UseVisualStyleBackColor = false;
            this.AddCircle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddCircle_MouseDown);
            // 
            // CtrlzBack
            // 
            this.CtrlzBack.BackColor = System.Drawing.Color.White;
            this.CtrlzBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CtrlzBack.BackgroundImage")));
            this.CtrlzBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CtrlzBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CtrlzBack.FlatAppearance.BorderSize = 0;
            this.CtrlzBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CtrlzBack.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CtrlzBack.Location = new System.Drawing.Point(387, 129);
            this.CtrlzBack.Name = "CtrlzBack";
            this.CtrlzBack.Size = new System.Drawing.Size(60, 60);
            this.CtrlzBack.TabIndex = 15;
            this.CtrlzBack.UseVisualStyleBackColor = false;
            this.CtrlzBack.Click += new System.EventHandler(this.CtrlZ_Click);
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Location = new System.Drawing.Point(574, 325);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(197, 97);
            this.treeView1.TabIndex = 14;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(628, 83);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 71);
            this.textBox1.TabIndex = 11;
            // 
            // CopyMenu
            // 
            this.CopyMenu.AutoSize = true;
            this.CopyMenu.BackColor = System.Drawing.SystemColors.Window;
            this.CopyMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CopyMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CopyMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyMenu.Location = new System.Drawing.Point(478, 263);
            this.CopyMenu.Name = "CopyMenu";
            this.CopyMenu.Size = new System.Drawing.Size(119, 40);
            this.CopyMenu.TabIndex = 12;
            this.CopyMenu.Text = "Копировать";
            this.CopyMenu.UseVisualStyleBackColor = false;
            this.CopyMenu.Visible = false;
            this.CopyMenu.Click += new System.EventHandler(this.Copy_Click);
            // 
            // PasteMenu
            // 
            this.PasteMenu.AutoSize = true;
            this.PasteMenu.BackColor = System.Drawing.SystemColors.Window;
            this.PasteMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PasteMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PasteMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasteMenu.Location = new System.Drawing.Point(478, 308);
            this.PasteMenu.Name = "PasteMenu";
            this.PasteMenu.Size = new System.Drawing.Size(119, 40);
            this.PasteMenu.TabIndex = 13;
            this.PasteMenu.Text = "Вставить";
            this.PasteMenu.UseVisualStyleBackColor = false;
            this.PasteMenu.Visible = false;
            this.PasteMenu.Click += new System.EventHandler(this.Paste_Click);
            // 
            // min
            // 
            this.min.AutoSize = true;
            this.min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.min.Cursor = System.Windows.Forms.Cursors.Hand;
            this.min.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.min.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.min.Location = new System.Drawing.Point(628, 160);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(151, 33);
            this.min.TabIndex = 16;
            this.min.Text = "Минимум";
            this.min.UseVisualStyleBackColor = false;
            this.min.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // max
            // 
            this.max.AutoSize = true;
            this.max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.max.Cursor = System.Windows.Forms.Cursors.Hand;
            this.max.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.max.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.max.Location = new System.Drawing.Point(636, 209);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(158, 33);
            this.max.TabIndex = 17;
            this.max.Text = "Максимум";
            this.max.UseVisualStyleBackColor = false;
            this.max.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // currencies
            // 
            this.currencies.AutoSize = true;
            this.currencies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.currencies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.currencies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.currencies.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.currencies.Location = new System.Drawing.Point(636, 234);
            this.currencies.Name = "currencies";
            this.currencies.Size = new System.Drawing.Size(189, 33);
            this.currencies.TabIndex = 18;
            this.currencies.Text = "Вероятность";
            this.currencies.UseVisualStyleBackColor = false;
            this.currencies.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.price.Cursor = System.Windows.Forms.Cursors.Hand;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.price.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.price.Location = new System.Drawing.Point(636, 263);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(166, 33);
            this.price.TabIndex = 19;
            this.price.Text = "Стоимость";
            this.price.UseVisualStyleBackColor = false;
            this.price.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // number
            // 
            this.number.AutoSize = true;
            this.number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.number.Cursor = System.Windows.Forms.Cursors.Hand;
            this.number.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.number.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.number.Location = new System.Drawing.Point(636, 293);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(254, 33);
            this.number.TabIndex = 20;
            this.number.Text = "Название и номер";
            this.number.UseVisualStyleBackColor = false;
            this.number.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // Center
            // 
            this.Center.BackColor = System.Drawing.Color.White;
            this.Center.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Center.BackgroundImage")));
            this.Center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Center.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Center.FlatAppearance.BorderSize = 0;
            this.Center.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Center.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Center.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Center.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Center.Location = new System.Drawing.Point(538, 46);
            this.Center.Margin = new System.Windows.Forms.Padding(0);
            this.Center.Name = "Center";
            this.Center.Size = new System.Drawing.Size(60, 60);
            this.Center.TabIndex = 18;
            this.Center.UseVisualStyleBackColor = false;
            this.Center.Click += new System.EventHandler(this.Centre_Click);
            // 
            // eventLabel
            // 
            this.eventLabel.AutoSize = true;
            this.eventLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.eventLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eventLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eventLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.eventLabel.Location = new System.Drawing.Point(368, 393);
            this.eventLabel.Name = "eventLabel";
            this.eventLabel.Size = new System.Drawing.Size(130, 29);
            this.eventLabel.TabIndex = 21;
            this.eventLabel.Text = "- Событие";
            this.eventLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddCircle_MouseDown);
            // 
            // knotLabel
            // 
            this.knotLabel.AutoSize = true;
            this.knotLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.knotLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.knotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.knotLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.knotLabel.Location = new System.Drawing.Point(504, 393);
            this.knotLabel.Name = "knotLabel";
            this.knotLabel.Size = new System.Drawing.Size(86, 29);
            this.knotLabel.TabIndex = 22;
            this.knotLabel.Text = "- Узел";
            this.knotLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddSquare_MouseDown);
            // 
            // listLabel
            // 
            this.listLabel.AutoSize = true;
            this.listLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.listLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.listLabel.Location = new System.Drawing.Point(335, 259);
            this.listLabel.Name = "listLabel";
            this.listLabel.Size = new System.Drawing.Size(81, 29);
            this.listLabel.TabIndex = 23;
            this.listLabel.Text = "- Лист";
            this.listLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddTriangle_MouseDown);
            // 
            // deleteLabel
            // 
            this.deleteLabel.AutoSize = true;
            this.deleteLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.deleteLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.deleteLabel.Location = new System.Drawing.Point(342, 216);
            this.deleteLabel.Name = "deleteLabel";
            this.deleteLabel.Size = new System.Drawing.Size(126, 29);
            this.deleteLabel.TabIndex = 24;
            this.deleteLabel.Text = "- Удалить";
            this.deleteLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Delete_MouseDown);
            // 
            // logoAdd
            // 
            this.logoAdd.AutoSize = true;
            this.logoAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.logoAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoAdd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.logoAdd.Location = new System.Drawing.Point(358, 88);
            this.logoAdd.Name = "logoAdd";
            this.logoAdd.Size = new System.Drawing.Size(123, 29);
            this.logoAdd.TabIndex = 25;
            this.logoAdd.Text = "Добавить";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.checkBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox6.Location = new System.Drawing.Point(396, 330);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(133, 33);
            this.checkBox6.TabIndex = 26;
            this.checkBox6.Text = "Каталог";
            this.checkBox6.UseVisualStyleBackColor = false;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.TreeView_CheckedChanged);
            // 
            // AddSquareMenu
            // 
            this.AddSquareMenu.AutoSize = true;
            this.AddSquareMenu.BackColor = System.Drawing.SystemColors.Window;
            this.AddSquareMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddSquareMenu.BackgroundImage")));
            this.AddSquareMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddSquareMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddSquareMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddSquareMenu.Location = new System.Drawing.Point(525, 129);
            this.AddSquareMenu.Name = "AddSquareMenu";
            this.AddSquareMenu.Size = new System.Drawing.Size(40, 40);
            this.AddSquareMenu.TabIndex = 27;
            this.AddSquareMenu.UseVisualStyleBackColor = false;
            this.AddSquareMenu.Visible = false;
            this.AddSquareMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddSquare_MouseDown);
            // 
            // AddTriangleMenu
            // 
            this.AddTriangleMenu.AutoSize = true;
            this.AddTriangleMenu.BackColor = System.Drawing.SystemColors.Window;
            this.AddTriangleMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddTriangleMenu.BackgroundImage")));
            this.AddTriangleMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddTriangleMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddTriangleMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTriangleMenu.Location = new System.Drawing.Point(574, 129);
            this.AddTriangleMenu.Name = "AddTriangleMenu";
            this.AddTriangleMenu.Size = new System.Drawing.Size(40, 40);
            this.AddTriangleMenu.TabIndex = 28;
            this.AddTriangleMenu.UseVisualStyleBackColor = false;
            this.AddTriangleMenu.Visible = false;
            this.AddTriangleMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddTriangle_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 547);
            this.Controls.Add(this.AddTriangleMenu);
            this.Controls.Add(this.AddSquareMenu);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.logoAdd);
            this.Controls.Add(this.deleteLabel);
            this.Controls.Add(this.listLabel);
            this.Controls.Add(this.knotLabel);
            this.Controls.Add(this.eventLabel);
            this.Controls.Add(this.Center);
            this.Controls.Add(this.number);
            this.Controls.Add(this.price);
            this.Controls.Add(this.CtrlzBack);
            this.Controls.Add(this.currencies);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.max);
            this.Controls.Add(this.min);
            this.Controls.Add(this.PasteMenu);
            this.Controls.Add(this.CopyMenu);
            this.Controls.Add(this.ChangeMenu);
            this.Controls.Add(this.DeleteMenu);
            this.Controls.Add(this.AddCircleMenu);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1WithInfo);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "ГРАФИЧЕСКИЧЕСКИЙ РЕДАКТОР ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button AddCircleMenu;
        private System.Windows.Forms.Button DeleteMenu;
        private System.Windows.Forms.ToolStripComboBox structureComboBox1;
        protected System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1WithInfo;
        private System.Windows.Forms.Button ChangeMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddCircle;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button AddSquare;
        private System.Windows.Forms.Button AddTriangle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripComboBox typeOfStripComboBox2;
        private System.Windows.Forms.Button CopyMenu;
        private System.Windows.Forms.Button PasteMenu;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox min;
        private System.Windows.Forms.CheckBox max;
        private System.Windows.Forms.CheckBox currencies;
        private System.Windows.Forms.CheckBox price;
        private System.Windows.Forms.CheckBox number;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button CtrlzBack;
        private System.Windows.Forms.Button SaveAsPicture;
        private System.Windows.Forms.Button Center;
        private System.Windows.Forms.Label eventLabel;
        private System.Windows.Forms.Label knotLabel;
        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.Label deleteLabel;
        private System.Windows.Forms.Label logoAdd;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox currencyStripComboBox3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Button AddSquareMenu;
        private System.Windows.Forms.Button AddTriangleMenu;
        private System.Windows.Forms.Button Total;
        private System.Windows.Forms.Button ReDownload;
        private System.Windows.Forms.Label treeLabel;
        private System.Windows.Forms.Button Open;
    }
}

