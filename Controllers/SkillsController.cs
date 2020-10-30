using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        [HttpGet("/skills/")]
        public IActionResult Skills()
        {
            string h1 = "<h1>Skills Tracker<h1>";
            string h2 = "<h2>Coding skills to learn:";
            string ol = "<ol><li>C#</li><li>JavaScript</li><li>Java</li></ol>";
            string skillsHtml = h1 + h2 + ol;

            return Content(skillsHtml, "text/html");
        }

        [HttpGet("/skills/form/")]
        [HttpPost("/skills/form/")]
        public IActionResult Form(string cSharp, string javaScript, string java, string date = "empty")
        {
            string dateInput = "<label for='dateForm'>Date:</lable>" + "<br>" +
                "<input type='date' id='dateForm' name='date'>";

            string options = "<option value='learning basics'>Learning Basics</option>" +
                "<option value='making apps'>Making Apps</option>" +
                "<option value='master coder'>Master Coder</option>";

            string cSharpSelect = "<label for='cSharp'>C#</label>" + "</br>" +
                "<select name='cSharp' id='cSharp'>" + options + "</select>";
            string javaScriptSelect = "<label for='javaScript'>JavaScript</label>" + "</br>" +
                "<select name='javaScript' id='javaScript'>" + options + "</select>";
            string javaSelect = "<label for='java'>Java</label>" + "</br>" +
                "<select name='java' id='java'>" + options + "</select>";

            string form = "<form method='post' action='/skills/form/'>" + dateInput + "</br>" +
                cSharpSelect + "</br>" + javaScriptSelect + "</br>" + javaSelect + "</br>" +
                "<input type='submit' value='Submit'/>" + "</form>";

            if (date == "empty")
            {
                return Content(form, "text/html");
            }

            string table = "<table><tr><th><h2>Language</h2></th><th><h2>Skill</h2></th></tr>" + 
                "<tr><td>C#</td><td>" + cSharp + "</td></tr>" +
                "<tr><td>JavaScript</td><td>" + javaScript + "</td></tr>" +
                "<tr><td>Java</td><td>" + java + "</td></tr></table>";


            string formHtml = "<h1>" + date + "</h1>" + table;
            return Content(formHtml, "text/html");
        }
    }
}
