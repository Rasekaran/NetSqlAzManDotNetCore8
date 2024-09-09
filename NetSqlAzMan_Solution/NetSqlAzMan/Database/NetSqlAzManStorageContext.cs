using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NetSqlAzMan.Database
{
    public partial class NetSqlAzManStorageContext : DbContext
    {
        public NetSqlAzManStorageContext()
        {
        }

        public NetSqlAzManStorageContext(DbContextOptions<NetSqlAzManStorageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NetsqlazmanApplicationAttributesTable> NetsqlazmanApplicationAttributesTables { get; set; }

        public virtual DbSet<NetsqlazmanApplicationAttributesView> NetsqlazmanApplicationAttributesViews { get; set; }

        public virtual DbSet<NetsqlazmanApplicationGroupMembersTable> NetsqlazmanApplicationGroupMembersTables { get; set; }

        public virtual DbSet<NetsqlazmanApplicationGroupMembersView> NetsqlazmanApplicationGroupMembersViews { get; set; }

        public virtual DbSet<NetsqlazmanApplicationGroupsTable> NetsqlazmanApplicationGroupsTables { get; set; }

        public virtual DbSet<NetsqlazmanApplicationPermissionsTable> NetsqlazmanApplicationPermissionsTables { get; set; }

        public virtual DbSet<NetsqlazmanApplicationsTable> NetsqlazmanApplicationsTables { get; set; }

        public virtual DbSet<NetsqlazmanApplicationsView> NetsqlazmanApplicationsViews { get; set; }

        public virtual DbSet<NetsqlazmanAuthorizationAttributesTable> NetsqlazmanAuthorizationAttributesTables { get; set; }

        public virtual DbSet<NetsqlazmanAuthorizationAttributesView> NetsqlazmanAuthorizationAttributesViews { get; set; }

        public virtual DbSet<NetsqlazmanAuthorizationView> NetsqlazmanAuthorizationViews { get; set; }

        public virtual DbSet<NetsqlazmanAuthorizationsTable> NetsqlazmanAuthorizationsTables { get; set; }

        public virtual DbSet<NetsqlazmanBizRuleView> NetsqlazmanBizRuleViews { get; set; }

        public virtual DbSet<NetsqlazmanBizRulesTable> NetsqlazmanBizRulesTables { get; set; }

        public virtual DbSet<NetsqlazmanDatabaseUser> NetsqlazmanDatabaseUsers { get; set; }

        public virtual DbSet<NetsqlazmanItemAttributesTable> NetsqlazmanItemAttributesTables { get; set; }

        public virtual DbSet<NetsqlazmanItemAttributesView> NetsqlazmanItemAttributesViews { get; set; }

        public virtual DbSet<NetsqlazmanItemsHierarchyTable> NetsqlazmanItemsHierarchyTables { get; set; }

        public virtual DbSet<NetsqlazmanItemsHierarchyView> NetsqlazmanItemsHierarchyViews { get; set; }

        public virtual DbSet<NetsqlazmanItemsTable> NetsqlazmanItemsTables { get; set; }

        public virtual DbSet<NetsqlazmanLogTable> NetsqlazmanLogTables { get; set; }

        public virtual DbSet<NetsqlazmanSetting> NetsqlazmanSettings { get; set; }

        public virtual DbSet<NetsqlazmanStoreAttributesTable> NetsqlazmanStoreAttributesTables { get; set; }

        public virtual DbSet<NetsqlazmanStoreAttributesView> NetsqlazmanStoreAttributesViews { get; set; }

        public virtual DbSet<NetsqlazmanStoreGroupMembersTable> NetsqlazmanStoreGroupMembersTables { get; set; }

        public virtual DbSet<NetsqlazmanStoreGroupMembersView> NetsqlazmanStoreGroupMembersViews { get; set; }

        public virtual DbSet<NetsqlazmanStoreGroupsTable> NetsqlazmanStoreGroupsTables { get; set; }

        public virtual DbSet<NetsqlazmanStorePermissionsTable> NetsqlazmanStorePermissionsTables { get; set; }

        public virtual DbSet<NetsqlazmanStoresTable> NetsqlazmanStoresTables { get; set; }

        public virtual DbSet<UsersDemo> UsersDemos { get; set; }

        // This is auto generated code. But this config supposed to be picked from the config.
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//            => optionsBuilder.UseSqlServer("Server=localhost;Database=NetSqlAzManStorage;Integrated Security=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NetsqlazmanApplicationAttributesTable>(entity =>
            {
                entity.HasKey(e => e.ApplicationAttributeId).HasName("PK_ApplicationAttributes");

                entity.ToTable("netsqlazman_ApplicationAttributesTable");

                entity.HasIndex(e => new { e.ApplicationId, e.AttributeKey }, "ApplicationAttributes_AuhorizationId_AttributeKey_Unique_Index").IsUnique();

                entity.HasIndex(e => new { e.ApplicationId, e.AttributeKey }, "IX_ApplicationAttributes");

                entity.Property(e => e.AttributeKey).HasMaxLength(255);
                entity.Property(e => e.AttributeValue).HasMaxLength(4000);

                entity.HasOne(d => d.Application).WithMany(p => p.NetsqlazmanApplicationAttributesTables)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_ApplicationAttributes_Applications");
            });

            modelBuilder.Entity<NetsqlazmanApplicationAttributesView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_ApplicationAttributesView");

                entity.Property(e => e.AttributeKey).HasMaxLength(255);
                entity.Property(e => e.AttributeValue).HasMaxLength(4000);
                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<NetsqlazmanApplicationGroupMembersTable>(entity =>
            {
                entity.HasKey(e => e.ApplicationGroupMemberId).HasName("PK_GroupMembers");

                entity.ToTable("netsqlazman_ApplicationGroupMembersTable");

                entity.HasIndex(e => new { e.ApplicationGroupId, e.ObjectSid, e.IsMember }, "ApplicationGroupMembers_ApplicationGroupId_ObjectSid_IsMember_Unique_Index").IsUnique();

                entity.HasIndex(e => new { e.ApplicationGroupId, e.ObjectSid }, "IX_ApplicationGroupMembers");

                entity.Property(e => e.ObjectSid)
                    .HasMaxLength(85)
                    .HasColumnName("objectSid");

                entity.HasOne(d => d.ApplicationGroup).WithMany(p => p.NetsqlazmanApplicationGroupMembersTables)
                    .HasForeignKey(d => d.ApplicationGroupId)
                    .HasConstraintName("FK_ApplicationGroupMembers_ApplicationGroup");
            });

            modelBuilder.Entity<NetsqlazmanApplicationGroupMembersView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_ApplicationGroupMembersView");

                entity.Property(e => e.ApplicationGroup).HasMaxLength(255);
                entity.Property(e => e.MemberType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.ObjectSid)
                    .HasMaxLength(85)
                    .HasColumnName("objectSid");
                entity.Property(e => e.WhereDefined)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NetsqlazmanApplicationGroupsTable>(entity =>
            {
                entity.HasKey(e => e.ApplicationGroupId).HasName("PK_Groups");

                entity.ToTable("netsqlazman_ApplicationGroupsTable", tb => tb.HasTrigger("ApplicationGroupDeleteTrigger"));

                entity.HasIndex(e => new { e.ApplicationId, e.Name }, "ApplicationGroups_ApplicationId_Name_Unique_Index").IsUnique();

                entity.HasIndex(e => new { e.ApplicationId, e.Name }, "IX_ApplicationGroups");

                entity.HasIndex(e => e.ObjectSid, "IX_ApplicationGroups_1");

                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.LDapQuery)
                    .HasMaxLength(4000)
                    .HasColumnName("LDapQuery");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.ObjectSid)
                    .HasMaxLength(85)
                    .HasColumnName("objectSid");

                entity.HasOne(d => d.Application).WithMany(p => p.NetsqlazmanApplicationGroupsTables)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_ApplicationGroups_Applications");
            });

            modelBuilder.Entity<NetsqlazmanApplicationPermissionsTable>(entity =>
            {
                entity.HasKey(e => e.ApplicationPermissionId).HasName("PK_ApplicationPermissions");

                entity.ToTable("netsqlazman_ApplicationPermissionsTable");

                entity.HasIndex(e => e.ApplicationId, "IX_ApplicationPermissions");

                entity.HasIndex(e => new { e.ApplicationId, e.SqlUserOrRole, e.NetSqlAzManFixedServerRole }, "IX_ApplicationPermissions_1");

                entity.Property(e => e.SqlUserOrRole).HasMaxLength(128);

                entity.HasOne(d => d.Application).WithMany(p => p.NetsqlazmanApplicationPermissionsTables)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_ApplicationPermissions_ApplicationsTable");
            });

            modelBuilder.Entity<NetsqlazmanApplicationsTable>(entity =>
            {
                entity.HasKey(e => e.ApplicationId).HasName("PK_Applications");

                entity.ToTable("netsqlazman_ApplicationsTable");

                entity.HasIndex(e => new { e.Name, e.StoreId }, "Applications_StoreId_Name_Unique_Index").IsUnique();

                entity.HasIndex(e => new { e.ApplicationId, e.Name }, "IX_Applications");

                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Store).WithMany(p => p.NetsqlazmanApplicationsTables)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Applications_Stores");
            });

            modelBuilder.Entity<NetsqlazmanApplicationsView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_ApplicationsView");

                entity.Property(e => e.ApplicationDescription).HasMaxLength(1024);
                entity.Property(e => e.ApplicationName).HasMaxLength(255);
                entity.Property(e => e.StoreDescription).HasMaxLength(1024);
                entity.Property(e => e.StoreName).HasMaxLength(255);
            });

            modelBuilder.Entity<NetsqlazmanAuthorizationAttributesTable>(entity =>
            {
                entity.HasKey(e => e.AuthorizationAttributeId).HasName("PK_AuthorizationAttributes");

                entity.ToTable("netsqlazman_AuthorizationAttributesTable");

                entity.HasIndex(e => new { e.AuthorizationId, e.AttributeKey }, "AuthorizationAttributes_AuhorizationId_AttributeKey_Unique_Index").IsUnique();

                entity.HasIndex(e => new { e.AuthorizationId, e.AttributeKey }, "IX_AuthorizationAttributes");

                entity.Property(e => e.AttributeKey).HasMaxLength(255);
                entity.Property(e => e.AttributeValue).HasMaxLength(4000);

                entity.HasOne(d => d.Authorization).WithMany(p => p.NetsqlazmanAuthorizationAttributesTables)
                    .HasForeignKey(d => d.AuthorizationId)
                    .HasConstraintName("FK_AuthorizationAttributes_Authorizations");
            });

            modelBuilder.Entity<NetsqlazmanAuthorizationAttributesView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_AuthorizationAttributesView");

                entity.Property(e => e.AttributeKey).HasMaxLength(255);
                entity.Property(e => e.AttributeValue).HasMaxLength(4000);
                entity.Property(e => e.AuthorizationType)
                    .HasMaxLength(19)
                    .IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.ObjectSid)
                    .HasMaxLength(85)
                    .HasColumnName("objectSid");
                entity.Property(e => e.Owner).HasMaxLength(255);
                entity.Property(e => e.SidWhereDefined)
                    .HasMaxLength(11)
                    .IsUnicode(false);
                entity.Property(e => e.ValidFrom).HasColumnType("datetime");
                entity.Property(e => e.ValidTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<NetsqlazmanAuthorizationView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_AuthorizationView");

                entity.Property(e => e.AuthorizationType)
                    .HasMaxLength(19)
                    .IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.ObjectSid)
                    .HasMaxLength(85)
                    .HasColumnName("objectSid");
                entity.Property(e => e.Owner).HasMaxLength(255);
                entity.Property(e => e.SidWhereDefined)
                    .HasMaxLength(11)
                    .IsUnicode(false);
                entity.Property(e => e.ValidFrom).HasColumnType("datetime");
                entity.Property(e => e.ValidTo).HasColumnType("datetime");
            });

            modelBuilder.Entity<NetsqlazmanAuthorizationsTable>(entity =>
            {
                entity.HasKey(e => e.AuthorizationId).HasName("PK_Authorizations");

                entity.ToTable("netsqlazman_AuthorizationsTable");

                entity.HasIndex(e => new { e.ItemId, e.ObjectSid }, "IX_Authorizations");

                entity.HasIndex(e => new { e.ItemId, e.ObjectSid, e.ObjectSidWhereDefined, e.AuthorizationType, e.ValidFrom, e.ValidTo }, "IX_Authorizations_1");

                entity.Property(e => e.ObjectSid)
                    .HasMaxLength(85)
                    .HasColumnName("objectSid");
                entity.Property(e => e.ObjectSidWhereDefined).HasColumnName("objectSidWhereDefined");
                entity.Property(e => e.OwnerSid)
                    .HasMaxLength(85)
                    .HasColumnName("ownerSid");
                entity.Property(e => e.OwnerSidWhereDefined).HasColumnName("ownerSidWhereDefined");
                entity.Property(e => e.ValidFrom).HasColumnType("datetime");
                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.Item).WithMany(p => p.NetsqlazmanAuthorizationsTables)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_Authorizations_Items");
            });

            modelBuilder.Entity<NetsqlazmanBizRuleView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_BizRuleView");

                entity.Property(e => e.BizRuleSource).HasColumnType("text");
                entity.Property(e => e.CompiledAssembly).HasColumnType("image");
                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<NetsqlazmanBizRulesTable>(entity =>
            {
                entity.HasKey(e => e.BizRuleId).HasName("PK_BizRules");

                entity.ToTable("netsqlazman_BizRulesTable");

                entity.Property(e => e.BizRuleSource).HasColumnType("text");
                entity.Property(e => e.CompiledAssembly).HasColumnType("image");
            });

            modelBuilder.Entity<NetsqlazmanDatabaseUser>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_DatabaseUsers");

                entity.Property(e => e.DbuserName)
                    .HasMaxLength(255)
                    .HasColumnName("DBUserName");
                entity.Property(e => e.DbuserSid)
                    .HasMaxLength(85)
                    .HasColumnName("DBUserSid");
                entity.Property(e => e.FullName).HasMaxLength(255);
                entity.Property(e => e.OtherFields).HasMaxLength(255);
            });

            modelBuilder.Entity<NetsqlazmanItemAttributesTable>(entity =>
            {
                entity.HasKey(e => e.ItemAttributeId).HasName("PK_ItemAttributes");

                entity.ToTable("netsqlazman_ItemAttributesTable");

                entity.HasIndex(e => new { e.ItemId, e.AttributeKey }, "IX_ItemAttributes");

                entity.HasIndex(e => new { e.ItemId, e.AttributeKey }, "ItemAttributes_AuhorizationId_AttributeKey_Unique_Index").IsUnique();

                entity.Property(e => e.AttributeKey).HasMaxLength(255);
                entity.Property(e => e.AttributeValue).HasMaxLength(4000);

                entity.HasOne(d => d.Item).WithMany(p => p.NetsqlazmanItemAttributesTables)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_ItemAttributes_Items");
            });

            modelBuilder.Entity<NetsqlazmanItemAttributesView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_ItemAttributesView");

                entity.Property(e => e.AttributeKey).HasMaxLength(255);
                entity.Property(e => e.AttributeValue).HasMaxLength(4000);
                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.ItemType)
                    .HasMaxLength(9)
                    .IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<NetsqlazmanItemsHierarchyTable>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.MemberOfItemId }).HasName("PK_ItemsHierarchy");

                entity.ToTable("netsqlazman_ItemsHierarchyTable", tb => tb.HasTrigger("ItemsHierarchyTrigger"));

                entity.HasIndex(e => e.ItemId, "IX_ItemsHierarchy");

                entity.HasIndex(e => e.MemberOfItemId, "IX_ItemsHierarchy_1");
            });

            modelBuilder.Entity<NetsqlazmanItemsHierarchyView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_ItemsHierarchyView");

                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.ItemType)
                    .HasMaxLength(9)
                    .IsUnicode(false);
                entity.Property(e => e.MemberDescription).HasMaxLength(1024);
                entity.Property(e => e.MemberName).HasMaxLength(255);
                entity.Property(e => e.MemberType)
                    .HasMaxLength(9)
                    .IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<NetsqlazmanItemsTable>(entity =>
            {
                entity.HasKey(e => e.ItemId).HasName("PK_Items");

                entity.ToTable("netsqlazman_ItemsTable", tb => tb.HasTrigger("ItemDeleteTrigger"));

                entity.HasIndex(e => new { e.ApplicationId, e.Name }, "IX_Items");

                entity.HasIndex(e => new { e.Name, e.ApplicationId }, "Items_ApplicationId_Name_Unique_Index").IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Application).WithMany(p => p.NetsqlazmanItemsTables)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_Items_Applications");

                entity.HasOne(d => d.BizRule).WithMany(p => p.NetsqlazmanItemsTables)
                    .HasForeignKey(d => d.BizRuleId)
                    .HasConstraintName("FK_Items_BizRules");
            });

            modelBuilder.Entity<NetsqlazmanLogTable>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK_Log")
                    .IsClustered(false);

                entity.ToTable("netsqlazman_LogTable");

                entity.HasIndex(e => e.WindowsIdentity, "IX_Log");

                entity.HasIndex(e => e.SqlIdentity, "IX_Log_1");

                entity.HasIndex(e => new { e.LogDateTime, e.InstanceGuid, e.OperationCounter }, "IX_Log_2")
                    .IsDescending(true, false, true)
                    .IsClustered();

                entity.Property(e => e.ENSDescription)
                    .HasMaxLength(4000)
                    .HasColumnName("ENSDescription");
                entity.Property(e => e.ENSType)
                    .HasMaxLength(255)
                    .HasColumnName("ENSType");
                entity.Property(e => e.LogDateTime).HasColumnType("datetime");
                entity.Property(e => e.LogType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MachineName).HasMaxLength(255);
                entity.Property(e => e.SqlIdentity)
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");
                entity.Property(e => e.WindowsIdentity).HasMaxLength(255);
            });

            modelBuilder.Entity<NetsqlazmanSetting>(entity =>
            {
                entity.HasKey(e => e.SettingName).HasName("PK_Settings");

                entity.ToTable("netsqlazman_Settings");

                entity.Property(e => e.SettingName).HasMaxLength(255);
                entity.Property(e => e.SettingValue).HasMaxLength(255);
            });

            modelBuilder.Entity<NetsqlazmanStoreAttributesTable>(entity =>
            {
                entity.HasKey(e => e.StoreAttributeId).HasName("PK_StoreAttributes");

                entity.ToTable("netsqlazman_StoreAttributesTable");

                entity.HasIndex(e => new { e.StoreId, e.AttributeKey }, "IX_StoreAttributes");

                entity.HasIndex(e => new { e.StoreId, e.AttributeKey }, "StoreAttributes_AuhorizationId_AttributeKey_Unique_Index").IsUnique();

                entity.Property(e => e.AttributeKey).HasMaxLength(255);
                entity.Property(e => e.AttributeValue).HasMaxLength(4000);

                entity.HasOne(d => d.Store).WithMany(p => p.NetsqlazmanStoreAttributesTables)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreAttributes_Stores");
            });

            modelBuilder.Entity<NetsqlazmanStoreAttributesView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_StoreAttributesView");

                entity.Property(e => e.AttributeKey).HasMaxLength(255);
                entity.Property(e => e.AttributeValue).HasMaxLength(4000);
                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<NetsqlazmanStoreGroupMembersTable>(entity =>
            {
                entity.HasKey(e => e.StoreGroupMemberId).HasName("PK_StoreGroupMembers");

                entity.ToTable("netsqlazman_StoreGroupMembersTable");

                entity.HasIndex(e => new { e.StoreGroupId, e.ObjectSid }, "IX_StoreGroupMembers");

                entity.HasIndex(e => new { e.StoreGroupId, e.ObjectSid, e.IsMember }, "StoreGroupMembers_StoreGroupId_ObjectSid_IsMember_Unique_Index").IsUnique();

                entity.Property(e => e.ObjectSid)
                    .HasMaxLength(85)
                    .HasColumnName("objectSid");

                entity.HasOne(d => d.StoreGroup).WithMany(p => p.NetsqlazmanStoreGroupMembersTables)
                    .HasForeignKey(d => d.StoreGroupId)
                    .HasConstraintName("FK_StoreGroupMembers_StoreGroup");
            });

            modelBuilder.Entity<NetsqlazmanStoreGroupMembersView>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToView("netsqlazman_StoreGroupMembersView");

                entity.Property(e => e.MemberType)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.ObjectSid)
                    .HasMaxLength(85)
                    .HasColumnName("objectSid");
                entity.Property(e => e.StoreGroup).HasMaxLength(255);
                entity.Property(e => e.WhereDefined)
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NetsqlazmanStoreGroupsTable>(entity =>
            {
                entity.HasKey(e => e.StoreGroupId).HasName("PK_StoreGroups");

                entity.ToTable("netsqlazman_StoreGroupsTable", tb => tb.HasTrigger("StoreGroupDeleteTrigger"));

                entity.HasIndex(e => new { e.StoreId, e.ObjectSid }, "IX_StoreGroups");

                entity.HasIndex(e => new { e.StoreId, e.Name }, "StoreGroups_StoreId_Name_Unique_Index").IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.LDapQuery)
                    .HasMaxLength(4000)
                    .HasColumnName("LDapQuery");
                entity.Property(e => e.Name).HasMaxLength(255);
                entity.Property(e => e.ObjectSid)
                    .HasMaxLength(85)
                    .HasColumnName("objectSid");

                entity.HasOne(d => d.Store).WithMany(p => p.NetsqlazmanStoreGroupsTables)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreGroups_Stores");
            });

            modelBuilder.Entity<NetsqlazmanStorePermissionsTable>(entity =>
            {
                entity.HasKey(e => e.StorePermissionId).HasName("PK_StorePermissions");

                entity.ToTable("netsqlazman_StorePermissionsTable");

                entity.HasIndex(e => e.StoreId, "IX_StorePermissions");

                entity.HasIndex(e => new { e.StoreId, e.SqlUserOrRole, e.NetSqlAzManFixedServerRole }, "IX_StorePermissions_1");

                entity.Property(e => e.SqlUserOrRole).HasMaxLength(128);

                entity.HasOne(d => d.Store).WithMany(p => p.NetsqlazmanStorePermissionsTables)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StorePermissions_StoresTable");
            });

            modelBuilder.Entity<NetsqlazmanStoresTable>(entity =>
            {
                entity.HasKey(e => e.StoreId).HasName("PK_Stores");

                entity.ToTable("netsqlazman_StoresTable");

                entity.HasIndex(e => e.Name, "Stores_Name_Unique_Index").IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1024);
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<UsersDemo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UsersDemo");

                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.Property(e => e.FullName).HasMaxLength(255);
                entity.Property(e => e.OtherFields).HasMaxLength(255);
                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}