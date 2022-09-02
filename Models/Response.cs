using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReactWebApi.Models
{
    public class Response
    {
        internal List<tble_login> listUsers;

        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }

        public tble_login User { get; set; }

        public List<tble_login>Users { get; set; }


    }
}