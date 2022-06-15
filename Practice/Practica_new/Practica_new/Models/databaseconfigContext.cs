using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Practica_new.Models
{
    public partial class databaseconfigContext : DbContext
    {
        public databaseconfigContext()
        {
        }

        public databaseconfigContext(DbContextOptions<databaseconfigContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Build> Builds { get; set; }
        public virtual DbSet<Carcass> Carcasses { get; set; }
        public virtual DbSet<Cpu> Cpus { get; set; }
        public virtual DbSet<Cpucool> Cpucools { get; set; }
        public virtual DbSet<Disk> Disks { get; set; }
        public virtual DbSet<Gpu> Gpus { get; set; }
        public virtual DbSet<Hdd> Hdds { get; set; }
        public virtual DbSet<Motherboard> Motherboards { get; set; }
        public virtual DbSet<O> Os { get; set; }
        public virtual DbSet<Psu> Psus { get; set; }
        public virtual DbSet<Ram> Rams { get; set; }
        public virtual DbSet<SaveBuild> SaveBuilds { get; set; }
        public virtual DbSet<SpravAmount> SpravAmounts { get; set; }
        public virtual DbSet<SpravRam> SpravRams { get; set; }
        public virtual DbSet<SpravRamModul> SpravRamModuls { get; set; }
        public virtual DbSet<Ssd> Ssds { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=databaseconfig;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Build>(entity =>
            {
                entity.HasKey(e => e.IdBuild);

                entity.ToTable("Build");

                entity.Property(e => e.IdBuild)
                    .ValueGeneratedNever()
                    .HasColumnName("id_build");

                entity.Property(e => e.IdCarcass).HasColumnName("id_carcass");

                entity.Property(e => e.IdCpu).HasColumnName("id_CPU");

                entity.Property(e => e.IdCpucool).HasColumnName("id_CPUcool");

                entity.Property(e => e.IdDisk).HasColumnName("id_Disk");

                entity.Property(e => e.IdGpu).HasColumnName("id_GPU");

                entity.Property(e => e.IdMotherboard).HasColumnName("id_motherboard");

                entity.Property(e => e.IdOs).HasColumnName("id_OS");

                entity.Property(e => e.IdPsu).HasColumnName("id_PSU");

                entity.Property(e => e.IdRam).HasColumnName("id_RAM");

                entity.HasOne(d => d.IdCarcassNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdCarcass)
                    .HasConstraintName("FK_Build_Carcass");

                entity.HasOne(d => d.IdCpuNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdCpu)
                    .HasConstraintName("FK_Build_CPU");

                entity.HasOne(d => d.IdCpucoolNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdCpucool)
                    .HasConstraintName("FK_Build_CPUcool");

                entity.HasOne(d => d.IdDiskNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdDisk)
                    .HasConstraintName("FK_Build_Disk");

                entity.HasOne(d => d.IdGpuNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdGpu)
                    .HasConstraintName("FK_Build_GPU");

                entity.HasOne(d => d.IdMotherboardNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdMotherboard)
                    .HasConstraintName("FK_Build_Motherboard");

                entity.HasOne(d => d.IdOsNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdOs)
                    .HasConstraintName("FK_Build_OS");

                entity.HasOne(d => d.IdPsuNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdPsu)
                    .HasConstraintName("FK_Build_PSU");

                entity.HasOne(d => d.IdRamNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdRam)
                    .HasConstraintName("FK_Build_RAM");
            });

            modelBuilder.Entity<Carcass>(entity =>
            {
                entity.HasKey(e => e.IdCarcass);

                entity.ToTable("Carcass");

                entity.Property(e => e.IdCarcass).HasColumnName("id_carcass");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.MotherboardFormFactor)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("motherboard_form_factor");

                entity.Property(e => e.NameCarcass)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Name_carcass");

                entity.Property(e => e.NumberAudioOutputs).HasColumnName("Number_audio_outputs");

                entity.Property(e => e.NumberUsbOutputs).HasColumnName("Number_USB_outputs");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Cpu>(entity =>
            {
                entity.HasKey(e => e.IdCpu);

                entity.ToTable("CPU");

                entity.Property(e => e.IdCpu).HasColumnName("id_CPU");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CountCore)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Count_core");

                entity.Property(e => e.EnergyConsumptionCpu).HasColumnName("Energy_Consumption_CPU");

                entity.Property(e => e.NameCpu)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Name_Cpu");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SeriesCpu)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Series_CPU");

                entity.Property(e => e.Soket)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Tdp).HasColumnName("TDP");
            });

            modelBuilder.Entity<Cpucool>(entity =>
            {
                entity.HasKey(e => e.IdCpucool);

                entity.ToTable("CPUcool");

                entity.Property(e => e.IdCpucool).HasColumnName("id_CPUcool");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CompatibleSockets)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Compatible_sockets");

                entity.Property(e => e.NameCpucool)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Name_CPUcool");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Tdp).HasColumnName("TDP");
            });

            modelBuilder.Entity<Disk>(entity =>
            {
                entity.HasKey(e => e.IdDisk)
                    .HasName("PK_Disk1");

                entity.ToTable("Disk");

                entity.Property(e => e.IdDisk).HasColumnName("id_Disk");

                entity.Property(e => e.IdHdd).HasColumnName("id_HDD");

                entity.Property(e => e.IdSsd).HasColumnName("id_SSD");

                entity.HasOne(d => d.IdHddNavigation)
                    .WithMany(p => p.Disks)
                    .HasForeignKey(d => d.IdHdd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disk_HDD");

                entity.HasOne(d => d.IdSsdNavigation)
                    .WithMany(p => p.Disks)
                    .HasForeignKey(d => d.IdSsd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Disk_SSD");
            });

            modelBuilder.Entity<Gpu>(entity =>
            {
                entity.HasKey(e => e.IdGpu);

                entity.ToTable("GPU");

                entity.Property(e => e.IdGpu).HasColumnName("id_GPU");

                entity.Property(e => e.AmountMemory)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Amount_memory");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.EnergyConsumptionGpu).HasColumnName("Energy_Consumption_GPU");

                entity.Property(e => e.GraphicsProc)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Graphics_proc");

                entity.Property(e => e.NameGpu)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Name_Gpu");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TypeMemory)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Type_memory");
            });

            modelBuilder.Entity<Hdd>(entity =>
            {
                entity.HasKey(e => e.IdHdd);

                entity.ToTable("HDD");

                entity.Property(e => e.IdHdd).HasColumnName("id_HDD");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.NameHdd)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Name_HDD");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SizeMemoryHdd)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Size_memory_HDD")
                    .IsFixedLength(true);

                entity.Property(e => e.SpeedDisk).HasColumnName("Speed_disk");
            });

            modelBuilder.Entity<Motherboard>(entity =>
            {
                entity.HasKey(e => e.IdMotherboard);

                entity.ToTable("Motherboard");

                entity.Property(e => e.IdMotherboard).HasColumnName("id_motherboard");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Chipset)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FormFactor)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Form_factor");

                entity.Property(e => e.NameMotherboard)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Name_motherboard");

                entity.Property(e => e.NumberM2storageSlots).HasColumnName("Number_m2storage_slots");

                entity.Property(e => e.NumberSlotsRam).HasColumnName("Number_slots_RAM");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SocketProcessor)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Socket_processor");
            });

            modelBuilder.Entity<O>(entity =>
            {
                entity.HasKey(e => e.IdOs);

                entity.ToTable("OS");

                entity.Property(e => e.IdOs).HasColumnName("id_OS");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.NameOs)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Name_os");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Psu>(entity =>
            {
                entity.HasKey(e => e.IdPsu);

                entity.ToTable("PSU");

                entity.Property(e => e.IdPsu).HasColumnName("id_PSU");

                entity.Property(e => e.AmountPower).HasColumnName("Amount_power");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Certificate)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.NamePsu)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Name_PSU");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Ram>(entity =>
            {
                entity.HasKey(e => e.IdRam);

                entity.ToTable("RAM");

                entity.Property(e => e.IdRam).HasColumnName("id_RAM");

                entity.Property(e => e.AmountMemoryRam).HasColumnName("Amount_memory_RAM");

                entity.Property(e => e.Brand).IsRequired();

                entity.Property(e => e.NameRam)
                    .IsRequired()
                    .HasColumnName("Name_RAM");

                entity.Property(e => e.NumbersModulesRam).HasColumnName("Numbers_Modules_RAM");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TypeMemoryRam).HasColumnName("Type_Memory_RAM");

                entity.HasOne(d => d.AmountMemoryRamNavigation)
                    .WithMany(p => p.Rams)
                    .HasForeignKey(d => d.AmountMemoryRam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RAM_Sprav_amount");

                entity.HasOne(d => d.NumbersModulesRamNavigation)
                    .WithMany(p => p.Rams)
                    .HasForeignKey(d => d.NumbersModulesRam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RAM_sprav_ram_modul");

                entity.HasOne(d => d.TypeMemoryRamNavigation)
                    .WithMany(p => p.Rams)
                    .HasForeignKey(d => d.TypeMemoryRam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RAM_Sprav_RAM");
            });

            modelBuilder.Entity<SaveBuild>(entity =>
            {
                entity.HasKey(e => e.IdSave);

                entity.ToTable("Save_build");

                entity.Property(e => e.IdSave).HasColumnName("id_save");

                entity.Property(e => e.IdBuild).HasColumnName("id_build");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.IdBuildNavigation)
                    .WithMany(p => p.SaveBuilds)
                    .HasForeignKey(d => d.IdBuild)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Save_build_Build");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SaveBuilds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Save_build_Users");
            });

            modelBuilder.Entity<SpravAmount>(entity =>
            {
                entity.ToTable("Sprav_amount");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AmountMemoryRam).HasColumnName("Amount_memory_RAM");
            });

            modelBuilder.Entity<SpravRam>(entity =>
            {
                entity.ToTable("Sprav_RAM");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.TypeMemoryRam)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Type_memory_RAM");
            });

            modelBuilder.Entity<SpravRamModul>(entity =>
            {
                entity.ToTable("sprav_ram_modul");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.NumbersModulesRam)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Numbers_Modules_RAM");
            });

            modelBuilder.Entity<Ssd>(entity =>
            {
                entity.HasKey(e => e.IdSsd);

                entity.ToTable("SSD");

                entity.Property(e => e.IdSsd).HasColumnName("id_SSD");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.NameSsd)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Name_SSD");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.SizeMemorySsd).HasColumnName("Size_memory_SSD");

                entity.Property(e => e.SpeedRecord).HasColumnName("Speed_record");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
