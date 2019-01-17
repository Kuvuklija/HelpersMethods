using System;
using System.Web.Mvc;

namespace HelpersMethods.Infrastructure{

    public static class CustomHelper{
        public static MvcHtmlString ListArrayItems(this HtmlHelper html, string[] list) {
            TagBuilder div = new TagBuilder("div");
            TagBuilder tag = new TagBuilder("ul");
            foreach(string str in list) {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(str);
                tag.InnerHtml += itemTag.ToString();
            }
            TagBuilder p = new TagBuilder("p");
            p.SetInnerText("Controller: "+html.ViewContext.Controller.ToString());

            div.InnerHtml = tag.ToString() + p.ToString();
            return new MvcHtmlString(div.ToString());
        }

        //public static MvcHtmlString DisplayMessage(this HtmlHelper html, string msg){ //it is vulnerability
        //public static string DisplayMessage(this HtmlHelper html, string msg){   //1 way to protection, but whole message has encoded, with <p>
        public static MvcHtmlString DisplayMessage(this HtmlHelper html, string msg){ //2 way more selective and encoded just I needing
            string encodedMessage = html.Encode(msg); //2 way
            string result = String.Format("This is the message: <p>{0}</p>", encodedMessage);
            return new MvcHtmlString(result); 
        }
    }
}