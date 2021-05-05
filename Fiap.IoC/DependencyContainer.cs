using Fiap.Application.Interfaces;
using Fiap.Application.Services;
using Fiap.Application.Validations;
using Fiap.Domain.Models;
using Fiap.Infrastructure.Clients;
using Fiap.Persistence.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IValidator<Aluno>, AlunoValidation>();

            //services.AddTransient<INoticiaService, NoticiaService>();
            //services.AddSingleton<INoticiaService, NoticiaService>();
            services.AddScoped<INoticiaService, NoticiaService>();
            services.AddScoped<IRssClient, RssGloboClient>();
            services.AddSingleton<ILoggerClient, LoggerClient>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=Fiap2021;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<DataContext>(option => option.UseSqlServer(connection));


        }
    }
}
