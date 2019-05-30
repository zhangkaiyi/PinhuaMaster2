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
    public static class funcNewRecordExtension
    {
        public static TRemote funcNewRecord<TLocal, TRemote>(this Pinhua2Context context, TLocal local,
            Action<TLocal> BeforeNew = null/*, Action<TRemote> AfterNew = null*/)
            where TLocal : _BaseTableMain
            where TRemote : _BaseTableMain
        {
            BeforeNew?.Invoke(local);

            Pinhua2Helper.CompleteMainOnCreate(local);
            var remote = Mapper.Map<TLocal, TRemote>(local);
            context.Entry<TRemote>(remote).State = EntityState.Added;

            //AfterNew?.Invoke(remote);
            //context.SaveChanges();
            return remote;
        }

        public static TRemoteD funcNewDetails<TLocal, TLocalD, TRemote, TRemoteD>(this Pinhua2Context context, TRemote remote, TLocalD localD,
            Action<TLocalD> BeforeNewD = null/*, Action<TRemoteD> AfterNew = null*/)
            where TLocal : _BaseTableMain
            where TLocalD : _BaseTableDetail
            where TRemote : _BaseTableMain
            where TRemoteD : _BaseTableDetail
        {
            BeforeNewD?.Invoke(localD);

            Pinhua2Helper.CompleteDetailOnCreate(remote, localD);
            var remoteD = Mapper.Map<TLocalD, TRemoteD>(localD);
            context.Entry<TRemoteD>(remoteD).State = EntityState.Added;

            //AfterNew?.Invoke(remoteD);
            //context.SaveChanges();
            return remoteD;
        }

        public static void funcNewRecordWithDetails<TLocal, TLocalD, TRemote, TRemoteD>(this Pinhua2Context context, TLocal local, IList<TLocalD> localDs,
            Action<TLocal> BeforeNew = null,
            Action<TLocalD> BeforeNewDetail = null,
            Action<TRemote> AfterNew = null,
            Action<TRemoteD> AfterNewDetail = null)
            where TLocal : _BaseTableMain
            where TLocalD : _BaseTableDetail
            where TRemote : _BaseTableMain
            where TRemoteD : _BaseTableDetail
        {
            var remote = funcNewRecord<TLocal, TRemote>(context, local, BeforeNew/*, AfterNew*/);

            foreach (var localD in localDs)
            {
                var remoteD = context.funcNewDetails<TLocal, TLocalD, TRemote, TRemoteD>(remote, localD, BeforeNewDetail/*, AfterNewDetail*/);
            }
            //context.SaveChanges();
        }
    }
}
