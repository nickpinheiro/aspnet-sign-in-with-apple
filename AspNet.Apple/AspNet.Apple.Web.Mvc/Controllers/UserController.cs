using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace AspNet.Apple.Web.Mvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // POST: User/Index
        [HttpPost]
        public ActionResult Index(int? id)
        {
            if (Request.Form.ContainsKey("code"))
            {
                Models.Apple.User appleUser = new Models.Apple.User();

                // Decode the JWT Token to obtain user's email address to correlate with your app user.  The decoded JWT token will always include the email address.
                JwtSecurityToken jwtSecurityToken = DecodeJwtToken(Request.Form["id_token"]);

                // Capture the Apple Id user object.  You will only receive the 'user' JSON object in the post the first time the user authenticate's to your app.
                // When user authenticates via iOS, the response will always include a 'user' key however it will be empty with simply a value of '{}' if the user has already authenticated to your app before.
                if ((Request.Form.ContainsKey("user")) && (Request.Form["user"] != "{}"))
                {
                    // Obtain the 'user' JSON object and deserialize to the 'Models.Apple.User' object
                    string json = Request.Form["user"].ToString();
                    appleUser = JsonConvert.DeserializeObject<Models.Apple.User>(json);
                    appleUser.Id = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;

                    return View(appleUser);
                }

                // The user has already authenticated with your app and the 'user' JSON object does not exist.  Therefore capture the email address from the JWT Token to associate with your persisted app user.
                else
                {
                    appleUser.email = jwtSecurityToken.Claims.First(claim => claim.Type == "email").Value;
                    appleUser.Id = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;

                    return View(appleUser);
                }
            }

            return View();
        }

        private JwtSecurityToken DecodeJwtToken(string id_token)
        {
            var jwt = id_token;
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(jwt) as JwtSecurityToken;

            return token;
        }
    }
}