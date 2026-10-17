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
                Id = product.Id,
                Brand = product.Brand,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Image = product.Image,
                Quantity = product.Quantity,
                Category = product.Category?.ToDTO(false) ?? null
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

        public static Product ToModel(this CreateProductDTO createProductDTO)
        {
            return createProductDTO.Variant switch
            {
                BcdDTO bcdDTO => new BCD
                {
                    Id = 0,
                    Brand = createProductDTO.Brand,
                    Price = createProductDTO.Price,
                    Description = createProductDTO.Description,
                    Image = createProductDTO.Image,
                    CategoryId = createProductDTO.CategoryId,
                    Quantity = createProductDTO.Quantity,
                    Model = bcdDTO.Model,
                    Size = bcdDTO.Size
                },
                SuitDTO suitDTO => new Suit
                {
                    Id = 0,
                    Brand = createProductDTO.Brand,
                    Price = createProductDTO.Price,
                    Description = createProductDTO.Description,
                    Image = createProductDTO.Image,
                    CategoryId = createProductDTO.CategoryId,
                    Quantity = createProductDTO.Quantity,
                    Model = suitDTO.Model,
                    Size = suitDTO.Size,
                    Type = suitDTO.Type,
                    Gender = suitDTO.Gender,
                    Thickness = suitDTO.Thickness
                },
                TankDTO tankDTO => new Tank()
                {
                    Id = 0,
                    Brand = createProductDTO.Brand,
                    Price = createProductDTO.Price,
                    Description = createProductDTO.Description,
                    Image = createProductDTO.Image,
                    CategoryId = createProductDTO.CategoryId,
                    Quantity = createProductDTO.Quantity,
                    Volume = tankDTO.Volume
                },
                RegulatorDTO regulatorDTO => new Regulator()
                {
                    Id = 0,
                    Brand = createProductDTO.Brand,
                    Price = createProductDTO.Price,
                    Description = createProductDTO.Description,
                    Image = createProductDTO.Image,
                    CategoryId = createProductDTO.CategoryId,
                    Quantity = createProductDTO.Quantity,
                    FirstStage = regulatorDTO.FirstStage,
                    SecondStage = regulatorDTO.SecondStage,
                    Octopus = regulatorDTO.Octopus
                },
                MaskDTO maskDTO => new Mask()
                {
                    Id = 0,
                    Brand = createProductDTO.Brand,
                    Price = createProductDTO.Price,
                    Description = createProductDTO.Description,
                    Image = createProductDTO.Image,
                    CategoryId = createProductDTO.CategoryId,
                    Quantity = createProductDTO.Quantity,
                    Model = maskDTO.Model
                },
                FinDTO finDTO => new Fin()
                {
                    Id = 0,
                    Brand = createProductDTO.Brand,
                    Price = createProductDTO.Price,
                    Description = createProductDTO.Description,
                    Image = createProductDTO.Image,
                    CategoryId = createProductDTO.CategoryId,
                    Quantity = createProductDTO.Quantity,
                    Model = finDTO.Model,
                    Size = finDTO.Size
                }
            };
        }

        public static Product ToModel(this UpdateProductDTO updateProductDto)
        {
            return updateProductDto.Variant switch
            {
                BcdDTO bcdDTO => new BCD
                {
                    Id = 0,
                    Brand = updateProductDto.Brand,
                    Price = updateProductDto.Price,
                    Description = updateProductDto.Description,
                    Image = updateProductDto.Image,
                    CategoryId = updateProductDto.CategoryId,
                    Quantity = updateProductDto.Quantity,
                    Model = bcdDTO.Model,
                    Size = bcdDTO.Size
                },
                SuitDTO suitDTO => new Suit
                {
                    Id = 0,
                    Brand = updateProductDto.Brand,
                    Price = updateProductDto.Price,
                    Description = updateProductDto.Description,
                    Image = updateProductDto.Image,
                    CategoryId = updateProductDto.CategoryId,
                    Quantity = updateProductDto.Quantity,
                    Model = suitDTO.Model,
                    Size = suitDTO.Size,
                    Type = suitDTO.Type,
                    Gender = suitDTO.Gender,
                    Thickness = suitDTO.Thickness
                },
                TankDTO tankDTO => new Tank()
                {
                    Id = 0,
                    Brand = updateProductDto.Brand,
                    Price = updateProductDto.Price,
                    Description = updateProductDto.Description,
                    Image = updateProductDto.Image,
                    CategoryId = updateProductDto.CategoryId,
                    Quantity = updateProductDto.Quantity,
                    Volume = tankDTO.Volume
                },
                RegulatorDTO regulatorDTO => new Regulator()
                {
                    Id = 0,
                    Brand = updateProductDto.Brand,
                    Price = updateProductDto.Price,
                    Description = updateProductDto.Description,
                    Image = updateProductDto.Image,
                    CategoryId = updateProductDto.CategoryId,
                    Quantity = updateProductDto.Quantity,
                    FirstStage = regulatorDTO.FirstStage,
                    SecondStage = regulatorDTO.SecondStage,
                    Octopus = regulatorDTO.Octopus
                },
                MaskDTO maskDTO => new Mask()
                {
                    Id = 0,
                    Brand = updateProductDto.Brand,
                    Price = updateProductDto.Price,
                    Description = updateProductDto.Description,
                    Image = updateProductDto.Image,
                    CategoryId = updateProductDto.CategoryId,
                    Quantity = updateProductDto.Quantity,
                    Model = maskDTO.Model
                },
                FinDTO finDTO => new Fin()
                {
                    Id = 0,
                    Brand = updateProductDto.Brand,
                    Price = updateProductDto.Price,
                    Description = updateProductDto.Description,
                    Image = updateProductDto.Image,
                    CategoryId = updateProductDto.CategoryId,
                    Quantity = updateProductDto.Quantity,
                    Model = finDTO.Model,
                    Size = finDTO.Size
                }
            };
        }
    }
}
