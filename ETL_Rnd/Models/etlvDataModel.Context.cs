﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ETL_Rnd.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ETL_ValidationEntities : DbContext
    {
        public ETL_ValidationEntities()
            : base("name=ETL_ValidationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tb_etl_valid_user> tb_etl_valid_user { get; set; }
        public DbSet<tb_etl_validation_TestProjectConnections> tb_etl_validation_TestProjectConnections { get; set; }
        public DbSet<tb_etl_validation_TestProjects> tb_etl_validation_TestProjects { get; set; }
    }
}
