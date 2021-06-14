using System.Collections.Generic;

namespace Poll_Pall_Light.Models
{
	public class PermissionViewModel
	{
		public string RoleId { get; set; }
		public IList<RoleClaimsViewModel> RoleClaims { get; set; }
	}
}