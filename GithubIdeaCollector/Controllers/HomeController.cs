using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GithubIdeaCollector.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string idea, string description)
        {
            if (idea == "" || idea == null)
            {
                ViewBag.Message = "Enter an idea yo!";
                return View();
            }

            try
            {
                var client = new GitHubClient(new ProductHeaderValue("Nommer-Idea-Lodger"));
                client.Credentials = new Credentials(Environment.GetEnvironmentVariable("GithubKey"));

                var newIdea = new NewIssue(idea) { Body = description };
                newIdea.Labels.Add("idea");

                await client.Issue.Create("NickBrooks", "Nommer-Roadmap", newIdea);

                ViewBag.Message = "You're an ideas man";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.ToString();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}