/*
The MIT License (MIT)
Copyright (c) 2007 - 2021 Microting A/S
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Microting.eFormInventoryBase.Infrastructure.Data
{
    using eFormApi.BasePn.Abstractions;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Microting.eFormApi.BasePn.Infrastructure.Database.Entities;

    public class InventoryPnDbContext : DbContext, IPluginDbContext
    {
        public InventoryPnDbContext() { }

        public InventoryPnDbContext(DbContextOptions<InventoryPnDbContext> options) : base(options)
        {
        }


        // Tables
        public DbSet<Item> Items { get; set; }

        public DbSet<ItemGroup> ItemGroups { get; set; }

        public DbSet<ItemType> ItemTypes { get; set; }

        public DbSet<ItemTypeDependency> ItemTypeDependencies { get; set; }

        public DbSet<ItemTypeTag> ItemTypeTags { get; set; }

        public DbSet<UploadedDataType> ItemTypeUploadedDatas { get; set; }

        public DbSet<InventoryTag> InventoryTags { get; set; }

        public DbSet<ItemGroupDependency> ItemGroupDependencys { get; set; }

        public DbSet<AssingnedSite> AssingnedSites { get; set; }

        // Version tables
        public DbSet<ItemVersion> ItemVersions { get; set; }

        public DbSet<ItemGroupVersion> ItemGroupVersions { get; set; }

        public DbSet<ItemTypeVersion> ItemTypeVersions { get; set; }

        public DbSet<ItemTypeDependencyVersion> ItemTypeDependencieVersions { get; set; }

        public DbSet<ItemTypeTagVersion> ItemTypeTagVersions { get; set; }

        public DbSet<UploadedDataTypeVersion> ItemTypeUploadedDataVersions { get; set; }

        public DbSet<InventoryTagVersion> InventoryTagVersions { get; set; }

        public DbSet<ItemGroupDependencyVersion> ItemGroupDependencyVersions { get; set; }

        public DbSet<AssingnedSiteVersion> AssingnedSiteVersions { get; set; }

        // Common tables
        public DbSet<PluginConfigurationValue> PluginConfigurationValues { get; set; }

        public DbSet<PluginConfigurationValueVersion> PluginConfigurationValueVersions { get; set; }

        public DbSet<PluginPermission> PluginPermissions { get; set; }

        public DbSet<PluginGroupPermission> PluginGroupPermissions { get; set; }

        public DbSet<PluginGroupPermissionVersion> PluginGroupPermissionVersions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemTypeDependency>()
                .HasOne(x => x.ParentItemType)
                .WithMany(x => x.DependItemTypes)
                .HasForeignKey(x => x.ParentItemTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemTypeDependency>()
                .HasOne(x => x.DependItemType)
                .WithMany(x => x.ParentItemTypes)
                .HasForeignKey(x => x.DependItemTypeId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UploadedDataType>()
                .HasOne(x => x.ItemType)
                .WithMany(x => x.ItemTypeUploadedDatas)
                .HasForeignKey(x => x.ItemTypeId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ItemTypeTag>()
                .HasOne(x => x.ItemType)
                .WithMany(x => x.ItemTypeTags)
                .HasForeignKey(x => x.ItemTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemTypeTag>()
                .HasOne(x => x.InventoryTag)
                .WithMany(x => x.ItemTypeTags)
                .HasForeignKey(x => x.InventoryTagId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemGroupDependency>()
                .HasOne(x => x.ItemType)
                .WithMany(x => x.ItemGroupDependencies)
                .HasForeignKey(x => x.ItemTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemGroupDependency>()
                .HasOne(x => x.ItemGroup)
                .WithMany(x => x.ItemGroupDependencies)
                .HasForeignKey(x => x.ItemGroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
