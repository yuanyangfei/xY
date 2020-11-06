/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/

namespace NFine.Code
{
    public class AjaxResult
    {
        public object state { get; set; }
     
        public string message { get; set; }
     
        public object data { get; set; }
    }
   
    public enum ResultType
    {
        info,
        success,
        warning,
        error
    }
}
