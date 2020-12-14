using entity.sql.importacao.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace entity.sql.importacao.Models
{
    public class EFContext : DbContext
    {
        //Base de dados portable
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=dtb_Importacao;Trusted_Connection=True;";
        
        //Base de dados local
       // private const string connectionString = @"Server=HP\DEVELOPER;Database=dtb_Importacao;Trusted_Connection=True;";

        public EFContext()
        {
        }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NFeTransp> NFeTransp { get; set; }
        public virtual DbSet<NFePag> NFePag { get; set; }
        public virtual DbSet<NFeDetPag> NFeDetPag { get; set; }
        public virtual DbSet<NotaFiscal> NotaFiscal { get; set; }
        public virtual DbSet<NFeDetItem> NFeDetItem { get; set; }
        public virtual DbSet<NFeIde> NFeIde { get; set; }

        public virtual DbSet<NFeTotalIcms> NFeTotalIcms { get; set; }
        public virtual DbSet<NFeEmi> NFeEmi { get; set; }
        public virtual DbSet<NFeImpCofins> NFeImpCofins { get; set; }
        public virtual DbSet<NFeImpIcms> NFeImpIcms { get; set; }
        public virtual DbSet<NFeImpPis> NFeImpPis { get; set; }
        public virtual DbSet<NFeImpCofinsAliq> NFeImpCofinsAliq { get; set; }
        public virtual DbSet<NFeImpCofinsNt> NFeImpCofinsNt { get; set; }
        public virtual DbSet<NFeImpPisAliq> NFeImpPisAliq { get; set; }
        public virtual DbSet<NFeImpPisNt> NFeImpPisNt { get; set; }
        public virtual DbSet<NFeEndEmi> NFeEndEmi { get; set; }
        public virtual DbSet<NFeInfAdic> NFeInfAdic { get; set; }
        public virtual DbSet<NFeInfSupl> NFeInfSupl { get; set; }
        public virtual DbSet<NFeProtNfe> NFeProtNfe { get; set; }
        public virtual DbSet<NFeSignature> NFeSignature { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }



    }
}
