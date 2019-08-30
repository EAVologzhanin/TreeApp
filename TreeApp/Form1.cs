using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
namespace TreeApp
{
    public delegate void DestDelegate(Point p, ref Circle c);
    public partial class Form1 : Form
    {
        public static int dyCenter;
        public static int currency = 1;
        public static bool visibleMenu;
        public static int selectTotalBy = 0; // Значение комбобокса, по которому делать расчет
        public static Circle copyCircle;
        public static Circle selectedFigure;

        public Bitmap bitmap;
        public Graphics g;
        public Pen p;
        public Circle firstCircle;
        public DestDelegate destDelegate;

        private int numberOfStream;
        private List<MemoryStream> ctrlZStreams = new List<MemoryStream>();
        private List<Circle> needChangeCircles = new List<Circle>();
        private MemoryStream copyCircleStream;
        private Circle treeViewCircle;
        private SolidBrush redBrush = new SolidBrush(Color.Red);
        private SolidBrush blackBrush = new SolidBrush(Color.Black);
        private SolidBrush greenBrush = new SolidBrush(Color.Green);
        private int lx, ly,cx, cy;
        private double coefForY = 1, coefForX = 1;
        private Circle movedCircle;
        private AddNewCircle addForm;
        private BinaryFormatter format = new BinaryFormatter();

        public Form1()
        {
            InitializeComponent();
            destDelegate = null;

            Size = MaximumSize;
            MinimumSize = new Size(500, 600);
            pictureBox1.MouseWheel += pictureBox1MouseWheel;

            First();
            structureComboBox1.SelectedIndex = 1;
            label1WithInfo.Visible = false;
            panel1.Cursor = Cursors.Default;
        }

        private void First()
        {
            pictureBox1.Width = Bounds.Size.Width * 2 - 40;
            pictureBox1.Height = Bounds.Size.Height + 52;
            panel1.Height = pictureBox1.Height;
            panel1.Width = 200;
            textBox1.Width = panel1.Width/4*3;
            textBox1.Height = textBox1.Width;
            treeView1.Size = new Size(panel1.Width*3/2,panel1.Width);
            pictureBox1.Location = new Point(panel1.Width, 0);
            panel1.Location = new Point(0, 0);
            CoordinatesButtonsInStart();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            p = new Pen(Color.Black);
            g = Graphics.FromImage(bitmap);
            typeOfStripComboBox2.SelectedIndex = 0;
            currencyStripComboBox3.SelectedIndex = 1;
        }

        private void CoordinatesButtonsInStart()
        {
            Open.Location = new Point(20, 50);
            Save.Location = new Point(Open.Location.X, Open.Location.Y + Open.Height + 10);
            SaveAsPicture.Location = new Point(Open.Location.X, Save.Location.Y + Save.Height + 10);
            logoAdd.Location = new Point(50, SaveAsPicture.Location.Y + Save.Height + 20);

            AddCircle.Location = new Point(20, SaveAsPicture.Location.Y + Save.Height + 50);
            AddSquare.Location = new Point(20, AddCircle.Location.Y + AddCircle.Height + 5);
            AddTriangle.Location = new Point(20, AddSquare.Location.Y + AddSquare.Height + 5);
            ReDownload.Location = new Point(20, AddTriangle.Location.Y + AddTriangle.Height + 5);
            Delete.Location = new Point(20,ReDownload.Location.Y + ReDownload.Height + 5);
            
            eventLabel.Location = new Point(AddCircle.Location.X + AddCircle.Width, AddCircle.Location.Y+4);
            knotLabel.Location = new Point(eventLabel.Location.X, AddSquare.Location.Y + 4);
            listLabel.Location = new Point(knotLabel.Location.X, AddTriangle.Location.Y + 4);
            treeLabel.Location = new Point(eventLabel.Location.X, ReDownload.Location.Y + 4);
            deleteLabel.Location = new Point(eventLabel.Location.X, Delete.Location.Y + 4);
            
            CtrlzBack.Location = new Point(Open.Location.X + panel1.Width, Open.Location.Y);
            Center.Location = new Point(CtrlzBack.Location.X + CtrlzBack.Width + 5, Open.Location.Y);

            textBox1.Location = new Point(panel1.Width*5+100, 50);
            treeView1.Location = new Point(pictureBox1.Width *4/5+10, pictureBox1.Height*2/3+10);

            min.Location = new Point(20, Delete.Location.Y + 50);
            max.Location = new Point(20, min.Location.Y + 25);
            currencies.Location = new Point(20, max.Location.Y + 25);
            price.Location = new Point(20, currencies.Location.Y + 25);
            number.Location = new Point(20, price.Location.Y + 25);
            checkBox6.Location = new Point(20, number.Location.Y + 25);
            Total.Location = new Point(20, checkBox6.Location.Y + 37);

        }
       
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FindCircleForTreeView(firstCircle, e.Node);
            selectedFigure = treeViewCircle;
            Redraw(false,0);
        }


        private void FindCircleForTreeView(Circle circle, TreeNode e)
        {
            if (e == circle.treeNode) treeViewCircle = circle;

            for (int i = 0; i < circle.children.Count; i++)
            {
                FindCircleForTreeView(circle.children[i], e);
            }
        }

        private void pictureBox1MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (e != null)
                    ChangedSize(e);
                coefForX = 1;
                firstCircle.R += 0;
            }
            catch (NullReferenceException)
            {

            }
        }

        private void ChangedSize(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (firstCircle.R <= 10 && coefForY >= 0.2 && coefForX <= 2)
                {
                    coefForX *= 1.2;
                    coefForY /= 1.2;
                    firstCircle.R += 1;
                }
            }
            else
            {
                if (firstCircle.R > 5 && coefForY <= 5 && coefForX >= 1)
                {
                    coefForX /= 1.2;
                    coefForY *= 1.2;
                    firstCircle.R -= 1;
                }
            }
            Redraw(false, 0);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (firstCircle != null)
            {
                lx = e.X;
                ly = e.Y;

                addForm?.Close();
                if (selectedFigure != null)
                {
                    if (selectedFigure is Square)
                        g.FillRectangle(blackBrush, selectedFigure.centre.X - selectedFigure.R, selectedFigure.centre.Y - selectedFigure.R, 2 * selectedFigure.R, 2 * selectedFigure.R);
                    if (selectedFigure is Triangle)
                        g.FillPolygon(blackBrush, ((Triangle)selectedFigure).coordinates);
                    else
                        g.FillEllipse(blackBrush, selectedFigure.centre.X - selectedFigure.R, selectedFigure.centre.Y - selectedFigure.R, 2 * selectedFigure.R, 2 * selectedFigure.R);
                }
                selectedFigure = null;
                if (firstCircle != null)
                    destDelegate(new Point(e.X, e.Y), ref selectedFigure);

                if (selectedFigure != null)
                {
                    textBox1.Text = selectedFigure.ToString();
                    if (selectedFigure != firstCircle)
                        treeView1.SelectedNode = selectedFigure.treeNode;
                    else
                        treeView1.SelectedNode = firstCircle.treeNode;

                    ChangeMenuVisible(true);
                    if (selectedFigure is Square)
                        g.FillRectangle(new SolidBrush(Color.Red), selectedFigure.centre.X - selectedFigure.R, selectedFigure.centre.Y - selectedFigure.R, 2 * selectedFigure.R, 2 * selectedFigure.R);
                    else if (selectedFigure is Triangle)
                    {
                        AddCircleMenu.Visible = false;
                        AddSquareMenu.Visible = false;
                        AddTriangleMenu.Visible = false;
                        AddCircle.Enabled = false;
                        AddTriangle.Enabled = false;
                        AddSquare.Enabled = false;
                        g.FillPolygon(new SolidBrush(Color.Red), ((Triangle)selectedFigure).coordinates);
                    }
                    else
                        g.FillEllipse(new SolidBrush(Color.Red), selectedFigure.centre.X - selectedFigure.R, selectedFigure.centre.Y - selectedFigure.R, 2 * selectedFigure.R, 2 * selectedFigure.R);

                    pictureBox1.Image = bitmap;
                }
                else
                {
                    ChangeMenuVisible(false);
                    Redraw(false, 0);
                    treeView1.SelectedNode = null;
                }
            }
            else
            {
                ChangeMenuVisible(true);
            }
        }

        private void CreateFigure(double chance, string info, double price, int whatIsIt)
        {
            int x;
            if (selectedFigure != null)
            {
                try
                {
                    x = selectedFigure.centre.X + firstCircle.children[0].centre.X - firstCircle.centre.X;
                }
                catch (NullReferenceException)
                {
                    x = selectedFigure.centre.X + 150;
                }
                catch (ArgumentOutOfRangeException)
                {
                    x = selectedFigure.centre.X + 150;
                }
                Circle newCircle;
                if (whatIsIt == 0)
                {
                    newCircle = new Circle(new Point(x, 0), selectedFigure.R, selectedFigure, ref destDelegate, chance, info, price);
                    selectedFigure.AddCircle(newCircle);
                }
                else if (whatIsIt == 1)
                {
                    newCircle = new Square(new Point(x, 0), selectedFigure.R, selectedFigure, ref destDelegate, chance, info, price);
                    selectedFigure.AddCircle(newCircle);
                }
                else
                {
                    newCircle = new Triangle(new Point(x, 0), selectedFigure.R, selectedFigure, ref destDelegate, chance, info, price);
                    selectedFigure.AddCircle(newCircle);
                }

                try
                {
                    treeView1.SelectedNode.Nodes.Add(newCircle.treeNode);
                }
                catch (NullReferenceException)
                {
                    treeView1.Nodes[0].Nodes.Add(newCircle.treeNode);
                }

                ChangeMenuVisible(true);
            }
            else
            {
                ChangeMenuVisible(false);
            }
            Redraw(false,0);
        }

        private void AddCircle_MouseDown(object sender, MouseEventArgs e) // Добавить Circle
        {
            if (firstCircle == null)
            {
                firstCircle = new Circle(new Point(300, Height / 2 - 141), 7, null, ref destDelegate, 1, "", 0);
                treeView1.Nodes.Add(new TreeNode("1"));
                Centre_Click(null, null);
                SaveToCtrlZ();
                ChangeMenuVisible(false);
            }
            else
            {
                SaveToCtrlZ();

                if (structureComboBox1.SelectedIndex == 0)// Если выбран graph, не показываем форму для введения информации
                {
                    CreateFigure(0, "", 0, 0);
                }
                else
                {
                    addForm = new AddNewCircle();
                    addForm.AddEvent += AddForm_AddEvent;
                    addForm.closed += AddForm_closed;
                    ChangeMenuVisible(false);
                    addForm.Show();
                    addForm.Location = new Point(pictureBox1.Width/2+panel1.Width/3, pictureBox1.Height/2-addForm.Height/2);
                }
            }
        }

        private void AddSquare_MouseDown(object sender, MouseEventArgs e) // Добавить Квадрат
        {
            if (firstCircle == null)
            {
                firstCircle = new Square(new Point(300, Height / 2 - 141), 7, null, ref destDelegate, 1, "", 0);
                treeView1.Nodes.Add(new TreeNode("1"));
                Centre_Click(null, null);
                SaveToCtrlZ();
                ChangeMenuVisible(false);
            }
            else
            {
                SaveToCtrlZ();

                if (structureComboBox1.SelectedIndex == 0)// Если выбран graph, не показываем форму для введения информации
                {
                    CreateFigure(0, "", 0, 1);
                }
                else
                {
                    addForm = new AddNewCircle();
                    addForm.closed += AddForm_closed;
                    addForm.AddSquare += AddForm_AddSquare;
                    ChangeMenuVisible(false);
                    addForm.Show();
                    addForm.Location = new Point(pictureBox1.Width / 2 + panel1.Width / 3, pictureBox1.Height / 2 - addForm.Height / 2);
                }
            }
        }
        
        private void AddTriangle_MouseDown(object sender, MouseEventArgs e)
        {
            if (firstCircle == null)
            {
                firstCircle = new Triangle(new Point(300, Height / 2 - 141), 7, null, ref destDelegate, 1, "", 0);
                treeView1.Nodes.Add(new TreeNode("1"));
                Centre_Click(null, null);
                SaveToCtrlZ();
                ChangeMenuVisible(false);
            }
            else
            {
                SaveToCtrlZ();

                if (structureComboBox1.SelectedIndex == 0)// Если выбран graph, не показываем форму для введения информации
                {
                    CreateFigure(0, "", 0, 2);
                }
                else
                {
                    addForm = new AddNewCircle();
                    addForm.closed += AddForm_closed;
                    addForm.AddTriangle += AddForm_AddTriangle;

                    ChangeMenuVisible(false);
                    addForm.Show();
                    addForm.Location = new Point(pictureBox1.Width / 2 + panel1.Width / 3, pictureBox1.Height / 2 - addForm.Height / 2);
                }
            }
        }
        private void AddForm_AddEvent(object sender, EventArgs e)
        {
            AddNewCircle newCircle = (AddNewCircle)sender;
            CreateFigure(newCircle.chance, newCircle.info, newCircle.price, 0);
            ChangeMenuVisible(true);
        }
        private void AddForm_AddTriangle(object sender, EventArgs e)
        {
            AddNewCircle newCircle = (AddNewCircle)sender;
            CreateFigure(newCircle.chance, newCircle.info, newCircle.price, 2);
            ChangeMenuVisible(true);
        }

        private void AddForm_AddSquare(object sender, EventArgs e)
        {
            AddNewCircle newCircle = (AddNewCircle)sender;
            CreateFigure(newCircle.chance, newCircle.info, newCircle.price, 1);
            ChangeMenuVisible(true);
        }


        private void AddForm_Changed(object sender, EventArgs e)
        {
            AddNewCircle newCircle = (AddNewCircle)sender;
            try
            {
                selectedFigure.information = newCircle.info;
                if (selectedFigure.parent is Square) selectedFigure.probablyToParent = 1;
                else selectedFigure.probablyToParent = newCircle.chance;
                selectedFigure.Price = newCircle.price;
                ChangeMenuVisible(true);
            } catch (NullReferenceException)//Обработка изменения 1 окружности
            {
                selectedFigure.probablyToParent = newCircle.chance;
            }
        }

        private void AddForm_closed()
        {
            ChangeMenuVisible(true);
        }
        private void OpenFile_Click(object sender, EventArgs e) // Open file
        {
            OpenFileDialog openFile = new OpenFileDialog();
            try
            {
                ChangeMenuVisible(false);
                selectedFigure = null;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream open = new FileStream(openFile.FileName, FileMode.Open))
                    {
                        coefForY = 1; coefForX = 1;

                        firstCircle = (Circle)format.Deserialize(open);
                        CirclesGetDelegate(firstCircle);
                        TreeViewAddAfterPaste(firstCircle);
                        ForCentre();
                        ForCentre();
                        SaveToCtrlZ();
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void SaveFile_Click(object sender, EventArgs e) // save file
        {
            SaveFileDialog savedialog = new SaveFileDialog() { Filter = "AppTree (*.AppTree)|*.AppTree" };

            savedialog.OverwritePrompt = true; //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
            savedialog.CheckPathExists = true; //отображать ли предупреждение, если пользователь указывает несуществующий путь

            if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
            {
                try
                {
                    using (FileStream save = new FileStream(savedialog.FileName, FileMode.Create))
                    {
                        format.Serialize(save, firstCircle);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        private void SavePicter_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog() { Filter = "Images Files (*.PNG)|*.PNG" };

            savedialog.OverwritePrompt = true; //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
            savedialog.CheckPathExists = true; //отображать ли предупреждение, если пользователь указывает несуществующий путь

            if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
            {
                try
                {
                    pictureBox1.Image.Save(savedialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ChangeMenuVisible(bool visible)
        {
            try
            {
                if (visible)
                {
                    AddCircleMenu.Location = new Point(selectedFigure.centre.X - 80 + panel1.Width, selectedFigure.centre.Y + 60);
                    AddSquareMenu.Location = new Point(AddCircleMenu.Location.X + AddCircleMenu.Width-1, AddCircleMenu.Location.Y);
                    AddTriangleMenu.Location = new Point(AddSquareMenu.Location.X + AddSquareMenu.Width-1, AddSquareMenu.Location.Y);
                    DeleteMenu.Location = new Point(selectedFigure.centre.X - 80 + panel1.Width, AddCircleMenu.Location.Y + AddCircleMenu.Height -1);
                    ChangeMenu.Location = new Point(selectedFigure.centre.X - 80 + panel1.Width, DeleteMenu.Location.Y + AddCircleMenu.Height - 3);
                    CopyMenu.Location = new Point(selectedFigure.centre.X - 80 + panel1.Width, ChangeMenu.Location.Y + AddCircleMenu.Height - 3);
                    PasteMenu.Location = new Point(selectedFigure.centre.X - 80 + panel1.Width, CopyMenu.Location.Y + AddCircleMenu.Height - 3);

                    AddCircleMenu.Visible = visible;
                    AddSquareMenu.Visible = visible;
                    AddTriangleMenu.Visible = visible;
                    DeleteMenu.Visible = visible;
                    CopyMenu.Visible = visible;
                    ChangeMenu.Visible = visible;
                    if (copyCircle != null)
                    {
                        PasteMenu.Enabled = visible;
                        PasteMenu.Visible = visible;
                    }
                    else
                    {
                        PasteMenu.Enabled = true;
                    }
                    AddCircle.Enabled = visible;
                    Delete.Enabled = visible;
                    AddSquare.Enabled = visible;
                    AddTriangle.Enabled = visible;
                    ReDownload.Enabled = visible;
                    eventLabel.Enabled = visible;
                    knotLabel.Enabled = visible;
                    listLabel.Enabled = visible;
                    deleteLabel.Enabled = visible;
                    treeLabel.Enabled = visible;
                    logoAdd.Visible = visible;


                    if (selectedFigure is Triangle)
                    {
                        AddCircleMenu.Visible = false;
                        AddSquareMenu.Visible = false;
                        AddTriangleMenu.Visible = false;
                        AddCircle.Enabled = false;
                        AddSquare.Enabled = false;
                        AddTriangle.Enabled = false;
                        ReDownload.Enabled = false;
                        eventLabel.Enabled = false;
                        knotLabel.Enabled = false;
                        listLabel.Enabled = false;
                        treeLabel.Enabled = false;
                        logoAdd.Visible = false;
                    } return;
                }

                AddCircleMenu.Visible = false;
                AddSquareMenu.Visible = false;
                AddTriangleMenu.Visible = false;
                DeleteMenu.Visible = false;
                ChangeMenu.Visible = false;
                CopyMenu.Visible = false;
                PasteMenu.Visible = false;
                AddCircle.Enabled = false;
                Delete.Enabled = false;
                AddSquare.Enabled = false;
                AddTriangle.Enabled = false;
                ReDownload.Enabled = false;
                eventLabel.Enabled = false;
                knotLabel.Enabled = false;
                listLabel.Enabled = false;
                deleteLabel.Enabled = false;
                treeLabel.Enabled = false;
                logoAdd.Visible = false;
            }
            catch (NullReferenceException)
            {
                AddCircle.Enabled = visible;
                Delete.Enabled = visible;
                AddSquare.Enabled = visible;
                AddTriangle.Enabled = visible;
                ReDownload.Enabled = visible;
                eventLabel.Enabled = visible;
                knotLabel.Enabled = visible;
                listLabel.Enabled = visible;
                deleteLabel.Enabled = visible;
                treeLabel.Enabled = visible;
                logoAdd.Visible = visible;
            }
        }

        private void Redraw(bool TheEnd,int dyCenter)
        {
            if (firstCircle != null)
            {
                bool GraphOrTree = structureComboBox1.SelectedIndex == 0 ? true : false;
                bool IsPrice = price.Checked;
                bool IsChance = currencies.Checked;
                bool IsNumber = number.Checked;
                int k = 5;
                bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(bitmap);
                firstCircle.AlgorithmOfCoordiantes(ref k, coefForY, coefForX, cy, dyCenter);
                firstCircle.Print(p, ref g, visibleMenu, TheEnd, blackBrush, IsPrice, IsChance, IsNumber);
                pictureBox1.Image = bitmap;
            }

            if (selectedFigure != null)
            {
                textBox1.Text = selectedFigure.ToString();
                ChangeMenuVisible(true);
                if (selectedFigure is Square)
                    g.FillRectangle(new SolidBrush(Color.Red), selectedFigure.centre.X - selectedFigure.R, selectedFigure.centre.Y - selectedFigure.R, 2 * selectedFigure.R, 2 * selectedFigure.R);
                else if (selectedFigure is Triangle)
                    g.FillPolygon(new SolidBrush(Color.Red), ((Triangle)selectedFigure).coordinates);
                else
                    g.FillEllipse(new SolidBrush(Color.Red), selectedFigure.centre.X - selectedFigure.R, selectedFigure.centre.Y - selectedFigure.R, 2 * selectedFigure.R, 2 * selectedFigure.R);

                pictureBox1.Image = bitmap;
            }

            if (Circle.TheBestCircle != null && min.Checked && Circle.TheBadCircle.Number != Circle.TheBestCircle.Number)
            {
                if (Circle.TheBestCircle is Square)
                    g.FillRectangle(greenBrush, Circle.TheBestCircle.centre.X - Circle.TheBestCircle.R, Circle.TheBestCircle.centre.Y - Circle.TheBestCircle.R, 2 * Circle.TheBestCircle.R, 2 * Circle.TheBestCircle.R);
                else if (Circle.TheBestCircle is Triangle)
                    g.FillPolygon(greenBrush, ((Triangle)Circle.TheBestCircle).coordinates);
                else
                    g.FillEllipse(greenBrush, Circle.TheBestCircle.centre.X - Circle.TheBestCircle.R, Circle.TheBestCircle.centre.Y - Circle.TheBestCircle.R, 2 * Circle.TheBestCircle.R, 2 * Circle.TheBestCircle.R);

                DrawGreenLines(Circle.TheBestCircle, ref g, new Pen(Color.Green, 2));
            }

            if (Circle.TheBadCircle != null && max.Checked && Circle.TheBadCircle.Number != Circle.TheBestCircle.Number)
            {
                if (Circle.TheBadCircle is Square)
                    g.FillRectangle(redBrush, Circle.TheBadCircle.centre.X - Circle.TheBadCircle.R, Circle.TheBadCircle.centre.Y - Circle.TheBadCircle.R, 2 * Circle.TheBadCircle.R, 2 * Circle.TheBadCircle.R);
                else if (Circle.TheBadCircle is Triangle)
                    g.FillPolygon(redBrush, ((Triangle)Circle.TheBadCircle).coordinates);
                else
                    g.FillEllipse(redBrush, Circle.TheBadCircle.centre.X - Circle.TheBadCircle.R, Circle.TheBadCircle.centre.Y - Circle.TheBadCircle.R, 2 * Circle.TheBadCircle.R, 2 * Circle.TheBadCircle.R);

                DrawGreenLines(Circle.TheBadCircle, ref g, new Pen(Color.Red, 2));
            }
            Circle.TheBestCircle = null;
            Circle.TheBadCircle = null;
        }

        private void NewCoordinateX(Circle c) // Присваиваем окружностям новые координаты, после встваки окружности
        {
            if (c.parent != null)
            {
                try
                {
                    c.centre.X = c.parent.centre.X + firstCircle.children[0].centre.X - firstCircle.centre.X;
                }
                catch
                {
                    c.centre.X = c.parent.centre.X + 100;
                }
                for (int i = 0; i < c.children.Count; i++)
                {
                    NewCoordinateX(c.children[i]);
                }
            }
        }

        private void DrawCopyPasteCircle(Circle c, ref Graphics g)
        {
            for (int i = 0; i < c.children.Count; i++)
            {
                Point forLines = new Point(c.centre.X + (c.children[i].centre.X - c.centre.X) / 3, c.children[i].centre.Y);
                g.DrawLine(new Pen(Color.Red, 2), forLines, c.centre);
                g.DrawLine((new Pen(Color.Red, 2)), c.children[i].centre, forLines);
                DrawCopyPasteCircle(c.children[i], ref g);
            }
        }

        private void DrawGreenLines(Circle best, ref Graphics g, Pen p)
        {
            if (best.parent != null)
            {
                Point forLines = new Point(best.parent.centre.X + (best.centre.X - best.parent.centre.X) / 3, best.centre.Y);
                g.DrawLine(p, forLines, best.centre);
                g.DrawLine(p, best.parent.centre, forLines);
                DrawGreenLines(best.parent, ref g, p);
            }

        }

        private void NewCoordinateX_MouseMove(Circle c, int dx)
        {
            try
            {
                for (int i = 0; i < c.children.Count; i++)
                {
                    NewCoordinateX_MouseMove(c.children[i], dx);
                }
                c.centre.X += dx;
            }
            catch (IndexOutOfRangeException)
            {

            }
            catch (NullReferenceException)
            {

            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Capture)
            {
                int dx = e.X - lx;
                int dy = e.Y - ly;
                cx += dx;
                cy += dy;
                lx = e.X;
                ly = e.Y;
                NewCoordinateX_MouseMove(firstCircle, dx);
                Redraw(false, 0);
                if (dx >= 4 || dy >= 4)
                {
                    selectedFigure = null;
                    Cursor = Cursors.Hand;
                    ChangeMenuVisible(false);
                }
            }

            if (firstCircle != null)
            {
                movedCircle = null;
                destDelegate(new Point(e.X, e.Y), ref movedCircle);
                if (movedCircle != null)
                {
                    textBox1.Text = movedCircle.ToString();
                }
            }
        }

       
        private void Change_Click(object sender, EventArgs e) // Изменить
        {
            SaveToCtrlZ();
            addForm = new AddNewCircle();
            addForm.ChangeEvent += AddForm_Changed;
            addForm.closed += AddForm_closed;
            ChangeMenuVisible(false);
            addForm.Show();
            addForm.Location = new Point(pictureBox1.Width / 2 + panel1.Width / 3, pictureBox1.Height / 2 - addForm.Height / 2);
        }
        private void Delete_MouseDown(object sender, MouseEventArgs e) // Удалить
        {
            if (selectedFigure != null)
            {
                SaveToCtrlZ();
                if (selectedFigure.parent != null)
                {
                    selectedFigure.parent.children.Remove(selectedFigure);
                    selectedFigure = null;
                }
                else
                {
                    firstCircle = null;
                    g.Clear(Color.White);
                    g.FillEllipse(new SolidBrush(Color.White), selectedFigure.centre.X - selectedFigure.R, selectedFigure.centre.Y - selectedFigure.R, 2 * selectedFigure.R, 2 * selectedFigure.R);
                }
                Redraw(false, 0);
                pictureBox1.Image = bitmap;
                selectedFigure = null;
                ChangeMenuVisible(false);
                ChangeMenuVisible(true);
                TreeViewAddAfterPaste(firstCircle);
            }
        }
        private void DownloadTree_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeMenuVisible(false);
            if (selectedFigure != null && selectedFigure.parent != null)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream open = new FileStream(openFile.FileName, FileMode.Open))
                    {
                        SaveToCtrlZ();
                        Circle NewTree = (Circle)format.Deserialize(open);
                        if (selectedFigure.children.Count == 0)
                        {
                            selectedFigure.parent.children.Add(NewTree);
                            NewTree.parent = selectedFigure.parent;
                            NewTree.probablyToParent = selectedFigure.probablyToParent;
                            NewTree.centre = selectedFigure.centre;
                            NewTree.GetParentChance(NewTree);
                            NewTree.GetTotalChance();
                            selectedFigure.parent.children.Remove(selectedFigure);
                        }
                        else
                        {
                            selectedFigure.children.Add(NewTree);
                            NewTree.parent = selectedFigure;
                        }
                        selectedFigure = null;
                        CirclesGetDelegate(NewTree.parent);
                        NewCoordinateX(NewTree);
                        pictureBox1MouseWheel(null, null);
                        Redraw(false, 0);
                        TreeViewAddAfterPaste(firstCircle);
                        ChangeMenuVisible(false);
                    }
                }
            }
            selectedFigure = null;
            Centre_Click(null, null);
        }
        private void Copy_Click(object sender, EventArgs e) //Copy
        {
            if (firstCircle.children.Count != 0)
            {
                copyCircleStream = new MemoryStream();
                format.Serialize(copyCircleStream, selectedFigure);
                copyCircle = selectedFigure;
                DrawCopyPasteCircle(copyCircle, ref g);
                pictureBox1.Image = bitmap;
            }
            ChangeMenuVisible(false);
        }
        private void Paste_Click(object sender, EventArgs e) //Paste
        {
            SaveToCtrlZ();
            copyCircleStream.Seek(0, SeekOrigin.Begin); //смещаем каретку в начало потока
            copyCircle = (Circle)format.Deserialize(copyCircleStream); // десериализуем поток в copyCircle

            if (selectedFigure.children.Count == 0) 
            {
                selectedFigure.parent.children.Add(copyCircle);
                copyCircle.parent = selectedFigure.parent;
                selectedFigure.parent.children.Remove(selectedFigure);
                selectedFigure = copyCircle;
            }
            else
            {
                selectedFigure.children.Add(copyCircle);
                copyCircle.parent = selectedFigure;
            }

            copyCircle.GetParentChance(copyCircle);
            copyCircle.GetTotalChance();
            TreeViewAddAfterPaste(firstCircle);
            CirclesGetDelegate(copyCircle.parent);
            NewCoordinateX(copyCircle);
            pictureBox1MouseWheel(null, null);
            if (selectedFigure != copyCircle)
            {
                Point forLines = new Point((copyCircle.parent.centre.X + copyCircle.centre.X) / 2, copyCircle.centre.Y);
                g.DrawLine(new Pen(Color.Red, 2), forLines, copyCircle.parent.centre);
                g.DrawLine((new Pen(Color.Red, 2)), copyCircle.centre, forLines);
            }
            ChangeMenuVisible(false);
            selectedFigure = null;
            Redraw(false,0);
            DrawCopyPasteCircle(copyCircle, ref g);
        }
       
        public void TreeViewAddAfterPaste(Circle c)
        {
            try
            {
                if (c.parent == null)
                {
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(new TreeNode("1"));
                    c.Number = "1";
                    treeView1.SelectedNode = treeView1.Nodes[0];

                    for (int i = 0; i < c.children.Count; i++)
                    {
                        c.children[i].Number = c.Number + "." + (i + 1);
                        treeView1.SelectedNode.Nodes.Add(c.children[i].treeNode);
                    }

                    for (int i = 0; i < c.children.Count; i++)
                    {
                        TreeViewAddAfterPaste(c.children[i]);
                    }
                }
                else
                {
                    treeView1.SelectedNode = c.treeNode;
                    for (int i = 0; i < c.children.Count; i++)
                    {
                        c.children[i].Number = c.Number + "." + (i + 1);
                        treeView1.SelectedNode.Nodes.Add(c.children[i].treeNode); 
                    }

                    for (int i = 0; i < c.children.Count; i++)
                    {
                        TreeViewAddAfterPaste(c.children[i]);
                    }
                }
            }
            catch (NullReferenceException)
            {
                treeView1.Nodes.Clear();
                g.Clear(Color.White);
                pictureBox1.Image = bitmap;
            }

        }
        public void CirclesGetDelegate(Circle c) // Метод присвоения делегата окружностям после открытия нового файла
        {
            destDelegate += c.Destination;
            for (int i = 0; i < c.children.Count; i++)
            {
                destDelegate += c.children[i].Destination;
                CirclesGetDelegate(c.children[i]);
            }
        }
        private void SaveToCtrlZ()
        {
            ctrlZStreams.Add(new MemoryStream());
            format.Serialize(ctrlZStreams[ctrlZStreams.Count - 1], firstCircle);
            numberOfStream = 1;
        }

        private void CtrlZ_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeMenuVisible(false);
                ctrlZStreams[ctrlZStreams.Count - numberOfStream].Seek(0, SeekOrigin.Begin);
                firstCircle = (Circle)format.Deserialize(ctrlZStreams[ctrlZStreams.Count - numberOfStream]);
                CirclesGetDelegate(firstCircle);
                TreeViewAddAfterPaste(firstCircle);
                selectedFigure = null;
                Redraw(false,0);
                numberOfStream++;
                ChangeMenuVisible(true);
            }
            catch (ArgumentOutOfRangeException)
            {
                ChangeMenuVisible(true);
            }
        }

       
        private void Centre_Click(object sender, EventArgs e) // Отцентровать
        {
            ForCentre();
            ForCentre();
        }

        private void ForCentre()
        {
            try
            {
                coefForY = 1;
                int ymin = firstCircle.centre.Y, ymax = ymin;
                pictureBox1MouseWheel(null, null);
                firstCircle.R = 7;
                firstCircle.centre.X = 200;
                MethodForCenter(firstCircle, ref ymin, ref ymax);
                dyCenter += pictureBox1.Height / 2-20 - (ymin+ymax)/2;
                Redraw(false, dyCenter);
                Redraw(false, 0);
            }
            catch (NullReferenceException)
            {

            }
        }

        private void MethodForCenter(Circle circle, ref int ymin, ref int ymax)
        {
            if (circle.centre.Y < ymin) ymin = circle.centre.Y;
            if (circle.centre.X > ymax) ymax = circle.centre.Y;


            for (int i = 0; i < circle.children.Count; i++)
            {
                circle.children[i].centre.X = circle.centre.X + 150;
                MethodForCenter(circle.children[i], ref ymin, ref ymax);
            }
        }

        private void Total_Click(object sender, EventArgs e)
        {
            selectTotalBy = typeOfStripComboBox2.SelectedIndex;
            Circle.TotalCircles.Clear();
            needChangeCircles.Clear();
            CheckCircles(firstCircle);
            if (needChangeCircles.Count == 0)
            {
                Redraw(true, 0);
            }
            else
            {
                Redraw(false, 0);

                for (int i = 0; i < needChangeCircles.Count; i++)
                {
                    needChangeCircles[i].DrawNeedChange(redBrush, ref g);
                }
                MessageBox.Show("Сумма вероятностей выделенных событий не равна 1");
                pictureBox1.Image = bitmap;
            }
        }

        private void CheckCircles(Circle c)
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < c.children.Count; i++)
                {
                    sum += c.children[i].probablyToParent;
                }
                if ((sum > 1 ||sum<0.99) && !(c is Square) && c.children.Count != 0) needChangeCircles.Add(c);
                for (int i = 0; i < c.children.Count; i++)
                {
                    CheckCircles(c.children[i]);
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        private void TreeView_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked) treeView1.Size = new Size(panel1.Width * 3 / 2, panel1.Width);
            else treeView1.Size = new Size(0,0);
        }

        private void Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            currency = currencyStripComboBox3.SelectedIndex;
            Redraw(true, 0);
        }
        
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Redraw(false, 0);
        }
        
        private void TypeOfTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            Redraw(false, 0);
        }
    }
}