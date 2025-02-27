﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskDelegationAPI.Models;

public partial class TaskDelegationContext : DbContext
{
    public TaskDelegationContext(DbContextOptions<TaskDelegationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentID).HasName("PK__Comments__C3B4DFAA66DF09E6");

            entity.Property(e => e.Content).IsUnicode(false);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");

            entity.HasOne(d => d.Task).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TaskID)
                .HasConstraintName("FK__Comments__TaskID__3E52440B");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserID)
                .HasConstraintName("FK__Comments__UserID__3F466844");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionID).HasName("PK__Permissi__EFA6FB0F51713BF3");

            entity.Property(e => e.Permission1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Permission");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskID).HasName("PK__Tasks__7C6949D1FCFA0318");

            entity.Property(e => e.DateComplete).HasColumnType("datetime");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Priority)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TaskCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Tasks__CreatedBy__3B75D760");

            entity.HasOne(d => d.GivenToNavigation).WithMany(p => p.TaskGivenToNavigations)
                .HasForeignKey(d => d.GivenTo)
                .HasConstraintName("FK__Tasks__GivenTo__3A81B327");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK__Users__1788CCAC1A50BCBF");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F28456D3EFA617").IsUnique();

            entity.Property(e => e.Email)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.HasKey(e => e.UserPermissionsID).HasName("PK__UserPerm__3E193133C31B2C8E");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.PermissionID)
                .HasConstraintName("FK__UserPermi__Permi__44FF419A");

            entity.HasOne(d => d.User).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.UserID)
                .HasConstraintName("FK__UserPermi__UserI__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}