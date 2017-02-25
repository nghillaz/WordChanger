﻿using System;
using System.Web.UI;
using System.Net;
using System.IO;
using System.Collections;

namespace WordChanger
{
    class Word
    {
        public string word;
        public string[] synonyms;
    }

    public partial class _Default : Page
    {
        public ArrayList WordList;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

<<<<<<< HEAD
        void AddWord(string addWordString)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://wordsapiv1.p.mashape.com/words/" + addWordString + "/synonyms");
            request.Method = "GET";
            request.Headers.Add("X-Mashape-Key", "ZkjLwuPJ5tmshpTGXkwqIwe4F8bEp1UjUdDjsn6C4XGPIWxytS");
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
            newWord.synonyms = new string[formattedJson.Length - 2];

            newWord.word = formattedJson[0].Substring(9, formattedJson[0].Length - 10);
            newWord.synonyms[0] = formattedJson[1].Substring(13, formattedJson[1].Length - 14);
            for (int i = 2; i < formattedJson.Length - 1; i++)
            {
                newWord.synonyms[i - 1] = formattedJson[i].Substring(1, formattedJson[i].Length - 2);
            }
            newWord.synonyms[formattedJson.Length - 2] = formattedJson[formattedJson.Length - 1].Substring(1, formattedJson[formattedJson.Length - 1].Length - 4);

            WordList.Add(newWord);
=======
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

>>>>>>> ecf85a11f9902546d74fb3518ca302ce34c3d5cc
        }
    }
}