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
    [HtmlTargetElement("input", Attributes = "my-model-for")]
    public class MyModelForInput : TagHelper
    {
        [HtmlAttributeName("my-model-for")]
        public CustomDisplayModel Model { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.Attributes.SetHtmlStringAttribute("id", $"{Model.RawName}");
            output.Attributes.SetHtmlStringAttribute("value", $"{(Model.IsSysColumn ? Model.RawValue : Model.Value)}");
            output.Attributes.SetHtmlStringAttribute("name", $"vm_Main.{Model.RawName}");

            if (!Model.Editable)
            {
                output.Attributes.SetHtmlStringAttribute("readonly", "readonly");
            }

            if (Model.IsDatetime && !Model.IsSysColumn)
            {
                output.Attributes.AddHtmlStringAttribute("data-provide", "datepicker");
                output.Attributes.AddHtmlStringAttribute("data-date-format", "yyyy-mm-dd");
                output.Attributes.AddHtmlStringAttribute("readonly", "true");
                output.CreateOrMergeAttribute("class", "bg-white");
            }
        }
    }
}