using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    DbSet<MunicipalityTax> MunicipalityTaxes { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
    }
}