﻿using LangoTop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangoTop.Infrastructure.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PageTitle).IsRequired().HasMaxLength(60);
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Picture).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Keywords).IsRequired().HasMaxLength(120);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(200);
            builder.Property(x => x.MetaDescription).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ShortLink).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PictureSmall).IsRequired().HasMaxLength(2000);

            builder
                .HasOne(x => x.ArticleCategory)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.CategoryId);

            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}