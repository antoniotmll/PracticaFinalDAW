﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticaFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cochesdawEntities6 : DbContext
    {
        public cochesdawEntities6()
            : base("name=cochesdawEntities6")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<coche> coches { get; set; }
        public virtual DbSet<lineapedido> lineapedidoes { get; set; }
        public virtual DbSet<pedido> pedidoes { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<stock> stocks { get; set; }
    }
}
