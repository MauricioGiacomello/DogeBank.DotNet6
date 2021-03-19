using System.Threading.Tasks;

namespace Api.Application.UseCases
{
    public interface IUseCaseAsync<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync();
    }
}
