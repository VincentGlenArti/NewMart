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
    
    public partial class Discount
    {
        public int ID { get; set; }
        public string DiscountUnit { get; set; }
        public string DiscountVal { get; set; }
        public int ProductID { get; set; }
    
        public virtual Product Product { get; set; }
    }
}