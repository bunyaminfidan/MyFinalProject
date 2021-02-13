using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint
    //T: class ile int string gibi referans tip olmayanların yazılması engellendi
    //T  referans tip olabilir
    //T ya IEntity olabilir yada IEntity den implemente edilen bir nesne olabilir.
    //new() IEntity bir nesne değil ve içi boş olduğu için yazılmamalı bunu engellemek içinde newlenebilen bir sınıf olmalı.
    //Interfaceler newlenemez.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //Expression DataAccess içerisinde doğrudan filtreleme işlemleri yapabilmek için Linq tarafından sağlanan bir işlem.
        //GetAll(p=>p.a == product.a) gibi sorgular yazabiliriz.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
