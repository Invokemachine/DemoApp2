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
    
    public partial class Workshop
    {
        public Workshop()
        {
            this.Manufacture = new HashSet<Manufacture>();
        }
    
        public int WorkshopId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Manufacture> Manufacture { get; set; }
    }
}
