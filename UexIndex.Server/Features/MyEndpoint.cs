using FastEndpoints;
using UexIndex.Server.Requests;
using UexIndex.Server.Responses;

namespace UexIndex.Server.Features;

public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MyRequest req, CancellationToken ct)
    {
        await Send.OkAsync(new()
        {
            FullName = req.FirstName + " + " + req.LastName,
            IsOver30 = req.Age > 30
        });
    }
}
