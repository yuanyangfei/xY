/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
using System;

namespace NFine.Domain
{
    public interface IDeleteAudited 
    {
        bool? F_DeleteMark { get; set; }
        
        string F_DeleteUserId { get; set; }
        
        DateTime? F_DeleteTime { get; set; } 
    }
}