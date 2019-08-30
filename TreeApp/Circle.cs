using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace TreeApp
{
    [Serializable]
    public class Circle
    {
        private string number;
        private string name;
        protected string cur;
        protected double price;
        protected int r;
        public TreeNode treeNode;
        public string information;
        public double totalProbably;
        public double probablyToParent; // circle to children
        public Point centre;
        public Circle parent;
        public List<Circle> children = new List<Circle>();
        public static List<Circle> TotalCircles = new List<Circle>(0);
        public static Circle TheBestCircle, TheBadCircle;

        public string Number
        {
            get { return number; }
            set
            {
                treeNode = new TreeNode(value + " " + information);
                number = value;
            }
        }
        public double Price
        {
            get { return price; }
            set { GetTotalChance(); price = value; }
        }
        public double PriceXProbably
        {
            get
            {
                if (parent != null)
                    return price * probablyToParent + parent.PriceXProbably;
                return price * probablyToParent;
            }
        }
        public double SumPrice
        {
            get
            {
                if (parent != null)
                    return price  + parent.SumPrice;
                return price;
            }
        }
        public int R
        {
            get { return r; }
            set
            {
                foreach (var item in children)
                {
                    item.R = value;
                }
                r = value;
            }
        }
        public Circle(Point centre, int r, Circle c, ref DestDelegate destDelegate, double chance, string info, double price)
        {
            parent = c;
            destDelegate += Destination;
            this.centre = centre;
            this.r = r;

            if (parent != null) Number = $"{parent.Number}.{parent.children.Count + 1}";
            else Number = "1";

            information = info;

            if (c is Square) probablyToParent = 1;
            else
                probablyToParent = chance;

            this.price = price;
            GetTotalChance();

            treeNode = new TreeNode(Number + " " +info);
        }

        public void GetTotalChance()
        {
            if (parent != null)
            {
                totalProbably = parent.totalProbably * probablyToParent;
            }
            else
            {
                totalProbably = 1;
            }
            for (int i = 0; i < children.Count; i++)
            {
                children[i].GetTotalChance();
            }
        }

        protected void TotalPrint(Pen p, ref Graphics g, bool f, bool theEnd, SolidBrush drawBrush, bool visiblePrice, bool visibleChance, bool visibleNumber)
        {
            Font drawFont = new Font("Times New Roman", 10);// Работа с строками
            StringFormat drawFormat = new StringFormat();
            
            if (children.Count == 0)
            {
                g.DrawString($"Вероятность: {totalProbably.ToString()} \nВероятностная стоимость: ({PriceXProbably} {cur}) \nСуммарная стоимость: {SumPrice} ", drawFont, drawBrush, centre.X + 25, centre.Y - 15, drawFormat);
                TotalCircles.Add(this);
            }

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Print(p, ref g, f, theEnd, drawBrush, visiblePrice, visibleChance, visibleNumber);
            }
            if (Form1.selectTotalBy == 0)
            {
                var result = from i in TotalCircles
                             orderby i.totalProbably
                             select i;

                TotalCircles = new List<Circle>(TotalCircles.Count);

                foreach (var item in result)
                {
                    TotalCircles.Add(item);
                }
            }
            else if(Form1.selectTotalBy == 2)
            {
                var result = from i in TotalCircles
                             orderby i.PriceXProbably
                             select i;

                TotalCircles = new List<Circle>(TotalCircles.Count);

                foreach (var item in result)
                {
                    TotalCircles.Add(item);
                }
            }
            else
            {
                var result = from i in TotalCircles
                             orderby i.SumPrice
                             select i;

                TotalCircles = new List<Circle>(TotalCircles.Count);

                foreach (var item in result)
                {
                    TotalCircles.Add(item);
                }
            }
            TheBestCircle = TotalCircles[0];
            TheBadCircle = TotalCircles[TotalCircles.Count - 1];
        }

        public virtual void Print(Pen p, ref Graphics g, bool visibleMenu, bool theEnd, SolidBrush drawBrush, bool visiblePrice, bool visibleChance, bool visibleNumber)
        {
            Font drawFont = new Font("Arial", 8);
            StringFormat drawFormat = new StringFormat();
            switch (Form1.currency)
            {
                case 0:
                    cur = "$";
                    break;
                case 1:
                    cur = "₽";
                    break;
                case 2:
                    cur = "€";
                    break;
                case 3:
                    cur = "£";
                    break;
                default:
                    cur = "¥";
                    break;
            }
            if (parent != null)
            {
                Point forLines = new Point(parent.centre.X + (centre.X - parent.centre.X) / 3, centre.Y);
                g.DrawLine(p, forLines, centre);
                g.DrawLine(p, parent.centre, forLines);

                if (!visibleMenu && !(parent is Square) && visibleChance)
                    g.DrawString(probablyToParent.ToString(), drawFont, drawBrush, (centre.X - parent.centre.X) / 2 + parent.centre.X, centre.Y + 3, drawFormat);
                if (!visibleMenu && visiblePrice)
                    g.DrawString($"({price.ToString()} {cur})", drawFont, drawBrush, (centre.X - parent.centre.X) / 2 + parent.centre.X, centre.Y + 17, drawFormat);
                if (!visibleMenu && visibleNumber)
                {
                    g.DrawString(Number, new Font("TimesNewRoman", 7), drawBrush, centre.X - 10, centre.Y + 7, drawFormat);
                    g.DrawString(information, drawFont, drawBrush, (centre.X - parent.centre.X) / 2 + parent.centre.X-15, centre.Y - 20, drawFormat);
                }
            }

            g.FillEllipse(drawBrush, centre.X - r, centre.Y - r, 2 * r, 2 * r);

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Print(p, ref g, visibleMenu, theEnd, drawBrush, visiblePrice, visibleChance, visibleNumber);
            }
            if (theEnd)
            {
                TotalPrint(p, ref g, visibleMenu, theEnd, drawBrush, visiblePrice, visibleChance, visibleNumber);
            }
        }

        public virtual void Destination(Point point, ref Circle circle)
        {
            if (Math.Pow((point.X - centre.X), 2) + Math.Pow((point.Y - centre.Y), 2) <= (r + 2) * (r + 2)) circle = this;
        }

        public void AddCircle(Circle circle)
        {
            children.Add(circle);
        }

        public void AlgorithmOfCoordiantes(ref int k, double ChangeSize, double ForX, int dy, int dyCenter)
        {
            centre.X = (int)(centre.X * ForX);

            if (children.Count == 0)
            {
                centre.Y = (int)(k * 80 / ChangeSize) + dy + Form1.dyCenter;
                k++;
            }
            else
            {
                foreach (var child in children) child.AlgorithmOfCoordiantes(ref k, ChangeSize, ForX, dy, dyCenter);
                centre.Y = ((children[0].centre.Y + children[children.Count - 1].centre.Y) / 2);
            }
        }

        internal virtual void DrawNeedChange(SolidBrush drawBrush, ref Graphics g)
        {
            g.FillEllipse(drawBrush, centre.X - r, centre.Y - r, 2 * r, 2 * r);
        }

        internal void GetParentChance(Circle circle)
        {
            probablyToParent = circle.probablyToParent;
        }

        public override string ToString()
        {
            if (GetType().Name == "Circle") name = "Событие";
            else if (GetType().Name == "Square") name = "Узел";
            else name = "Лист";

            return
                $"Название:{information}" + Environment.NewLine +
                $"Тип:  {name}" + Environment.NewLine +
                $"Вероятность:  {probablyToParent:f2}" + Environment.NewLine +
                $"Стоимость:  {price:f2}" + Environment.NewLine + Environment.NewLine +
                $"Порядковый номер:  {Number}";
        }
    }
}
