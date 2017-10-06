using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using ICO.Core.Entities;

namespace ICO.Services.IcoServices
{
    public class IcoService : IIcoService
    {
        /// <summary>
        /// Get data by ico from database or from ARES online system
        /// </summary>
        /// <param name="ico">specific ico</param>
        /// <returns>entry from database or ARES</returns>
        public virtual Data GetDataByIcoFromDb(int ico)
        {
            using (var cx = new icosContext())
            {
                return cx.Data.Include(x => x.ObecNavigation).Include(y => y.OkresNavigation).Where(z => z.Ico == ico).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get ico data from online ARES system
        /// </summary>
        /// <param name="ico">specific ico</param>
        /// <returns>ico entry from ARES</returns>
        public virtual Zaznam GetDataByIcoFromARES(int ico)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_std.cgi?ico=" + ico.ToString()).Result;
            var result = response.Content.ReadAsStringAsync();

            XDocument doc = XDocument.Parse(result.Result, LoadOptions.PreserveWhitespace);
            doc.Descendants().Attributes().Where(a => a.IsNamespaceDeclaration).Remove();
            foreach (var elem in doc.Descendants())
                elem.Name = elem.Name.LocalName;
            string finalXml = doc.ToString();

            Ares_odpovedi model = new Ares_odpovedi();
            XmlSerializer serializer = new XmlSerializer(typeof(Ares_odpovedi));
            using (TextReader reader = new StringReader(finalXml))
            {
                model = (Ares_odpovedi)serializer.Deserialize(reader);
            }

            return model.Odpoved.Zaznam;
        }
    }
}
