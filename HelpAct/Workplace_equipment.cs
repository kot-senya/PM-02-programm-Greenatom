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
    
    public partial class Workplace_equipment
    {
        public int ID_workplace_equipment { get; set; }
        public Nullable<int> ID_workplace { get; set; }
        public Nullable<int> ID_equipment { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual Workplace Workplace { get; set; }
    }
}
