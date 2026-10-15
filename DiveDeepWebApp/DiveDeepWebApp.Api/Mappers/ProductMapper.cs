using DiveDeepWebApp.Api.DTOs;
using DiveDeepWebApp.Api.DTOs.Variants;
using DiveDeepWebApp.Api.Models;

namespace DiveDeepWebApp.Api.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this Product product)
        {
            return new ProductDTO
            {
                Brand = product.Brand,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image
            };
        }

        public static ProductVariantDTO ToVariantDTO(this Product product)
        {
            return product switch
            {
                BCD bcd => new BcdDTO()
                {
                    Id = bcd.Id,
                    Model = bcd.Model,
                    Size = bcd.Size
                },
                Suit suit => new SuitDTO()
                {
                    Id = suit.Id,
                    Model = suit.Model,
                    Size = suit.Size,
                    Type = suit.Type,
                    Gender = suit.Gender,
                    Thickness = suit.Thickness
                },
                Tank tank => new TankDTO()
                {
                    Id = tank.Id,
                    Volume = tank.Volume
                },
                Regulator regulator => new RegulatorDTO()
                {
                    Id = regulator.Id,
                    FirstStage = regulator.FirstStage,
                    SecondStage = regulator.SecondStage,
                    Octopus = regulator.Octopus
                },
                Mask mask => new MaskDTO()
                {
                    Id = mask.Id,
                    Model = mask.Model
                },
                Fin fin => new FinDTO()
                {
                    Id = fin.Id,
                    Model = fin.Model,
                    Size = fin.Size
                }
            };
        }
    }
}
