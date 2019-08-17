using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GingerbreadMarket.Models
{
    public class OrdersRepository
    {
        private static OrdersRepository repo = new OrdersRepository();

        public static OrdersRepository Current
        {
            get
            {
                return repo;
            }
        }

        private List<Order> data = new List<Order>
        {
            new Order
            {
                Id = 1, Count = 1, Price = 2.2, Email = "aaa@m.ru", IsSell = true
            },
            new Order
            {
                Id = 2, Count = 10, Price = 1.0, Email = "111@g.com"
            }
        };

        public IEnumerable<Order> GetAll()
        {
            return data;
        }

        public Order Get(int id)
        {
            return data.Where(o => o.Id == id).FirstOrDefault();
        }

        public Order Add(Order item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
            return item;
        }
        public void Remove(int id)
        {
            Order item = Get(id);
            if (item != null)
            {
                data.Remove(item);
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