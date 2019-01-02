using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace App1.ExpandListView
{
    public class ExpandedModel
    {
        private Product _oldProduct;
        public ObservableCollection<Product> Products { get; set; }
        
        public ExpandedModel()
        {
            Products = new ObservableCollection<Product>
            {
                new Product
                {
                    Title = "Microsoft Surface",
                    Image = "https://png.pngtree.com/element_origin_min_pic/00/04/39/09568c92aac0962.jpg",
                    IsVisible = false
                    
                },
                new Product
                {
                    Title = "Microsoft Lumia 535",
                    Image = "https://png.pngtree.com/element_origin_min_pic/00/04/39/09568c92aac0962.jpg",
                    IsVisible = false
                },
                new Product
                {
                    Title = "Microsoft 650",
                    Image = "https://png.pngtree.com/element_origin_min_pic/00/04/39/09568c92aac0962.jpg",
                    IsVisible = false
                },
                new Product
                {
                    Title = "Lenovo Surface",
                    Image = "https://png.pngtree.com/element_origin_min_pic/00/04/39/09568c92aac0962.jpg",
                    IsVisible =  false
                },
                new Product
                {
                    Title = "Microsoft edge",
                    Image = "https://png.pngtree.com/element_origin_min_pic/00/04/39/09568c92aac0962.jpg",
                    IsVisible = false
                }
            };
        }

        public void ShoworHiddenProducts(Product product)
        {
            if (_oldProduct == product)
            {
                product.IsVisible = !product.IsVisible;
                UpDateProducts(product);
            }
            else
            {
                if (_oldProduct != null)
                {
                    _oldProduct.IsVisible = false;
                    UpDateProducts(_oldProduct);

                }
                product.IsVisible = true;
                UpDateProducts(product);
            }
            _oldProduct = product;
        }

        private void UpDateProducts(Product product)
        {

            var Index = Products.IndexOf(product);
            Products.Remove(product);
            Products.Insert(Index, product);

        }

    }

    public class Product
    {
        public string Title { get; set; }

        public bool IsVisible { get; set; }
        public string Image { get; set; }
    }


}
