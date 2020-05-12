using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace AspNet.Apple.Web.Razor.Pages
{
    [IgnoreAntiforgeryToken]
    public class UserModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public Models.Apple.User AppleUser { get; set; }

        public IActionResult OnPost()
        {
            if (Request.Form.ContainsKey("code"))
            {
                // Decode the JWT Token to obtain user's email address to correlate with your app user.  The decoded JWT token will always include the email address.
                JwtSecurityToken jwtSecurityToken = DecodeJwtToken(Request.Form["id_token"]);

                // Capture the Apple Id user object.  You will only receive the 'user' JSON object in the post the first time the user authenticate's to your app.
                // When user authenticates via iOS, the response will always include a 'user' key however it will be empty with simply a value of '{}' if the user has already authenticated to your app before.
                if ((Request.Form.ContainsKey("user")) && (Request.Form["user"] != "{}"))
                {
                    // Obtain the 'user' JSON object and deserialize to the 'Models.Apple.User' object
                    string json = Request.Form["user"].ToString();
                    AppleUser = JsonConvert.DeserializeObject<Models.Apple.User>(json);
                    AppleUser.Id = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;

                    return Page();
                }

                // The user has already authenticated with your app and the 'user' JSON object does not exist.  Therefore capture the email address from the JWT Token to associate with your persisted app user.
                else
                {
                    AppleUser.email = jwtSecurityToken.Claims.First(claim => claim.Type == "email").Value;
                    AppleUser.Id = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;

                    return Page();
                }
            }

            return Page();
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