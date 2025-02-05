using Microsoft.AspNetCore.Mvc;

namespace MyEncryptionAPI.Controllers
{
    [Route(api/[controller])]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        [HttpPost(encrypt)]
        public ActionResult<string> Encrypt([FromBody] string input)
        {
            var encrypted = EncryptText(input);
            return Ok(encrypted);
        }

        [HttpPost(decrypt)]
        public ActionResult<string> Decrypt([FromBody] string input)
        {
            var decrypted = DecryptText(input);
            return Ok(decrypted);
        }

        private string EncryptText(string input)
        {
            var shift = 3;
            var result = ;
            foreach (var ch in input)
            {
                result += (char)(ch + shift);
            }
            return result;
        }

        private string DecryptText(string input)
        {
            var shift = 3;
            var result = ;
            foreach (var ch in input)
            {
                result += (char)(ch - shift);
            }
            return result;
        }
    }
}
