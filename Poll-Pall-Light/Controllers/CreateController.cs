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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

            var qI = await _qService.GetQItemsByPollId(x);

            var aList = new List<AItem>();

            foreach (var g in qI){
                var aI = await _aService.GetAItemsByQId(g.ID);
                aList.AddRange(aI);
            }

            var p = new PollVariables
            {
                QId = i.ID,
                AId = 0,
                PollId = x,
                Boolean = qItemViewModel.QBool,
                Text = qItemViewModel.PollVariables.Text,
                Number = qItemViewModel.PollVariables.Number,
                QBool = qItemViewModel.QBool,
                QImage = qItemViewModel.QImage,
                QText = qItemViewModel.QText,
                QNumber = qItemViewModel.QNumber               
            };

            var qiv = new QItemViewModel
            {
                QItem = i,
                AItems = aList,
                QItems = qI,
                Image = qItemViewModel.Image,
                QBool = p.QBool,
                QImage = p.QImage,
                QText = p.QText,
                QNumber = p.QNumber
                
            };
            
            if (qItemViewModel.Image is { Length: > 0 }){
                await using var fs1 = qItemViewModel.Image.OpenReadStream();
                await using var ms1 = new MemoryStream();
                await fs1.CopyToAsync(ms1);
                var p1 = ms1.ToArray();
                p.Picture = p1;
            }
            
            _pollService.AddPollVariableItem(p);
            
            var pL = new List<PollVariables>();

            foreach (var qLi in qI){
                var n = await _pollService.GetPollVariablesByPollAndQId(x, qLi.ID);
                pL.AddRange(n);
            }

            qiv.VariablesList = pL;
            
            return View(qiv);
        }
        
        /// <summary>
        /// Q View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> QView(int? id)
        {
            Poll p;

            QItemViewModel pnQ;
            
            var y = Convert.ToInt32(TempData["idCurrent"]);

            int? idSure = 0;

            List<QItem> l;

            if (id != 0){
                 p = await _pollService.GetPollById(id);
                 l = await _qService.GetQItemsByPollId(id);
                 idSure = id;
            }

            else{
                p = await _pollService.GetPollById(y);
                l = await _qService.GetQItemsByPollId(y);
                idSure = y;
            }
            
            _initQ = new List<QItem>
            {
                new(){PollID = p.ID, Title = "Init Q"}
            };

            var pL = new List<PollVariables>();
            

            foreach (var qLi in l){
                var n = await _pollService.GetPollVariablesByPollAndQId(idSure, qLi.ID);
                pL.AddRange(n);
            }

            
            if (l.Count == 0)
            {
                pnQ = new QItemViewModel()
                {
                    AItems = await _aService.GetAItems(),
                    QCreateViewModel = new QCreateViewModel(),
                    VariablesList = pL,
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
                     VariablesList = pL,
                     QItems = l,
                     PollTitle = p.Title,
                     PollID = p.ID
                 };               
            }

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
           
            var pId = Convert.ToInt32(TempData["id"]);
            
            var q = await _qService.GetQItemByID(id);
            
            var aList = await _aService.GetAItemsByQId(id);

            var pVars = new List<PollVariables>();

            foreach (var i in aList){
                pVars.AddRange(await _pollService.GetPollVariablesByPollAndAAndQId(q.PollID, q.ID, i.ID));
            }

            var a = new AItemViewModel
            {
                Title = q.Title,
                AItems = aList,
                QConnectedByPollId = await _qService.GetQItemsByPollId(q.PollID),
                QItemId = q.ID,
                PollId = pId,
                VariablesList = pVars
            };

            ViewData["Qid"] = q.ID;
            
            return View(a);
        }
        
        /// <summary>
        /// Create A
        /// </summary>
        /// <param name="aItemViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateAItem(AItemViewModel aItemViewModel)
        {
            var i = Convert.ToInt32(TempData["idQCurrent"]);

            var a = new AItem
            {
                QItemID = i,
                QID = aItemViewModel.QId,
                
            };

            _aService.AddAItem(a);
            
            var currentA = await _aService.GetLastAItemByQID(i);

            var currentQ = await _qService.GetQItemByID(i);

            var pVar = new PollVariables
            {
                AId = currentA.ID,
                QId = i,
                PollId = currentQ.PollID,
                Boolean = aItemViewModel.PollVariables.Boolean,
                Text = aItemViewModel.PollVariables.Text,
                Number = aItemViewModel.PollVariables.Number,
                QBool = aItemViewModel.QBool,
                QImage = aItemViewModel.QImage,
                QText = aItemViewModel.QText,
                QNumber = aItemViewModel.QNumber
            };
            
            if (aItemViewModel.Image is { Length: > 0 }){
                await using var fs1 = aItemViewModel.Image.OpenReadStream();
                await using var ms1 = new MemoryStream();
                await fs1.CopyToAsync(ms1);
                var p1 = ms1.ToArray();
                pVar.Picture = p1;
            } 
            
            var aList = await _aService.GetAItemsByQId(currentQ.ID);
            
            var aItemView = new AItemViewModel
            {
                Title = currentQ.Title,
                AItems = aList,
                QConnectedByPollId = await _qService.GetQItemsByPollId(currentQ.PollID),
                QItemId = currentQ.ID,
                PollId = currentQ.PollID,
                
            };

            var varList = new List<PollVariables>();
            
            _pollService.AddPollVariableItem(pVar);
            
            foreach(var ai in aItemView.AItems)
                varList.AddRange(await _pollService.GetPollVariablesByPollAndAAndQId(currentQ.PollID, currentQ.ID, ai.ID));

            aItemView.VariablesList = varList;


            return View(aItemView);
        }
    }
}
