﻿using BloodDonation.Database.Application.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.CodeAnalysis;

namespace BloodDonation.Database.Api.Filters
{
    [ExcludeFromCodeCoverage]
    public class ExceptionDefaultFilter : ExceptionFilterAttribute
    {
        private readonly ErrorViewModel _error;

        public ExceptionDefaultFilter() : base()
        {
            _error = new ErrorViewModel();
        }

        public override void OnException(ExceptionContext context)
        {
            _error.Errors.Add(context.Exception.Message);
            context.Result = new BadRequestObjectResult(_error);
        }
    }
}
