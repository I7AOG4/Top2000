namespace Top2000.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblArtist")]
    public partial class tblArtist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblArtist()
        {
            tblSongs = new HashSet<tblSongs>();
        }

        [Key]
        public int ArtistID { get; set; }

        [Required]
        [StringLength(255)]
        public string ArtistName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSongs> tblSongs { get; set; }
    }
}
