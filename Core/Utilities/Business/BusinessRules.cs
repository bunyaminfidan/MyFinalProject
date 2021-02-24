using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
  public  class BusinessRules
    {
        //List<IResult> olarak liste de yapabilriz. 13. gün 2:25 dakika 

        //params verilince istediğimiz kadar IResult verilebiliyor.
        //gönderilen parametreleri array yapıyor ve logicse atıyor.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    //parametre ile gönderilen iş kurallarından başarısız olan logici business managere haber veriyoruz.
                    //logic : CheckIfProductCountOfCategoryCorrect yani method
                    return logic;
                }

            }
            return null;
        }
    }
}
