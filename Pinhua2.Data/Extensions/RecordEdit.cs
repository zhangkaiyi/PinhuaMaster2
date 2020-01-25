using Microsoft.EntityFrameworkCore;
using Pinhua2.Data.Models;
using Pinhua2.Data.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Pinhua2.Data
{
    public static class RecordEditExtension
    {
        public static TDst RecordEdit<TSrc, TDst>(this Pinhua2Context context, TSrc src,
            Action<TSrc> Editing = null/*, Action<TRemote> AfterNew = null*/)
            where TSrc : _BaseTableMain
            where TDst : _BaseTableMain
        {
            var dst = context.Set<TDst>().FirstOrDefault(m => m.RecordId == src.RecordId);
            if (dst == null)
                return null;

            Editing?.Invoke(src);

            src.CreateTime = dst.CreateTime;
            src.CreateUser = dst.CreateUser;
            src.LastEditTime = DateTime.Now;
            src.LastEditUser = src.LastEditUser ?? "张凯译";

            StaticAutoMapper.Current.Map<TSrc, TDst>(src, dst);
            context.Entry<TDst>(dst).State = EntityState.Modified;
            context.SaveChanges();

            return dst;
        }

        public static bool TryRecordEdit<TSrc, TDst>(this Pinhua2Context context, TSrc src, out TDst outDst, Action<TSrc> Editing = null)
        where TSrc : _BaseTableMain
        where TDst : _BaseTableMain
        {
            var dst = context.Set<TDst>().FirstOrDefault(m => m.RecordId == src.RecordId);
            if (dst == null)
            {
                outDst = null;
                return false;
            }

            Editing?.Invoke(src);

            src.CreateTime = dst.CreateTime;
            src.CreateUser = dst.CreateUser;
            src.LastEditTime = DateTime.Now;
            src.LastEditUser = src.LastEditUser ?? "张凯译";

            StaticAutoMapper.Current.Map<TSrc, TDst>(src, dst);
            context.Entry<TDst>(dst).State = EntityState.Modified;
            var ret = context.SaveChanges();

            if (ret > 0)
            {
                outDst = dst;
                return true;
            }
            else
            {
                outDst = null;
                return false;
            }
        }

        public static IQueryable<TDstD> RecordDetailsEdit<TSrc, TSrcD, TDst, TDstD>(this Pinhua2Context context, TSrc dto, IList<TSrcD> srcDSet,
            Action<TSrcD> Adding = null, Action<TSrcD> Updating = null, Action<TDstD> Deleting = null)
            where TSrc : _BaseTableMain
            where TSrcD : _BaseTableDetail
            where TDst : _BaseTableMain
            where TDstD : _BaseTableDetail
        {
            var dst = context.Set<TDst>().AsNoTracking().FirstOrDefault(r => r.RecordId == dto.RecordId);
            if (dst == null)
                return null;

            var dstDSet = context.Set<TDstD>().Where(d => d.RecordId == dst.RecordId);
            foreach (var DstD in dstDSet)
            {
                if (!srcDSet.Any(p => p.Idx == DstD.Idx)) // 新列表没有数据库中的Idx，则删除
                {
                    Deleting?.Invoke(DstD);
                    context.Remove<TDstD>(DstD);
                }
            }

            foreach (var srcD in srcDSet)
            {
                srcD.RecordId = dst.RecordId;

                if (dstDSet.Any(d => d.Idx == srcD.Idx)) // Idx有相同的，则修改
                {
                    Updating?.Invoke(srcD);

                    // 将删除的重新标记为修改
                    var dstD = dstDSet.FirstOrDefault(m => m.Idx == srcD.Idx);
                    context.Attach<TDstD>(dstD).State = EntityState.Modified;
                    StaticAutoMapper.Current.Map<TSrcD, TDstD>(srcD, dstD);
                }
                else if (!dstDSet.Any(d => d.Idx == srcD.Idx)) // Idx没有相同的，则添加
                {
                    Adding?.Invoke(srcD);
                    var dstD = StaticAutoMapper.Current.Map<TDstD>(srcD);
                    context.Attach<TDstD>(dstD).State = EntityState.Added;
                }
            }

            return dstDSet;
        }

        public static bool TryRecordDetailsEdit<TSrc, TSrcD, TDst, TDstD>(this Pinhua2Context context, TSrc dto, IEnumerable<TSrcD> srcDSet,
            out IEnumerable<TDstD> outDstDSet, Action<TSrcD> Adding = null, Action<TSrcD> Updating = null, Action<TDstD> Deleting = null)
            where TSrc : _BaseTableMain
            where TSrcD : _BaseTableDetail
            where TDst : _BaseTableMain
            where TDstD : _BaseTableDetail
        {
            var dst = context.Set<TDst>().AsNoTracking().FirstOrDefault(r => r.RecordId == dto.RecordId);
            if (dst == null)
            {
                outDstDSet = null;
                return false;
            }

            var dstDSet = context.Set<TDstD>().Where(d => d.RecordId == dst.RecordId);

            if (!srcDSet.Any())
            {
                outDstDSet = dstDSet;
                return true;
            }

            foreach (var DstD in dstDSet)
            {
                if (!srcDSet.Any(p => p.Idx == DstD.Idx)) // 新列表没有数据库中的Idx，则删除
                {
                    Deleting?.Invoke(DstD);
                    context.Remove<TDstD>(DstD);
                }
            }

            foreach (var srcD in srcDSet)
            {
                srcD.RecordId = dst.RecordId;

                if (dstDSet.Any(d => d.Idx == srcD.Idx)) // Idx有相同的，则修改
                {
                    Updating?.Invoke(srcD);

                    // 将删除的重新标记为修改
                    var dstD = dstDSet.FirstOrDefault(m => m.Idx == srcD.Idx);
                    context.Attach<TDstD>(dstD).State = EntityState.Modified;
                    StaticAutoMapper.Current.Map<TSrcD, TDstD>(srcD, dstD);
                }
                else if (!dstDSet.Any(d => d.Idx == srcD.Idx)) // Idx没有相同的，则添加
                {
                    Adding?.Invoke(srcD);
                    var dstD = StaticAutoMapper.Current.Map<TDstD>(srcD);
                    context.Attach<TDstD>(dstD).State = EntityState.Added;
                }
            }

            if (context.SaveChanges() > 0)
            {
                outDstDSet = dstDSet.AsEnumerable<TDstD>();
                return true;
            }
            else
            {
                outDstDSet = null;
                return false;
            }
        }

        public static IQueryable<TRemoteD> RecordDetailsEdit2<TLocal, TLocalD, TRemote, TRemoteD>(this Pinhua2Context context, TLocal _local, IList<TLocalD> _localDs,/*TRemote remote, IList<TRemoteD> _remoteDs,*/
    Action<TLocalD> CreatingD = null, Action<TLocalD> UpdatingD = null, Action<TRemoteD> DeletingD = null)
    where TLocal : _BaseTableMain
    where TLocalD : _BaseTableDetail
    where TRemote : _BaseTableMain
    where TRemoteD : _BaseTableDetail
        {
            var remote = context.Set<TRemote>().AsNoTracking().FirstOrDefault(r => r.RecordId == _local.RecordId);
            if (remote == null)
                return null;

            var remoteDs = context.Set<TRemoteD>();
            foreach (var remoteD in remoteDs)
            {
                if (!_localDs.Any(p => p.子单号 == remoteD.子单号)) // 新列表没有数据库中的子单号，则删除
                {
                    #region 应该在外部执行
                    //var tb_报价D = context.Set<tb_报价表D>().FirstOrDefault(d => d.子单号 == remoteD.子单号);
                    //if (tb_报价D != null)
                    //    tb_报价D.状态 = "";
                    #endregion

                    DeletingD?.Invoke(remoteD);
                    context.Remove<TRemoteD>(remoteD);
                }
            }

            foreach (var localD in _localDs)
            {
                Pinhua2Helper.CompleteDetailOnUpdate(remote, localD);

                if (remoteDs.Any(d => d.子单号 == localD.子单号)) // 子单号有相同的，则修改
                {
                    UpdatingD?.Invoke(localD);

                    // 将删除的重新标记为修改
                    var remoteD = remoteDs.FirstOrDefault(m => m.子单号 == localD.子单号);
                    context.Attach<TRemoteD>(remoteD).State = EntityState.Modified;
                    Mapper.Map<TLocalD, TRemoteD>(localD, remoteD);
                }
                else if (!remoteDs.Any(d => d.子单号 == localD.子单号)) // 子单号没有相同的，则添加
                {
                    CreatingD?.Invoke(localD);
                    #region 应该在外部执行
                    // 将新的标记为添加
                    //if (string.IsNullOrEmpty(localD.子单号)) // 子单号为空的，表示新插入
                    //{
                    //    //localD.子单号 = context.funcAutoCode("子单号");
                    //    var remoteD = Mapper.Map<TRemoteD>(localD);
                    //    context.Entry<TRemoteD>(remoteD).State = EntityState.Added;
                    //}
                    //else if (!string.IsNullOrEmpty(localD.子单号)) // 子单号不为空，表示从报价单引入，插入
                    //{
                    //    var remoteD = Mapper.Map<TRemoteD>(localD);
                    //    context.Entry<TRemoteD>(remoteD).State = EntityState.Added;
                    //}
                    #endregion
                    var remoteD = Mapper.Map<TRemoteD>(localD);
                    context.Attach<TRemoteD>(remoteD).State = EntityState.Added;
                }
            }

            return remoteDs;
        }

    }
}
