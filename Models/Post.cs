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
    
    public partial class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public string content { get; set; }
        public Nullable<int> parent { get; set; }
        public Nullable<int> likes { get; set; }
        public Nullable<int> commentCount { get; set; }
        public Nullable<int> commentId { get; set; }
        public Nullable<int> imageId { get; set; }
    
        public virtual Comments Comments { get; set; }
    }
}
