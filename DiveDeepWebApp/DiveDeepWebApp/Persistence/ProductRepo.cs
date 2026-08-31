using DiveDeepWebApp.Models;
using System.Runtime.CompilerServices;

namespace DiveDeepWebApp.Persistence
{
    public class ProductRepo
    {
        private List<Product> products;
        public ProductRepo()
        {
            products = new List<Product>();
            InitPoductList();
        }

        public List<Product> GetAll()
        {
            return products;
        }
        public List<Product> GetAllByClass<Type>()
        {
            return GetAll().FindAll(x => x.GetType() == typeof(Type));
        }

        private void InitPoductList()
        {
            products = new List<Product>();



        }
    }
}
