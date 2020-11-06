/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/

namespace NFine.Code
{
  
    public class Pagination
    {
        public int rows { get; set; }
     
        public int page { get; set; }
    
        public string sidx { get; set; }
     
        public string sord { get; set; }
      
        public int records { get; set; }
      
        public int total
        {
            get
            {
                if (records > 0)
                {
                    return records % this.rows == 0 ? records / this.rows : records / this.rows + 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
