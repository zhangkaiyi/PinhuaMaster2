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
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenCreate && MyVueModelFor.IsHiddenCreate)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenDetails && MyVueModelFor.IsHiddenDetails)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenEdit && MyVueModelFor.IsHiddenEdit)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenDelete && MyVueModelFor.IsHiddenDelete)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            //var content = output.GetChildContentAsync().GetAwaiter().GetResult().GetContent();
            //if (content.ToLower() == "yes")
            //{
            //    output.Attributes.SetAttribute("class", "text-primary");
            //}
        }

        private void CreateOrMergeAttribute(string name, object content, TagHelperOutput output)
        {
            var currentAttribute = output.Attributes.FirstOrDefault(attribute => attribute.Name == name);
            if (currentAttribute == null)
            {
                var attribute = new TagHelperAttribute(name, content);
                output.Attributes.Add(attribute);
            }
            else
            {
                var newAttribute = new TagHelperAttribute(
                    name,
                    $"{currentAttribute.Value.ToString()} {content.ToString()}",
                    currentAttribute.ValueStyle);
                output.Attributes.Remove(currentAttribute);
                output.Attributes.Add(newAttribute);
            }
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
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenCreate && MyVueModelFor.IsHiddenCreate)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenDetails && MyVueModelFor.IsHiddenDetails)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenEdit && MyVueModelFor.IsHiddenEdit)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenDelete && MyVueModelFor.IsHiddenDelete)
            {
                CreateOrMergeAttribute("class", "d-none", output);
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

        private void CreateOrMergeAttribute(string name, object content, TagHelperOutput output)
        {
            var currentAttribute = output.Attributes.FirstOrDefault(attribute => attribute.Name == name);
            if (currentAttribute == null)
            {
                var attribute = new TagHelperAttribute(name, content);
                output.Attributes.Add(attribute);
            }
            else
            {
                var newAttribute = new TagHelperAttribute(
                    name,
                    $"{currentAttribute.Value.ToString()} {content.ToString()}",
                    currentAttribute.ValueStyle);
                output.Attributes.Remove(currentAttribute);
                output.Attributes.Add(newAttribute);
            }
        }
    }
}