//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace oTicket
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Offer
    {
        [Key]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdDoctors { get; set; }
        public int IdDays { get; set; }
        public int IdTime { get; set; }
    
        public virtual Authorization Authorization { get; set; }
        public virtual Days Days { get; set; }
        public virtual Doctors Doctors { get; set; }
        public virtual Times Times { get; set; }
    }
}