using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Integration.Api.Models
{
    /// <summary>
    /// Class with informations of the user
    /// </summary>
    public class User
    {
        /// <summary>
        /// Code of the user
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Role of the user
        /// </summary>
        public string Role { get; set; }
    }
}
