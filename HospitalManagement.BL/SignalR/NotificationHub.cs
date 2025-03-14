using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.SignalR
{
    public class NotificationHub : Hub
    {
        private static List<string> _activeUsers = new List<string>();

        public async Task UserLoggedIn(string username)
        {
            if (!_activeUsers.Contains(username))
            {
                _activeUsers.Add(username);
            }

            await Clients.All.SendAsync("UserStatusChanged", username, true); 
        }

        public async Task UserLoggedOut(string username)
        {
            if (_activeUsers.Contains(username))
            {
                _activeUsers.Remove(username);
            }

            await Clients.All.SendAsync("UserStatusChanged", username, false); 
        }

        public Task<List<string>> GetActiveUsers()
        {
            return Task.FromResult(_activeUsers);
        }
    }

}
