﻿using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.JSInterop;
using Pinhua2.Common.Attributes;
using Pinhua2.Common.DataAnnotations;
using System.Linq.Expressions;
using Pinhua2.ViewModels;
using Klazor;
using AutoMapper;
using Pinhua2.Data;
using Microsoft.EntityFrameworkCore;
using Pinhua2.BlazorApp.Pages.Components;

namespace Pinhua2.BlazorApp.Pages.基础数据.字典
{
    public abstract class RBase : _CRUDBase
    {
        [Parameter] public int RecordId { get; set; }

        protected dto字典 main = new dto字典();

        protected KTable2 detailsTable;
        protected List<dto字典D> detailsTableDataSource { get; set; } = new List<dto字典D>();

        protected override void OnInitialized()
        {
            main = Mapper.Map<dto字典>(PinhuaContext.tb_字典表.AsNoTracking().FirstOrDefault(m => m.RecordId == RecordId));
            detailsTableDataSource = Mapper.ProjectTo<dto字典D>(PinhuaContext.tb_字典表D.AsNoTracking().Where(m => m.RecordId == RecordId)).ToList();
        }
    }
}
