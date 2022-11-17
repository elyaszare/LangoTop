﻿using System;
using System.Linq;
using _01_Query.Contracts.Banner;
using LangoTop.Infrastructure;

namespace _01_Query.Query
{
    public class BannerQuery : IBannerQuery
    {
        private readonly LangoTopContext _context;

        public BannerQuery(LangoTopContext context)
        {
            _context = context;
        }

        public BannerQueryModel GetBannerBy(long type)
        {
            return _context.Banners.Where(x => x.EndDate > DateTime.Now).Select(x => new BannerQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                Type = x.Type,
                BannerPicture = x.BannerPicture,
                EndDate = x.EndDate.ToString(),
                CompanyName = x.CompanyName,
                Height = x.Height,
                IsRemoved = x.IsRemoved,
                Link = x.Link,
                StartDate = x.StartDate.ToString(),
                Width = x.Width
            }).FirstOrDefault(x => x.Type == type && !x.IsRemoved);
        }
    }
}