using Domain.Entites;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Data.DataSeeding
{
    public class DataSeeding : IDataSeeding
    {
        private readonly BlogDbContext _dbContext;

        public DataSeeding(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DataSeed()
        {
            try
            {
                var PaginationResult = await _dbContext.Database.GetPendingMigrationsAsync();
                if (PaginationResult.Any())
                {
                    await _dbContext.Database.MigrateAsync();
                }

                // seeding لكل Connection فتح ال
                await _dbContext.Database.OpenConnectionAsync();

                try
                {
                    // Categories
                    if (!_dbContext.Categories.Any())
                    {
                        // Json File تلقائي بقلو لا انا هبعتهولك في ال id بدل ما يضيف ال
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Categories] ON");
                        var categoriesData = File.OpenRead("..\\Persistence\\Data\\DataSeeding\\JsonFile\\categories.json");
                        var categories = await JsonSerializer.DeserializeAsync<List<Category>>(categoriesData);
                        if (categories is not null && categories.Any())
                        {
                            await _dbContext.Categories.AddRangeAsync(categories);
                            // معتمده علي بعض ides لعد كل قراءه ملف عشان ال SaveChangesAsync بنعمل
                            await _dbContext.SaveChangesAsync();
                        }
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Categories] OFF");
                        
                    }

                    // Tags
                    if (!_dbContext.Tags.Any())
                    {
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Tags] ON");
                        var tagsData = File.OpenRead("..\\Persistence\\Data\\DataSeeding\\JsonFile\\tags.json");
                        var tags = await JsonSerializer.DeserializeAsync<List<Tag>>(tagsData);
                        if (tags is not null && tags.Any())
                        {
                            await _dbContext.Tags.AddRangeAsync(tags);
                            await _dbContext.SaveChangesAsync();
                        }
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Tags] OFF");
                        
                    }

                    // Users
                    if (!_dbContext.Users.Any())
                    {
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Users] ON");
                        var userData = File.OpenRead("..\\Persistence\\Data\\DataSeeding\\JsonFile\\users.json");
                        var options = new JsonSerializerOptions
                        {
                            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
                        };
                        var users = await JsonSerializer.DeserializeAsync<List<User>>(userData, options);
                        if (users is not null && users.Any())
                        {
                            await _dbContext.Users.AddRangeAsync(users);
                            await _dbContext.SaveChangesAsync();
                        }
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Users] OFF");
                      
                    }

                    // BlogPosts
                    if (!_dbContext.BlogPosts.Any())
                    {
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [BlogPosts] ON");
                        var blogPostData = File.OpenRead("..\\Persistence\\Data\\DataSeeding\\JsonFile\\blogposts.json");
                        var options = new JsonSerializerOptions
                        {
                            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
                        };
                        var blogposts = await JsonSerializer.DeserializeAsync<List<BlogPost>>(blogPostData, options);
                        if (blogposts is not null && blogposts.Any())
                        {
                            await _dbContext.BlogPosts.AddRangeAsync(blogposts);
                            await _dbContext.SaveChangesAsync();
                        }
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [BlogPosts] OFF");
                      
                    }

                    // Comments
                    if (!_dbContext.Comments.Any())
                    {
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Comments] ON");
                        var commentsData = File.OpenRead("..\\Persistence\\Data\\DataSeeding\\JsonFile\\comments.json");
                        var comments = await JsonSerializer.DeserializeAsync<List<Comment>>(commentsData);
                        if (comments is not null && comments.Any())
                        {
                            await _dbContext.Comments.AddRangeAsync(comments);
                            await _dbContext.SaveChangesAsync();
                        }
                        await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Comments] OFF");
                       
                    }

                    // BlogPostTags
                    if (!_dbContext.BlogPostTags.Any())
                    {
                        var blogPostTagsData = File.OpenRead("..\\Persistence\\Data\\DataSeeding\\JsonFile\\blogposttags.json");
                        var blogPostTags = await JsonSerializer.DeserializeAsync<List<BlogPostTag>>(blogPostTagsData);
                        if (blogPostTags is not null && blogPostTags.Any())
                        {
                            await _dbContext.BlogPostTags.AddRangeAsync(blogPostTags);
                            await _dbContext.SaveChangesAsync();
                        }
                       
                    }

                    
                }
                finally
                {
                    await _dbContext.Database.CloseConnectionAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Data Seeding Failed : {ex.Message}");
            }
        }
    }
}