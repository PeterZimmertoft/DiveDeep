using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Helpers
{
    public static class ConvertProductToProductVariantDTO
    {
        public static string? Size(Product p)
        {
            return p is Suit suit ? suit.Size :
                    p is BCD bcd ? bcd.Size :
                    p is Fin fin ? fin.Size : null;
        }
        public static string? Thickness(Product p)
        {
            return p is Suit suit ? suit.Thickness : null;
        }
        public static string? Gender(Product p)
        {
            return p is Suit suit ? suit.Gender : null;
        }
    }
}

