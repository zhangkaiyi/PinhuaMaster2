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
    [HtmlTargetElement("input", Attributes = "my-model-readonly")]
    public class MyModelReadonly : TagHelper
    {
        [HtmlAttributeName("my-model-readonly")]
        public CustomDisplayModel Model { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (!Model.Editable)
            {
                output.Attributes.SetHtmlStringAttribute("readonly", "readonly");
            }
        }
    }
}