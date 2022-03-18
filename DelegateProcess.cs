using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


public class DelegateProcess
{
    #region General

    delegate void dlgSetText(Control control, string text);
    public void SetText(Control control, string text)
    {
        if (control.InvokeRequired) control.Invoke(new dlgSetText(SetText), control, text);
        else control.Text = text;
    }

    delegate string dlgGetText(Control control);
    public string GetText(Control control)
    {
        if (control.InvokeRequired) return control.Invoke(new dlgGetText(GetText), control).ToString();
        return control.Text;
    }

    delegate void dlgSetEnabled(Control control, bool enabled);
    public void SetEnabled(Control control, bool enabled)
    {
        if (control.InvokeRequired) control.Invoke(new dlgSetEnabled(SetEnabled), control, enabled);
        else control.Enabled = enabled;
    }

    delegate void dlgRefresh(Control control);
    public void Refresh(Control control)
    {
        if (control.InvokeRequired) control.Invoke(new dlgRefresh(Refresh), control);
        else control.Refresh();
    }
    delegate void dlgAddLine(Control control, string text);
    public void AddLine(Control control, string text = "")
    {
        if (control.InvokeRequired) control.Invoke(new dlgAddLine(AddLine), control, text);
        else
        {
            control.Text += Environment.NewLine + text;            
        }
    }

    delegate void dlgExecute(Control ctrl, Action action);
    public void Execute(Control ctrl, Action action)
    {
        if (ctrl.InvokeRequired) ctrl.Invoke(new dlgExecute(Execute), ctrl, action);
        else
        {
            action();
        }
    }
    delegate T dlgGetControlValue<TControl, T>(TControl ctrl, Func<TControl, T> selector) where TControl : Control;
    public T GetControlValue<TControl, T>(TControl ctrl, Func<TControl, T> selector) where TControl : Control
    {
        if (ctrl.InvokeRequired) return (T)ctrl.Invoke(new dlgGetControlValue<TControl, T>(GetControlValue), ctrl, selector);
        else return selector(ctrl);
    }


    #endregion

    #region ComboBox
    delegate void dlgAddComboBoxItem(ComboBox cbo, object item);
    public void AddComboBoxItem(ComboBox cbo, object item)
    {
        if (cbo.InvokeRequired) cbo.Invoke(new dlgAddComboBoxItem(AddComboBoxItem), cbo, item);
        else cbo.Items.Add(item);
    }
    delegate void dlgAddComboBoxItems(ComboBox cbo, object[] items);
    public void AddComboBoxItems(ComboBox cbo, object[] items)
    {
        if (cbo.InvokeRequired) cbo.Invoke(new dlgAddComboBoxItems(AddComboBoxItems), cbo, items);
        else cbo.Items.AddRange(items);
    }
    delegate void dlgSetComboBoxIndex(ComboBox cbo, int index);
    public void SetComboBoxIndex(ComboBox cbo, int index)
    {
        if (cbo.InvokeRequired) cbo.Invoke(new dlgSetComboBoxIndex(SetComboBoxIndex), cbo, index);
        else cbo.SelectedIndex = index;
    }
    delegate void dlgSetComboBoxSource<TKey, TValue>(ComboBox cbo, Dictionary<TKey,TValue> source);
    public void SetComboBoxSource<TKey, TValue>(ComboBox cbo, Dictionary<TKey, TValue> source)
    {
        if (cbo.InvokeRequired) cbo.Invoke(new dlgSetComboBoxSource<TKey, TValue>(SetComboBoxSource), cbo, source);
        else
        {
            cbo.ValueMember = "key";
            cbo.DisplayMember = "value";
            if (source.Count == 0) cbo.DataSource = new BindingSource(null, null);
            else cbo.DataSource = new BindingSource(source, null);
        }
    }
    delegate void dlgClearComboBoxItems(ComboBox cbo);
    public void ClearComboBoxItems(ComboBox cbo)
    {
        if (cbo.InvokeRequired) cbo.Invoke(new dlgClearComboBoxItems(ClearComboBoxItems), cbo);
        else cbo.Items.Clear();
    }
    #endregion

    #region DataGridView
    delegate void dlgSetDataGridViewValue(DataGridView dgv, int rowIndex, string columnName, object value);
    public void SetDataGridViewValue(DataGridView dgv, int rowIndex, string columnName, object value)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgSetDataGridViewValue(SetDataGridViewValue), dgv, rowIndex, columnName, value);
        else
        {
            if(dgv.RowCount > rowIndex && rowIndex > -1)
                dgv.Rows[rowIndex].Cells[columnName].Value = value;
        }
    }

    delegate void dlgSetDataGridViewValueColor(DataGridView dgv, int rowIndex, string columnName, Color backColor, Color foreColor, object value);
    public void SetDataGridViewValueColor(DataGridView dgv, int rowIndex, string columnName, Color backColor, Color foreColor, object value)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgSetDataGridViewValueColor(SetDataGridViewValueColor), dgv, rowIndex, columnName, backColor, foreColor, value);
        else
        {
            if (dgv.RowCount > rowIndex && rowIndex > -1)
            {
                dgv.Rows[rowIndex].Cells[columnName].Value = value;
                if (string.IsNullOrEmpty(columnName))
                {
                    dgv.Rows[rowIndex].DefaultCellStyle.BackColor = backColor;
                    dgv.Rows[rowIndex].DefaultCellStyle.ForeColor = foreColor;
                }
                else
                {
                    dgv.Rows[rowIndex].Cells[columnName].Style.BackColor = backColor;
                    dgv.Rows[rowIndex].Cells[columnName].Style.ForeColor = foreColor;
                }
            }
        }
    }

    delegate void dlgClearDataGridViewColumns(DataGridView dgv);
    public void ClearDataGridViewColumns(DataGridView dgv)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgClearDataGridViewColumns(ClearDataGridViewColumns), dgv);
        else dgv.Columns.Clear();
    }

    delegate void dlgAddDataGridViewColumn(DataGridView dgv, string columnName, string headerText);
    public void AddDataGridViewColumn(DataGridView dgv, string columnName, string headerText)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgAddDataGridViewColumn(AddDataGridViewColumn), dgv, columnName, headerText);
        else dgv.Columns.Add(columnName, headerText);
    }

    delegate void dlgAddDataGridViewColumns(DataGridView dgv, Dictionary<string,string> columns);
    public void AddDataGridViewColumns(DataGridView dgv, Dictionary<string, string> columns)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgAddDataGridViewColumns(AddDataGridViewColumns), dgv, columns);
        else
        {
            DataGridViewColumn[] dcolumns = columns.Select(ite => new DataGridViewColumn() { Name=ite.Key, HeaderText = ite.Value }).ToArray();
            dgv.Columns.AddRange(dcolumns);
        }
    }

    delegate void dlgClearDataGridViewRows(DataGridView dgv);
    public void ClearDataGridViewRows(DataGridView dgv)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgClearDataGridViewRows(ClearDataGridViewRows), dgv);
        else dgv.Rows.Clear();
    }

    delegate int dlgAddDataGridViewRow(DataGridView dgv, params object[] values);
    public int AddDataGridViewRow(DataGridView dgv, params object[] values)
    {
        if (dgv.InvokeRequired) return Convert.ToInt32(dgv.Invoke(new dlgAddDataGridViewRow(AddDataGridViewRow), dgv, values));
        else
        {
            int idx = dgv.Rows.Add(values);            
            return idx;
        }
    
    }

    delegate int dlgAddDataGridViewRowColor(DataGridView dgv, Color backColor, Color foreColor, string columnName, params object[] values);
    public int AddDataGridViewRowColor(DataGridView dgv, Color backColor, Color foreColor, string columnName, params object[] values)
    {
        if (dgv.InvokeRequired) return Convert.ToInt32(dgv.Invoke(new dlgAddDataGridViewRowColor(AddDataGridViewRowColor), dgv, backColor, foreColor, columnName, values));
        else
        {
            DataGridViewButtonCell cell = new DataGridViewButtonCell();
            
            int idx = dgv.Rows.Add(values);
            if (string.IsNullOrEmpty(columnName))
            {
                dgv.Rows[idx].DefaultCellStyle.BackColor = backColor;
                dgv.Rows[idx].DefaultCellStyle.ForeColor = foreColor;
            }
            else
            {
                dgv.Rows[idx].Cells[columnName].Style.BackColor = backColor;
                dgv.Rows[idx].Cells[columnName].Style.ForeColor = foreColor;
            }
            return idx;
        }

    }

    delegate int dlgGetDataGridViewColumnCount(DataGridView dgv);
    public int GetDataGridViewColumnCount(DataGridView dgv)
    {
        if (dgv.InvokeRequired) return Convert.ToInt32(dgv.Invoke(new dlgGetDataGridViewColumnCount(GetDataGridViewColumnCount), dgv));
        return dgv.ColumnCount;
    }

    delegate int dlgGetDataGridViewRowCount(DataGridView dgv);
    public int GetDataGridViewRowCount(DataGridView dgv)
    {
        if (dgv.InvokeRequired) return Convert.ToInt32(dgv.Invoke(new dlgGetDataGridViewRowCount(GetDataGridViewRowCount), dgv));
        return dgv.RowCount;
    }

    delegate List<DataGridViewRow> dlgGetDataGridViewRows(DataGridView dgv);
    public List<DataGridViewRow> GetDataGridViewRows(DataGridView dgv)
    {
        if (dgv.InvokeRequired) return (List<DataGridViewRow>)dgv.Invoke(new dlgGetDataGridViewRows(GetDataGridViewRows), dgv);
        return dgv.Rows.Cast<DataGridViewRow>().ToList();
    }

    delegate List<DataGridViewRow> dlgGetDataGridViewCheckedRows(DataGridView dgv, string checkColumn);
    public List<DataGridViewRow> GetDataGridViewCheckedRows(DataGridView dgv, string checkColumn)
    {
        if (dgv.InvokeRequired) return (List<DataGridViewRow>)dgv.Invoke(new dlgGetDataGridViewCheckedRows(GetDataGridViewCheckedRows), dgv, checkColumn);
        else
        {
            List<DataGridViewRow> result = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[checkColumn].Value.Equals(true) && row.Visible)
                    result.Add(row);
            }
            return result;
        }
    }
    delegate List<DataGridViewRow> dlgGetDataGridViewSelectedRows(DataGridView dgv);
    public List<DataGridViewRow> GetDataGridViewSelectedRows(DataGridView dgv)
    {
        if (dgv.InvokeRequired) return (List<DataGridViewRow>)dgv.Invoke(new dlgGetDataGridViewSelectedRows(GetDataGridViewSelectedRows), dgv);
        else
        {
            List<DataGridViewRow> result = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                result.Add(row);
            }
            return result;
        }
    }

    delegate void dlgSetActionDataGridView(DataGridView dgv, Action<DataGridView> action);
    public void SetActionDataGridView(DataGridView dgv, Action<DataGridView> action)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgSetActionDataGridView(SetActionDataGridView), dgv, action);
        else
        {
            action(dgv);
        }
    }

    delegate void dlgSetDataGridViewSelectedRowIndex(DataGridView dgv, int rowIndex);
    public void SetDataGridViewSelectedRowIndex(DataGridView dgv, int rowIndex)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgSetDataGridViewSelectedRowIndex(SetDataGridViewSelectedRowIndex), dgv, rowIndex);
        else
        {
            dgv.Rows[rowIndex].Selected = true;
        }
    }

    delegate CheckBox dlgAddDataGridViewCheckBoxAll(DataGridView dgv, string chkColumnName, EventHandler chkall_ClickExt, DataGridViewCellEventHandler cellContentClickExt);
    public CheckBox AddDataGridViewCheckBoxAll(DataGridView dgv, string chkColumnName, EventHandler chkall_ClickExt = null, DataGridViewCellEventHandler cellContentClickExt=null)
    {
        if (dgv.InvokeRequired) return (CheckBox)dgv.Invoke(new dlgAddDataGridViewCheckBoxAll(AddDataGridViewCheckBoxAll), dgv, chkColumnName, chkall_ClickExt, cellContentClickExt);
        else
        {
            CheckBox chkall = new CheckBox() { Size = new Size(18,18), BackColor = Color.Transparent };
            
            int cIdx = dgv.Columns[chkColumnName].Index;
            Rectangle headerRect = dgv.GetCellDisplayRectangle(0, -1, true);
            int x = 0;
            for (int i = 0; i < cIdx; i++) if(dgv.Columns[i].Visible) x += dgv.Columns[i].Width - 6;

            chkall.Location = new Point(x + 10, headerRect.Location.Y + 8);

            dgv.Controls.Add(chkall);
            
            dgv.CellContentClick += (o, e) => 
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (e.ColumnIndex == cIdx)
                {
                    chkall.Checked = true;
                    foreach (DataGridViewRow row in dgv.Rows)
                        if (row.Cells[cIdx].Value.Equals(false))
                        {
                            chkall.Checked = false;
                            break;
                        }
                }
                if(e.ColumnIndex == cIdx)
                    cellContentClickExt?.Invoke(o, e);
            };
            chkall.Click += (o, e) => 
            {
                CheckBox chk = o as CheckBox;
                for (int rIdx = 0; rIdx < dgv.RowCount; rIdx++)
                    dgv[cIdx, rIdx].Value = chk.Checked;
                dgv.RefreshEdit();
                chkall_ClickExt?.Invoke(o, e);
            };
            return chkall;
        }
    }
    delegate void dlgShowHideDataGridViewRows(DataGridView dgv, Dictionary<string, object> columnValuesForHidding, bool isShown);
    public void ShowHideDataGridViewRows(DataGridView dgv, Dictionary<string, object> columnValuesForHidding, bool isShown)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgShowHideDataGridViewRows(ShowHideDataGridViewRows), dgv, columnValuesForHidding, isShown);
        else
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (columnValuesForHidding.All(ite => row.Cells[ite.Key].Value.Equals(ite.Value)))
                    row.Visible = isShown;
            }
            dgv.RefreshEdit();
        }
    }
    delegate void dlgShowHideDataGridViewRows_MultiValues(DataGridView dgv, List<Dictionary<string, object>> columnValuesForHiddings, bool isShown);
    public void ShowHideDataGridViewRows_MultiValues(DataGridView dgv, List<Dictionary<string, object>> columnValuesForHiddings, bool isShown)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgShowHideDataGridViewRows_MultiValues(ShowHideDataGridViewRows_MultiValues), dgv, columnValuesForHiddings, isShown);
        else
        {
            foreach (Dictionary<string, object> columnValuesForHidding in columnValuesForHiddings)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (columnValuesForHidding.All(ite => row.Cells[ite.Key].Value.Equals(ite.Value)))
                        row.Visible = isShown;
                }
            }            
            dgv.RefreshEdit();
        }
    }
    delegate void dlgShowHideAllDataGridViewRows(DataGridView dgv, bool isShown);
    public void ShowHideDataAllGridViewRows(DataGridView dgv, bool isShown)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgShowHideAllDataGridViewRows(ShowHideDataAllGridViewRows), dgv, isShown);
        else
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Visible = isShown;
            }
            dgv.RefreshEdit();
        }
    }
    delegate void dlgSetDataGridViewCheckedRows(DataGridView dgv, string checkColumn, bool isChecked);
    public void SetDataGridViewCheckedRows(DataGridView dgv, string checkColumn, bool isChecked)
    {
        if (dgv.InvokeRequired) dgv.Invoke(new dlgSetDataGridViewCheckedRows(SetDataGridViewCheckedRows), dgv, checkColumn, isChecked);
        else
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Visible) row.Cells[checkColumn].Value = isChecked;
            }
            dgv.RefreshEdit();
        }
    }
    #endregion

    #region PictureBox
    delegate void dlgSetPictureBoxImageFromBinary(PictureBox pic, byte[] input);
    public void SetPictureBoxImageFromBinary(PictureBox pic, byte[] input)
    {
        if (pic.InvokeRequired) pic.Invoke(new dlgSetPictureBoxImageFromBinary(SetPictureBoxImageFromBinary), pic, input);
        else
        {
            pic.Image = Bitmap.FromStream(new System.IO.MemoryStream(input));
            pic.Refresh();
        }
    }
    delegate void dlgSetPictureBoxImageFromImage(PictureBox pic, Image input);
    public void SetPictureBoxImageFromImage(PictureBox pic, Image input)
    {
        if (pic.InvokeRequired) pic.Invoke(new dlgSetPictureBoxImageFromImage(SetPictureBoxImageFromImage), pic, input);
        else
        {
            pic.Image = input;
            pic.Refresh();
        }
    }
    delegate void dlgSetPictureBoxImageFromFile(PictureBox pic, string imageUrl);
    public void SetPictureBoxImageFromFile(PictureBox pic, string imageUrl)
    {
        if (pic.InvokeRequired) pic.Invoke(new dlgSetPictureBoxImageFromFile(SetPictureBoxImageFromFile), pic, imageUrl);
        else
        {
            pic.Image = Bitmap.FromFile(imageUrl);
            pic.Refresh();
        }
    }
    #endregion

    #region TreeView
    delegate void dlgAddTreeViewNodes(TreeView tv, params TreeNode[] nodes);
    public void AddTreeViewNodes(TreeView tv, params TreeNode[] nodes)
    {
        if (tv.InvokeRequired) tv.Invoke(new dlgAddTreeViewNodes(AddTreeViewNodes), tv, nodes);
        else
        {
            tv.Nodes.AddRange(nodes);
        }
    }
    #endregion

    #region TabControl
    delegate void dlgRemoveTabControlTabPage(TabControl tc, TabPage tp);
    public void RemoveTabControlTabPage(TabControl tc, TabPage tp)
    {
        if (tc.InvokeRequired) tc.Invoke(new dlgRemoveTabControlTabPage(RemoveTabControlTabPage), tc, tp);
        else
            tc.TabPages.Remove(tp);
    }
    #endregion

    #region ProgressBar
    delegate void dlgSetProgressBarValue(ProgressBar pgb, int value);
    public void SetProgressBarValue(ProgressBar pgb, int value)
    {
        if (pgb.InvokeRequired) pgb.Invoke(new dlgSetProgressBarValue(SetProgressBarValue), pgb, value);
        else pgb.Value = value;
    }
    delegate void dlgSetProgressBarMaximum(ProgressBar pgb, int value);
    public void SetProgressBarMaximum(ProgressBar pgb, int value)
    {
        if (pgb.InvokeRequired) pgb.Invoke(new dlgSetProgressBarMaximum(SetProgressBarMaximum), pgb, value);
        else pgb.Maximum = value;
    }
    #endregion

    delegate void dlgAppendText(RichTextBox rtxt, string text);
    public void AppendText(RichTextBox rtxt, string text = "")
    {
        if (rtxt.InvokeRequired) rtxt.Invoke(new dlgAppendText(AppendText), rtxt, text);
        else
        {
            rtxt.AppendText(Environment.NewLine + text);
            rtxt.ScrollToCaret();
        }
    }
}

