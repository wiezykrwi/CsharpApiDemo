using FastEndpoints;

namespace BasicApi.Posts;

public class GetPostsEndpoint(IPostsRepository postsRepository) : EndpointWithoutRequest<List<Post>>
{
    private readonly IPostsRepository _postsRepository = postsRepository;

    public override void Configure()
    {
        Get("/posts");
        AllowAnonymous();
    }

    public override Task<List<Post>> ExecuteAsync(CancellationToken ct)
    {
        return _postsRepository.GetAll(ct);
    }
}