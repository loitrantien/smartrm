namespace SmartRmApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SmartRmDBModel : DbContext
    {
        public SmartRmDBModel()
            : base("name=SmartRmDBModel")
        {
        }

        public virtual DbSet<tbl_deviceRegistration> tbl_deviceRegistration { get; set; }
        public virtual DbSet<tbl_dishes> tbl_dishes { get; set; }
        public virtual DbSet<tbl_dishesType> tbl_dishesType { get; set; }
        public virtual DbSet<tbl_floor> tbl_floor { get; set; }
        public virtual DbSet<tbl_invoice> tbl_invoice { get; set; }
        public virtual DbSet<tbl_invoiceDetail> tbl_invoiceDetail { get; set; }
        public virtual DbSet<tbl_menu> tbl_menu { get; set; }
        public virtual DbSet<tbl_menuType> tbl_menuType { get; set; }
        public virtual DbSet<tbl_order> tbl_order { get; set; }
        public virtual DbSet<tbl_orderDetail> tbl_orderDetail { get; set; }
        public virtual DbSet<tbl_table> tbl_table { get; set; }
        public virtual DbSet<tbl_tableType> tbl_tableType { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_deviceRegistration>()
                .Property(e => e.device_name)
                .IsFixedLength();

            modelBuilder.Entity<tbl_dishes>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dishes>()
                .Property(e => e.unit)
                .IsFixedLength();

            modelBuilder.Entity<tbl_dishes>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_dishes>()
                .HasMany(e => e.tbl_menu)
                .WithRequired(e => e.tbl_dishes)
                .HasForeignKey(e => e.dishes_id);

            modelBuilder.Entity<tbl_dishesType>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_dishesType>()
                .HasMany(e => e.tbl_dishes)
                .WithRequired(e => e.tbl_dishesType)
                .HasForeignKey(e => e.type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_floor>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_floor>()
                .HasMany(e => e.tbl_table)
                .WithRequired(e => e.tbl_floor)
                .HasForeignKey(e => e.floor_id);

            modelBuilder.Entity<tbl_invoice>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_invoice>()
                .Property(e => e.total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_invoice>()
                .HasMany(e => e.tbl_invoiceDetail)
                .WithRequired(e => e.tbl_invoice)
                .HasForeignKey(e => e.invoice_id);

            modelBuilder.Entity<tbl_invoiceDetail>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_menuType>()
                .HasMany(e => e.tbl_menu)
                .WithRequired(e => e.tbl_menuType)
                .HasForeignKey(e => e.type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_order>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_order>()
                .Property(e => e.total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_order>()
                .HasMany(e => e.tbl_orderDetail)
                .WithRequired(e => e.tbl_order)
                .HasForeignKey(e => e.order_id);

            modelBuilder.Entity<tbl_orderDetail>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_table>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_table>()
                .HasMany(e => e.tbl_invoice)
                .WithOptional(e => e.tbl_table)
                .HasForeignKey(e => e.table_id);

            modelBuilder.Entity<tbl_table>()
                .HasMany(e => e.tbl_order)
                .WithRequired(e => e.tbl_table)
                .HasForeignKey(e => e.table_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_tableType>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_tableType>()
                .HasMany(e => e.tbl_table)
                .WithRequired(e => e.tbl_tableType)
                .HasForeignKey(e => e.type_id);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_invoice)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.user_id);
        }
    }
}
