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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                var facade = new BLLFacade();
                var genre = facade.GenreService.Create(new GenreBO()
                {
                    Name = "Comedy"
                });
                facade.GenreService.Create(new GenreBO()
                {
                    Name = "Horror"
                });
                facade.GenreService.Create(new GenreBO()
                {
                    Name = "Sci-Fi"
                });
                facade.GenreService.Create(new GenreBO()
                {
                    Name = "Fantasy"
                });
                facade.GenreService.Create(new GenreBO()
                {
                    Name = "Romance"
                });

                var video = facade.VideoService.Create(new VideoBO()
                {
                    Name = "Video 722",
                    PricePrDay = 10,
                    GenreId = genre.Id
                });

                for (int i = 0; i < 10000; i++)
                facade.RentalService.Create(new RentalBO()
                {
                    From = DateTime.Now.AddMonths(-1),
                    To = DateTime.Now.AddMonths(1),
                    VideoId = video.Id
                });
            }

            app.UseMvc();
        }
    }
}
