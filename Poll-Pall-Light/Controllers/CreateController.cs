using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AItemAPI.Models;
using AItemAPI.Services;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Poll_Pall_Light.Models;
using PollAPI.Models;
using PollAPI.Services;
using QItemAPI.Models;
using QItemAPI.Services;
using QnAAPI.Services;

namespace Poll_Pall_Light.Controllers 
{
    public class CreateController : Controller 
    {
        /// <summary>
        /// Services And Constructor
        /// </summary>
        private readonly UserManager<ApplicationUser> _manager;
        
        private readonly IAService _aService;
        private readonly IQService _qService;
        private readonly IPollService _pollService;

        private List<QItem> _initQ;

        public CreateController(IAService aService, IQService qService, IPollService pollService, UserManager<ApplicationUser> manager)
        {
            _aService = aService;
            _qService = qService;
            _pollService = pollService;
            _manager = manager;
        }
        
        /// <summary>
        /// Poll Index View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var p = new PItemViewModel
            {
                Polls = await _pollService.GetPollsByUserId(userId)
            };

            var q = new List<QItem>();
            
            foreach (var x in p.Polls)
            {
                q.AddRange(await _qService.GetQItemsByPollId(x.ID));
            }

            p.QItems = q;
            
            return View(p);
        }
        
        /// <summary>
        /// Sorting
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> IndexSortedByNameAscending()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var p = new PItemViewModel
            {
                Polls = await _pollService.SortPollsByNameByPollId(userId)
            };

            var q = new List<QItem>();
            
            foreach (var x in p.Polls)
            {
                q.AddRange(await _qService.GetQItemsByPollId(x.ID));
            }

            p.QItems = q;
            
            return View(p);
        }  
        
        [HttpGet]
        public async Task<IActionResult> IndexSortedByNameDescending()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var p = new PItemViewModel
            {
                Polls = await _pollService.SortPollsByNameByPollIdDescending(userId)
            };

            var q = new List<QItem>();
            
            foreach (var x in p.Polls)
            {
                q.AddRange(await _qService.GetQItemsByPollId(x.ID));
            }

            p.QItems = q;
            
            return View(p);
        }  

        /// <summary>
        /// Create Poll
        /// </summary>
        /// <param name="pItemViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreatePoll(PItemViewModel pItemViewModel)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var q = new QItem()
            {
                Title = pItemViewModel.QTitle,
                EndPoll = false
            };
            _qService.AddQItem(q);
            
            var p = new Poll()
            {
                Title = pItemViewModel.PollTitle,
                Description = pItemViewModel.PollDescription,
                QRootID = q.ID,
                UserId = currentUserId,
                IsPrivate = pItemViewModel.IsPrivate
            };
            _pollService.AddPItem(p);

            var x = await _pollService.GetPollByQRootId(p.QRootID);
            
            q.PollID = x.ID;
            _qService.UpdateQItem(q);

            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// Create Q
        /// </summary>
        /// <param name="qItemViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateQItem(QItemViewModel qItemViewModel)
        {
            int x = Convert.ToInt32(TempData["idCurrent"]);
 
            var q = new QItem()
            {
                Title = qItemViewModel.QCreateViewModel.Title,
                EndPoll = false,
                PollID = x
            };
            _qService.AddQItem(q);
            var i = await _qService.GetLastQItemByPollId(x);

            var p = new PollVariables
            {
                QId = i.ID,
                PollId = x,
                Boolean = qItemViewModel.QBool,
                Picture = ImageToByteArraybyMemoryStream(qItemViewModel.Image),
                Text = qItemViewModel.PollVariables.Text,
                Number = qItemViewModel.PollVariables.Number
            };

            var qiv = new QItemViewModel
            {
                QItem = i,
                PollVariables = p,
                Image = qItemViewModel.Image,
                QBool = qItemViewModel.QBool,
                QImage = qItemViewModel.QImage,
                QText = qItemViewModel.QText,
                QNumber = qItemViewModel.QNumber
                
            };

            _pollService.AddPollVariableItem(p);

            return View(qiv);
        }
        
        [HttpGet]
        public async Task<IActionResult> QView(int? id)
        {
            Poll p;

            QItemViewModel pnQ;
            
            var y = Convert.ToInt32(TempData["idCurrent"]);
            
            if(id != 0)
                p = await _pollService.GetPollById(id);
            else
                p = await _pollService.GetPollById(y);
            
            _initQ = new List<QItem>
            {
                new(){PollID = p.ID, Title = "Init Q"}
            };
            
            var l = await _qService.GetQItemsByPollId(p.ID);
            
            if (l.Count == 0)
            {
                pnQ = new QItemViewModel()
                {
                    AItems = await _aService.GetAItems(),
                    QCreateViewModel = new QCreateViewModel(),
                    QItems = _initQ,
                    PollTitle = p.Title,
                    PollID = p.ID
                };
            }
            else
            {
                 pnQ = new QItemViewModel()
                 {
                     AItems = await _aService.GetAItems(),
                     QCreateViewModel = new QCreateViewModel(),
                     QItems = l,
                     PollTitle = p.Title,
                     PollID = p.ID
                 };               
            }

            ViewData["qCreate"] = new QCreateViewModel();
            ViewData["PollID"] = pnQ.PollID;

            return View(pnQ);
        }

        /// <summary>
        /// A View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AView(int? id)
        {
           // TODO -Give poll id with x 
           
            var y = Convert.ToInt32(TempData["idCurrent"]);
            var pId = Convert.ToInt32(TempData["id"]);
            
            var q = await _qService.GetQItemByID(id);
            
            var aList = await _aService.GetAItemsByQId(id);

            var a = new AItemViewModel
            {
                Title = q.Title,
                AItems = aList,
                QConnectedByPollId = await _qService.GetQItemsByPollId(q.PollID),
                PollId = pId
            };

            ViewData["Qid"] = id;
            ViewData["Pid"] = y;
            ViewData["pId"] = pId;
            
            return View(a);
        }
        
        /// <summary>
        /// Create A
        /// </summary>
        /// <param name="aItemViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateAItem(AItemViewModel aItemViewModel)
        {
            var i = Convert.ToInt32(TempData["idQ"]);

            var y = Convert.ToInt32(TempData["p"]);
            
            var a = new AItem
            {
                Title = aItemViewModel.AItem.Title,
                QItemID = i,
                QID = aItemViewModel.QId,
                isChecked = aItemViewModel.rightAnswer
            };
            
            _aService.AddAItem(a);
            
            return RedirectToAction("AView", new {id = i});
        }
        
        private static byte[] ImageToByteArraybyMemoryStream(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }        
    }
}
