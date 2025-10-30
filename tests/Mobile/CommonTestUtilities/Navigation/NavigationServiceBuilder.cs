using Moq;
using PlanShare.App.Navigation;
using PlanShare.App.ViewModels.Popups;

namespace CommonTestUtilities.Navigation;
public class NavigationServiceBuilder
{
    public static Mock<INavigationService> Build() => new Mock<INavigationService>();

}
