using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WordChanger
{
    public partial class _Default : Page
    {
        ArrayList words = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Submit_Button(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ', ',', '.', ';', '\t', '"' };
            var wordList = inputBox.Text.Split(delimiterChars);
            Populate_Word_List(wordList);
            PrintDat(wordList);
        }
        protected void Populate_Word_List(string[] wordList)
        {
            
        }
        protected void PrintDat(string[] wordList)
        {
            dropDownPar.InnerText = wordList[2];
        }
    /*    protected void Drop_Down_Maker()
        {
            for (int i = 0; i < words.Count; i++)
            {
     //           setToList(word)
            }
        }
    //    protected void setToList(Word word)
        {

        }*/
    }

}