using DesignPatternsDemo.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Text;
using static DesignPatternsDemo.Model.MediatorModel;

namespace DesignPatternsDemo.Controllers
{
    public class MediatorController : Controller
    {
        public string Index()
        {
            StringBuilder sb = new StringBuilder();
            var room = new ChatRoom();
            var ac = new IoTDevice("Air Conditioner");
            var asp = new IoTDevice("Aspirator");
            room.Join(ac);
            room.Join(asp);
            ac.changeState();
            string alert = "Air Conditioner" + (ac.state ? " activated" : " deactivated");
            ac.Alert(alert);
            asp.Alert("Ok.");
            var siri = new IoTDevice("Siri");
            room.Join(siri);
            siri.changeState();
            alert = "Siri" + (siri.state ? " activated" : " deactivated");
            siri.Alert(alert);
            ac.PrivateAlert("Siri", "Air Conditioner" + (ac.state ? " activated" : " deactivated"));
            sb.AppendLine("Air Conditioner:");
            foreach(string el in ac.chatLog)
            {
                sb.AppendLine(el);
            }
            sb.AppendLine("Aspirator:");
            foreach (string el in asp.chatLog)
            {
                sb.AppendLine(el);
            }
            sb.AppendLine("Siri:");
            foreach (string el in siri.chatLog)
            {
                sb.AppendLine(el);
            }
            return sb.ToString();
        }
    }
}
