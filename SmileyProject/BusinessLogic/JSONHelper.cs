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

        public List<Smiley> GetSmileys()
        {
            List<Smiley> smileyList = new List<Smiley>();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string content = File.ReadAllText("smiley_content.json");
            smileyList = jss.Deserialize<List<Smiley>>(content);
            return smileyList;
        }

    }
}
