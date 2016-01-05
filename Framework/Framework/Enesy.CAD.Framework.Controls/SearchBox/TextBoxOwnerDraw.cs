using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Enesy.CAD.Framework.Controls
{
    public partial class TextBoxOwnerDraw : Panel, INotifyPropertyChanged
    {
        private Panel pn = new Panel();
        private string searchWaterMark =  "Search in: All columns";
        private Button SearchButton = new Button();
        private TextBoxWithHeight MyTextBox = new TextBoxWithHeight();
        private ButtonNoBorder filterButton = new ButtonNoBorder();
        private int cornerRadius = 0;
        private Color borderColor = Color.Transparent;
        private int borderSize = 0;
        private Size preferredSize = new Size(300, 25);

        public event FilterDataSearchEventHandler FilterCommand;
        
        public string StringToFilter = "";

        /// <summary>
        /// Cột để filter dữ liệu, mặc định filter trong tất cả các cột
        /// </summary>
        public string columnToFilter = "All columns";

        public DataGridViewColumnCollection columnsList = null;

        // Declare the event 
        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchWaterMark
        {
            get { return searchWaterMark; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    searchWaterMark = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged("SearchWaterMark");
                    //MessageBox.Show(SearchWaterMark);
                    MyTextBox.Text = SearchWaterMark;
                }
            }
        }

        // Create the OnPropertyChanged method to raise the event 
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        /// <summary>
        /// Access the textbox
        /// </summary>
        public TextBox TextBox
        {
            get { return MyTextBox; }
        }
        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                RestyleTextBox();
                this.Invalidate();
            }
        }
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                RestyleTextBox();
                this.Invalidate();
            }
        }
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                RestyleTextBox();
                this.Invalidate();
            }
        }
        public Size PrefSize
        {
            get { return preferredSize; }
            set
            {
                preferredSize = value;
                RestyleTextBox();
                this.Invalidate();
            }
        }

        public TextBoxOwnerDraw()
        {
            //searchWaterMark = "Search in: All columns";

            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            pn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pn.BackColor = Color.White;
            //pn.Padding = new System.Windows.Forms.Padding(2,2,2,2);
            pn.Size = preferredSize;
            //pn.AutoSize = true;
            //pn.Dock = DockStyle.Fill;
            this.Controls.Add(pn);

            filterButton.BackColor = Color.White;
            filterButton.FlatStyle = FlatStyle.Flat;
            filterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            filterButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            filterButton.Cursor = Cursors.Hand;
            filterButton.FlatAppearance.BorderSize = 0;
            filterButton.Size = new Size(33, pn.Height);
            //filterButton.Text = "Columns";
            filterButton.Image = Framework.Resource.Filter;
            filterButton.ImageAlign = ContentAlignment.MiddleLeft;
            //filterButton.Location = new Point(0, preferredSize.Height / 2 - filterButton.Height/2);
            filterButton.Click += filterButton_Click;
            this.pn.Controls.Add(filterButton);
            filterButton.Dock = DockStyle.Left;

            SearchButton.BackColor = Color.White;
            SearchButton.FlatStyle = FlatStyle.Flat;
            SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            SearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            SearchButton.Cursor = Cursors.Hand;
            SearchButton.FlatAppearance.BorderSize = 0;
            SearchButton.Size = new Size(30, pn.Height);
            //SearchButton.Location = new Point(MyTextBox.Left + MyTextBox.Width, preferredSize.Height / 2 - filterButton.Height / 2);
            SearchButton.Image = Framework.Resource.SearchButtonDisable;
            SearchButton.ImageAlign = ContentAlignment.MiddleCenter;
            SearchButton.Click += SearchButton_Click;
            //SearchButton.MouseHover += SearchButton_MouseHover;
            //SearchButton.MouseClick += SearchButton_MouseClick;
            //SearchButton.MouseUp += SearchButton_MouseUp;
            //SearchButton.MouseLeave += SearchButton_MouseLeave;
            //btn.Click += btn_Click;
            this.pn.Controls.Add(SearchButton);
            SearchButton.Dock = DockStyle.Right;

            MyTextBox.Location = new Point(filterButton.Width + 3, filterButton.Top + 5);
            //MyTextBox.Font = new Font(MyTextBox.Font.FontFamily, 12);
            MyTextBox.Width = preferredSize.Width - 3 - filterButton.Width - 30;
            MyTextBox.Height = pn.Height - 4;
            //MyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            MyTextBox.Text = SearchWaterMark;
            MyTextBox.ForeColor = Color.Gray;
            //MyTextBox.KeyDown += MyTextBox_KeyDown;
            MyTextBox.TextChanged += MyTextBox_TextChanged;
            MyTextBox.Enter += MyTextBox_Enter;
            MyTextBox.Leave += MyTextBox_Leave;
            this.pn.Controls.Add(MyTextBox);
            //MyTextBox.Dock = DockStyle.Fill;

            
            RestyleTextBox();

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //if (this.MyTextBox.TextLength > 0 && this.MyTextBox.Text != this.SearchWaterMark && this.Search != null)
            //{
            //    DataGridViewColumn c = null;
            //    if (this.columnComboBox.SelectedIndex > 0 && this.columnsList != null && this.columnsList.GetColumnCount(DataGridViewElementStates.Visible) > 0)
            //    {
            //        DataGridViewColumn[] cols = this.columnsList.Cast<DataGridViewColumn>().Where(col => col.Visible).ToArray<DataGridViewColumn>();

            //        if (cols.Length == this.columnComboBox.Items.Count - 1)
            //        {
            //            if (cols[this.columnComboBox.SelectedIndex - 1].HeaderText == this.columnComboBox.SelectedItem.ToString())
            //                c = cols[this.columnComboBox.SelectedIndex - 1];
            //        }
            //    }

            //    SearchToolBarSearchEventArgs args = new SearchToolBarSearchEventArgs(
            //        this.MyTextBox.Text,
            //        c,
            //        false,
            //        false,
            //        true
            //    );
            //    this.Search(this, args);
            //}
        }

        public void SetFocus()
        {
            MyTextBox.Text = string.Empty;
            MyTextBox.Focus();
        }

        //private void MyTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape)
        //    {
        //        MyTextBox.Text = "";
        //        MyTextBox.Focus();
        //    }

        //    if (this.MyTextBox.TextLength > 0 && this.MyTextBox.Text != this.SearchWaterMark && e.KeyData == Keys.Enter)
        //    {
        //        e.SuppressKeyPress = false;
        //        e.Handled = true;
        //        try
        //        {
        //            //searchButton_Click(this.SearchButton, new EventArgs());
        //            //MessageBox.Show("Nothing found! Try another search", "Search result Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        }
        //        catch
        //        {
        //            MessageBox.Show("Nothing found! Try another search", "Search result Dialog", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}




        private void MyTextBox_Leave(object sender, EventArgs e)
        {
            if (this.MyTextBox.Text.Trim() == "")
            {
                this.MyTextBox.Text = SearchWaterMark;
                this.MyTextBox.ForeColor = Color.Gray;
            }
        }

        private void MyTextBox_Enter(object sender, EventArgs e)
        {
            if (this.MyTextBox.Text == SearchWaterMark)
            {
                this.MyTextBox.Text = "";
            }
            else
            {
                //MessageBox.Show(SearchWaterMark);
                //this.MyTextBox.Text = "";
                MyTextBox.SelectAll();
                this.MyTextBox.ForeColor = Color.Gray;
            }
        }

        private void MyTextBox_TextChanged(object sender, EventArgs e)
        {
            this.SearchButton.Enabled = this.MyTextBox.TextLength > 0 && this.MyTextBox.Text != SearchWaterMark;

            if(this.MyTextBox.TextLength > 0 && this.MyTextBox.Text != SearchWaterMark)
                SearchButton.Image = Framework.Resource.SearchButtonHover;
            else
                SearchButton.Image = Framework.Resource.SearchButtonDisable;

            //
            this.StringToFilter = this.MyTextBox.Text;
            /////////////////////////////////////////////
            try
            {
                FilterDataSearchEventArgs filterarg = new FilterDataSearchEventArgs(this.MyTextBox.Text);
                this.FilterCommand(this, filterarg);
            }
            catch
            {

            }
        }

        public void SearchReset()
        {
            this.MyTextBox.Text = this.SearchWaterMark;
            this.MyTextBox.ForeColor = Color.Gray;
        }

        public void SetColumns(DataGridViewColumnCollection columns)
        {
            this.columnsList = columns;
        }

        private void SearchButton_MouseUp(object sender, MouseEventArgs e)
        {
            SearchButton.Image = Framework.Resource.SearchButtonHover;
        }

        private void SearchButton_MouseLeave(object sender, EventArgs e)
        {
            SearchButton.Image = Framework.Resource.SearchButtonDisable;
        }

        private void SearchButton_MouseClick(object sender, MouseEventArgs e)
        {
            SearchButton.Image = Framework.Resource.SearchButtonPressed;
        }

        private void SearchButton_MouseHover(object sender, EventArgs e)
        {
            SearchButton.Image = Framework.Resource.SearchButtonHover;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            // Tạo menu

            ContextMenuStrip Menu = new ContextMenuStrip();
            //Menu.Items.Insert(0, new ToolStripLabel("Search in:"));

            ToolStripMenuItem MenuCommandStart = new ToolStripMenuItem("All columns");
            //MenuCommandStart.CheckOnClick = true;
            //MenuCommandStart.CheckState = CheckState.Checked;
            //MenuCommandStart.MouseDown += new MouseEventHandler(MenuCommandStart_Click);
            Menu.Items.AddRange(new ToolStripItem[] { MenuCommandStart });

            ////ToolStripMenuItem MenuCommandViewVideo = new ToolStripMenuItem("Shortcut");
            ////MenuCommandViewVideo.CheckOnClick = true;
            ////Menu.Items.AddRange(new ToolStripItem[] { MenuCommandViewVideo });

            Menu.Items.Add(new ToolStripSeparator());

            if (this.columnsList != null)
                foreach (DataGridViewColumn c in this.columnsList)
                {
                    Menu.Items.Add(c.HeaderText);
                }

            Menu.ItemClicked += Menu_ItemClicked;

            //Assign created context menu strip to the DataGridView
            this.ContextMenuStrip = Menu;

            Menu.Show(this.filterButton, new Point(pn.Location.X, pn.Location.Y + pn.Height));
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                columnToFilter = e.ClickedItem.Text;
                SearchWaterMark = "Search in: " + columnToFilter;
                this.MyTextBox.Text = SearchWaterMark;
            }
            catch
            {
                MessageBox.Show("No thing to filter");
            }
        }

        private void RestyleTextBox()
        {
            double TopPos = Math.Floor(((double)this.preferredSize.Height / 2) - ((double)MyTextBox.Height / 2));

            MyTextBox.BackColor = Color.White;
            this.BackColor = Color.Transparent;

            pn.Location = new Point(0, 4);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (cornerRadius > 0 && borderSize > 0)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle cRect = this.ClientRectangle;
                Rectangle safeRect = new Rectangle(cRect.X, cRect.Y, cRect.Width - this.BorderSize, cRect.Height - this.BorderSize);

                // Background color
                using (Brush bgBrush = new SolidBrush(MyTextBox.BackColor))
                {
                    DrawRoundRect(g, bgBrush, safeRect, (float)this.CornerRadius);
                }
                // Border
                ////using (Pen borderPen = new Pen(this.BorderColor, (float)this.BorderSize))
                ////{
                ////    DrawRoundRect(g, borderPen, safeRect, (float)this.CornerRadius);
                ////}
            }
            base.OnPaint(e);
        }

        #region Private Methods
        private GraphicsPath getRoundRect(int x, int y, int width, int height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner (Top Right)
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner (Bottom Right)
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner (Bottom Left)
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner (Top Left)
            gp.CloseFigure();
            return gp;
        }
        private void DrawRoundRect(Graphics g, Pen p, Rectangle rect, float radius)
        {
            GraphicsPath gp = getRoundRect(rect.X, rect.Y, rect.Width, rect.Height, radius);
            g.DrawPath(p, gp);
            gp.Dispose();
        }
        private void DrawRoundRect(Graphics g, Pen p, int x, int y, int width, int height, float radius)
        {
            GraphicsPath gp = getRoundRect(x, y, width, height, radius);
            g.DrawPath(p, gp);
            gp.Dispose();
        }
        private void DrawRoundRect(Graphics g, Brush b, int x, int y, int width, int height, float radius)
        {
            GraphicsPath gp = getRoundRect(x, y, width, height, radius);
            g.FillPath(b, gp);
            gp.Dispose();
        }
        private void DrawRoundRect(Graphics g, Brush b, Rectangle rect, float radius)
        {
            GraphicsPath gp = getRoundRect(rect.X, rect.Y, rect.Width, rect.Height, radius);
            g.FillPath(b, gp);
            gp.Dispose();
        }
        #endregion

        // Cá cơm
        public delegate void FilterDataSearchEventHandler(object sender, FilterDataSearchEventArgs e);
        public class FilterDataSearchEventArgs : EventArgs
        {
            public string ValueToFilter { get; private set; }

            public FilterDataSearchEventArgs(string value)
            {
                this.ValueToFilter = value;
            }
        }

    }

    public delegate void SearchBoxSearchEventHandler(object sender, SearchBoxSearchEventArgs e);

    public class SearchBoxSearchEventArgs : EventArgs
    {
        public string ValueToSearch { get; private set; }
        public DataGridViewColumn ColumnToSearch { get; private set; }
        public bool CaseSensitive { get; private set; }
        public bool WholeWord { get; private set; }
        public bool FromBegin { get; private set; }

        public SearchBoxSearchEventArgs(string Value, DataGridViewColumn Column, bool Case, bool Whole, bool fromBegin)
        {
            this.ValueToSearch = Value;
            this.ColumnToSearch = Column;
            this.CaseSensitive = Case;
            this.WholeWord = Whole;
            this.FromBegin = fromBegin;
        }
    }
}
