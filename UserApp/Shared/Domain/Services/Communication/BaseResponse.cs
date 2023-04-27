namespace UserApp.Shared.Domain.Services.Communication;

public class BaseResponse<TEntity>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public TEntity? Resource { get; set; }

    public BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }

    public BaseResponse(TEntity? resource)
    {
        Success = true;
        Message = String.Empty;
        Resource = resource;
    }
}