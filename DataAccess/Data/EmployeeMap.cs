using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class EmployeeMap
    {
        public EmployeeMap(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Position).IsRequired();
            entityBuilder.Property(t => t.Year).IsRequired();
            entityBuilder.Property(t => t.Characteristic).IsRequired();
            entityBuilder.Property(t => t.Decree).IsRequired();
        }
    }
}
