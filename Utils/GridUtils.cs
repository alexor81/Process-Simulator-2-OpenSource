// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Utils
{
    public static class GridUtils
    {
        public static int[]         saveColumnsWidth(DataGridView aGrid, int[] aPrevWidth)
        {
            if (aGrid.ColumnCount == 0)
            {
                return aPrevWidth;
            }

            int lCount      = aGrid.ColumnCount - 1;
            int[] lResult   = new int[lCount];

            for (int i = 0; i < lCount; i++)
            {
                lResult[i] = aGrid.Columns[i].Width;
            }

            return lResult;
        }

        public static void          restoreColumnsWidth(DataGridView aGrid, int[] aWidth)
        {
            if (aWidth == null)
            {
                return;
            }

            for (int i = 0; i < aWidth.Length; i++)
            {
                aGrid.Columns[i].Width = aWidth[i];
            }
        }

        public static int           findRow(DataGridView aGrid, int lColumn, string aName)
        {
            DataGridViewRow lRow;
            int lCount = aGrid.RowCount;
            for (int i = 0; i < lCount; i++ )
            {
                lRow = aGrid.Rows[i];
                if (lRow.Cells[lColumn].Value.ToString().Equals(aName, StringComparison.Ordinal))
                {
                    return lRow.Index;
                }
            }
            return -1;
        }

        public static StringBuilder correctFilter(string aFilter)
        {
            StringBuilder lResult = new StringBuilder();
            int lStart = 0;
            int i;

            for (i = 0; i < aFilter.Length; i++)
            {
                if (aFilter[i] == '[' || aFilter[i] == ']' || aFilter[i] == '*' || aFilter[i] == '%')
                {
                    lResult.Append(aFilter.Substring(lStart, i - lStart));
                    lStart = i + 1;
                    lResult.Append("[");
                    lResult.Append(aFilter[i]);
                    lResult.Append("]");
                }
            }

            if (lStart != i)
            {
                lResult.Append(aFilter.Substring(lStart, i - lStart));
            }

            return lResult;
        }

        public static void          setGridDataSource(DataGridView aDataGridView, DataTable aDataTable, string aFilter, 
                                                        ref int[] aColumnsWidth, ref DataView aDataView, ref string aSelect)
        {
            List<string> lSelectedItems     = new List<string>();
            int lFirstRowIndex              = 0;
            int lSortedColumnIndex          = 0;
            var lListSortDirection          = ListSortDirection.Ascending;

            if (aDataTable != null && String.IsNullOrWhiteSpace(aSelect) == false)
            {
                lSelectedItems.Add(aSelect);
            }

            if (aDataGridView.DataSource != null)
            {
                #region Row

                    if (aDataTable != null && lSelectedItems.Count == 0 && aDataGridView.SelectedRows.Count != 0)
                    {
                        lFirstRowIndex = aDataGridView.FirstDisplayedScrollingRowIndex;

                        int lCount = aDataGridView.SelectedRows.Count;
                        for (int i = 0; i < lCount; i++)
                        {
                            lSelectedItems.Add(aDataGridView.SelectedRows[i].Cells[0].Value.ToString());
                        }
                    }

                #endregion

                #region Column

                    if (aDataGridView.SortedColumn != null)
                    {
                        lSortedColumnIndex = aDataGridView.SortedColumn.Index;
                        switch (aDataGridView.SortOrder)
                        {
                            case SortOrder.Ascending: lListSortDirection = ListSortDirection.Ascending;
                                break;

                            case SortOrder.Descending: lListSortDirection = ListSortDirection.Descending;
                                break;
                        }
                    }

                    aColumnsWidth = GridUtils.saveColumnsWidth(aDataGridView, aColumnsWidth);

                #endregion

                aDataGridView.DataSource = null;
                aDataView.Dispose();
                aDataView = null;
            }

            if (aDataTable != null)
            {
                aDataView                   = aDataTable.DefaultView;
                aDataView.RowFilter         = aFilter;
                aDataGridView.DataSource    = aDataView;

                #region Column

                    aDataGridView.Sort(aDataGridView.Columns[lSortedColumnIndex], lListSortDirection);

                #endregion

                #region Row

                    if (aDataGridView.RowCount > 0)
                    {
                        if (lFirstRowIndex >= 0 && lFirstRowIndex < aDataGridView.RowCount)
                        {
                            try // Иначе в свёрнутом виде ругается: No room is available to display rows
                            {
                                aDataGridView.FirstDisplayedScrollingRowIndex = lFirstRowIndex;
                            }
                            catch { }
                        }

                        if (aDataGridView.MultiSelect)
                        {
                            aDataGridView.Rows[0].Selected = false;
                        }

                        int lRow;
                        int lCount = lSelectedItems.Count;
                        for (int i = 0; i < lCount; i++)
                        {
                            lRow = findRow(aDataGridView, 0, lSelectedItems[i]);
                            if (lRow != -1)
                            {
                                aDataGridView.Rows[lRow].Selected = true;
                            }
                        }

                        if (aDataGridView.SelectedRows.Count == 1)
                        {
                            int lSelectedRowIndex   = aDataGridView.SelectedRows[0].Index;
                            int lFirst              = aDataGridView.FirstDisplayedScrollingRowIndex;
                            int lRowCount           = aDataGridView.DisplayedRowCount(true);

                            if (lSelectedRowIndex < lFirst || lSelectedRowIndex > lFirst + lRowCount - 1)
                            {
                                try // Иначе в свёрнутом виде ругается: No room is available to display rows
                                {
                                    aDataGridView.FirstDisplayedScrollingRowIndex = lSelectedRowIndex;
                                }
                                catch { }
                            }
                        }
                    }

                    #endregion
            }

            aSelect = "";
        }
    }
}
