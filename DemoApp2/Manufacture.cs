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
    
    public partial class Manufacture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manufacture()
        {
            this.ManufactureMaterial = new HashSet<ManufactureMaterial>();
        }
    
        public int ManufactureId { get; set; }
        public int ProductId { get; set; }
        public int WorkshopId { get; set; }
        public int PeopleRequired { get; set; }
        public System.TimeSpan TimeRequired { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Workshop Workshop { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureMaterial> ManufactureMaterial { get; set; }
    }
}
