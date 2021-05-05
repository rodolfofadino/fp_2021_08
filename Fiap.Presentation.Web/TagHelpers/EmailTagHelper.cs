using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.Presentation.Web.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        const string Domain = "fiap.com.br";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var address = $"{MailTo}@{Domain}";

            output.Attributes.SetAttribute("href", $"mailto:{address}");
            output.Content.SetContent(address);
        }
    }
}
