//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Musteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteriler()
        {
            this.Satislar = new HashSet<Satislar>();
        }
    
        public int MusteriID { get; set; }

        [Required(ErrorMessage = "M��teri Ad� Bo� B�rak�lamaz!")]
        [StringLength(50, ErrorMessage = "M��teri Ad� En Fazla 50 Karakter Olabilir!")]
        public string MusteriAd { get; set; }

        [Required(ErrorMessage = "M��teri Soyad� Bo� B�rak�lamaz!")]
        [StringLength(50, ErrorMessage = "M��teri Soyad� En Fazla 50 Karakter Olabilir!")]
        public string MusteriSoyad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satislar> Satislar { get; set; }
    }
}
