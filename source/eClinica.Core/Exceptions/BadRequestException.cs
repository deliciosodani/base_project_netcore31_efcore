using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eClinica.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        private readonly IEnumerable<string> _list;

        public BadRequestException(string description)
        {
            _list = new List<string>
            {
                  description
            };
        }

        public string GetJsonDescription()
        {
            var result = _list.Select(x => new
            {
                ErrorMessage = x,
                Severity = 0,
                ErrorCode = "InternalValidation"
            })
            .ToList();

            return JsonConvert.SerializeObject(result,
                new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                }
            );
        }
    }
}
