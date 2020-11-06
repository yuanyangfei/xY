/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
using System.Collections;
using System.Collections.Generic;

namespace NFine.Code.Extend
{
    public static class ExtList
    {
        public static List<T> GetPage<T>(this List<T> data, int pageIndex, int pageSize, out int allPage)
        {
            allPage = 1;
            return null;
        }
        public static List<T> IListToList<T>(IList list)
        {
            T[] array = new T[list.Count];
            list.CopyTo(array, 0);
            return new List<T>(array);
        }
    }
}
