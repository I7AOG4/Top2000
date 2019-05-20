namespace Top2000.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblSongs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSongs()
        {
            tblRanking = new HashSet<tblRanking>();
        }

        [Key]
        public int SongID { get; set; }

        public int? ArtistID { get; set; }

        [StringLength(255)]
        public string SongName { get; set; }

        public int? SongYear { get; set; }

        public virtual tblArtist tblArtist { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRanking> tblRanking { get; set; }
    }
}
