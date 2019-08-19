using System;
using System.Linq;

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
            {
                var BuyDbItem = db.Orders.Where(o => o.IsSell == false).OrderBy(o => o.Price).First();
                deal.SellDate = DateTime.Now;
                deal.BuyDate = BuyDbItem.Date;
                deal.Price = BuyDbItem.Price;
                deal.BuyEmail = BuyDbItem.Email;
                deal.SellEmail = item.Email;

                if (UpdateDbCount(BuyDbItem, item))
                {
                    deal.Count = item.Count;
                    item.Count = 0;
                }
                else
                {
                    deal.Count = BuyDbItem.Count;
                    Remove(BuyDbItem.Id);
                }
            }
            else
            {
                var SellDbItem = db.Orders.Where(o => o.IsSell == true).OrderByDescending(o => o.Price).First();
                deal.SellDate = SellDbItem.Date;
                deal.BuyDate = DateTime.Now;
                deal.Price = SellDbItem.Price;
                deal.BuyEmail = item.Email;
                deal.SellEmail = SellDbItem.Email;

                if (UpdateDbCount(SellDbItem, item))
                {
                    deal.Count = item.Count;
                    item.Count = 0;
                }
                else
                {
                    deal.Count = SellDbItem.Count;
                    Remove(SellDbItem.Id);
                }
            }
            db.Deals.Add(deal);
            db.SaveChanges();
        }
        private bool UpdateDbCount(Order DbOrder, Order item)
        {
            if (DbOrder.Count > item.Count)
            {
                DbOrder.Count -= item.Count;
                return true;
            }
            else
            {
                item.Count -= DbOrder.Count;
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
    }
}