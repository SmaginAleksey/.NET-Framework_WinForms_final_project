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
    
    public partial class PBX
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PBX()
        {
            this.History = new HashSet<History>();
            this.Subscribers = new HashSet<Subscribers>();
        }
    
        public int Id { get; set; }
        public int PBXModelId { get; set; }
        public int RailroadStationId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> History { get; set; }
        public virtual PBXModels PBXModels { get; set; }
        public virtual RailroadStations RailroadStations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subscribers> Subscribers { get; set; }
    }
}
