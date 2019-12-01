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
    [HtmlTargetElement(Attributes = "my-vue-for")]
    public class MyVueForTagHelper : TagHelper
    {
        [HtmlAttributeName("my-vue-for")]
        public CustomDisplayModel Model { get; set; }

        [HtmlAttributeName("my-v-model-prefix")]
        public string MyVModelPrefix { get; set; }

        [HtmlAttributeName("my-v-on")]
        public string MyVOn { get; set; }

        [HtmlAttributeName("my-v-bind")]
        public string MyVBind { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (Model.IsVueVModel)
            {
                if (string.IsNullOrEmpty(MyVModelPrefix))
                {
                    output.Attributes.SetAttribute("v-model", $"{Model.VueVModelTargetPrefix}.{Model.RawName}");
                }
                else
                {
                    output.Attributes.SetAttribute("v-model", $"{MyVModelPrefix}.{Model.RawName}");
                }

            }
        }
    }
}