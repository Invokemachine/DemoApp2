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
    
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.ManufactureMaterial = new HashSet<ManufactureMaterial>();
            this.MaterialHistory = new HashSet<MaterialHistory>();
        }
    
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public int MaterialTypeId { get; set; }
        public int SupplierId { get; set; }
        public int QuantityInPackage { get; set; }
        public int UnitTypeId { get; set; }
        public int QuantityInStock { get; set; }
        public double MinCost { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public double Cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufactureMaterial> ManufactureMaterial { get; set; }
        public virtual MaterialType MaterialType { get; set; }
        public virtual UnitType UnitType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialHistory> MaterialHistory { get; set; }
    }
}
