using AutoMapper;
using Pinhua2.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pinhua2.Web.Mapper
{
    public class _CRUD_Template_Model_Main
    {
        public string Title { get; set; }
        public object Data { get; set; }
        //public Type DataType { get; set; }
    }

    public class _CRUD_Template_Model_Details
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public IEnumerable<object> Data { get; set; }
        //public Type DataType { get; set; }
    }

    public class _CRUD_Template_Model_SelectModal
    {
        public string Title { get; set; } = "商品列表";
        public string Url { get; set; } = "/api/product/all";
        public Type DataType { get; set; } = typeof(tb_商品表);
    }

    public class _CRUD_Template_Model
    {
        public _CRUD_Template_Model_Main RecordMain { get; set; } = new _CRUD_Template_Model_Main();
        public IList<_CRUD_Template_Model_Details> RecordDetailsArray { get; set; } = new List<_CRUD_Template_Model_Details>();
        public _CRUD_Template_Model_SelectModal SelectModal { get; set; } = new _CRUD_Template_Model_SelectModal();
    }

    public class _CRUD_Template_Model_Index
    {
        public _CRUD_Template_Model_Details RecordMains { get; set; } = new _CRUD_Template_Model_Details();
        public IList<_CRUD_Template_Model_Details> RecordDetailsArray { get; set; } = new List<_CRUD_Template_Model_Details>();
    }
}
