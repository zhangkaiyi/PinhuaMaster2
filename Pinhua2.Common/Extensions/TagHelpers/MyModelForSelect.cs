﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
    [HtmlTargetElement("select", Attributes = "my-model-for")]
    public class MyModelForSelect : TagHelper
    {
        public CustomDisplayModel MyModelFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.Attributes.SetHtmlStringAttribute("id", $"{MyModelFor.RawName}");
            output.Attributes.SetHtmlStringAttribute("name", $"vm_Main.{MyModelFor.RawName}");

            if (MyModelFor.IsReadonly)
            {
                output.CreateOrMergeAttribute("disabled", true);
            }
        }
    }
}