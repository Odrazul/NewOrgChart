﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace OrgChartWebApp.DAL
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class OrgChartDatabaseEntities : DbContext
{
    public OrgChartDatabaseEntities()
        : base("name=OrgChartDatabaseEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<OrgchartUser> OrgchartUsers { get; set; }

}

}

