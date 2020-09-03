using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Vonage.Messaging;
using Vonage.Utility;
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
            var inbound = WebhookParser.ParseWebhook<InboundSms>(Request.Body,Request.ContentType);
            await HubContext.Clients.All.SendAsync("ReceiveMessage", inbound.Msisdn, inbound.Text);
            return NoContent();
        }
    }
}