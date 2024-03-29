//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Курсовая.NET_Framework__WinForms_
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phones()
        {
            this.History = new HashSet<History>();
            this.Subscribers = new HashSet<Subscribers>();
        }
    
        public int Id { get; set; }
        public Nullable<int> PhoneVendorId { get; set; }
        public string Model { get; set; }
        public Nullable<int> PhoneTypeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> History { get; set; }
        public virtual PhoneTypes PhoneTypes { get; set; }
        public virtual PhoneVendors PhoneVendors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscribers> Subscribers { get; set; }
        public override string ToString()
        {
            return this.Model;
        }
    }
}
