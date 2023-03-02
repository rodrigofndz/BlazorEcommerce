﻿namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var result =
                await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }

        public async Task GetProductsAsync()
        {
            var result = 
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product");
            Products = result.Data;
        }
    }
}
