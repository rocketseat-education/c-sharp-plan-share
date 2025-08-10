using PlanShare.App.ViewModels.Pages.Dashboard;

namespace PlanShare.App.Views.Pages.Dashboard;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardViewModel dashDashboardViewModel)
	{
		InitializeComponent();
		BindingContext = dashDashboardViewModel;
    }
}