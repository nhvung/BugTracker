using System.Windows.Forms;
using System.Drawing;

namespace System.Windows.Forms
{
    public partial class DataGridViewStatusColumn : DataGridViewImageColumn
    {
        public DataGridViewStatusColumn()
        {
            CellTemplate = new DataGridViewStatusCell();
        }
    }
    public partial class DataGridViewStatusCell : DataGridViewImageCell
    {
        public class StatusCell
        {
            public string Value { get; set; }
            public Color BackColor { get; set; }
            public Color ForeColor { get; set; }
            public StatusCell() { }
            public StatusCell(string value, Color backColor, Color foreColor)
            {
                Value = value;
                BackColor = backColor;
                ForeColor = foreColor;
            }
            public override string ToString()
            {
                return Value;
            }
        }
        static Image _emptyImage;
        static DataGridViewStatusCell()
        {
            _emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        public DataGridViewStatusCell()
        {
            ValueType = typeof(StatusCell);
        }
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return _emptyImage;
        }
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {

                StatusCell cell = (StatusCell)value;
                Brush backColorBrush = new SolidBrush(cell.BackColor);
                Brush foreColorBrush = new SolidBrush(cell.ForeColor);
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));
                var measure = graphics.MeasureString(cell.Value, cellStyle.Font);
                graphics.FillRectangle(backColorBrush, cellBounds.X + 1, cellBounds.Y + 1, cellBounds.Width - 2, cellBounds.Height - 2);

                float x = ((float)cellBounds.Width - measure.Width) / 2;
                float y = ((float)cellBounds.Height - measure.Height) / 2;                
                graphics.DrawString(cell.Value, cellStyle.Font, foreColorBrush, cellBounds.X + x, cellBounds.Y + y, StringFormat.GenericDefault);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


