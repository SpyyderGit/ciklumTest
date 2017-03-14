using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BookStore.Models
{
    public class BookDbinitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            HtmlWeb website = new HtmlWeb();
            HtmlDocument document = website.Load("http://www.yakaboo.ua/top100/category/bestsales/id/4723/");

            HtmlNodeCollection Info = document.DocumentNode.SelectNodes("//div[@class = 'caption']");

            if (document != null)
            {
                string pattern = @"\D";
                foreach (HtmlNode addAuthor in Info)
                {
                    try
                    {
                        string path = addAuthor.ChildNodes["table"].InnerText;
                        string title = addAuthor.ChildNodes["h3"].FirstChild.InnerText;
                        string author = addAuthor.ChildNodes[5].FirstChild.InnerText;
                        string remark = addAuthor.ChildNodes[11].FirstChild.InnerText;
                        double price = Convert.ToInt32(Regex.Replace(path, pattern, String.Empty));
                        db.Books.Add(new Book { Name = title, Author = author, Price = price, Remark = remark });
                    }
                    catch (NullReferenceException e)
                    {
                        
                    }
                }
            }

            base.Seed(db);            
        }
    }
}