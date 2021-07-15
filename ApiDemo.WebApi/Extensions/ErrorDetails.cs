﻿using Newtonsoft.Json;

namespace GlobalErrorHandling.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Trace { get; set; }

        /// <summary>
        /// Sobre escritura metodo ToString
        /// </summary>
        /// <returns>Serializa el objeto y lo retorna</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}