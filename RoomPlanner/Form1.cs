using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Globalization;

namespace RoomPlanner
{
    public partial class Form1 : Form
    {
        const float WallThickness = 10;

        WallData CurrentlyDrawnWall = null;
        Button SelectedButton = null;
        Point OriginalMousePosition;
        bool MouseIsDown = false;
        BindingList<FurnitureData> FurnitureList = new BindingList<FurnitureData>();
        List<Button> ButtonList;

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            newBlueprintToolStripMenuItem_Click(this, null);
            listBox1.DataSource = FurnitureList;
            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);

            ButtonList = new List<Button> { CoffeeTableButton, TableButton, SofaButton, BedButton, WallButton };
        }

        private void newBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            pictureBox1.Size = pictureBox1.Parent.Size;
            FurnitureList.Clear();
            //listBox1.DataSource = null;
            //listBox1.DataSource = FurnitureList;

            DrawDesign();
            
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                newBlueprintToolStripMenuItem_Click(this, null);
            }
            if(e.KeyCode == Keys.Delete && listBox1.SelectedItem!=null)
            {
                FurnitureList.Remove(listBox1.SelectedItem as FurnitureData);
                listBox1.SelectedItem = null;
                DrawDesign();
            }
        }

        private void SelectButton(Button button)
        {
            if(CurrentlyDrawnWall!=null)
            {
                finishDrawingWall();
            }
            listBox1.SelectedItem = null;
            if (SelectedButton == button)
            {
                SelectedButton.BackColor = Color.White;
                SelectedButton = null;
            }
            else
            {
                if(SelectedButton!=null)
                {
                    SelectedButton.BackColor = Color.White;
                }
                SelectedButton = button;
                SelectedButton.BackColor = Color.Wheat;
            }
            DrawDesign();
        }


        private void CoffeeTableButton_Click(object sender, EventArgs e)
        {
            SelectButton(CoffeeTableButton);
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            SelectButton(TableButton);
        }

        private void SofaButton_Click(object sender, EventArgs e)
        {
            SelectButton(SofaButton);
        }

        private void BedButton_Click(object sender, EventArgs e)
        {
            SelectButton(BedButton);
        }

        private void WallButton_Click(object sender, EventArgs e)
        {
            SelectButton(WallButton);
        }

        private string ButtonName(Button button)
        {
            if (button == CoffeeTableButton)
                return GlobalStrings.CoffeeTable;
            if (button == TableButton)
                return GlobalStrings.Table;
            if (button == SofaButton)
                return GlobalStrings.Sofa;
            if (button == BedButton)
                return GlobalStrings.Bed;
            if (button == WallButton)
                return GlobalStrings.Wall;
            throw new ArgumentException();
        }

        class FurnitureData
        {
            public int id;
            public readonly string name;
            public int x, y;
            public Image image;
            public float angle = 0;

            public override string ToString()
            {
                if(id==0)
                {
                    return $"{GlobalStrings.CoffeeTable} {{X={x},Y={y}}}";
                }
                if (id == 1)
                {
                    return $"{GlobalStrings.Table} {{X={x},Y={y}}}";
                }
                if (id == 2)
                {
                    return $"{GlobalStrings.Sofa} {{X={x},Y={y}}}";
                }
                if (id == 3)
                {
                    return $"{GlobalStrings.Bed} {{X={x},Y={y}}}";
                }
                if (id == 4)
                {
                    return $"{GlobalStrings.Wall} {{X={x},Y={y}}}";
                }
                else
                    throw new ArgumentException();
            }
            public FurnitureData(int _id, string _name, int _x, int _y, Image _image = null)
            {
                id = _id;
                name = _name;
                x = _x; y = _y;
                image = _image;
            }
        }

        class WallData : FurnitureData
        {
            public List<Point> anchors = new List<Point>();
            public WallData(int _id, string _name, int _x, int _y, Image _image = null):base(_id, _name, _x, _y, _image) { anchors.Add(new Point(0, 0)); }
            public void AddPoint(Point p) { anchors.Add(new Point(p.X - x, p.Y - y)); }
            public void ModLastPoint(Point p) { anchors[anchors.Count - 1] = new Point(p.X - x, p.Y - y); }
            public void RemoveLastPoint() { anchors.RemoveAt(anchors.Count - 1); }
        }

        private void DrawDesign()
        {
            Bitmap surfece = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(surfece);
            

            //for(int i=0;i<FurnitureList.Count;i++)
            foreach(FurnitureData furniture in FurnitureList)
            {
                //FurnitureData furniture = FurnitureList[i] as FurnitureData;

                gr.TranslateTransform(furniture.x, furniture.y);
                gr.RotateTransform(furniture.angle);

                if(furniture is WallData)
                {
                    using (var p = new GraphicsPath())
                    {
                        Brush brush;
                        if (furniture == listBox1.SelectedItem)
                            brush = new SolidBrush(Color.FromArgb(127, 0, 0, 0));
                        else
                            brush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
                        p.AddLines((furniture as WallData).anchors.ToArray());
                        gr.DrawPath(new Pen(brush, WallThickness), p);
                    }
                }
                else
                {
                   if(furniture == listBox1.SelectedItem)
                    {
                        ColorMatrix m = new ColorMatrix();
                        m.Matrix33 = 0.5f;
                        ImageAttributes attributes = new ImageAttributes();
                        attributes.SetColorMatrix(m, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                        gr.DrawImage(furniture.image,
                            new Rectangle(- furniture.image.Width / 2, - furniture.image.Height / 2, furniture.image.Width, furniture.image.Height),
                            0,
                            0,
                            furniture.image.Width,
                            furniture.image.Height,
                            GraphicsUnit.Pixel,
                            attributes);
                    }
                    else
                    {
                        gr.DrawImage(furniture.image, -furniture.image.Width / 2, -furniture.image.Height / 2);
                    }
                    
                }

                gr.ResetTransform();


            }

            pictureBox1.Image = surfece;
            gr.Dispose();
        }
        
        private void finishDrawingWall()
        {
            CurrentlyDrawnWall.RemoveLastPoint();
            if(CurrentlyDrawnWall.anchors.Count<=1)
            {
                FurnitureList.Remove(CurrentlyDrawnWall);
                listBox1.Refresh();
            }
            CurrentlyDrawnWall = null;
            SelectButton(WallButton);
            DrawDesign();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if(CurrentlyDrawnWall!=null && e.Button == MouseButtons.Right)
            {
                finishDrawingWall();
            }
        }

        private void AddNewElement(MouseEventArgs e)
        {
            if (SelectedButton == WallButton)
            {
                if (CurrentlyDrawnWall == null)
                {
                    WallData wall = new WallData(ButtonList.IndexOf(SelectedButton), ButtonName(SelectedButton), e.Location.X, e.Location.Y, SelectedButton.BackgroundImage);
                    CurrentlyDrawnWall = wall;

                    FurnitureList.Add(wall);
                    listBox1.SelectedItem = null;
                    //listBox1.Items.Add(wall);
                    //listBox1.DataSource = null;
                    //listBox1.DataSource = FurnitureList;
                }
                CurrentlyDrawnWall.AddPoint(e.Location);
                DrawDesign();
                
            }
            else
            {
                FurnitureList.Add(new FurnitureData(ButtonList.IndexOf(SelectedButton), ButtonName(SelectedButton), e.Location.X, e.Location.Y, SelectedButton.BackgroundImage));
                //listBox1.Items.Add(new FurnitureData(ButtonName(SelectedButton), e.Location.X, e.Location.Y, SelectedButton.BackgroundImage));
                //listBox1.DataSource = null;
                //listBox1.DataSource = FurnitureList;
                DrawDesign();
                SelectButton(SelectedButton);
            }
        }

        private void SelectElement(MouseEventArgs e)
        {
            foreach (FurnitureData furniture in FurnitureList)
            {
                if (furniture is WallData)
                {
                    using (var p = new GraphicsPath())
                    {
                        p.AddLines((furniture as WallData).anchors.ToArray());

                        Matrix transformMatrix = new Matrix();
                        transformMatrix.Translate(furniture.x, furniture.y);
                        transformMatrix.Rotate(furniture.angle);
                        p.Transform(transformMatrix);

                        if (p.IsOutlineVisible(e.Location, new Pen(Brushes.Black, WallThickness)))
                        {
                            listBox1.SelectedItem = furniture;
                            //DrawDesign();
                            return;
                        }
                    }
                }
                else
                {
                    using (var p = new GraphicsPath())
                    {
                        p.AddRectangle(new Rectangle(-furniture.image.Width / 2,
                            -furniture.image.Height / 2,
                            furniture.image.Width,
                            furniture.image.Height));

                        Matrix transformMatrix = new Matrix();
                        transformMatrix.Translate(furniture.x, furniture.y);
                        transformMatrix.Rotate(furniture.angle);
                        p.Transform(transformMatrix);

                        if (p.IsVisible(e.Location))
                        {
                            listBox1.SelectedItem = furniture;
                            //DrawDesign();
                            return;
                        }
                    }
                }
            }
            listBox1.SelectedItem = null;
            //DrawDesign();
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            if(pictureBox1.Size.Height<panel1.Height || pictureBox1.Size.Width<panel1.Width)
            {
                pictureBox1.Height = (pictureBox1.Height > panel1.Height) ? pictureBox1.Height : panel1.Height;
                pictureBox1.Width = (pictureBox1.Width > panel1.Width) ? pictureBox1.Width : panel1.Width;
                DrawDesign();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(CurrentlyDrawnWall!=null)
            {
                CurrentlyDrawnWall.ModLastPoint(e.Location);
                DrawDesign();
            }
            if(MouseIsDown && listBox1.SelectedItem!=null && SelectedButton==null)
            {
                var furniture = listBox1.SelectedItem as FurnitureData;
                furniture.x += e.Location.X - OriginalMousePosition.X;
                furniture.y += e.Location.Y - OriginalMousePosition.Y;

                OriginalMousePosition = e.Location;
                DrawDesign();
                FurnitureList.ResetBindings();
               
                
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawDesign();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            MouseIsDown = true;

            if (SelectedButton == null && e.Button == MouseButtons.Left)
            {
                SelectElement(e);
                OriginalMousePosition = e.Location;
            }
            if (SelectedButton != null && e.Button == MouseButtons.Left)
            {
                AddNewElement(e);
            }
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseIsDown = false;
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(listBox1.SelectedItem!=null)
            {
                (listBox1.SelectedItem as FurnitureData).angle += e.Delta/12;
                DrawDesign();
            }
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void saveBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveBlueprintDialog = new SaveFileDialog();
            saveBlueprintDialog.Filter = "Blueprint files|*.bp";
            saveBlueprintDialog.Title = "Save the Blueprint";
            if(saveBlueprintDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveBlueprintDialog.FileName != "")
                {
                    System.IO.FileStream fs = (System.IO.FileStream)saveBlueprintDialog.OpenFile();
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (FurnitureData furniture in FurnitureList)
                        {
                            string value = $"{furniture.id},{furniture.angle},{furniture.x},{furniture.y}";
                            if (furniture is WallData)
                            {
                                foreach (Point p in (furniture as WallData).anchors)
                                {
                                    value += $",{p.X},{p.Y}";
                                }
                            }
                            //byte[] data = new UTF8Encoding(true).GetBytes(value);
                            //fs.Write(data, 0, data.Length);
                            sw.WriteLine(value);

                        }
                    }
                    fs.Close();
                    MessageBox.Show(GlobalStrings.SaveSuccess);
                }
            }
            
           
        }

        private void openBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openBlueprintDialog = new OpenFileDialog();
            openBlueprintDialog.Filter = "Blueprint files|*.bp";
            openBlueprintDialog.Title = "Open a Blueprint";

            if(openBlueprintDialog.ShowDialog() == DialogResult.OK)
            {
                var fs = openBlueprintDialog.OpenFile();
                string content;
                using (StreamReader sr = new StreamReader(fs))
                {
                    content = sr.ReadToEnd();
                }
                fs.Close();
                var furnitureStringList = content.Split("\n".ToCharArray());
                newBlueprintToolStripMenuItem_Click(this, null);
                foreach(string furnitureString in furnitureStringList)
                {
                    if(furnitureString!="")
                    {
                        var s = furnitureString.Split(",".ToCharArray());
                        if (Int32.Parse(s[0]) == 4)
                        {
                            WallData furniture = new WallData(Int32.Parse(s[0]), "", Int32.Parse(s[2]), Int32.Parse(s[3]));
                            furniture.angle = Int32.Parse(s[1]);
                            furniture.image = WallButton.BackgroundImage;
                            for (int i = 6; i < s.Length; i += 2)
                            {
                                furniture.anchors.Add(new Point(Int32.Parse(s[i]), Int32.Parse(s[i + 1])));
                            }
                            FurnitureList.Add(furniture);
                        }
                        else
                        {
                            FurnitureData furniture = new FurnitureData(Int32.Parse(s[0]), "", Int32.Parse(s[2]), Int32.Parse(s[3]));
                            furniture.angle = Int32.Parse(s[1]);
                            switch (Int32.Parse(s[0]))
                            {
                                case 0:
                                    furniture.image = CoffeeTableButton.BackgroundImage;
                                    break;
                                case 1:
                                    furniture.image = TableButton.BackgroundImage;
                                    break;
                                case 2:
                                    furniture.image = SofaButton.BackgroundImage;
                                    break;
                                case 3:
                                    furniture.image = BedButton.BackgroundImage;
                                    break;
                                default:
                                    throw new ArgumentException();
                            }
                            FurnitureList.Add(furniture);
                        }
                    
                    }
                }
                FurnitureList.ResetBindings();
                DrawDesign();
                MessageBox.Show(GlobalStrings.OpenSuccess);
            }
            
        }

        private void angielskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
        }

        private void polskiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("pl");
        }

        private void ChangeLanguage(string language)
        {
            CultureInfo culture_info = new CultureInfo(language);

            Thread.CurrentThread.CurrentCulture = culture_info;
            Thread.CurrentThread.CurrentUICulture = culture_info;

            // Make a ComponentResourceManager.
            ComponentResourceManager component_resource_manager
                = new ComponentResourceManager(this.GetType());

            // Apply resources to the form.
            component_resource_manager.ApplyResources(
                this, "$this", culture_info);

            // Apply resources to the form's controls.
            foreach (Control ctl in this.Controls)
            {
                component_resource_manager.ApplyResources(
                    ctl, ctl.Name, culture_info);
            }


            this.Controls.Clear();
            this.InitializeComponent();

            this.DrawDesign();
            listBox1.DataSource = null;
            listBox1.DataSource = FurnitureList;
            listBox1.SelectedItem = null;
            FurnitureList.ResetBindings();
            pictureBox1.BackColor = Color.White;

            pictureBox1.MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
            ButtonList = new List<Button> { CoffeeTableButton, TableButton, SofaButton, BedButton, WallButton };
        }
    }

}
