namespace Inventory.Core.Business.Errors;

public class EntityWithIdNotExistsError : IError
{
    public EntityWithIdNotExistsError(Type type, int id)
    {
        var typeWithoutNamespace = type.ToString().Split(".")[^1];
        
        Message = $"{typeWithoutNamespace} with id={id} does not exist";
    }

    public int Code { get; } = 1001;
    public string Message { get; }
}