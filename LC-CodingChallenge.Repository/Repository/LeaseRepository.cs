using LC_CodingChallenge.Repository.Interfaces;
using LC_CodingChallenge.Repository.Models;
using LC_CodingChallenge.Repository.SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace LC_CodingChallenge.Repository.Repository
{
    public class LeaseRepository : ILeaseRepository
    {
        public void BulkUpdateCSVFile(DataTable dataTable)
        {
            SQLData sqlData = new SQLData(ConfigurationManager.ConnectionStrings["db"].ToString());
            var Paras = new Dictionary<string, object>();
            Paras.Add(@"LeaseDataTable", dataTable);

            sqlData.ExecuteNonQueryTableValued(@"spBulkUpdateLease", Paras);
        }
        public List<Lease> GetAllleases()
        {
            string connStr = ConfigurationManager.ConnectionStrings["db"].ToString();

            string cmd = @"spGetAllLeases";
            Dictionary<string, object> paras = new Dictionary<string, object>();
            SQLData sqlData = new SQLData(connStr);
            sqlData.IsStoredProcedure = true;
            IEnumerable<Lease> leases = sqlData.GetData<Lease>(cmd, paras, x =>
                new Lease
                {
                    RowNumber = Convert.ToInt32(x["Row"]),
                    Name = x["Name"].ToString(),
                    StartDate = Convert.ToDateTime(x["StartDate"]),
                    EndDate = Convert.ToDateTime(x["EndDate"]),
                    PaymentAmount = Convert.ToDecimal(x["PaymentAmount"]),
                    NumberOfPayments = Convert.ToInt32(x["NumberOfPayment"]),
                    InterestRate = Convert.ToDouble(x["InterestRate"]),
                });
            return leases.ToList();
        }
    }
}
