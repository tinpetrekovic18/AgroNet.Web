using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroNet.Model
{
    public class AppUser:IdentityUser
    {

        [ForeignKey("Vlasnik")]
        public int VlasnikId { get; set; }

    }
}
