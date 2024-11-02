using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControls
{
    [DefaultEvent("TextChanged")]
    public class CustomTextBox : UserControl
    {
        private TextBox textBox;
        private Color borderColor = Color.MediumSlateBlue;
        private Color borderFocusColor = Color.HotPink;
        private int borderSize = 2;
        private bool isFocused = false;
        private string placeholderText = "";
        private Color placeholderColor = Color.DarkGray;
        private int borderRadius = 15; // Mặc định là 15  

        public event EventHandler TextChanged;

        public CustomTextBox()
        {
            InitializeComponent();
            textBox.TextChanged += (s, e) => TextChanged?.Invoke(this, e);
            textBox.Enter += (s, e) => { isFocused = true; Invalidate(); HidePlaceholder(s, e); };
            textBox.Leave += (s, e) => { isFocused = false; Invalidate(); ShowPlaceholder(s, e); };
        }

        [Category("Appearance")]
        public string PlaceholderText
        {
            get => placeholderText;
            set
            {
                placeholderText = value;
                ShowPlaceholder(this, EventArgs.Empty);
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color PlaceholderColor
        {
            get => placeholderColor;
            set { placeholderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public Color BorderFocusColor
        {
            get => borderFocusColor;
            set { borderFocusColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(Width - borderRadius - borderSize * 2, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(Width - borderRadius - borderSize * 2, Height - borderRadius - borderSize * 2, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, Height - borderRadius - borderSize * 2, borderRadius, borderRadius, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);

                using (Pen borderPen = new Pen(isFocused ? borderFocusColor : borderColor, borderSize))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }

                if (string.IsNullOrEmpty(textBox.Text) && !isFocused)
                {
                    TextRenderer.DrawText(e.Graphics, placeholderText, textBox.Font, new Point(2,
                        (Height - textBox.Font.Height) / 2), placeholderColor);
                }
            }
        }

        private void InitializeComponent()
        {
            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(borderSize, borderSize),
                Size = new Size(150 - borderSize * 2, 30 - borderSize * 2),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            this.Controls.Add(textBox);
            this.Size = new Size(150, 30);
            AdjustFontSize();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            textBox.Size = new Size(Width - borderSize * 2, Height - borderSize * 2);
            textBox.Location = new Point(borderSize, borderSize);
            AdjustFontSize();
        }
        private void AdjustFontSize()
        {
            // Tính toán kích thước font dựa trên chiều cao của TextBox  
            float newFontSize = Height * 0.4f; // Điều chỉnh tỷ lệ theo ý muốn  
            textBox.Font = new Font(textBox.Font.FontFamily, newFontSize, textBox.Font.Style);
        }
        private void ShowPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.ForeColor = placeholderColor;
                textBox.Text = placeholderText;
                textBox.GotFocus += RemovePlaceholder;
                textBox.LostFocus += ShowPlaceholder;
            }
        }

        private void HidePlaceholder(object sender, EventArgs e)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.ForeColor = Color.Black;
                textBox.Text = string.Empty;
                textBox.GotFocus -= RemovePlaceholder;
                textBox.LostFocus -= ShowPlaceholder;
            }
        }
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
                textBox.GotFocus -= RemovePlaceholder; // Đăng ký bỏ sự kiện  
                textBox.LostFocus -= ShowPlaceholder; // Đăng ký bỏ sự kiện  
            }
        }
    }
}
