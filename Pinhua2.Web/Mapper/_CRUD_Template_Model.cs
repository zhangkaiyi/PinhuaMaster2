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
        public IEnumerable<object> Data { get; set; }
        //public Type DataType { get; set; }
    }

    public class _CRUD_Template_Model
    {
        public _CRUD_Template_Model_Main RecordMain { get; set; }
        public IEnumerable<_CRUD_Template_Model_Details> RecordDetailsArray { get; set; }
    }
}
