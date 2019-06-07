using Microsoft.EntityFrameworkCore;
using Pinhua2.Data.Models;
using Pinhua2.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Newtonsoft.Json.Linq;

namespace Pinhua2.Data
{
    public static partial class Pinhua2ListExtension
    {
        public static IEnumerable<view_AllOrdersIO> list_订单待发(this Pinhua2Context context)
        {
            var l = from m in context.view_全部订单收发()
                    where m.待发 > 0
                    select m;

            return l.ToList();
        }

        public static IEnumerable<view_AllOrdersIO> list_订单待发(this Pinhua2Context context, string customerId)
        {
            var l = from m in context.list_订单待发()
                    where m.往来号 == customerId
                    select m;

            return l;
        }

        public static IEnumerable<view_AllOrdersIO> list_订单待收(this Pinhua2Context context)
        {
            var l = from m in context.view_全部订单收发()
                    where m.待收 > 0
                    select m;

            return l.ToList();
        }

        public static IEnumerable<view_AllOrdersIO> list_订单待收(this Pinhua2Context context, string customerId)
        {
            var l = from m in context.list_订单待发()
                    where m.往来号 == customerId
                    select m;

            return l;
        }

        public static IEnumerable<view_AllOrdersPay> list_收付待收(this Pinhua2Context context)
        {
            var l = from m in context.view_全部订单收付()
                    where m.待收 > 0
                    select m;

            return l.ToList();
        }

        public static IEnumerable<view_AllOrdersPay> list_收付待收(this Pinhua2Context context, string customerId)
        {
            var l = from m in context.list_收付待收()
                    where m.往来号 == customerId
                    select m;

            return l;
        }

        public static IEnumerable<view_AllOrdersPay> list_收付待付(this Pinhua2Context context)
        {
            var l = from m in context.view_全部订单收付()
                    where m.待付 > 0
                    select m;

            return l.ToList();
        }

        public static IEnumerable<view_AllOrdersPay> list_收付待付(this Pinhua2Context context, string customerId)
        {
            var l = from m in context.list_收付待付()
                    where m.往来号 == customerId
                    select m;

            return l;
        }
    }
}
