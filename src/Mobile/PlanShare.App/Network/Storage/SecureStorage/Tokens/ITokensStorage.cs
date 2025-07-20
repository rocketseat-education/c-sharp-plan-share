namespace PlanShare.App.Network.Storage.SecureStorage.Tokens;

public interface ITokensStorage
{
    Task Save(Models.ValueObjects.Tokens tokens);
    Task<Models.ValueObjects.Tokens> Get();
    void Clear();
}
