using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Html;

namespace TagHelpers
{
    public static class TagHelperExtensions
    {
        static public void CreateOrMergeAttribute(this TagHelperOutput output, string name, object content)
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

        static public void SetHtmlStringAttribute(this TagHelperAttributeList attributes, string name, object value)
        {
            if (value?.GetType() == typeof(string))
                attributes.SetAttribute(name, new HtmlString((string)value));
            else
                attributes.SetAttribute(name, value);
        }

        static public void AddHtmlStringAttribute(this TagHelperAttributeList attributes, string name, object value)
        {
            if (value?.GetType() == typeof(string))
                attributes.Add(name, new HtmlString((string)value));
            else
                attributes.Add(name, value);
        }
    }
}
