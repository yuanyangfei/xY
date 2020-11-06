/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Application.SystemManage
{
    public class OrganizeApp
    {
        private IOrganizeRepository service = new OrganizeRepository();

        public List<OrganizeEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.F_CreatorTime).ToList();
        }
        public OrganizeEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.F_ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("");
            }
            else
            {
                service.Delete(t => t.F_Id == keyValue);
            }
        }
        public void SubmitForm(OrganizeEntity organizeEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                organizeEntity.Modify(keyValue);
                service.Update(organizeEntity);
            }
            else
            {
                organizeEntity.Create();
                service.Insert(organizeEntity);
            }
        }
    }
}
