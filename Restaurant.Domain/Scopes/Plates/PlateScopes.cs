using Restaurant.Domain.Entities;
using Restaurant.SharedKernel.Validation;

namespace Restaurant.Domain.Scopes.Plates
{
    public static class PlateScopes
    {
        public static bool CreatePlateScopeIsValid(this Plate plate)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(plate.PlateName, "O nome do prato é obrigatório"),
                AssertionConcern.AssertIsGreaterThan(plate.Price, 0, "O preço do prato não pode ser igual a zero")
            );
        }

        public static bool UpdatePlateScopeIsValid(this Plate plate, string plateName, decimal price, int restaurantId)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(plateName, "O nome do prato é obrigatório"),
                AssertionConcern.AssertIsGreaterThan(price, 0, "O preço do prato não pode ser igual a zero"),
                AssertionConcern.AssertIsGreaterThan(restaurantId, 0, "O restaurante do prato é obrigatório ser informado")
            );
        }
    }
}
