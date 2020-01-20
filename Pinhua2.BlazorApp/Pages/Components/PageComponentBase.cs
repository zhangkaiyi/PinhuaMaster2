using AutoMapper;
using Klazor;
using Microsoft.AspNetCore.Components;
using Pinhua2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.BlazorApp.Pages.Components
{
    public class PageComponentBase : KComponentBase
    {
        [Inject] public Pinhua2Context PinhuaContext { get; set; }
        [Inject] public IMapper Mapper { get; set; }
    }
}
