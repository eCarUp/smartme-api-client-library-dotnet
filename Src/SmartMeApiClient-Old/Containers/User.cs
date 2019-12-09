#region License
// Copyright (c) 2019 smart-me AG https://www.smart-me.com/
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;
using System.Collections.Generic;

namespace SmartMeApiClient.Containers
{
    /// <summary>
    /// Container Class for the smart-me User
    /// </summary>
    public class User
    {
        public User()
        {
            ChildUsers = new List<User>();
        }

        /// <summary>
        /// The ID of the User
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// The Username of the User
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The EMail Address of the User
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Flag if this User is an Admin User
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// The Users created by this users.
        /// </summary>
        public ICollection<User> ChildUsers { get; set; }
    }
}
