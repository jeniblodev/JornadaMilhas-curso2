using JornadaMilhasV0.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV0.Dados;
public class JornadaMilhasContext: DbContext
{    
    public DbSet<OfertaViagem> OfertasViagem { get; set; }
    public DbSet<Rota> Rota { get; set; }

    public JornadaMilhasContext()
    {
        
    }
    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration configuration = new ConfigurationBuilder()
                                               .SetBasePath(Directory.GetCurrentDirectory())
                                               .AddJsonFile("appsettings.json")
                                               .Build();
        var inMemory = bool.Parse(configuration["InMemory:Use"]!);
        if (inMemory)
        {          
           return;
        }
        optionsBuilder.UseSqlServer(configuration["ConnectionString:DefaultConnection"]!);


    }
}
