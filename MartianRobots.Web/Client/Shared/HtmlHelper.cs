using Microsoft.AspNetCore.Components;
using System.Web;

namespace MartianRobots.Web.Client.Shared
{
    public class HtmlHelper
    {
        public static MarkupString RenderMultiline(string textWithLineBreaks)
        {
            var encodedLines = (textWithLineBreaks ?? string.Empty)
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => HttpUtility.HtmlEncode(line))
                .ToArray();

            return (MarkupString)string.Join("<br />", encodedLines);
        }
    }
}
