//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Master
    {
        public Master()
        {
            this.EquipmentMaster = new HashSet<EquipmentMaster>();
        }
    
        public int MasterId { get; set; }
        public int EmployeeId { get; set; }
        public bool HasFamily { get; set; }
        public string HealthProblems { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ICollection<EquipmentMaster> EquipmentMaster { get; set; }
    }
}