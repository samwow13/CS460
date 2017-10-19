using HW5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HW5.DAL
{
    public class RequestContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
    }
}