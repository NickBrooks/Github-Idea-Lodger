using Flurl.Http;
using Github_Idea_Lodger.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Github_Idea_Lodger.Controllers
{
    public class HomeController : Controller
    {
        private async Task<string> sendToApi(Idea idea)
        {
            string URL = "https://api.github.com/repos/NickBrooks/Nommer-Roadmap/issues?access_token=" + Environment.GetEnvironmentVariable("GithubKey"); ;
            var labelList = new List<string>();
            labelList.Add("idea");

            var response = await URL
                .WithHeader("User-Agent", "NickBrooks")
                .PostUrlEncodedAsync(new
                {
                    title = idea.title,
                    body = idea.description,
                    assignee = "NickBrooks",
                    labels = labelList
                })
                .ReceiveString();

            return response;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string idea, string description)
        {
            if (idea == "" || idea == null)
            {
                ViewData["Result"] = "Enter an idea yo!";
                return View();
            }

            Idea newIdea = new Idea();
            newIdea.title = idea;
            newIdea.description = description;

            try
            {
                await sendToApi(newIdea);
                ViewData["Result"] = "You're an ideas man";
            }
            catch (Exception ex)
            {
                ViewData["Result"] = ex.ToString();
            }            

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
