using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public class view_AllOrdersPay : view_AllOrders
    {
        public decimal? 已收 { get; set; }
        public decimal? 待收 { get; set; }
        public decimal? 已付 { get; set; }
        public decimal? 待付 { get; set; }
    }

    public class view_AllOrders2Pay_pay
    {
        public decimal? 已收 { get; set; }
        public decimal? 待收 { get; set; }
        public decimal? 已付 { get; set; }
        public decimal? 待付 { get; set; }
    }
    public class view_AllOrders2Pay : view_AllOrders2
    {
        public view_AllOrders2Pay_pay Pay { get; set; }
    }
}
