using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VideoMenuBLL;
using VideoMenuBLL.BusiessObjects;
using VideoMenuBLL.BusinessObjects;

namespace VideoRest
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
            services.AddMvc();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();
                /*var genre = facade.GenreService.Create(new GenreBO()
                {
                    Name = "Comedy"
                });
                var genre2 = facade.GenreService.Create(new GenreBO()
                {
                    Name = "Horror"
                });
                var genre3 = facade.GenreService.Create(new GenreBO()
                {
                    Name = "Sci-Fi"
                });
                var genre4 = facade.GenreService.Create(new GenreBO()
                {
                    Name = "Fantasy"
                });
                var genre5 = facade.GenreService.Create(new GenreBO()
                {
                    Name = "Romance"
                });

                var video = facade.VideoService.Create(new VideoBO()
                {
                    Name = "Video 722",
                    PricePrDay = 10,
                    GenreIds = new List<int>() { genre.Id, genre4.Id }
                });

                for (int i = 0; i < 3; i++)
                facade.RentalService.Create(new RentalBO()
                {
                    From = DateTime.Now.AddMonths(-1),
                    To = DateTime.Now.AddMonths(1),
                    VideoId = video.Id
                });*/
            }

            app.UseMvc();
        }
    }
}
