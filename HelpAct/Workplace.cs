//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpAct
{
    using System;
    using System.Collections.Generic;
    
    public partial class Workplace
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Workplace()
        {
            this.Workplace_software = new HashSet<Workplace_software>();
            this.Workplace_equipment = new HashSet<Workplace_equipment>();
        }
    
        public int ID_workplace { get; set; }
        public string Number_workplace { get; set; }
        public Nullable<int> ID_user { get; set; }
        public Nullable<int> ID_office_room { get; set; }
    
        public virtual Office_rooms Office_rooms { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workplace_software> Workplace_software { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workplace_equipment> Workplace_equipment { get; set; }
    }
}
