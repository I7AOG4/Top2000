namespace Top2000.EF
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class EFContext : DbContext
	{
		public EFContext()
			: base("name=EFContext")
		{
		}

		public virtual DbSet<tblArtist> tblArtist { get; set; }
		public virtual DbSet<tblRanking> tblRanking { get; set; }
		public virtual DbSet<tblSongs> tblSongs { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
