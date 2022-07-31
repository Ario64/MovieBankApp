//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieBankApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movies()
        {
            this.MovieGenres = new HashSet<MovieGenres>();
        }
    
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public string Title { get; set; }
        public string TagLine { get; set; }
        public int Year { get; set; }
        public double ImdbRate { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public string Cast { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Directors Directors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieGenres> MovieGenres { get; set; }
    }
}