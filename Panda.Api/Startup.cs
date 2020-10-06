using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Panda.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddApiVersioning(o => {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PandaFrame API",
                    Description = "API for PandaFrame",
                    Contact = new OpenApiContact() { Name = "еж╢О", Email = "1367903451@qq.com" }
                });
                option.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "PandaFrame API",
                    Description = "API for PandaFrame",
                    Contact = new OpenApiContact() { Name = "еж╢О", Email = "1367903451@qq.com" }
                });

                option.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var versions = apiDesc.CustomAttributes()
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });

                option.OperationFilter<RemoveVersionParameterOperationFilter>();
                option.DocumentFilter<SetVersionInPathDocumentFilter>();

                option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(Startup).Assembly.GetName().Name}.xml"), true);
                //option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"PandaFrame.xml"), true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 api");
                option.SwaggerEndpoint("/swagger/v2/swagger.json", "v2 api");

                option.RoutePrefix = string.Empty;
                option.DocumentTitle = "PandaFrame API";
            });
        }
    }
}
