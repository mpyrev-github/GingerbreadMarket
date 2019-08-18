using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GingerbreadMarket.Models
{
    public class OrdersRepository
    {
        private static OrdersContext db = new OrdersContext();

        public OrdersContext GetDb()
        {
            return db;
        }

        public Order GetOrder(int id)
        {
            return db.Orders.Where(o => o.Id == id).FirstOrDefault();
        }

        public void Add(Order item)
        {
            MakeDeal(item);
            if (item.Count!=0)
            {
                if (db.Orders.Count() != 0)
                    item.Id = db.Orders.OrderBy(o => o.Id).Last().Id + 1;
                else item.Id = 1;
                item.Date = DateTime.Now;
                db.Orders.Add(item);
                db.SaveChanges();
            }
        }

        private void MakeDeal(Order item)
        {
            if (item.IsSell)
            {
                while (db.Orders.Where(o => o.IsSell == false).Count() != 0 && 
                    item.Price <= db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First().Price && item.Count != 0 )
                    AddDeal(db, item);
            }
            else 
                while (db.Orders.Where(o => o.IsSell == true).Count() != 0 &&
                    item.Price >= db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First().Price && item.Count != 0 )
                    AddDeal(db, item);
        }
        private void AddDeal(OrdersContext db, Order item)
        {
            Deal deal = new Deal();
            if (db.Deals.Count() != 0)
                deal.Id = db.Deals.OrderBy(o => o.Id).Last().Id + 1;
            else deal.Id = 1;
            deal.DealDate = DateTime.Now;
            if (item.IsSell)
                deal.SellDate = DateTime.Now;
            else deal.SellDate = db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First().Date;
            if (item.IsSell)
                deal.BuyDate = db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First().Date;
            else deal.BuyDate = DateTime.Now;
            if (item.IsSell)
                deal.Price = db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First().Price;
            else deal.Price = db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First().Price;
            if (item.IsSell)
                deal.BuyEmail = db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First().Email;
            else deal.BuyEmail = item.Email;
            if (item.IsSell)
                deal.SellEmail = item.Email;
            else deal.SellEmail = db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First().Email;
            if (UpdateCount(db, item))
            {
                deal.Count = item.Count;
                item.Count = 0;
            }
            else if (item.IsSell)
            {
                deal.Count = db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First().Count;
                Remove(db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First().Id);
            }
            else
            {
                deal.Count = db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First().Count;
                Remove(db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First().Id);
            }
            db.Deals.Add(deal);
            db.SaveChanges();
        }
        private bool UpdateCount(OrdersContext db, Order item)
        {
            if (item.IsSell)
                if (db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First().Count > item.Count)
                {
                    db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First().Count -= item.Count;
                    return true;
                }
                else
                {
                    item.Count -= db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First().Count;
                    return false;
                }
            else if (db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First().Count > item.Count)
                {
                    db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First().Count -= item.Count;
                    return true;
                }
                else
                {
                    item.Count -= db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First().Count;
                    return false;
                }
        }
        private void Remove(int id)
        {
            Order item = GetOrder(id);
            if (item != null)
            {
                db.Orders.Remove(item);
                db.SaveChanges();
            }
        }
        public void RemoveDeals()
        {
            foreach (var deal in db.Deals)
            db.Deals.Remove(deal);
            db.SaveChanges();
        }

        public bool Update(Order item)
        {
            Order storedItem = GetOrder(item.Id);
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