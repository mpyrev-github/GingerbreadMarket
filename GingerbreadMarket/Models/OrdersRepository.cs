using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GingerbreadMarket.Models
{
    public class OrdersRepository
    {
        private static OrdersRepository repo = new OrdersRepository();
        private static OrdersContext db = new OrdersContext();
        public static OrdersRepository Current
        {
            get
            {
                return repo;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Where(o => o.Id == id).FirstOrDefault();
        }

        public Order Add(Order item)
        {
            item.Id = db.Orders.Last().Id + 1;
            db.Orders.Add(item);
            db.SaveChanges();
            return item;
        }
        public void Remove(int id)
        {
            Order item = Get(id);
            if (item != null)
            {
                db.Orders.Remove(item);
                db.SaveChanges();
            }
        }

        public bool Update(Order item)
        {
            Order storedItem = Get(item.Id);
            if (storedItem != null)
            {
                storedItem.Price = item.Price;
                storedItem.Count = item.Count;
                storedItem.Email = item.Email;
                storedItem.IsSell = item.IsSell;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}