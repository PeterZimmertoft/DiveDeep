using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Mappers
{
    public static class BookingMapper
    {
        public static BookingDTO ToDTO(this Booking booking)
        {
            return new BookingDTO()
            {
                Id = booking.Id,
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                Price = booking.Price,
                RowVersion = booking.RowVersion,
                Products = booking.BookingProducts
                    .Select(x =>
                    {
                        ProductDTO productDTO = x.Product.ToDTO();
                        productDTO.Quantity = x.Quantity;
                        productDTO.Variants = new List<ProductVariantDTO>()
                        {
                            x.Product.ToVariantDTO()
                        };

                        return productDTO;
                    })
                    .ToList()
            };
        }
    }
}