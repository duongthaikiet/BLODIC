//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DuongThaiKiet.DTKEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdminGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdminGroup()
        {
            this.AdminUserGroups = new HashSet<AdminUserGroup>();
        }
    
        public int Id { get; set; }
        public string GroupName { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsChildUserActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdminUserGroup> AdminUserGroups { get; set; }
    }
}
