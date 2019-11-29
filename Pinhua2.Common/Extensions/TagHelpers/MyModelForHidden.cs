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
        public bool MyHiddenRef { get; set; }
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
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenCreate && MyModelFor.IsHiddenCreate)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenDetails && MyModelFor.IsHiddenDetails)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenEdit && MyModelFor.IsHiddenEdit)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenDelete && MyModelFor.IsHiddenDelete)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (MyHiddenRef && MyModelFor.IsHiddenRef)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }
        }
    }
}