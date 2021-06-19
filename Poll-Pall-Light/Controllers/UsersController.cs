using System.Linq;
using System.Threading.Tasks;
using AItemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poll_Pall_Light.Models;
using PollAPI.Services;
using QItemAPI.Services;

namespace Poll_Pall_Light.Controllers
{
	[Authorize]
	public class UsersController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IAService _aService;
		private readonly IQService _qService;
		private readonly IPollService _pollService;
		public UsersController(UserManager<ApplicationUser> userManager, IPollService pollService, IAService aService, IQService qService)
		{
			_userManager = userManager;
			_pollService = pollService;
			_aService = aService;
			_qService = qService;
		}
		public async Task<IActionResult> Index()
		{
			var allUser = await _userManager.Users.ToListAsync();
			return View(allUser);
		}

		public async Task<IActionResult> Delete(string userId)
		{
			var deleteUser = await _userManager.FindByIdAsync(userId);
			var pollsByUser = await _pollService.GetPollsByUserId(userId);
			if (deleteUser != null)
			{
				foreach (var poll in pollsByUser)
				{
					_pollService.DeletePItem(poll.ID);

					var q = await _qService.GetQItemsByPollId(poll.ID);

					foreach (var n in q)
					{
						_aService.DeleteAItemsByQId(n.ID);
					}

					_qService.DeleteQItemsByPollId(poll.ID);
				}

				await _userManager.DeleteAsync(deleteUser);
				return RedirectToAction("Index", "Users", null, null);
			}

			return View(NotFound());
		}
	}
}