//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Seafplus.BusinessLogic.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Board
    {
        public Board()
        {
            this.Lists = new HashSet<List>();
            this.UserBoards = new HashSet<UserBoard>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> OrganizationId { get; set; }
    
        public virtual ICollection<List> Lists { get; set; }
        public virtual ICollection<UserBoard> UserBoards { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
