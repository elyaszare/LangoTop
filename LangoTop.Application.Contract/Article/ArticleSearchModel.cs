﻿namespace LangoTop.Application.Contract.Article
{
    public class ArticleSearchModel
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public long AuthorId { get; set; }
    }
}