using System.Collections.Generic;

namespace Poll_Pall_Light.Models
{
	public class ManageUserRolesViewModel
	{
		public string UserId { get; set; }
		public IList<UserRolesViewModel> UserRoles { get; set; }
	}
}