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
    
    public partial class Status_application
    {
        public int ID_status_application { get; set; }
        public Nullable<System.DateTime> Modified_date { get; set; }
        public string Comment { get; set; }
        public Nullable<int> ID_application { get; set; }
        public Nullable<int> ID_user { get; set; }
        public Nullable<int> ID_error { get; set; }
    
        public virtual Applications Applications { get; set; }
        public virtual Error_state Error_state { get; set; }
        public virtual Users Users { get; set; }
    }
}
