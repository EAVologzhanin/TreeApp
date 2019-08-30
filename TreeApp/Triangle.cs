using System;
using System.Drawing;


namespace TreeApp
{
    [Serializable]
    public class Triangle : Circle
    {
        public PointF[] coordinates = new PointF[3];
        public Triangle(Point centre, int r, Circle c, ref DestDelegate destDelegate, double chance, string info, double price) : base(centre, r, c, ref destDelegate, chance, info, price)
        {
            
        }

        public override void Print(Pen p, ref Graphics g, bool f, bool theEnd, SolidBrush drawBrush, bool visiblePrice, bool visibleChance, bool visibleNumber)
        {
            Font drawFont = new Font("Arial", 8);// Работа с строками
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

                if (!f && !(parent is Square) && visibleChance)
                    g.DrawString(probablyToParent.ToString(), drawFont, drawBrush, (centre.X - parent.centre.X) / 2 + parent.centre.X, centre.Y + 3, drawFormat);
                if (!f && visiblePrice)
                    g.DrawString($"({price.ToString()} {cur})", drawFont, drawBrush, (centre.X - parent.centre.X) / 2 + parent.centre.X, centre.Y + 17, drawFormat);
                if (!f && visibleNumber)
                {
                    g.DrawString(Number, new Font("TimesNewRoman", 7), drawBrush, centre.X - 10, centre.Y + 7, drawFormat);
                    g.DrawString(information, drawFont, drawBrush, (centre.X - parent.centre.X) / 2 + parent.centre.X-15, centre.Y - 20, drawFormat);
                }
            }
            coordinates[0] = new Point(centre.X-r, centre.Y);
            coordinates[1] = new Point(centre.X+r, centre.Y + 2*r);
            coordinates[2] = new Point(centre.X +r, centre.Y - 2*r);
            g.FillPolygon(drawBrush, coordinates);

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Print(p, ref g, f, theEnd, drawBrush, visiblePrice, visibleChance,visibleNumber);
            }
            if (theEnd)
            {
                TotalPrint(p, ref g, f, theEnd, drawBrush, visiblePrice, visibleChance,visibleNumber);
            }
        }
        internal override void DrawNeedChange(SolidBrush drawBrush, ref Graphics g)
        {
            coordinates[0] = new Point(centre.X - r, centre.Y);
            coordinates[1] = new Point(centre.X + r, centre.Y + 2 * r);
            coordinates[2] = new Point(centre.X + r, centre.Y - 2 * r);
            g.FillPolygon(drawBrush, coordinates);
        }
    }
}
