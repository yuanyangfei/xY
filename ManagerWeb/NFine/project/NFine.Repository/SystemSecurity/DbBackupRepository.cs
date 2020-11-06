/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
using NFine.Code;
using NFine.Data;
using NFine.Data.Extensions;
using NFine.Domain.Entity.SystemSecurity;
using NFine.Domain.IRepository.SystemSecurity;
using NFine.Repository.SystemSecurity;

namespace NFine.Repository.SystemSecurity
{
    public class DbBackupRepository : RepositoryBase<DbBackupEntity>, IDbBackupRepository
    {
        public void DeleteForm(string keyValue)
        {
           
        }
        public void ExecuteDbBackup(DbBackupEntity dbBackupEntity)
        {
        }
    }
}
