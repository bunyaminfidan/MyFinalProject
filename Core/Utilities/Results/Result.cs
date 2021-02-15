using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //get : ReadOnly'dır. Yani Constructor ile set edilebilir.
        //sadece get yazıldı. set yazılmadı dikkat et.
        // set koyulmadı programcı kısıtlandı;
        //Projelerimizde dönütleri Constructor ile döneceğiz. kafasına göre dönemeyeck
        //Kodların okunurluğu standart edildi.
        //Kodların kullanımı standart edildi.

        //aynı kod iki defa yazılmaz. ....  prensibine uygun değil.

        //public Result(bool success, string message)
        //{
        //    Message = message;
        //    Success = success; silindi yeni constructor oluşturuldu.
        //} ben mesaj göndermek istemiyorum sadece success döneyim diyebilir.

        /// 
        /// this:c# da classın kendisi demek.
        /// 29. satıra 2 parametre gönderilirse her iki Constructor da çalışır.
        /// 
        /// 2 parametresi olan constructor'a :this ifadesini kullanıp
        /// tek parametre verirsek o zaman verilen parametreyi
        /// 1 paramatresş olan constructor'a iletir ve o da çalışır.
        /// prensiplere uygun olru
        /// 
        /// 
        public Result(bool success, string message) : this(success) //this:c# da classın kendisi demek yani Result
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }
    }
}
