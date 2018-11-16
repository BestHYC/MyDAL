﻿using MyDAL.Core.Bases;
using MyDAL.Core.Enums;
using MyDAL.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyDAL.Impls
{
    internal class QueryFirstOrDefaultImpl<M>
        : Impler, IQueryFirstOrDefault<M>
        where M : class
    {
        internal QueryFirstOrDefaultImpl(Context dc)
            : base(dc)
        {
        }

        public async Task<M> FirstOrDefaultAsync()
        {
            DC.Method = UiMethodEnum.FirstOrDefaultAsync;
            DC.SqlProvider.GetSQL();
            return await DC.DS.ExecuteReaderSingleRowAsync<M>();
        }

        public async Task<VM> FirstOrDefaultAsync<VM>()
            where VM:class
        {
            SelectMHandle<M, VM>();
            DC.DPH.SetParameter();
            DC.Method = UiMethodEnum.FirstOrDefaultAsync;
            DC.SqlProvider.GetSQL();
            return await DC.DS.ExecuteReaderSingleRowAsync<VM>();
        }

        public async Task<VM> FirstOrDefaultAsync<VM>(Expression<Func<M, VM>> func)
            where VM:class
        {
            SelectMHandle(func);
            DC.DPH.SetParameter();
            DC.Method = UiMethodEnum.FirstOrDefaultAsync;
            DC.SqlProvider.GetSQL();
            return await DC.DS.ExecuteReaderSingleRowAsync<VM>();
        }
    }

    internal class QueryFirstOrDefaultXImpl
        : Impler, IQueryFirstOrDefaultX
    {
        internal QueryFirstOrDefaultXImpl(Context dc)
            : base(dc)
        {
        }

        public async Task<M> FirstOrDefaultAsync<M>()
            where M:class
        {
            SelectMHandle<M>();
            DC.DPH.SetParameter();
            DC.Method = UiMethodEnum.JoinFirstOrDefaultAsync;
            DC.SqlProvider.GetSQL();
            return await DC.DS.ExecuteReaderSingleRowAsync<M>();
        }

        public async Task<VM> FirstOrDefaultAsync<VM>(Expression<Func<VM>> func)
            where VM:class
        {
            SelectMHandle(func);
            DC.DPH.SetParameter();
            DC.Method = UiMethodEnum.JoinFirstOrDefaultAsync;
            DC.SqlProvider.GetSQL();
            return await DC.DS.ExecuteReaderSingleRowAsync<VM>();
        }
    }
}
