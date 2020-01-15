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
    public static class RecordExtension
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
