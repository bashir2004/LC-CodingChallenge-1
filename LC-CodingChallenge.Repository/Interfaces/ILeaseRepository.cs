using LC_CodingChallenge.Repository.Models;
using System.Collections.Generic;
using System.Data;

namespace LC_CodingChallenge.Repository.Interfaces
{
    public interface ILeaseRepository
    {
        void BulkUpdateCSVFile(DataTable dataTable);
        List<Lease> GetAllleases();
    }
}
