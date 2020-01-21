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
        public static TOriginal RecordEdit<TDto, TOriginal>(this Pinhua2Context context, TDto dto,
            Action<TDto> Editing = null/*, Action<TRemote> AfterNew = null*/)
            where TDto : _BaseTableMain
            where TOriginal : _BaseTableMain
        {
            var original = context.Set<TOriginal>().FirstOrDefault(m => m.RecordId == dto.RecordId);
            if (original == null)
                return null;

            Editing?.Invoke(dto);

            dto.CreateTime = original.CreateTime;
            dto.CreateUser = original.CreateUser;
            dto.LastEditTime = DateTime.Now;
            dto.LastEditUser = dto.LastEditUser ?? "张凯译";

            StaticAutoMapper.Current.Map<TDto, TOriginal>(dto, original);
            context.Entry<TOriginal>(original).State = EntityState.Modified;
            context.SaveChanges();

            return original;
        }

        public static IQueryable<TOriginalD> RecordDetailsEdit<TDto, TDtoD, TOriginal, TOriginalD>(this Pinhua2Context context, TDto dto, IList<TDtoD> dtoDs,
            Action<TDtoD> Adding = null, Action<TDtoD> Updating = null, Action<TOriginalD> Deleting = null)
            where TDto : _BaseTableMain
            where TDtoD : _BaseTableDetail
            where TOriginal : _BaseTableMain
            where TOriginalD : _BaseTableDetail
        {
            var original = context.Set<TOriginal>().AsNoTracking().FirstOrDefault(r => r.RecordId == dto.RecordId);
            if (original == null)
                return null;

            var originalDs = context.Set<TOriginalD>().Where(d => d.RecordId == original.RecordId);
            foreach (var originalD in originalDs)
            {
                if (!dtoDs.Any(p => p.Idx == originalD.Idx)) // 新列表没有数据库中的Idx，则删除
                {
                    Deleting?.Invoke(originalD);
                    context.Remove<TOriginalD>(originalD);
                }
            }

            foreach (var dtoD in dtoDs)
            {
                dtoD.RecordId = original.RecordId;

                if (originalDs.Any(d => d.Idx == dtoD.Idx)) // Idx有相同的，则修改
                {
                    Updating?.Invoke(dtoD);

                    // 将删除的重新标记为修改
                    var originalD = originalDs.FirstOrDefault(m => m.Idx == dtoD.Idx);
                    context.Attach<TOriginalD>(originalD).State = EntityState.Modified;
                    StaticAutoMapper.Current.Map<TDtoD, TOriginalD>(dtoD, originalD);
                }
                else if (!originalDs.Any(d => d.Idx == dtoD.Idx)) // Idx没有相同的，则添加
                {
                    Adding?.Invoke(dtoD);
                    var remoteD = StaticAutoMapper.Current.Map<TOriginalD>(dtoD);
                    context.Attach<TOriginalD>(remoteD).State = EntityState.Added;
                }
            }

            return originalDs;
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
