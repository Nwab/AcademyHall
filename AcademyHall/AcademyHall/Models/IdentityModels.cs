using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AcademyHall.DataLink;
using System.ComponentModel.DataAnnotations;
using System;

namespace AcademyHall.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AcademyUser : IdentityUser<int, AcademyUserLogin, AcademyUserRole, AcademyUserClaim>
    {
        public string studentID { get; set; }
        public string StaffID { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateCreated { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AcademyUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class AcademyUserLogin : IdentityUserLogin<int> { }

    public class AcademyUserRole : IdentityUserRole<int> { }
    public class AcademyUserClaim : IdentityUserClaim<int> { }
    public class AcademyRole : IdentityRole<int, AcademyUserRole>
    {
        public AcademyRole() { }

        public AcademyRole(string roleName)
        {
            this.Name = roleName;
        }

        public AcademyRole(string name, string description)
            : this(name)
        {
            this.RoleDescription = description;
        }
        public string RoleDescription { get; set; }
    }

    public class AcademyUserStore : UserStore<AcademyUser, AcademyRole, int,
    AcademyUserLogin, AcademyUserRole, AcademyUserClaim>
    {
        public AcademyUserStore(AcademyHallDbContext context)
            : base(context)
        {
        }
    }

    public class AcademyRoleStore : RoleStore<AcademyRole, int, AcademyUserRole>
    {
        public AcademyRoleStore(AcademyHallDbContext context)
            : base(context)
        {
        }
    }
}
    