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
    public class RecordManager
    {
        readonly protected Pinhua2Context _pinhua2Context;
        readonly protected IMapper _mapper;
        public RecordManager(Pinhua2Context pinhua2Context, IMapper mapper)
        {
            _pinhua2Context = pinhua2Context;
            _mapper = mapper;
        }
        public TRemote AddRecord<TLocal, TRemote>(TLocal local,
            Action<TLocal> BeforeNew = null/*, Action<TRemote> AfterNew = null*/)
            where TLocal : _BaseTableMain
            where TRemote : _BaseTableMain
        {
            BeforeNew?.Invoke(local);

            Pinhua2Helper.CompleteMainOnCreate(local);
            var remote = _mapper.Map<TLocal, TRemote>(local);
            _pinhua2Context.Entry<TRemote>(remote).State = EntityState.Added;

            //AfterNew?.Invoke(remote);
            //var i = _pinhua2Context.SaveChanges();
            return remote;
        }

        public TRemoteD AddRecordDetail<TLocal, TLocalD, TRemote, TRemoteD>(TRemote remote, TLocalD localD,
            Action<TLocalD> BeforeNewD = null/*, Action<TRemoteD> AfterNew = null*/)
            where TLocal : _BaseTableMain
            where TLocalD : _BaseTableDetail
            where TRemote : _BaseTableMain
            where TRemoteD : _BaseTableDetail
        {
            BeforeNewD?.Invoke(localD);

            localD.RecordId = remote.RecordId;

            var remoteD = _mapper.Map<TLocalD, TRemoteD>(localD);
            _pinhua2Context.Entry<TRemoteD>(remoteD).State = EntityState.Added;

            //AfterNew?.Invoke(remoteD);
            //context.SaveChanges();
            return remoteD;
        }
    }
}
