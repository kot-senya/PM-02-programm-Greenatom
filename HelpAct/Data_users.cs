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
    
    public partial class Data_users
    {
        public int id_data_user { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<int> ID_user { get; set; }
        public Nullable<int> ID_role_user { get; set; }
    
        public virtual Roles Roles { get; set; }
        public virtual Users Users { get; set; }
    }
}
