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
    
    public partial class Workplace_software
    {
        public int ID_workplace_software { get; set; }
        public Nullable<int> ID_workplace { get; set; }
        public Nullable<int> ID_software { get; set; }
    
        public virtual Software Software { get; set; }
        public virtual Workplace Workplace { get; set; }
    }
}
