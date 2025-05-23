//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace grid
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Agent_PontOfSales = new HashSet<Agent_PontOfSales>();
            this.Card = new HashSet<Card>();
            this.Employee_Bank = new HashSet<Employee_Bank>();
            this.Employee_Equipment = new HashSet<Employee_Equipment>();
            this.HistoryAgentSales = new HashSet<HistoryAgentSales>();
            this.Inventory = new HashSet<Inventory>();
            this.Request = new HashSet<Request>();
            this.Request1 = new HashSet<Request>();
            this.SupplyMaterial = new HashSet<SupplyMaterial>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdEmployee { get; set; }
        public Nullable<int> IdAgentType { get; set; }
        public Nullable<int> IdCompanyAgent { get; set; }
        public string JurAddressAgent { get; set; }
        public string InnAgent { get; set; }
        public string KppAgent { get; set; }
        public string DirectorsFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LogoAgent { get; set; }
        public Nullable<int> IdPriorityAgent { get; set; }
        public Nullable<bool> IsNewAgent { get; set; }
        public Nullable<int> IdPassport { get; set; }
        public Nullable<bool> IsMaried { get; set; }
        public Nullable<bool> IsDesabled { get; set; }
        public Nullable<int> CountChildren { get; set; }
        public Nullable<int> UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agent_PontOfSales> Agent_PontOfSales { get; set; }
        public virtual AgentType AgentType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Card> Card { get; set; }
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Bank> Employee_Bank { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Equipment> Employee_Equipment { get; set; }
        public virtual Passport Passport { get; set; }
        public virtual PriorityType PriorityType { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryAgentSales> HistoryAgentSales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory> Inventory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Request { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Request1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplyMaterial> SupplyMaterial { get; set; }
    }
}
