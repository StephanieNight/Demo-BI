﻿using DataAccess;
using DataService.Handlers.UniqueWords;

namespace DataService.Services.BIServices
{
    public class ParallelBIService : BaseService
    {
        public ParallelBIService(BIContext context) : base(context, new ParallelHandler()) { }
    }
}