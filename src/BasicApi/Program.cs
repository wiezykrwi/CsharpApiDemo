using BasicApi.Database;
using BasicApi.Posts;
using Dapper;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection(nameof(DatabaseOptions)));
builder.Services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddTransient<IPostsRepository, PostsRepository>();

SqlMapper.AddTypeHandler(new PostIdMapper());

builder.Services.AddFastEndpoints();

var app = builder.Build();
app.UseFastEndpoints();
app.Run();