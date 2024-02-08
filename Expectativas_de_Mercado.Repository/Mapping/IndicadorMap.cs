using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Expectativas_de_Mercado.Model.Core;

namespace Expectativas_de_Mercado.Repository.Mapping;
internal class IndicadorMap : IEntityTypeConfiguration<Indicador>
{
    public void Configure(EntityTypeBuilder<Indicador> builder)
    {
        builder.ToTable(nameof(Indicador));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);
        
        builder.HasData
        (
            new Indicador(Indicador_Id.IPCA),
            new Indicador(Indicador_Id.IGP_M),
            new Indicador(Indicador_Id.Selic)
        );

        builder.HasMany(x => x.ExpectativasMercados).WithOne();
    }
}