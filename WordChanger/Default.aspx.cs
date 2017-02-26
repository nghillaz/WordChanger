using System;
using System.Collections;
using System.Linq;
using System.Web.UI;
using System.Net;
using System.IO;
using System.Collections;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;

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
        public Hashtable WordHashTable;
        public Hashtable NonoListHashTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (WordList == null || WordList.Count == 0)
                WordList = new ArrayList();
            if (WordHashTable == null || WordHashTable.Count == 0)
                WordHashTable = new Hashtable();
            if (NonoListHashTable == null || NonoListHashTable.Count == 0)
                NonoListHashTable = new Hashtable();
        }

        protected void Submit_Button(object sender, EventArgs e)
        {
            string inputText = inputBox.Text;
            ArrayList parsedText = new ArrayList();
            String sub = "";


            int i = 0;
            while (i < inputText.Length)
            {
                if (Char.IsLetter(inputText[i]))
                {
                    sub += inputText.Substring(i, 1);
                    if (i + 1 == inputText.Length || char.IsLetter(inputText[i + 1]) == false)
                    {
                        parsedText.Add(sub);
                    }
                }
                else
                {
                    sub = inputText.Substring(i, 1);
                    parsedText.Add(sub);
                    sub = "";
                }
                i++;
            }

            for (i = 0; i < parsedText.Count; i++)
            {
                AddWord((string)parsedText[i]);
            }
            Drop_Down_Maker();
        }
        //Finds the values of the drop down lists and compiles them into the final text box. 
        protected void Final_Button(object sender, EventArgs e)
        {
            String finalOut = "";
              for (int i = 0; i < dropDownPanel.Controls.Count; i++)
            {
                if (dropDownPanel.Controls[i] is DropDownList)
                {
                    finalOut += ((DropDownList)dropDownPanel.Controls[i]).SelectedValue;
                }
                else if (dropDownPanel.Controls[i] is Label){ 
                    finalOut += ((Label)dropDownPanel.Controls[i]).Text;
                }
                else
                {
                    //ignore
                }
                
            }
            outputLb.Text = finalOut;
        
        }

        protected void Drop_Down_Maker()
        {
            for (int i = 0; i < WordList.Count; i++)
            {
                //check to see if it should even be a dropdown menu
                if (((Word)WordList[i]).synonyms == null || ((Word)WordList[i]).synonyms.Count == 0)
                {
                    Label lab = new Label();
                    lab.Text = ((Word)WordList[i]).word;
                    dropDownPanel.Controls.Add(lab);
                }
                else {
                    DropDownList ddl = new DropDownList();
                    ddl.Items.Add(((Word)WordList[i]).word);
                    ddl.BorderStyle = BorderStyle.None;
                    for (int j = 0; j < ((Word)WordList[i]).synonyms.Count; j++)
                    {
                        ListItem dropdownItem = new ListItem();
                        dropdownItem.Text = (string)((Word)WordList[i]).synonyms[j];
                        dropdownItem.Value = "" + j;
                        ddl.Items.Add(dropdownItem);
                    }
                    dropDownPanel.Controls.Add(ddl);
                }
            }
        }

        void AddWord(string addWordString)
        {
            //if the word is on the nonolist, add a placeholder word with no synonyms
            if (IsInNonoList(addWordString))
            {
                Word newWord = new Word();
                newWord.word = addWordString;
                WordList.Add(newWord);
                return;
            }
            //if the word has already been looked up on the api
            //add it to the word array, but skip the step of checking the api
            if (WordHashTable.Contains(addWordString))
            {
                WordList.Add(WordHashTable[addWordString]);
            }
            //the word hasn't been searched
            else
            {
                //exception catching for web exceptions
                try
                {
                    string apikey = File.ReadAllText(Server.MapPath("~") + "\\Resources\\api.txt", Encoding.UTF8);
                    string jsonString = "";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://wordsapiv1.p.mashape.com/words/" + addWordString + "/synonyms");
                    request.Method = "GET";
                    request.Headers.Add("X-Mashape-Key", apikey);
                    jsonString = "";
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
                    //check to see if there are no synonyms
                    if (formattedJson[1].Substring(13, formattedJson[1].Length - 14) == "")
                    {
                        //no synonyms
                        newWord.synonyms.Clear();
                        WordHashTable.Add(addWordString, newWord);
                        WordList.Add(newWord);
                        return;
                    }
                    else
                        //first synonym
                        newWord.synonyms.Add(formattedJson[1].Substring(13, formattedJson[1].Length - 14));
                    for (int i = 2; i < formattedJson.Length - 1; i++)
                    {
                        newWord.synonyms.Add(formattedJson[i].Substring(1, formattedJson[i].Length - 2));
                    }
                    newWord.synonyms.Add(formattedJson[formattedJson.Length - 1].Substring(1, formattedJson[formattedJson.Length - 1].Length - 4));

                    //add new word to hashtable in order to speed up lookup time in the future
                    WordHashTable.Add(addWordString, newWord);
                    WordList.Add(newWord);
                }
                catch (WebException)
                {
                    Word exceptionWord = new Word();
                    exceptionWord.word = addWordString;
                    WordHashTable.Add(addWordString, exceptionWord);
                    WordList.Add(exceptionWord);
                    return;
                }
            }
        }

        bool IsInNonoList(string nonoInput)
        {
            if (NonoListHashTable.Count == 0)
            {
                string nonolist = File.ReadAllText(Server.MapPath("~") + "\\Resources\\nonolist.txt", Encoding.UTF8);
                string[] nonolistArray = nonolist.Split(',');
                for (int i = 0; i < nonolistArray.Length; i++)
                    if (!NonoListHashTable.ContainsKey(nonolistArray[i]))
                        NonoListHashTable.Add(nonolistArray[i], nonolistArray[i]);
            }
            return NonoListHashTable.ContainsKey(nonoInput);
        }
    }
}