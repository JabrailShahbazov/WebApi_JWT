using System;
using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;

namespace AuthServer.Service
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<DtoMapper>(); });
            return config.CreateMapper();
        });

        public static IMapper Mapper => lazy.Value;
    }
}