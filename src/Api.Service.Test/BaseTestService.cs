using System;
using Api.CrossCutting.Mappings;
using Api.Service.Test.Mapping;
using AutoMapper;

namespace Api.Service.Test
{
    public class BaseTestService
    {
        public IMapper Mapper { get; set; }

        public BaseTestService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public void Dispose()
            {
            }

            public IMapper GetMapper()
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ModelToEntityProfile());
                    cfg.AddProfile(new RequestToModelProfile());
                    cfg.AddProfile(new EntityToRequestProfile());
                    cfg.AddProfile(new EntityToRequestTestProfile());

                });

                return config.CreateMapper();
            }
        }
    }
}
