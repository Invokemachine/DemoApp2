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
    
    public partial class MaterialHistory
    {
        public MaterialHistory()
        {
            this.Supplier = new HashSet<Supplier>();
        }
    
        public int MaterialHistoryId { get; set; }
        public int MaterialId { get; set; }
        public int OperationTypeId { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual OperationType OperationType { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}