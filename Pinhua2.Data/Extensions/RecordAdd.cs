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
    public static class RecordAddExtension
    {
        public static TOriginal RecordAdd<TDto, TOriginal>(this Pinhua2Context context, TDto local,
            Action<TDto> Adding = null/*, Action<TRemote> AfterNew = null*/)
            where TDto : _BaseTableMain
            where TOriginal : _BaseTableMain
        {
            Adding?.Invoke(local);

            Pinhua2Helper.CompleteMainOnCreate(local);
            var remote = StaticAutoMapper.Current.Map<TDto, TOriginal>(local);
            context.Entry<TOriginal>(remote).State = EntityState.Added;

            //AfterNew?.Invoke(remote);
            //context.SaveChanges();
            return remote;
        }

        public static bool TryRecordAdd<TSrc, TDst>(this Pinhua2Context context, TSrc src, Action<TSrc> Adding = null)
            where TSrc : _BaseTableMain
            where TDst : _BaseTableMain
        {
            Adding?.Invoke(src);

            src.CreateTime = DateTime.Now;
            src.CreateUser = src.CreateUser ?? "张凯译";
            var dst = StaticAutoMapper.Current.Map<TSrc, TDst>(src);
            context.Entry<TDst>(dst).State = EntityState.Added;

            var nret = context.SaveChanges();
            if (nret > 0)
            {
                // SaveChanges 成功的话，把数据库中的数据比如 RecordId 返回
                // src.RecordId = dst.RecordId;
                StaticAutoMapper.Current.Map<TDst, TSrc>(dst, src);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static TOriginalD RecordDetailAdd<TDto, TDtoD, TOriginal, TOriginalD>(this Pinhua2Context context, TOriginal remote, TDtoD localD,
            Action<TDtoD> BeforeNewD = null/*, Action<TRemoteD> AfterNew = null*/)
            where TDto : _BaseTableMain
            where TDtoD : _BaseTableDetail
            where TOriginal : _BaseTableMain
            where TOriginalD : _BaseTableDetail
        {
            BeforeNewD?.Invoke(localD);

            //Pinhua2Helper.CompleteDetailOnCreate(remote, localD);
            localD.RecordId = remote.RecordId;

            var remoteD = StaticAutoMapper.Current.Map<TDtoD, TOriginalD>(localD);
            context.Entry<TOriginalD>(remoteD).State = EntityState.Added;

            //AfterNew?.Invoke(remoteD);
            //context.SaveChanges();
            return remoteD;
        }

        public static bool TryRecordDetailsAdd<TSrc, TSrcD, TDst, TDstD>(this Pinhua2Context context, TSrc src, IEnumerable<TSrcD> srcDSet,
            Action<IEnumerable<TSrcD>> Adding = null)
            where TSrc : _BaseTableMain
            where TSrcD : _BaseTableDetail
            where TDst : _BaseTableMain
            where TDstD : _BaseTableDetail
        {
            Adding?.Invoke(srcDSet);

            if (!srcDSet.Any())
            {
                // 如果明细为空，直接返回 true ，避免主表数据无法保存成功
                return true;
            }

            foreach (var srcD in srcDSet)
            {
                srcD.RecordId = src.RecordId;
                var dstD = StaticAutoMapper.Current.Map<TSrcD, TDstD>(srcD);
                context.Entry<TDstD>(dstD).State = EntityState.Added;
            }

            var nRet = context.SaveChanges();
            if (nRet > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static TOriginalD RecordDetailAdd<TDtoD, TOriginalD>(this Pinhua2Context context, TDtoD dto, Action<TDtoD> Adding = null)
            where TDtoD : _BaseTableDetail
            where TOriginalD : _BaseTableDetail
        {
            Adding?.Invoke(dto);

            var remoteD = StaticAutoMapper.Current.Map<TDtoD, TOriginalD>(dto);
            context.Entry<TOriginalD>(remoteD).State = EntityState.Added;

            //context.SaveChanges();
            return remoteD;
        }
    }
}
