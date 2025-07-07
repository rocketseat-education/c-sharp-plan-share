using PlanShare.App.Extensions;

namespace PlanShare.App.Resources.Styles.Handlers;


class CustomEntryHandler
{
    public static void Customize()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("PlanShareEntry", (handler, entry) =>
        {
            var cursorColor = Application.Current!.GetPrimaryColor();
            var lineColor = Application.Current!.GetLineColor();

            var hexadecimal = cursorColor.ToHex();
        });
    }
}
