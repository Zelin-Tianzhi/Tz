using Tz.Data.Repository;
using Tz.Domain.Entity.SystemSecurity;

namespace Tz.Domain.IRepository.SystemSecurity
{
    public interface IDbBackupRepository : IRepositoryBase<DbBackupEntity>
    {
        void DeleteForm(string keyValue);
        void ExecuteDbBackup(DbBackupEntity dbBackupEntity);
    }
}