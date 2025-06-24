namespace PlanShare.App.Resources.Styles.Handlers;


class CustomEntryHandler
{
    public static void Customize()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("PlanShareEntry", (handler, entry) =>
        {
           
        });
    }
}
