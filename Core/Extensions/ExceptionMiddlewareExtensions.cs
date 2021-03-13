using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions 
        //uygulamayı sarıyor.
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        //IApplicationBuilder yaşam döngüsü araya yeni bir kod ekliyoruz.
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
