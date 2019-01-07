using SmileyProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SmileyProject.BusinessLogic
{
    class JSONHelper
    {

        public List<Categories> GetCategories()
        {
            List<Categories> List = new List<Categories>();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string content = File.ReadAllText("smiley_content.json");
            List = jss.Deserialize<List<Categories>>(content);
            return List;
        }

    }
}
