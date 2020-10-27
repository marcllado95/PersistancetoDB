using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Empleats.Models;

namespace Empleats.Data
{
    public class EmpleatsContext : DbContext
    {
        public EmpleatsContext (DbContextOptions<EmpleatsContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }   //DBset es como una tabla pero en codigo
        //aqui tenemos registradas todas las tablas de la base de datos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee"); //modelo Employeee se junta con tabla llamada "Employee"
        }
    }
}
