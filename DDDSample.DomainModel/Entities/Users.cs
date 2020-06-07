using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDSample.DomainModel
{
    public class Users
    {
        private List<User> _Users;

        public Users ()
        {
            _Users = new List<User> ();
        }

        public int Count { get { return _Users.Count (); } }

        public User GetById (Id id)
        {
            return _Users.SingleOrDefault (x => x.Id == id);
        }

        public void Add (User user)
        {
            _Users.Add (user);
        }
    }
}