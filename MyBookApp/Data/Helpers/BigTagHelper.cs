using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyBookApp.Data.Helpers
{
    [HtmlTargetElement("big")]
   // [HtmlTargetElement(Attribute ="big")]
    public class BigTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
         output.TagName = "h3";
            
        }
    }
}
