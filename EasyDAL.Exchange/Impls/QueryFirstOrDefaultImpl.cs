﻿using MyDAL.Common;
using MyDAL.Core;
using MyDAL.Enums;
using MyDAL.Helper;
using MyDAL.Interfaces;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyDAL.Impls
{
    internal class QueryFirstOrDefaultImpl<M>
        : Impler, IQueryFirstOrDefault<M>
    {
        internal QueryFirstOrDefaultImpl(Context dc) 
            : base(dc)
        {
        }

        public async Task<M> QueryFirstOrDefaultAsync()
        {
            return await QueryFirstOrDefaultAsyncHandle<M, M>();
        }

        public async Task<VM> QueryFirstOrDefaultAsync<VM>()
        {
            return await QueryFirstOrDefaultAsyncHandle<M, VM>();
        }

        public async Task<VM> QueryFirstOrDefaultAsync<VM>(Expression<Func<M, VM>> func)
        {
            SelectMHandle(func);
            return await QueryFirstOrDefaultAsyncHandle<M, VM>();
        }
    }

    internal class QueryFirstOrDefaultXImpl
        : Impler, IQueryFirstOrDefaultX
    {
        internal QueryFirstOrDefaultXImpl(Context dc) 
            : base(dc)
        {
        }

        public async Task<M> QueryFirstOrDefaultAsync<M>()
        {
            SelectMHandle<M>();
            return await SqlHelper.QueryFirstOrDefaultAsync<M>(
                DC.Conn,
                DC.SqlProvider.GetSQL<M>(UiMethodEnum.JoinQueryFirstOrDefaultAsync)[0],
                DC.GetParameters());
        }

        public async Task<VM> QueryFirstOrDefaultAsync<VM>(Expression<Func<VM>> func)
        {
            SelectMHandle(func);
            return await SqlHelper.QueryFirstOrDefaultAsync<VM>(
                DC.Conn,
                DC.SqlProvider.GetSQL<VM>(UiMethodEnum.JoinQueryFirstOrDefaultAsync)[0],
                DC.GetParameters());
        }
    }
}
