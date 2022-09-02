using ReactWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace ReactWebApi.Controllers
{
    public class UserController : ApiController
    {
        testEntities db = new testEntities();
        [Route("api/User/AddUser")]
        [HttpPost]
        public Response AddUser(UserModel userModel)
        {
            Response response = new Response();
            tble_login user = new tble_login();
            user.USERNAME = userModel.USERNAME;
            user.PASSWORD = userModel.PASSWORD;
            if(user!=null)
            {
                db.tble_login.Add(user);
                db.SaveChanges();
                response.ResponseCode = "200";
                response.ResponseMessage = "User added";
            }
            else
            {
                response.ResponseCode = "100";
                response.ResponseMessage = "Error" +
                    "";
            }
            return response;
        }

        [Route("api/User/GetUser")]
        [HttpGet]
        public Response GetUsers()
        {
            Response response = new Response();
            List<tble_login> users = new List<tble_login>();
            users = db.tble_login.ToList();
            response.ResponseCode = "200";
            response.ResponseMessage = "Data fetched";
            response.Users = users;
            return response;
        }
        [Route("api/login")]
        [HttpPost]
        public string UserLogin(Models.Login login)

        {
            string output;
            var log = db.tble_login.Where(x => x.USERNAME.Equals(login.USERNAME) && x.PASSWORD.Equals(login.PASSWORD)).FirstOrDefault();
            if (log == null)
            {
                output = "email or password is wrong";
            }
            else
            {
                output = "success";
            }
            return output;
        }
    }
}