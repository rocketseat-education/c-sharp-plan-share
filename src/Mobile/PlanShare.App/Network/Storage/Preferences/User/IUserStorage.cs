namespace PlanShare.App.Network.Storage.Preferences.User;

public interface IUserStorage
{
    void Save(Models.ValueObjects.User user);
    Models.ValueObjects.User Get();
    bool IsLoggedIn();
    void Clear();

}