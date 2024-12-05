using FastEndpoints;

namespace BasicApi.Posts;

public class CreatePostEndpoint(IPostsRepository postsRepository) : Endpoint<CreatePostRequest>
{
    private readonly IPostsRepository _postsRepository = postsRepository;

    public override void Configure()
    {
        Post("/posts");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePostRequest req, CancellationToken ct)
    {
        await _postsRepository.CreateAsync(new Post
        {
            Title = req.Title,
            Content = req.Content
        }, ct);

        await SendOkAsync(ct);
    }
}

public class CreatePostRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
}