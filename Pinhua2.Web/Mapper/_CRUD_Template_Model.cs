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
        public string Title { get; set; } = string.Empty;
        public object Data { get; set; } = new object();
        //public Type DataType { get; set; }
    }

    public class _CRUD_Template_Model_Details
    {
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public IEnumerable<object> Data { get; set; } = new List<object>();
        //public Type DataType { get; set; }
    }

    public class _CRUD_Template_Model_SelectModal
    {
        public string Title { get; set; } = "商品列表";
        public string Url { get; set; } = "/api/product/all";
        public Type DataType { get; set; } = typeof(vm_商品_地板);
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

    public class MyTemplateCRUD
    {
        private _CRUD_Template_Model_Main _main { get; set; } = new _CRUD_Template_Model_Main();
        private IList<_CRUD_Template_Model_Details> _detailsList { get; set; } = new List<_CRUD_Template_Model_Details>();
        private _CRUD_Template_Model_SelectModal _selectModal { get; set; } = new _CRUD_Template_Model_SelectModal();
        private _CRUD_Template_Model _model { get; set; } = new _CRUD_Template_Model();

        static public MyTemplateCRUD Create()
        {
            return new MyTemplateCRUD();
        }

        public MyTemplateCRUD SetMain(_CRUD_Template_Model_Main main)
        {
            _main = main;
            return this;
        }

        public MyTemplateCRUD AddDetails(_CRUD_Template_Model_Details details)
        {
            _detailsList = _detailsList ?? new List<_CRUD_Template_Model_Details>();
            _detailsList.Add(details);
            return this;
        }

        public MyTemplateCRUD SetDetailsList(IList<_CRUD_Template_Model_Details> detailsList)
        {
            _detailsList = detailsList;
            return this;
        }

        public MyTemplateCRUD SetSelectModal(_CRUD_Template_Model_SelectModal selectModal)
        {
            _selectModal = selectModal;
            return this;
        }

        public _CRUD_Template_Model GetModel()
        {
            _model = new _CRUD_Template_Model
            {
                RecordMain = _main,
                RecordDetailsArray = _detailsList,
                SelectModal = _selectModal
            };
            return _model;
        }
    }

    public class MyTemplateIndex
    {
        private _CRUD_Template_Model_Index _model { get; set; }
        private _CRUD_Template_Model_Details _mainList { get; set; }
        private IList<_CRUD_Template_Model_Details> _detailsList { get; set; }

        static public MyTemplateIndex Create()
        {
            return new MyTemplateIndex();
        }

        public MyTemplateIndex AddDetails(_CRUD_Template_Model_Details details)
        {
            _detailsList = _detailsList ?? new List<_CRUD_Template_Model_Details>();
            _detailsList.Add(details);
            return this;
        }

        public MyTemplateIndex SetDetailsList(IList<_CRUD_Template_Model_Details> detailsList)
        {
            _detailsList = detailsList;
            return this;
        }

        public _CRUD_Template_Model_Index GetModel()
        {
            _model = new _CRUD_Template_Model_Index
            {
                RecordMains = _mainList,
                RecordDetailsArray = _detailsList
            };
            return _model;
        }
    }
}
