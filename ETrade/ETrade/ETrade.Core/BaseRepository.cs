﻿using ETrade.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        TradeContext _db;
        public BaseRepository(TradeContext db)
        {
            _db = db;
        }
        
        public bool Add(T entity)
        {
            try
            {
                Set().Add(entity);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                Set().Remove(Find(Id));
                return true;

            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool Delete(string Id)
        {
            try
            {
                Set().Remove(Find(Id));
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int Id, int Id2)
        {
            try
            {
                Set().Remove(Find(Id,Id2)); //Delete ve Find da hata verdiği için ikisine ekleme yaptık
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }

        public T Find(string Id)
        {
            return Set().Find(Id);
        }

        public T Find(int Id, int Id2)
        {
            return Set().Find(Id,Id2);
            //BasketDetail Id =BD.Id Id2=BD.ProductId
            // Id yi basketdetail deki Id ile eşleştiriyor Id2 de basketdetail daki productId ile eşleştiriyor
            //BURDA SIRA ÖNEMLİ ÖNCE NORMAL ID YAZMALI SONRA PRODUCTID
        }

        public List<T> List()
        {
            return Set().ToList();  
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
