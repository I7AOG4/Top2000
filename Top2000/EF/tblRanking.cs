namespace Top2000.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRanking")]
    public partial class tblRanking
    {
        [Key]
        public int RankingID { get; set; }

        public int? SongID { get; set; }

        public int? RankingPosition { get; set; }

        public int? RankingYear { get; set; }

        public virtual tblSongs tblSongs { get; set; }
    }
}
