//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp1
{
    using System;
    using System.Collections.Generic;
    
    public partial class PartnerAndPostavchik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartnerAndPostavchik()
        {
            this.HistoryPostavs = new HashSet<HistoryPostav>();
            this.Materials = new HashSet<Material>();
            this.PartnerProducts = new HashSet<PartnerProduct>();
            this.Users = new HashSet<User>();
            this.ZakazProducts = new HashSet<ZakazProduct>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> ID_Type { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string YurAdress { get; set; }
        public string INN { get; set; }
        public string Logotipe { get; set; }
        public Nullable<double> Raiting { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryPostav> HistoryPostavs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Material> Materials { get; set; }
        public virtual TypePartner TypePartner { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartnerProduct> PartnerProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZakazProduct> ZakazProducts { get; set; }
    }
}
