using DinnerDDD.Application.Menus.Commands.CreateMenu;
using DinnerDDD.Contracts.Menus;
using Mapster;

namespace DinnerDDD.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);
        }
    }
}
