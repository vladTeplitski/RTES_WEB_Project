﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

public partial class rtesEntities1 : DbContext
{
    public rtesEntities1()
        : base("name=rtesEntities1")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }

    public virtual DbSet<abstract_user> abstract_user { get; set; }
    public virtual DbSet<@case> @case { get; set; }
    public virtual DbSet<client> client { get; set; }
    public virtual DbSet<emergencyReport> emergencyReport { get; set; }
    public virtual DbSet<third_party> third_party { get; set; }
    public virtual DbSet<messagesTable> messagesTable { get; set; }
}
