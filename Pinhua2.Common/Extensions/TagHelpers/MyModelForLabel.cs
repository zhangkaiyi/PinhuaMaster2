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
    [HtmlTargetElement("label", Attributes = "my-model-for")]
    public class MyModelForLabel : TagHelper
    {
        public CustomDisplayModel MyModelFor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.Attributes.AddHtmlStringAttribute("for", $"{MyModelFor.RawName}");
            output.Content.SetHtmlContent(MyModelFor.Name.ToString());

            if (MyModelFor.IsRequired)
            {
                output.CreateOrMergeAttribute("class", "text-danger");
            }
        }
    }
}