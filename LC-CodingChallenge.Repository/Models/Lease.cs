using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions;

namespace LC_CodingChallenge.Repository.Models
{
    public class Lease
    {
        private decimal _paymentAmount;
        private string _name;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _numberOfPayments;
        private double _interestRate;
        private int _rowNumber;

        public int RowNumber { get => _rowNumber; set => _rowNumber = value; }
        public string Name { get => _name; set => _name = value; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get => _startDate; set { _startDate = value; } }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public decimal PaymentAmount { get => _paymentAmount; set => _paymentAmount = value; }
        public int NumberOfPayments { get => _numberOfPayments; set => _numberOfPayments = value; }
        public double InterestRate { get => _interestRate; set => _interestRate = value; }
        public double InterestRatePct { get => (_interestRate * 100).Truncate(); }

    }
    public sealed class LeaseMap : ClassMap<Lease>
    {
        public LeaseMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.StartDate).Name("Start Date");
            Map(m => m.EndDate).Name("End Date");
            Map(m => m.PaymentAmount).Name("Payment Amount");
            Map(m => m.NumberOfPayments).Name("Number of Payments");
            Map(m => m.InterestRate).Name("Interest Rate");
        }
    }
}
