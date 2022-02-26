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

namespace Task5
{
    public partial class Form1 : Form
    {
        private TextBox tb = new TextBox();

        public Form1()
        {
            List<IFurniture> list = GetList(10);
            List<IFurniture> listSorted = GetSortedList(list);
            Font f = new Font("Times new roman", 30, Font.Style);
            tb.Font = f;
            tb.Width = 1530;
            tb.Height = 800;
            tb.Multiline = true;
            tb.AcceptsTab = true;
            tb.WordWrap = true;
            tb.ScrollBars =  ScrollBars.Vertical;
            tb.Text = "List:" + Environment.NewLine + ListToString(list) + Environment.NewLine +
                      "Sorted:" + Environment.NewLine + ListToString(listSorted);
            Controls.Add(tb);
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Focus();
            InitializeComponent();
        }

        
        private List<IFurniture> GetSortedList(List<IFurniture> list)
        {
            List<IFurniture> output = new List<IFurniture>(list);
            output.Sort();
            return output;
        }

        private string ListToString(List<IFurniture> list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                BookCloset bc = (BookCloset) list[i];
                sb.Append(bc.Material.ToString()).Append(" shelf, priceCoef = ").Append(bc.GetPriceCoefficient())
                    .Append(", w = ").Append(bc.GetWidth()).Append(", h = ").Append(bc.GetHeight()).Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        private List<IFurniture> GetList(int length)
        {
            Random r = new Random();
            List<IFurniture> list = new List<IFurniture>();
            for (int i = 0; i < length; i++)
            {
                Material material = (Material) Enum.GetValues(typeof(Material)).GetValue(
                    r.Next(Enum.GetValues(typeof(Material)).Length));
                int width = 500 + 50 * r.Next(5);
                int height = 1000 + 50 * r.Next(10);
                int shelvesCount = r.Next(10);
                list.Add(new BookCloset(material, width, height, shelvesCount));
            }

            return list;
        }
    }
}