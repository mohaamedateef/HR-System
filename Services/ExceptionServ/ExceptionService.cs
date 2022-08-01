﻿using HRSystem.Repositories.ExceptionRepo;

namespace HRSystem.Services.ExceptionServ
{
    public class ExceptionService : IExceptionService
    {
        private readonly IExceptionRepository ExceptionRepo;

        public ExceptionService(IExceptionRepository ExceptionRepo)
        {
            this.ExceptionRepo = ExceptionRepo;
        }
    }
}