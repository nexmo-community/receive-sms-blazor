using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Nexmo.Api.Messaging;
using System.IO;
using System.Threading.Tasks;
using ReceiveSmsBlazor.Hubs;

namespace ReceiveSmsBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : Controller
    {
        IHubContext<SmsHub> HubContext { get; set; }

        public SmsController(IHubContext<SmsHub> hubContext)
        {
            HubContext = hubContext;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InboundSms()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var json = await reader.ReadToEndAsync();
                var inbound = JsonConvert.DeserializeObject<InboundSms>(json);                
                await HubContext.Clients.All.SendAsync("ReceiveMessage", inbound.Msisdn, inbound.Text);
            }
            return NoContent();
        }
    }
}