using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UsesCases.Pet.Update;

public class UpdatePetUseCase
{
    public ResponseRegisterPetJson Execute(int id, RequestPetJson request)
    {
        return new ResponseRegisterPetJson
        {
            Id = 7,
            Name = request.Name,
        };
    }
}
