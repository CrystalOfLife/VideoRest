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
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.BusiessObjects;

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
                facade.VideoService.Create(new VideoBO()
                {
                    Name = "Video 722"
                });
                facade.VideoService.Create(new VideoBO()
                {
                    Name = "Clickbait 101"
                });
                facade.GenreService.Create(new GenreBO()
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
            }

            app.UseMvc();
        }
    }
}
