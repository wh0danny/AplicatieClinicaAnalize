using AplicatieClinicaAnalize.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicatieClinicaAnalize.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Analiza).Where(n => n.UserId == userId).ToListAsync();
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Cantitate = item.Amount,
                    AnalizaId = item.Analiza.Id,
                    OrderId = order.Id,
                    Pret = item.Analiza.PretAnaliza
                };
                await _context.OrderItem.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();

        }
    }
}
