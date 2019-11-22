using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Pinhua2.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TagHelpers
{
    [HtmlTargetElement("th", Attributes = "my-model-for")]
    public class MyVueThTagHelper : TagHelper
    {
        public CustomDisplayModel MyModelFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            //var content = output.GetChildContentAsync().GetAwaiter().GetResult().GetContent();
            //if (content.ToLower() == "yes")
            //{
            //    output.Attributes.SetAttribute("class", "text-primary");
            //}
        }
    }
    [HtmlTargetElement("td", Attributes = "my-model-for")]
    public class MyVueTdTagHelper : TagHelper
    {
        public CustomDisplayModel MyModelFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            //var content = output.GetChildContentAsync().GetAwaiter().GetResult().GetContent();
            //if (content.ToLower() == "yes")
            //{
            //    output.Attributes.SetAttribute("class", "text-primary");
            //}

            if (MyModelFor.IsVueComputed)
            {
                output.Content.SetHtmlContent($"{{{{ MyVueComputed{MyModelFor.RawName}(todo) }}}}")
                    .AppendHtml($"<input :name=\"buildName(index, '{MyModelFor.RawName}')\" type=\"hidden\" :value=\"MyVueComputed{MyModelFor.RawName}(todo)\" />");
            }
            else
            {
                var childContent = output.GetChildContentAsync().GetAwaiter().GetResult().GetContent();
                output.Content.SetHtmlContent($"{{{{ todo.{MyModelFor.RawName} }}}}").AppendHtml(childContent);
            }
        }
    }
}