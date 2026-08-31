using DiveDeepWebApp.Models;
using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace DiveDeepWebApp.Persistence
{
    public class AttributeRepo
    {
        private List<ProductAttribute> attributes = new List<ProductAttribute>();

        public AttributeRepo()
        {

            attributes.Add(new ProductAttribute
            {
                ID = 1,
                Name = "Størrelser",
                Values = new List<Value>() {
                    new Value { Name = "S" },
                    new Value { Name = "M" },
                    new Value { Name = "L" }
                }
            });

            attributes.Add(new ProductAttribute
            {
                ID = 2,
                Name = "Størrelser",
                Values = new List<Value>() {
                    new Value { Name = "XS" },
                    new Value { Name = "S" },
                    new Value { Name = "M" },
                    new Value { Name = "L" },
                    new Value { Name = "XL" }
                }
            });

            attributes.Add(new ProductAttribute
            {
                ID = 3,
                Name = "Type",
                Values = new List<Value>() {
                    new Value { Name = "Våddragt" },
                    new Value { Name = "Tørdragt" }
                }
            });

            attributes.Add(new ProductAttribute
            {
                ID = 4,
                Name = "Køn",
                Values = new List<Value>() {
                    new Value { Name = "Herre" },
                    new Value { Name = "Dame" }
                }
            });

            attributes.Add(new ProductAttribute
            {
                ID = 5,
                Name = "Tykkelse",
                Unit = "mm",
                Values = new List<Value>() {
                    new Value { Name = "3" },
                    new Value { Name = "3,5" },
                    new Value { Name = "5" },
                    new Value { Name = "7" }
                }
            });

            //Model tilhørende BCD
            attributes.Add(new ProductAttribute
            {
                ID = 6,
                Name = "Model",
                Values = new List<Value>() {
                    new Value { Name = "Navigator Lite BCD" },
                    new Value { Name = "BCD Glide" },
                    new Value { Name = "BCD Hydros Pro" },
                    new Value { Name = "BCD Modular" }
                }
            });

            //Model tilhørende Dykkerdragt
            attributes.Add(new ProductAttribute
            {
                ID = 7,
                Name = "Model",
                Values = new List<Value>() {
                    new Value { Name = "Definition" },
                    new Value { Name = "W5" },
                    new Value { Name = "Proteus" },
                    new Value { Name = "Exodry 4.0" },
                    new Value { Name = "D7 Evo" },
                    new Value { Name = "E.Lite Plus" },
                }
            });

            attributes.Add(new ProductAttribute
            {
                ID = 8,
                Name = "Volumen",
                Unit = "liter",
                Values = new List<Value>() {
                    new Value { Name = "5" },
                    new Value { Name = "10" },
                    new Value { Name = "12" },
                    new Value { Name = "15" }
                }
            });

            attributes.Add(new ProductAttribute
            {
                ID = 9,
                Name = "1. trin",
                Values = new List<Value>() {
                    new Value { Name = "MK25EVO" },
                    new Value { Name = "MK17EVO" },
                    new Value { Name = "MK25EVO BT" },
                }
            });

            attributes.Add(new ProductAttribute
            {
                ID = 10,
                Name = "2. trin",
                Values = new List<Value>() {
                    new Value { Name = "S600" },
                    new Value { Name = "C370" },
                    new Value { Name = "A700 Carbon BT" },
                }
            });

            attributes.Add(new ProductAttribute
            {
                ID = 11,
                Name = "Octopus",
                Values = new List<Value>() {
                    new Value { Name = "R105" },
                    new Value { Name = "R095" },
                    new Value { Name = "S270" },
                }
            });

            //Model tilhørende Maske/Snorkel
            attributes.Add(new ProductAttribute
            {
                ID = 12,
                Name = "Model",
                Values = new List<Value>() {
                    new Value { Name = "Ghost" },
                    new Value { Name = "D-Mask" },
                    new Value { Name = "Spectra Mini" },
                    new Value { Name = "Crystal VU" },
                    new Value { Name = "Scout Kontrast" },
                    new Value { Name = "Scout Enhance" },
                    new Value { Name = "Element" }
                }
            });

            //Model tilhørende Finner
            attributes.Add(new ProductAttribute
            {
                ID = 13,
                Name = "Model",
                Values = new List<Value>() {
                    new Value { Name = "Jet Fin" },
                    new Value { Name = "GO Travel" },
                    new Value { Name = "Seawing Supernova" },
                    new Value { Name = "Propulsion" },
                    new Value { Name = "ALA" },
                    new Value { Name = "Tech" },
                    new Value { Name = "Rec Fin" }
                }
            });
        }
    }
}
