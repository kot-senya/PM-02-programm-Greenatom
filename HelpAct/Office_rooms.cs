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
    
    public partial class Office_rooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Office_rooms()
        {
            this.Workplace = new HashSet<Workplace>();
        }
    
        public int ID_office_room { get; set; }
        public string Cabinet_office { get; set; }
        public Nullable<int> ID_office { get; set; }
    
        public virtual Offices Offices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workplace> Workplace { get; set; }
    }
}
