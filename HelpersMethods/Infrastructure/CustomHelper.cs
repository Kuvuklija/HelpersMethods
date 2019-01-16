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
    }
}