using System.Data;
using Dapper;
using StronglyTypedIds;

namespace BasicApi.Posts;

public class Post
{
    public PostId Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}

[StronglyTypedId(Template.Int)]
public partial struct PostId
{
}

public class PostIdMapper : SqlMapper.TypeHandler<PostId>
{
    public override void SetValue(IDbDataParameter parameter, PostId value)
    {
        parameter.Value = value.Value;
    }

    public override PostId Parse(object value)
    {
        return new PostId((int) value);
    }
}