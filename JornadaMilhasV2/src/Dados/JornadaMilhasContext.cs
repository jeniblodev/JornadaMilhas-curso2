using JornadaMilhasV0.Modelos;
using Microsoft.EntityFrameworkCore;
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
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");


    }
}
