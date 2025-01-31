using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MyEncryptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptionController : ControllerBase
    {
        private const int Shift = 3; // Skiftning för Caesar-chiffer

        [HttpPost("Encrypt")]
        public IActionResult Encrypt([FromBody] string? plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
                return BadRequest(new { Error = "Input cannot be null or empty" });

            var encryptedText = EncryptString(plainText);
            return Ok(new { EncryptedText = encryptedText });
        }

        [HttpPost("Decrypt")]
        public IActionResult Decrypt([FromBody] string? encryptedText)
        {
            if (string.IsNullOrWhiteSpace(encryptedText))
                return BadRequest(new { Error = "Input cannot be null or empty" });

            var decryptedText = DecryptString(encryptedText);
            return Ok(new { DecryptedText = decryptedText });
        }

        private string EncryptString(string input)
        {
            StringBuilder result = new();
            foreach (char c in input)
            {
                result.Append((char)(c + Shift));
            }
            return result.ToString();
        }

        private string DecryptString(string input)
        {
            StringBuilder result = new();
            foreach (char c in input)
            {
                result.Append((char)(c - Shift));
            }
            return result.ToString();
        }
    }
}
