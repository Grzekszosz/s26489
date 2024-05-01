﻿using WebApplication2.Model;

namespace WebApplication2.Services;

public interface IWareHouseService
{
    Task<int> AddProductAsync(Product product);
    Task<bool> AvaliableProductAsync(int IDProduct);
}