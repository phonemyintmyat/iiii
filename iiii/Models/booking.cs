//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iiii.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class booking
    {
        public Nullable<int> RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public System.Guid BookingID { get; set; }
        public string username { get; set; }
        public string useremail { get; set; }
        public int userphone { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime Dayselect { get; set; }
        [DataType(DataType.Time)]
        public System.TimeSpan selecttime { get; set; }
    
        public virtual restaurant restaurant { get; set; }
    }
}
