using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Panda.Core
{
    public class MyDbContext : DbContext
    {
        //public virtual DbSet<User> Users { get; set; }
        //public virtual DbSet<Menu> Menus { get; set; }
        //public virtual DbSet<Role> Roles { get; set; }
        //public virtual DbSet<UserRole> UserRoles { get; set; }
        //public virtual DbSet<RoleMenu> RoleMenus { get; set; }


        public MyDbContext(DbContextOptions<MyDbContext> options)
         : base(options)
        {
        }

    }
}
