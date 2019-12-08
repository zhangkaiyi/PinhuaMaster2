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
    public class MyVModelModel
    {
        public string Prefix { get; set; }
        public string Name { get; set; }
    }

    public class MyVOnModel
    {
        public string Event { get; set; }
        public string Method { get; set; }
    }

    public class MyVBindModel
    {
        public string Prop { get; set; }
        public string Method { get; set; }
        public string Args { get; set; }
    }

    [HtmlTargetElement(Attributes = "my-use-vue")]
    public class MyUseVue : TagHelper
    {
        [HtmlAttributeName("my-use-vue")]
        public CustomDisplayModel Model { get; set; }

        [HtmlAttributeName("my-v-model")]
        public MyVModelModel MyVModel { get; set; }

        [HtmlAttributeName("my-v-model-force")]
        public MyVModelModel MyVModelForce { get; set; }

        [HtmlAttributeName("my-v-on")]
        public MyVOnModel MyVOn { get; set; }

        [HtmlAttributeName("my-v-on-force")]
        public MyVOnModel MyVOnForce { get; set; }

        [HtmlAttributeName("my-v-bind")]
        public IList<MyVBindModel> MyVBind { get; set; }

        [HtmlAttributeName("my-v-bind-force")]
        public IList<MyVBindModel> MyVBindForce { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            // v-model
            if (MyVModelForce != null)
            {

                output.Attributes.SetHtmlStringAttribute("v-model", $"{MyVModelForce.Prefix}.{MyVModelForce.Name}");
            }
            else if (Model.IsVueVModel)
            {
                if (MyVModel != null)
                {
                    output.Attributes.SetHtmlStringAttribute("v-model", $"{MyVModel.Prefix}.{MyVModel.Name}");
                }
            }

            // v-on
            if (MyVOnForce != null)
            {
                output.Attributes.SetHtmlStringAttribute($"v-on:{MyVOnForce.Event}", $"{MyVOnForce.Method}");
            }
            else if (Model.IsVueVOn)
            {
                if (MyVOn != null)
                {
                    output.Attributes.SetHtmlStringAttribute($"v-on:{MyVOn.Event}", $"{MyVOn.Method}");
                }

            }

            // v-bind
            if (MyVBindForce != null && MyVBindForce.Count > 0)
            {
                foreach (var item in MyVBindForce)
                {
                    output.Attributes.SetHtmlStringAttribute($"v-bind:{item.Prop}", $"{item.Method}");
                }
            }
            else if (Model.IsVueVBind)
            {
                if (MyVBind != null && MyVBind.Count > 0)
                {
                    foreach (var item in MyVBind)
                    {
                        output.Attributes.SetHtmlStringAttribute($"v-bind:{item.Prop}", $"{item.Method}");
                    }
                }

            }
        }
    }
}