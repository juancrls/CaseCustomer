using AutoMapper;

namespace Infrastructure.Persist.AutoMapper
{
    public class AutoMapperConfig
    {
        public MapperConfiguration Configure() => new MapperConfiguration(cfg => { cfg.AddProfile<Mapper>(); });
    }
}