using DiveDeepWebApp.Api.Models;
using Microsoft.AspNetCore.Identity;
namespace DiveDeepWebApp.Api.Data;
// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public List<Booking> Bookings { get; set; }
    public List<CartItem> CartItems { get; set; }
}
