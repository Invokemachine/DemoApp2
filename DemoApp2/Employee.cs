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
    
    public partial class Employee
    {
        public Employee()
        {
            this.EmployeeMovement = new HashSet<EmployeeMovement>();
            this.Master = new HashSet<Master>();
        }
    
        public int EmployeeId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime Birthday { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string BankInformation { get; set; }
        public int PositionId { get; set; }
    
        public virtual Position Position { get; set; }
        public virtual ICollection<EmployeeMovement> EmployeeMovement { get; set; }
        public virtual ICollection<Master> Master { get; set; }
    }
}
