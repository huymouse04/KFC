using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CustomPanel : Panel
{
    public CustomPanel()
    {
        this.BorderStyle = BorderStyle.None; // Bỏ border mặc định  
    }

    // Thuộc tính cho màu nền  
    public Color PanelColor { get; set; } = Color.LightGray;

    // Màu sắc của border  
    public Color BorderColor { get; set; } = Color.Black;

    // Bán kính các góc   
    private float borderRadius = 20f; // Để có thể kiểm soát thay đổi
    public float BorderRadius
    {
        get => borderRadius;
        set
        {
            borderRadius = value;
            this.Invalidate(); // Vẽ lại panel khi giá trị BorderRadius thay đổi
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Vẽ màu nền cho panel  
        using (Brush brush = new SolidBrush(PanelColor))
        {
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        // Vẽ border tròn  
        using (GraphicsPath path = new GraphicsPath())
        {
            // Tạo hình chữ nhật với các góc tròn  
            path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90); // Góc trên trái  
            path.AddArc(this.Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90); // Góc trên phải  
            path.AddArc(this.Width - BorderRadius, this.Height - BorderRadius, BorderRadius, BorderRadius, 0, 90); // Góc dưới phải  
            path.AddArc(0, this.Height - BorderRadius, BorderRadius, BorderRadius, 90, 90); // Góc dưới trái  
            path.CloseFigure();

            // Đổ màu cho border  
            using (Brush borderBrush = new SolidBrush(BorderColor))
            {
                e.Graphics.FillPath(borderBrush, path);
            }
        }
    }

    // Ghi đè phương thức OnResize để vẽ lại khi kích thước thay đổi  
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        this.Invalidate(); // Gọi lại phương thức vẽ (OnPaint) khi kiểm soát kích thước  
    }

    // Ví dụ về phương thức tùy chỉnh  
    public void ResetPanel()
    {
        this.Controls.Clear(); // Xóa mọi điều khiển bên trong  
        this.PanelColor = Color.LightGray; // Đặt lại màu nền  
    }
}
