//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEB_MVC4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location
    {
        public Location()
        {
            this.Stock = new HashSet<Stock>();
            this.Order = new HashSet<Order>();
        }
    
        public short ID { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    
        public virtual ICollection<Stock> Stock { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}