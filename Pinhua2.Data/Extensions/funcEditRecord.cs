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
    public static class funcEditRecordExtension
    {
        public static TRemote funcEditRecord<TLocal, TRemote>(this Pinhua2Context context, TLocal local,
            Action<TLocal> BeforeNew = null/*, Action<TRemote> AfterNew = null*/)
            where TLocal : _BaseTableMain
            where TRemote : _BaseTableMain
        {
            var remote = context.Set<TRemote>().FirstOrDefault(m => m.RecordId == local.RecordId);
            if (remote == null)
                return null;

            BeforeNew?.Invoke(local);

            Pinhua2Helper.CompleteMainOnEdit(local);
            Mapper.Map<TLocal, TRemote>(local, remote);
            context.Entry<TRemote>(remote).State = EntityState.Modified;

            //AfterNew?.Invoke(remote);
            //context.SaveChanges();
            return remote;
        }

        public static IQueryable<TRemoteD> funcEditDetails<TLocal, TLocalD, TRemote, TRemoteD>(this Pinhua2Context context, TLocal _local, IList<TLocalD> _localDs,/*TRemote remote, IList<TRemoteD> _remoteDs,*/
            Action<TLocalD> CreatingD = null, Action<TLocalD> UpdatingD = null, Action<TRemoteD> DeletingD = null)
            where TLocal : _BaseTableMain
            where TLocalD : _BaseTableDetail
            where TRemote : _BaseTableMain
            where TRemoteD : _BaseTableDetail
        {
            var remote = context.Set<TRemote>().AsNoTracking().FirstOrDefault(r => r.RecordId == _local.RecordId);
            if (remote == null)
                return null;

            var remoteDs = context.Set<TRemoteD>().Where(d => d.RecordId == remote.RecordId);
            foreach (var remoteD in remoteDs)
            {
                if (!_localDs.Any(p => p.Idx == remoteD.Idx)) // 新列表没有数据库中的Idx，则删除
                {
                    #region 应该在外部执行
                    //var tb_报价D = context.Set<tb_报价表D>().FirstOrDefault(d => d.Idx == remoteD.Idx);
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

                if (remoteDs.Any(d => d.Idx == localD.Idx)) // Idx有相同的，则修改
                {
                    UpdatingD?.Invoke(localD);

                    // 将删除的重新标记为修改
                    var remoteD = remoteDs.FirstOrDefault(m => m.Idx == localD.Idx);
                    context.Attach<TRemoteD>(remoteD).State = EntityState.Modified;
                    Mapper.Map<TLocalD, TRemoteD>(localD, remoteD);
                }
                else if (!remoteDs.Any(d => d.Idx == localD.Idx)) // Idx没有相同的，则添加
                {
                    CreatingD?.Invoke(localD);
                    #region 应该在外部执行
                    // 将新的标记为添加
                    //if (string.IsNullOrEmpty(localD.Idx)) // Idx为空的，表示新插入
                    //{
                    //    //localD.Idx = context.funcAutoCode("Idx");
                    //    var remoteD = Mapper.Map<TRemoteD>(localD);
                    //    context.Entry<TRemoteD>(remoteD).State = EntityState.Added;
                    //}
                    //else if (!string.IsNullOrEmpty(localD.Idx)) // Idx不为空，表示从报价单引入，插入
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

        public static IQueryable<TRemoteD> funcEditDetails2<TLocal, TLocalD, TRemote, TRemoteD>(this Pinhua2Context context, TLocal _local, IList<TLocalD> _localDs,/*TRemote remote, IList<TRemoteD> _remoteDs,*/
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
