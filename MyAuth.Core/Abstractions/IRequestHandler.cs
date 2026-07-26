using System;
using System.Collections.Generic;
using System.Text;

namespace MyAuth.Core.Abstractions
{
    public interface IRequestHandler<Tresponse,Trequest>
    {
        Task<DataResponse<Tresponse>> HandleAsync(Trequest request,CancellationToken ct);
    }

    public sealed record EmptyRequest
    {
        public static readonly EmptyRequest Instance = new();
    }
}
