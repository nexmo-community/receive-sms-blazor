#pragma checksum "C:\Users\slore\source\repos\ReceiveSmsBlazor\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9a59b8a8348779f397b7c60a978085aa01efe48"
// <auto-generated/>
#pragma warning disable 1591
namespace ReceiveSmsBlazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\slore\source\repos\ReceiveSmsBlazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\slore\source\repos\ReceiveSmsBlazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\slore\source\repos\ReceiveSmsBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\slore\source\repos\ReceiveSmsBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\slore\source\repos\ReceiveSmsBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\slore\source\repos\ReceiveSmsBlazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\slore\source\repos\ReceiveSmsBlazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\slore\source\repos\ReceiveSmsBlazor\_Imports.razor"
using ReceiveSmsBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\slore\source\repos\ReceiveSmsBlazor\_Imports.razor"
using ReceiveSmsBlazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\slore\source\repos\ReceiveSmsBlazor\Pages\Index.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Messages</h1>\r\n\r\n");
            __builder.OpenElement(1, "table");
            __builder.AddAttribute(2, "class", "table");
            __builder.AddAttribute(3, "id", "messageList");
            __builder.AddMarkupContent(4, "\r\n    ");
            __builder.OpenElement(5, "thead");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.AddMarkupContent(7, "<tr>\r\n            <th>From Number</th>\r\n            <th>Message</th>\r\n        </tr>\r\n");
#nullable restore
#line 13 "C:\Users\slore\source\repos\ReceiveSmsBlazor\Pages\Index.razor"
         foreach (var message in _messages)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(8, "            ");
            __builder.OpenElement(9, "tr");
            __builder.AddMarkupContent(10, "\r\n                ");
            __builder.OpenElement(11, "td");
            __builder.AddContent(12, 
#nullable restore
#line 16 "C:\Users\slore\source\repos\ReceiveSmsBlazor\Pages\Index.razor"
                     message.FromNumber

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n                ");
            __builder.OpenElement(14, "td");
            __builder.AddContent(15, 
#nullable restore
#line 17 "C:\Users\slore\source\repos\ReceiveSmsBlazor\Pages\Index.razor"
                     message.Text

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n");
#nullable restore
#line 19 "C:\Users\slore\source\repos\ReceiveSmsBlazor\Pages\Index.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(18, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 24 "C:\Users\slore\source\repos\ReceiveSmsBlazor\Pages\Index.razor"
       
    private HubConnection _hubConnection;
    private List<Message> _messages = new List<Message>();
    private class Message
    {
        public string FromNumber { get; set; }
        public string Text { get; set; }
    }

    protected override async Task OnInitializedAsync()
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/SmsHub"))
            .Build();
        _hubConnection.On<string, string>("ReceiveMessage", (from, text) =>
        {
            var message = new Message { FromNumber = from, Text = text };
            _messages.Add(message);
            StateHasChanged();
        });
        await _hubConnection.StartAsync();
    }

    public bool IsConnected => _hubConnection.State == HubConnectionState.Connected;

    public void Dispose()
    {
        _ = _hubConnection.DisposeAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591