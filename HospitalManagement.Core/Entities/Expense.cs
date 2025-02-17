using HospitalManagement.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class Expense:BaseEntity
    {
        public string? Name {  get; set; }
        public string? Surname {  get; set; }
        public string? Phone {  get; set; }
        public string? Source { get; set; }
        public decimal? Quantity {  get; set; }
        public decimal? Expenses {  get; set; }
        public DateOnly? BuyDate { get; set; }
    }
}
