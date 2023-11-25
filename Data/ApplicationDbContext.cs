using IdentetyPackageProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentetyPackageProject.Data {
    public class ApplicationDbContext : IdentityDbContext<AppUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }


    }
}
