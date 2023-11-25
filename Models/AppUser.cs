using Microsoft.AspNetCore.Identity;

namespace IdentetyPackageProject.Models {
    public class AppUser : IdentityUser {
        public string NickName { get; set; }
    }
}
