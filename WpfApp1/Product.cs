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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.CreateProducts = new HashSet<CreateProduct>();
            this.ProductionProducts = new HashSet<ProductionProduct>();
            this.ZakazProducts = new HashSet<ZakazProduct>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public Nullable<int> IDTypeProduct { get; set; }
        public Nullable<double> Sebestoim { get; set; }
        public string Image { get; set; }
        public Nullable<double> MinPricePartner { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string WeightUpakov { get; set; }
        public string Sertificate { get; set; }
        public string NumberStandart { get; set; }
        public string TimeIzgotov { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreateProduct> CreateProducts { get; set; }
        public virtual TypeProduct TypeProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductionProduct> ProductionProducts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZakazProduct> ZakazProducts { get; set; }
    }
}
