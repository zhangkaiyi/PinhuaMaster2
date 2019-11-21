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
    [HtmlTargetElement(Attributes = "my-model-for")]
    public class MyModelForHidden : TagHelper
    {
        public CustomDisplayModel MyModelFor { get; set; }

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

            if (MyHiddenIndex && MyModelFor.IsHiddenIndex)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenCreate && MyModelFor.IsHiddenCreate)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenDetails && MyModelFor.IsHiddenDetails)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenEdit && MyModelFor.IsHiddenEdit)
            {
                CreateOrMergeAttribute("class", "d-none", output);
            }

            if (MyHiddenDelete && MyModelFor.IsHiddenDelete)
            {
                CreateOrMergeAttribute("class", "d-none", output);
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