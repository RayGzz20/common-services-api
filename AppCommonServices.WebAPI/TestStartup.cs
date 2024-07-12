namespace AppCommonServices.WebAPI
{
    public class TestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurar servicios necesarios para las pruebas de integración
            services.AddControllers();
            // Agrega tus servicios necesarios para las pruebas de integración aquí
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configurar middleware relevante para las pruebas de integración
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
