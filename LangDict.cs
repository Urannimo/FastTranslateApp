using System;
using System.Net;
using System.IO;

namespace TranslateAppOne
{
    public class LangDict
    {
        public LangDict()
        {
            var answer = getAllLanguages();
        }

        private string getAllLanguages()
        {
            try
            {
                HttpWebRequest newReq = WebRequest.CreateHttp(appSettings.apiBaseAllLang + appSettings.getApikey() + "&ui=ru");
                return sendRequest(newReq);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}