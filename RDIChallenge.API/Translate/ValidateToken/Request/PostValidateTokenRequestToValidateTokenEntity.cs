using RDIChallenge.API.Models.ValidateToken.Request;

namespace RDIChallenge.API.Translate.ValidateToken.Request
{
    public class PostValidateTokenRequestToValidateTokenEntity
    {
        public static Domain.Entities.ValidateToken Translate(PostValidateTokenRequest model) =>
            model != null ? Domain.Entities.ValidateToken.Create(
                costumerId: model.CostumerId,
                cardId: model.CardId,
                token: model.Token,
                cvv: model.CVV
             ) : Domain.Entities.ValidateToken.Create();
    }
}
