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
    [HtmlTargetElement("th", Attributes = "my-vue-model-for")]
    public class MyVueThTagHelper : TagHelper
    {
        public CustomDisplayModel MyVueModelFor { get; set; }

        public bool MyHiddenIndex { get; set; }
        public bool MyHiddenCreate { get; set; }
        public bool MyHiddenDetails { get; set; }
        public bool MyHiddenEdit { get; set; }
        public bool MyHiddenDelete { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (MyHiddenIndex && MyVueModelFor.IsHiddenIndex)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenCreate && MyVueModelFor.IsHiddenCreate)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenDetails && MyVueModelFor.IsHiddenDetails)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenEdit && MyVueModelFor.IsHiddenEdit)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenDelete && MyVueModelFor.IsHiddenDelete)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            //var content = output.GetChildContentAsync().GetAwaiter().GetResult().GetContent();
            //if (content.ToLower() == "yes")
            //{
            //    output.Attributes.SetAttribute("class", "text-primary");
            //}
        }
    }
    [HtmlTargetElement("td", Attributes = "my-vue-model-for")]
    public class MyVueTdTagHelper : TagHelper
    {
        public CustomDisplayModel MyVueModelFor { get; set; }

        public bool MyHiddenIndex { get; set; }
        public bool MyHiddenCreate { get; set; }
        public bool MyHiddenDetails { get; set; }
        public bool MyHiddenEdit { get; set; }
        public bool MyHiddenDelete { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            //var content = output.GetChildContentAsync().GetAwaiter().GetResult().GetContent();
            //if (content.ToLower() == "yes")
            //{
            //    output.Attributes.SetAttribute("class", "text-primary");
            //}

            if (MyHiddenIndex && MyVueModelFor.IsHiddenIndex)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenCreate && MyVueModelFor.IsHiddenCreate)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenDetails && MyVueModelFor.IsHiddenDetails)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenEdit && MyVueModelFor.IsHiddenEdit)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenDelete && MyVueModelFor.IsHiddenDelete)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyVueModelFor.IsVueComputed)
            {
                output.Content.SetHtmlContent($"{{{{ MyVueComputed{MyVueModelFor.RawName}(todo) }}}}")
                    .AppendHtml($"<input :name=\"buildName(index, '{MyVueModelFor.RawName}')\" type=\"hidden\" :value=\"MyVueComputed{MyVueModelFor.RawName}(todo)\" />");
            }
            else
            {
                var childContent = output.GetChildContentAsync().GetAwaiter().GetResult().GetContent();
                output.Content.SetHtmlContent($"{{{{ todo.{MyVueModelFor.RawName} }}}}").AppendHtml(childContent);
            }
        }
    }
}