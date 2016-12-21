using Sisacon.Domain.Entities;

namespace Sisacon.Application.Interfaces
{
    public interface IConfigurationAppService : IAppServiceBase<Configuration>
    {
        ResponseMessage<Configuration> getByUserId(int id);
    }
}
