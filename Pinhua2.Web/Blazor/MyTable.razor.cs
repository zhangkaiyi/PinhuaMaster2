using Blazui.Component;
using Microsoft.AspNetCore.Components;
using Pinhua2.Data;
using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Blazor
{
    public class TestData
    {
        public DateTime Time { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public partial class MyTable : ComponentBase
    {
        protected List<TestData> Datas = new List<TestData>();
        protected List<TestData> LargeDatas = new List<TestData>();
        private List<view_AllOrdersPay> dataSource { get; set; }


        [Inject]
        MessageService MessageService { get; set; }

        [Inject]
        Pinhua2Context pinhua2 { get; set; }

        protected override void OnInitialized()
        {
            Datas.Add(new TestData()
            {
                Address = "地址1",
                Name = "张三",
                Time = DateTime.Now
            });
            Datas.Add(new TestData()
            {
                Address = "地址2",
                Name = "张三1",
                Time = DateTime.Now
            });
            Datas.Add(new TestData()
            {
                Address = "地址3",
                Name = "张三3",
                Time = DateTime.Now
            });
            LargeDatas.AddRange(Datas);
            LargeDatas.AddRange(Datas);
            LargeDatas.AddRange(Datas);
            LargeDatas.AddRange(Datas);
            LargeDatas.AddRange(Datas);

            dataSource = pinhua2.list_收付待收().ToList();

        }

        public void Edit(TestData testData)
        {
            MessageService.Show($"正在编辑 " + testData.Name);
        }
        public void Del(TestData testData)
        {
            MessageService.Show($"正在删除 " + testData.Name, MessageType.Warning);
        }
    }
}
