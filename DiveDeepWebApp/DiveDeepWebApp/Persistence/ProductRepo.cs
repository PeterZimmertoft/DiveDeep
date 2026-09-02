using DiveDeepWebApp.Models;
using System.Runtime.CompilerServices;

namespace DiveDeepWebApp.Persistence
{
    public static class ProductRepo
    {
        private static List<Product> products;
        static ProductRepo()
        {
            products = new List<Product>();
            InitPoductList();
        }

        public static List<Product> GetAll()
        {
            return products;
        }
        public static List<Product> GetAllByClass(Type type)
        {
            return GetAll().FindAll(x => x.GetType() == type);
        } 
        
        private static void InitPoductList()
        {
            InitBCDs();
            InitSuits();
            InitTanks();
            InitRegulators();
            InitMasks();
            InitFins();

        }
        private static void InitBCDs()
        {
            // Scubapro – BCD Glide
            products.Add(new BCD { Brand = "Scubapro", Description = "Beskrivelse her", Price = 140, Model = "BCD Glide", Size = "S, M, L" });

            /*
            products.Add(new BCD{ Brand = "Scubapro", Description = "Beskrivelse her", Price = 140, Model = "BCD Glide", Size = "S" });
            products.Add(new BCD{ Brand = "Scubapro", Description = "Beskrivelse her", Price = 140, Model = "BCD Glide", Size = "M" });
            
            products.Add(new BCD
            {
                Brand = "Scubapro",
                Description = "Beskrivelse her",
                Price = 140,
                Model = "BCD Glide",
                Size = "L"
            });
            */

            // Scubapro – BCD Hydros Pro
            products.Add(new BCD
            {
                Brand = "Scubapro",
                Description = "Beskrivelse her",
                Price = 200,
                Model = "BCD Hydros Pro",
                Size = "S, M, L"
            });

            /*
             * products.Add(new BCD
            {
                Brand = "Scubapro",
                Description = "Beskrivelse her",
                Price = 200,
                Model = "BCD Hydros Pro",
                Size = "S"
            });
            products.Add(new BCD
            {
                Brand = "Scubapro",
                Description = "Beskrivelse her",
                Price = 200,
                Model = "BCD Hydros Pro",
                Size = "M"
            });
            products.Add(new BCD
            {
                Brand = "Scubapro",
                Description = "Beskrivelse her",
                Price = 200,
                Model = "BCD Hydros Pro",
                Size = "L"
            });
            */

            // Seac – BCD Modular
            products.Add(new BCD
            {
                Brand = "Seac",
                Description = "Beskrivelse her",
                Price = 145,
                Model = "BCD Modular",
                Size = "S"
            });

            /*
            products.Add(new BCD
            {
                Brand = "Seac",
                Description = "Beskrivelse her",
                Price = 145,
                Model = "BCD Modular",
                Size = "S"
            });
            products.Add(new BCD
            {
                Brand = "Seac",
                Description = "Beskrivelse her",
                Price = 145,
                Model = "BCD Modular",
                Size = "M"
            });
            products.Add(new BCD
            {
                Brand = "Seac",
                Description = "Beskrivelse her",
                Price = 145,
                Model = "BCD Modular",
                Size = "L"
            });
            */

            //Scubapro - Navigator Lite BCD
            products.Add(new BCD
            {
                Brand = "Scubapro",
                Description = "Beskrivelse her",
                Price = 125,
                Model = "Navigator Lite BCD",
                Size = "S, M, L"
            });

            /*products.Add(new BCD
            {
                Brand = "Scubapro",
                Description = "Beskrivelse her",
                Price = 125,
                Model = "Navigator Lite BCD",
                Size = "S"
            });
            products.Add(new BCD
            {
                Brand = "Scubapro",
                Description = "Beskrivelse her",
                Price = 125,
                Model = "Navigator Lite BCD",
                Size = "M"
            });
            products.Add(new BCD
            {
                Brand = "Scubapro",
                Description = "Beskrivelse her",
                Price = 125,
                Model = "Navigator Lite BCD",
                Size = "L"
            });*/
        }
        private static void InitSuits()
        {
            // Scubapro – Definition – 3 mm
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3 mm" });
            /*products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "S", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3 mm" });
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "M", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3 mm" });
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "L", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3 mm" });
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3 mm" });*/

            // Scubapro – Definition – 5 mm
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });
            //products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "S", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });
            //products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "M", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });
            //products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "L", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });
            //products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });

            // Scubapro – Definition – 7 mm
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "7 mm" });
            /*products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "S", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "7 mm" });
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "M", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "7 mm" });
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "L", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "7 mm" });
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 100, Model = "Definition", Size = "XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "7 mm" });*/

            // Waterproof – W5 – 3.5 mm
            products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 100, Model = "W5", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3.5 mm" });
            /*products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 100, Model = "W5", Size = "S", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3.5 mm" });
            products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 100, Model = "W5", Size = "M", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3.5 mm" });
            products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 100, Model = "W5", Size = "L", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3.5 mm" });
            products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 100, Model = "W5", Size = "XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "3.5 mm" });*/

            // Fourth Element – Proteus – 5 mm
            products.Add(new Suit { Brand = "Fourth Element", Description = "Beskrivelse her", Price = 120, Model = "Proteus", Size = "XS, S, M, L, XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });
            /*products.Add(new Suit { Brand = "Fourth Element", Description = "Beskrivelse her", Price = 120, Model = "Proteus", Size = "S", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });
            products.Add(new Suit { Brand = "Fourth Element", Description = "Beskrivelse her", Price = 120, Model = "Proteus", Size = "M", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });
            products.Add(new Suit { Brand = "Fourth Element", Description = "Beskrivelse her", Price = 120, Model = "Proteus", Size = "L", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });
            products.Add(new Suit { Brand = "Fourth Element", Description = "Beskrivelse her", Price = 120, Model = "Proteus", Size = "XL", Type = "Våddragt", Gender = "Herre/Dame", Thickness = "5 mm" });*/

            // Scubapro – Exodry 4.0 – Tørdragt
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 300, Model = "Exodry 4.0", Size = "XS, S, M, L, XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            /*products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 300, Model = "Exodry 4.0", Size = "S", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 300, Model = "Exodry 4.0", Size = "M", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 300, Model = "Exodry 4.0", Size = "L", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            products.Add(new Suit { Brand = "Scubapro", Description = "Beskrivelse her", Price = 300, Model = "Exodry 4.0", Size = "XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });*/

            // Waterproof – D7 Evo – Tørdragt
            products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 320, Model = "D7 Evo", Size = "XS, S, M, L, XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            /*products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 320, Model = "D7 Evo", Size = "S", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 320, Model = "D7 Evo", Size = "M", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 320, Model = "D7 Evo", Size = "L", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            products.Add(new Suit { Brand = "Waterproof", Description = "Beskrivelse her", Price = 320, Model = "D7 Evo", Size = "XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });*/

            // Santi – E.Lite Plus – Tørdragt
            products.Add(new Suit { Brand = "Santi", Description = "Beskrivelse her", Price = 350, Model = "E.Lite Plus", Size = "XS, S, M, L, XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            /*products.Add(new Suit { Brand = "Santi", Description = "Beskrivelse her", Price = 350, Model = "E.Lite Plus", Size = "S", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            products.Add(new Suit { Brand = "Santi", Description = "Beskrivelse her", Price = 350, Model = "E.Lite Plus", Size = "M", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            products.Add(new Suit { Brand = "Santi", Description = "Beskrivelse her", Price = 350, Model = "E.Lite Plus", Size = "L", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });
            products.Add(new Suit { Brand = "Santi", Description = "Beskrivelse her", Price = 350, Model = "E.Lite Plus", Size = "XL", Type = "Tørdragt", Gender = "Herre/Dame", Thickness = "N/A" });*/
        }
        private static void InitTanks()
        {
            products.Add(new Tank
            {
                Brand = "Scubapro",
                Price = 150,
                Volume = 5
            });

            products.Add(new Tank
            {
                Brand = "Scubapro",
                Price = 160,
                Volume = 10
            });

            products.Add(new Tank
            {
                Brand = "Scubapro",
                Price = 170,
                Volume = 12
            });

            products.Add(new Tank
            {
                Brand = "Scubapro",
                Price = 180,
                Volume = 15
            });
        }
        private static void InitRegulators()
        {
            // Scubapro – MK25EVO / S600 / R105
            products.Add(new Regulator
            {
                Brand = "Scubapro",
                FirstStage = "MK25EVO",
                SecondStage = "S600",
                Octopus = "R105",
                Price = 125
            });

            // Scubapro – MK17EVO / C370 / R095
            products.Add(new Regulator
            {
                Brand = "Scubapro",
                FirstStage = "MK17EVO",
                SecondStage = "C370",
                Octopus = "R095",
                Price = 100
            });

            // Scubapro – MK25EVO BT / A700 Carbon BT / S270
            products.Add(new Regulator
            {
                Brand = "Scubapro",
                FirstStage = "MK25EVO BT",
                SecondStage = "A700 Carbon BT",
                Octopus = "S270",
                Price = 150
            });
        }
        private static void InitMasks() 
        { 
            products.Add(new Mask
            {
                Brand = "Scubapro",
                Model = "Ghost",
                Price = 50
            });

            products.Add(new Mask
            {
                Brand = "Scubapro",
                Model = "D-Mask",
                Price = 60
            });

            products.Add(new Mask
            {
                Brand = "Scubapro",
                Model = "Spectra Mini",
                Price = 50
            });

            products.Add(new Mask
            {
                Brand = "Scubapro",
                Model = "Crystal VU",
                Price = 75
            });

            products.Add(new Mask
            {
                Brand = "Fourth Element",
                Model = "Scout Kontrast",
                Price = 75
            });

            products.Add(new Mask
            {
                Brand = "Fourth Element",
                Model = "Scout Enhance",
                Price = 75
            });

            products.Add(new Mask
            {
                Brand = "Tusa",
                Model = "Element",
                Price = 75
            });
        }
        private static void InitFins()
        {
            products.Add(new Fin { Brand = "Scubapro", Description = "Beskrivelse her", Price = 50, Model = "Jet Fin", Size = "XS, S, M, L, XL" });
            products.Add(new Fin { Brand = "Scubapro", Description = "Beskrivelse her", Price = 50, Model = "GO Travel", Size = "XS, S, M, L, XL" });
            products.Add(new Fin { Brand = "Scubapro", Description = "Beskrivelse her", Price = 60, Model = "Seawing Supernova", Size = "XS, S, M, L, XL" });
            products.Add(new Fin { Brand = "Seac", Description = "Beskrivelse her", Price = 50, Model = "Propulsion", Size = "XS, S, M, L, XL" });
            products.Add(new Fin { Brand = "Seac", Description = "Beskrivelse her", Price = 50, Model = "ALA", Size = "XS, S, M, L, XL" });
            products.Add(new Fin { Brand = "Forth Element", Description = "Beskrivelse her", Price = 75, Model = "Tech", Size = "XS, S, M, L, XL" });
            products.Add(new Fin { Brand = "Forth Element", Description = "Beskrivelse her", Price = 80, Model = "Rec Fin", Size = "XS, S, M, L, XL" });
        }
    }
}
