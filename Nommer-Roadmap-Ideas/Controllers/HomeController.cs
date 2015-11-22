using Github_Idea_Lodger.Models;
using Octokit;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Github_Idea_Lodger.Controllers
{
    public class HomeController : Controller
    {
        private async Task<string> sendToApi(Idea idea)
        {
            var client = new GitHubClient(new ProductHeaderValue("Nommer-Idea-Lodger"));
            client.Credentials = new Credentials(Environment.GetEnvironmentVariable("GithubKey"));

            var newIdea = new NewIssue(idea.title) { Body = idea.description };
            newIdea.Labels.Add("idea");

            var response = await client.Issue.Create("NickBrooks", "Nommer-Roadmap", newIdea);

            return response.ToString();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string idea, string description)
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

        public ActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
