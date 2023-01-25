using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace work.mvc.Models
{
    public class TimeZonesDetailsModel
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public string Type { get; set; }
        public int OffDay { get; set; }
        //public int StartDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        public bool One { get; set; }
        public bool Two { get; set; }
        public bool Three { get; set; }
        public bool Four { get; set; }
        public bool Five { get; set; }
        public bool Six { get; set; }
        public bool Seven { get; set; }
        public bool Eight { get; set; }
        public bool Nine { get; set; }
        public bool Ten { get; set; }
        public bool Eleven { get; set; }
        public bool Twelve { get; set; }
        public bool Thirteen { get; set; }
        public bool Fourteen { get; set; }
        public bool Fifteen { get; set; }
        public bool Sixteen { get; set; }
        public bool Seventeen { get; set; }
        public bool Eighteen { get; set; }
        public bool Nineteen { get; set; }
        public bool Twenty { get; set; }
        public bool TwentyOne { get; set; }
        public bool TwentyTwo { get; set; }
        public bool TwentyThree { get; set; }
        public bool TwentyFour { get; set; }
        public bool TwentyFive { get; set; }
        public bool TwentySix { get; set; }
        public bool TwentySeven { get; set; }
        public bool TwentyEight { get; set; }
        public bool TwentyNine { get; set; }
        public bool Thirty { get; set; }
        public bool ThirtyOne { get; set; }
    }
}
