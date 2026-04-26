
using Domain.Entites;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.DataSeeding;
using Persistence.Data.DbContexts;
using Persistence.unitofwork;
using Service.ImplementServices;
using Service.MappingProfile;
using ServiceAbstraction.Interfaces;

namespace BlogPost
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region  Add services to the container

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // BlogDbContext
            builder.Services.AddDbContext<BlogDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            // Identity 
            builder.Services.AddIdentityCore<User>()
                   .AddRoles<IdentityRole<int>>() 
                   .AddEntityFrameworkStores<BlogDbContext>();
            // DataSeeding
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();
            // AutoMapper 
            builder.Services.AddAutoMapper(cfg => { }, typeof(BlogPostProfile).Assembly);
            // UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            // IBlogPostService
            builder.Services.AddScoped<IBlopPostService, BlopPostService>();
            // CommentService
            builder.Services.AddScoped<ICommentService, CommentService>();

            #endregion



            var app = builder.Build();

            //Pending Migration ÂÌŒ‘ Â‰« »—œÊ ⁄‘«‰ Ì‘Ê› ·Ê ›ÌÂ «Ì  run ﬂ· „« «·«»·ﬂÌ‘‰ Ì⁄„·
            // DataSeed() «··Ì ÃÊ«Â« «·· ÂÌÂ Method Â—ÊÕ «ﬁ—«¡ «·œ« « „‰ «· DataSeeding Ê„‰ «· DataSeeding Ê„‰Â« ÂÊ’· · GetRequiredService<IDataSeeding>() ⁄‘«‰ «Ê’· · Create Scope  »⁄„·
            using var scope = app.Services.CreateScope();
            var objectOgDataSeed = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await objectOgDataSeed.DataSeed();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
