using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinhua2.Data.Models
{
    public class view_AllOrdersIO : view_AllOrders
    {
        public decimal? 已收 { get; set; }
        public decimal? 待收 { get; set; }
        public decimal? 已发 { get; set; }
        public decimal? 待发 { get; set; }
    }

    public class view_AllOrders2IO_io
    {
        public decimal? 已收 { get; set; }
        public decimal? 待收 { get; set; }
        public decimal? 已发 { get; set; }
        public decimal? 待发 { get; set; }
    }

    public class view_AllOrders2IO : view_AllOrders2
    {
        public view_AllOrders2IO_io IO { get; set; }
    }
}
