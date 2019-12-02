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
    public enum MyModelHiddenType
    {
        Index,
        Create,
        Details,
        Edit,
        Delete,
        Ref,
    }

    [HtmlTargetElement(Attributes = "my-model-hidden")]
    public class MyModelHidden : TagHelper
    {
        [HtmlAttributeName("my-model-hidden")]
        public CustomDisplayModel Model { get; set; }

        [HtmlAttributeName("hidden-type")]
        public MyModelHiddenType HiddenType { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (HiddenType == MyModelHiddenType.Index && Model.IsHiddenIndex)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (HiddenType == MyModelHiddenType.Create && Model.IsHiddenCreate)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (HiddenType == MyModelHiddenType.Details && Model.IsHiddenDetails)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (HiddenType == MyModelHiddenType.Edit && Model.IsHiddenEdit)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (HiddenType == MyModelHiddenType.Delete && Model.IsHiddenDelete)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }

            if (HiddenType == MyModelHiddenType.Ref && Model.IsHiddenRef)
            {
                output.CreateOrMergeAttribute("class", "d-none");
            }
        }
    }
}