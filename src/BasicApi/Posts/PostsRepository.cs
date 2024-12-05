using BasicApi.Database;
using Dapper;

namespace BasicApi.Posts;

public interface IPostsRepository
{
    Task<List<Post>> GetAll(CancellationToken cancellationToken);
    Task CreateAsync(Post post, CancellationToken cancellationToken);
}

public class PostsRepository(IDbConnectionFactory connectionFactory) : IPostsRepository
{
    public async Task<List<Post>> GetAll(CancellationToken cancellationToken)
    {
        using var connection = await connectionFactory.Create(cancellationToken);
        var results = await connection.QueryAsync<Post>("select * from posts");
        return results.ToList();
    }

    public async Task CreateAsync(Post post, CancellationToken cancellationToken)
    {
        using var connection = await connectionFactory.Create(cancellationToken);
        await connection.ExecuteAsync("insert into posts (title, content) values (@title, @content)",
            new { title = post.Title, content = post.Content });
    }
}