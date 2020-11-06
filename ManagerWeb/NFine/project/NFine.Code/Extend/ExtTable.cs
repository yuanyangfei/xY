/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
using System.Data;

namespace NFine.Code
{
    public static class ExtTable
    {
        public static DataTable GetPage(this DataTable data, int pageIndex, int pageSize, out int allPage)
        {
            allPage = data.Rows.Count / pageSize;
            allPage += data.Rows.Count % pageSize == 0 ? 0 : 1;
            DataTable Ntable = data.Clone();
            int startIndex = pageIndex * pageSize;
            int endIndex = startIndex + pageSize > data.Rows.Count ? data.Rows.Count : startIndex + pageSize;
            if (startIndex < endIndex)
                for (int i = startIndex; i < endIndex; i++)
                {
                    Ntable.ImportRow(data.Rows[i]);
                }
            return Ntable;
        }
        public static DataTable GetDataFilter(DataTable data, string condition)
        {
            if (data != null && data.Rows.Count > 0)
            {
                if (condition.Trim() == "")
                {
                    return data;
                }
                else
                {
                    DataTable newdt = new DataTable();
                    newdt = data.Clone();
                    DataRow[] dr = data.Select(condition);
                    for (int i = 0; i < dr.Length; i++)
                    {
                        newdt.ImportRow((DataRow)dr[i]);
                    }
                    return newdt;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
