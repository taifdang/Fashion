using Fashion_API.DTO;
using Fashion_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_API.Service
{
    public interface IVariantService
    {
        Task<IEnumerable<ProductVariant>> get();
        Task<ProductVariant> getId(int id);
        Task<ProductVariant> post([FromForm] VariantDTO variantDTO);

    }
}
