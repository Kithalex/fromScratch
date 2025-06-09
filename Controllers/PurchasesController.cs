using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RetailStoreAPI.Data;
using RetailStoreAPI.Dtos;
using RetailStoreAPI.Models;

namespace RetailStoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchasesController : ControllerBase
{
    private readonly Context _context;

    public PurchasesController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Purchase>>> GetPurchases()
    {
        return await _context.Purchases
            .Include(p => p.Customer)
            .Include(p => p.Items).ThenInclude(i => i.Product)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Purchase>> GetPurchase(int id)
    {
        var purchase = await _context.Purchases
            .Include(p => p.Customer)
            .Include(p => p.Items).ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (purchase == null) return NotFound();
        return purchase;
    }

    [HttpPost]
    public async Task<ActionResult<Purchase>> CreatePurchase(CreatePurchaseDto dto)
    {
        var purchase = new Purchase
        {
            CustomerId = dto.CustomerId,
            PurchaseDate = DateTime.UtcNow,
            Items = dto.Items.Select(i => new PurchaseItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList()
        };

        _context.Purchases.Add(purchase);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPurchase), new { id = purchase.Id }, purchase);
    }
}
