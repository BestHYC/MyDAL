﻿using MyDAL.Core.Bases;
using MyDAL.Impls;
using MyDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyDAL.UserFacade.Query
{
    public sealed class DistinctQ<M>
        : Operator, IAll<M>, IAllPagingList<M>, ITop<M>, IFirstOrDefault<M>, Interfaces.IList<M>, IPagingList<M>, IPagingListO<M>, ICount<M>
        where M : class
    {
        internal DistinctQ(Context dc) 
            : base(dc)
        {
        }

        /// <summary>
        /// 单表数据查询
        /// </summary>
        /// <returns>返回全表数据</returns>
        public async Task<List<M>> AllAsync()
        {
            return await new AllImpl<M>(DC).AllAsync();
        }
        /// <summary>
        /// 单表数据查询
        /// </summary>
        /// <typeparam name="VM">ViewModel</typeparam>
        /// <returns>返回全表数据</returns>
        public async Task<List<VM>> AllAsync<VM>()
            where VM : class
        {
            return await new AllImpl<M>(DC).AllAsync<VM>();
        }
        public async Task<List<F>> AllAsync<F>(Expression<Func<M, F>> propertyFunc)
        {
            return await new AllImpl<M>(DC).AllAsync<F>(propertyFunc);
        }
        public async Task<List<string>> AllAsync(Expression<Func<M, string>> propertyFunc)
        {
            return await new AllImpl<M>(DC).AllAsync(propertyFunc);
        }

        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns>返回全表分页数据</returns>
        public async Task<PagingList<M>> PagingAllListAsync(int pageIndex, int pageSize)
        {
            return await new AllPagingListImpl<M>(DC).PagingAllListAsync(pageIndex, pageSize);
        }
        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <typeparam name="VM">ViewModel</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns>返回全表分页数据</returns>
        public async Task<PagingList<VM>> PagingAllListAsync<VM>(int pageIndex, int pageSize)
            where VM : class
        {
            return await new AllPagingListImpl<M>(DC).PagingAllListAsync<VM>(pageIndex, pageSize);
        }

        /// <summary>
        /// 单表数据查询
        /// </summary>
        /// <param name="count">top count</param>
        /// <returns>返回 top count 条数据</returns>
        public async Task<List<M>> TopAsync(int count)
        {
            return await new TopImpl<M>(DC).TopAsync(count);
        }
        /// <summary>
        /// 单表数据查询
        /// </summary>
        /// <param name="count">top count</param>
        /// <returns>返回 top count 条数据</returns>
        public async Task<List<VM>> TopAsync<VM>(int count)
            where VM : class
        {
            return await new TopImpl<M>(DC).TopAsync<VM>(count);
        }
        /// <summary>
        /// 单表数据查询
        /// </summary>
        /// <param name="count">top count</param>
        /// <returns>返回 top count 条数据</returns>
        public async Task<List<VM>> TopAsync<VM>(int count, Expression<Func<M, VM>> columnMapFunc)
            where VM : class
        {
            return await new TopImpl<M>(DC).TopAsync<VM>(count, columnMapFunc);
        }

        /// <summary>
        /// 单表单条数据查询
        /// </summary>
        public async Task<M> FirstOrDefaultAsync()
        {
            return await new FirstOrDefaultImpl<M>(DC).FirstOrDefaultAsync();
        }
        /// <summary>
        /// 单表单条数据查询
        /// </summary>
        /// <typeparam name="VM">ViewModel</typeparam>
        public async Task<VM> FirstOrDefaultAsync<VM>()
            where VM : class
        {
            return await new FirstOrDefaultImpl<M>(DC).FirstOrDefaultAsync<VM>();
        }
        /// <summary>
        /// 单表单条数据查询
        /// </summary>
        /// <typeparam name="VM">ViewModel</typeparam>
        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<M, T>> columnMapFunc)
        {
            return await new FirstOrDefaultImpl<M>(DC).FirstOrDefaultAsync<T>(columnMapFunc);
        }

        /// <summary>
        /// 单表多条数据查询
        /// </summary>
        public async Task<List<M>> ListAsync()
        {
            return await new ListImpl<M>(DC).ListAsync();
        }
        /// <summary>
        /// 单表多条数据查询
        /// </summary>
        /// <typeparam name="VM">ViewModel</typeparam>
        public async Task<List<VM>> ListAsync<VM>()
            where VM : class
        {
            return await new ListImpl<M>(DC).ListAsync<VM>();
        }
        /// <summary>
        /// 单表多条数据查询
        /// </summary>
        public async Task<List<VM>> ListAsync<VM>(Expression<Func<M, VM>> columnMapFunc)
            where VM : class
        {
            return await new ListImpl<M>(DC).ListAsync<VM>(columnMapFunc);
        }
        /// <summary>
        /// 单表多条数据查询
        /// </summary>
        public async Task<List<M>> ListAsync(int topCount)
        {
            return await new ListImpl<M>(DC).ListAsync(topCount);
        }
        /// <summary>
        /// 单表多条数据查询
        /// </summary>
        public async Task<List<VM>> ListAsync<VM>(int topCount)
            where VM : class
        {
            return await new ListImpl<M>(DC).ListAsync<VM>(topCount);
        }
        /// <summary>
        /// 单表多条数据查询
        /// </summary>
        public async Task<List<VM>> ListAsync<VM>(int topCount, Expression<Func<M, VM>> columnMapFunc)
            where VM : class
        {
            return await new ListImpl<M>(DC).ListAsync<VM>(topCount, columnMapFunc);
        }

        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        public async Task<PagingList<M>> PagingListAsync(int pageIndex, int pageSize)
        {
            return await new PagingListImpl<M>(DC).PagingListAsync(pageIndex, pageSize);
        }
        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <typeparam name="VM">ViewModel</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        public async Task<PagingList<VM>> PagingListAsync<VM>(int pageIndex, int pageSize)
            where VM : class
        {
            return await new PagingListImpl<M>(DC).PagingListAsync<VM>(pageIndex, pageSize);
        }
        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <typeparam name="VM">ViewModel</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        public async Task<PagingList<VM>> PagingListAsync<VM>(int pageIndex, int pageSize, Expression<Func<M, VM>> columnMapFunc)
            where VM : class
        {
            return await new PagingListImpl<M>(DC).PagingListAsync<VM>(pageIndex, pageSize, columnMapFunc);
        }

        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        public async Task<PagingList<M>> PagingListAsync(PagingQueryOption option)
        {
            return await new PagingListOImpl<M>(DC).PagingListAsync(option);
        }
        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <typeparam name="VM">ViewModel</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        public async Task<PagingList<VM>> PagingListAsync<VM>(PagingQueryOption option)
            where VM : class
        {
            return await new PagingListOImpl<M>(DC).PagingListAsync<VM>(option);
        }
        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <typeparam name="VM">ViewModel</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页条数</param>
        public async Task<PagingList<VM>> PagingListAsync<VM>(PagingQueryOption option, Expression<Func<M, VM>> columnMapFunc)
            where VM : class
        {
            return await new PagingListOImpl<M>(DC).PagingListAsync<VM>(option, columnMapFunc);
        }

        /// <summary>
        /// 查询符合条件数据条目数
        /// </summary>
        public async Task<int> CountAsync()
        {
            return await new CountImpl<M>(DC).CountAsync();
        }
        /// <summary>
        /// 查询符合条件数据条目数
        /// </summary>
        public async Task<int> CountAsync<F>(Expression<Func<M, F>> propertyFunc)
        {
            return await new CountImpl<M>(DC).CountAsync(propertyFunc);
        }

    }
}
