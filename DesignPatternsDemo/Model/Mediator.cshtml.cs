using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using static DesignPatternsDemo.Model.MediatorModel;

namespace DesignPatternsDemo.Model
{
    public class MediatorModel : PageModel
    {
        public class IoTDevice
        {
            public string Name;
            public ChatRoom Room;
            public List<string> chatLog = new List<string>();
            public Boolean state = false;

            public IoTDevice(string name)
            {
                Name = name;
            }

            public void Receive(string sender, string message)
            {
                string s = $"[{Name}'s notification session] {sender}: '{message}'";
                chatLog.Add(s);
            }

            public void changeState()
            {
                state = !state;
            }

            public void Alert(string message)
            {
                Room.Broadcast(Name, message);
                chatLog.Add("Me: " + message);
            }

            public void PrivateAlert(string to, string message)
            {
                state = !state;
                Room.Message(Name, to, message);
            }
        }
    }

    public class ChatRoom
    {
        private List<IoTDevice> devices = new List<IoTDevice>();

        public void Broadcast(string source, string message)
        {
            foreach (var dev in devices)
                if (dev.Name != source)
                    dev.Receive(source, message);
        }

        public void Join(IoTDevice p)
        {
            string joinMsg = $"{p.Name} joined";
            Broadcast("General", joinMsg);
            p.Room = this;
            devices.Add(p);
        }

        public void Message(string source, string destination, string message)
        {
            devices.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
        }
    }
}
