//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationPwsz.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class users
    {
        public int id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public Nullable<int> wiek { get; set; }
        public string miejscowosc { get; set; }
        public Nullable<bool> plec { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public Nullable<System.DateTime> data_urodzenia { get; set; }
        public Nullable<bool> login_flag { get; set; }
    }
}
