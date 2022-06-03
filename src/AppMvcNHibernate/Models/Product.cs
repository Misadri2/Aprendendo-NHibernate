using System;

namespace AppMvcNHibernate.Models
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Quantity { get; set; }
        public virtual double Price { get; set; }
    }
}

