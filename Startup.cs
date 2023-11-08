using WebApiCompras.Services;
namespace WebApiCompras
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
            services.AddControllers();
            services.AddSwaggerGen();
            // configure DI for application services
            services.AddScoped<IColeccionesService, ColeccionesService>();
            services.AddScoped<IDetalleordencompraService, DetalleordencompraService>();
            services.AddScoped<IDetalleordenpedidoService, DetalleordenpedidoService>();
            services.AddScoped<IRequerimientoService, RequerimientoService>();
            services.AddScoped<IInsumosService, InsumosService>();
            services.AddScoped<ISurtidoService, SurtidoService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IOrdenpedidoService, OrdenpedidoService>();
            services.AddScoped<IOrdencompraService, OrdencompraService>();
            services.AddScoped<IDetalleRequerimientoService, DetalleRequerimientoService>();
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers
                           .Add("X-Copyright", "Copyright 2016 - JMA");
                    }
                });
            }

            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskman API V1"); });

            app.UseRouting();
            // if (env.EnvironmentName == "Development")
            // {

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            Console.WriteLine(env.EnvironmentName);
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
