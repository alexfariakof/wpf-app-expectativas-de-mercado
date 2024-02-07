using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Expectativas_de_Mercado.Model.Aggregates;
using Expectativas_de_Mercado.Model.ValueObjects;

namespace Expectativas_de_Mercado.Repository.Mapping;
internal class SelicMap : IEntityTypeConfiguration<Selic>
{
    public void Configure(EntityTypeBuilder<Selic> builder)
    {
        builder.ToTable(nameof(Selic));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Data).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Reuniao).IsRequired();

        builder.OwnsOne<Media>(e => e.Media, c =>
        {
            c.Property(x => x.Value).HasColumnName("Media").IsRequired();

        });

        builder.OwnsOne<Mediana>(e => e.Mediana, c =>
        {
            c.Property(x => x.Value).HasColumnName("Mediana").IsRequired();

        });

        builder.OwnsOne<DesvioPadrao>(e => e.DesvioPadrao, c =>
        {
            c.Property(x => x.Value).HasColumnName("DesvioPadrao").IsRequired();

        });

        builder.Property(x => x.Minimo).IsRequired();
        builder.Property(x => x.Maximo).IsRequired();
        builder.Property(x => x.NumeroRespondentes).IsRequired();
        builder.Property(x => x.BaseCalculo).IsRequired();
    }
}