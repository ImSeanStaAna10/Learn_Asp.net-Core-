namespace WebNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ===============================
            // 1. CREATE APPLICATION BUILDER
            // ===============================
            // Ito yung "setup stage" ng application
            // Dito ka nagreregister ng services (MVC, DB, DI, etc.)
            var builder = WebApplication.CreateBuilder(args);

            // ===============================
            // 2. REGISTER MVC SERVICES
            // ===============================
            // Sinasabi nito sa system:
            // "Gagamit tayo ng Controllers + Views (MVC pattern)"
            builder.Services.AddControllersWithViews();

            // ===============================
            // 3. BUILD THE APP
            // ===============================
            // After nito, final na ang configuration
            var app = builder.Build();

            // ===============================
            // 4. ENABLE STATIC FILES
            // ===============================
            // Para gumana CSS, JS, images (wwwroot folder later)
            app.UseStaticFiles();

            // ===============================
            // 5. ENABLE ROUTING SYSTEM
            // ===============================
            // Ito ang nagdi-direct ng URL papunta sa controller
            app.UseRouting();

            // ===============================
            // 6. AUTHORIZATION PIPELINE
            // ===============================
            // Para sa login/security features (optional muna ngayon)
            app.UseAuthorization();

            // ===============================
            // 7. MVC ROUTE CONFIGURATION
            // ===============================
            // Dito sinasabi kung paano babasahin ang URL

            app.MapControllerRoute(
                name: "default",

                // format:
                // /Home/Index
                // /Controller/Action/Id
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            // ===============================
            // 8. RUN APPLICATION
            // ===============================
            // Start ng web server
            app.Run();
        }
    }
}