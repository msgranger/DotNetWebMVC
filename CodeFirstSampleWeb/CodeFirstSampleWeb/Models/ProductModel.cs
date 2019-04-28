namespace CodeFirstSampleWeb.Models
{
    public class ProductModel
    {
        public PagedList.IPagedList<EntitiesLayer.Concrete.Product> PagedList { get; set; }

        public string Adi { get; set; }

    }
}