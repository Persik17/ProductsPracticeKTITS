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
    
    public partial class Request_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request_Product()
        {
            this.HistoryAgentSales = new HashSet<HistoryAgentSales>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdRequest { get; set; }
        public Nullable<int> IdProduct { get; set; }
        public Nullable<int> Count { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryAgentSales> HistoryAgentSales { get; set; }
        public virtual Product Product { get; set; }
        public virtual Request Request { get; set; }
    }
}
