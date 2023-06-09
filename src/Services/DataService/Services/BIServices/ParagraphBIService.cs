﻿using DataAccess;
using DataService.Handlers.UniqueWords;

namespace DataService.Services.BIServices
{
    public class ParagraphBIService : BaseService
    {
        public ParagraphBIService(BIContext context) : base(context, new ParagraphHandler()) { }
    }
}