using System;
using System.Web.UI;
using System.Net;
using System.IO;
using System.Collections;
using System.Text;

namespace WordChanger
{
    public class Word
    {
        public string word;
        public ArrayList synonyms;
    }

    public partial class _Default : Page
    {
        public ArrayList WordList;

        protected void Page_Load(object sender, EventArgs e)
        {
            WordList = new ArrayList();

            AddWord("dude");
        }

        void AddWord(string addWordString)
        {
            string apikey = File.ReadAllText(Server.MapPath("~") + "\\Resources\\api.txt", Encoding.UTF8);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://wordsapiv1.p.mashape.com/words/" + addWordString + "/synonyms");
            request.Method = "GET";
            request.Headers.Add("X-Mashape-Key", apikey);
            string jsonString = "";
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    jsonString = reader.ReadToEnd();
                }
            }
            string[] formattedJson = jsonString.Split(',');

            Word newWord = new Word();
            newWord.synonyms = new ArrayList();
            
            newWord.word = formattedJson[0].Substring(9, formattedJson[0].Length - 10);
            newWord.synonyms.Add(formattedJson[1].Substring(13, formattedJson[1].Length - 14));
            for (int i = 2; i < formattedJson.Length - 1; i++)
            {
                newWord.synonyms.Add(formattedJson[i].Substring(1, formattedJson[i].Length - 2));
            }
            newWord.synonyms.Add(formattedJson[formattedJson.Length - 1].Substring(1, formattedJson[formattedJson.Length - 1].Length - 4));

            WordList.Add(newWord);
        }
    }
}