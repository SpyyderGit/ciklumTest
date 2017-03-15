using HtmlAgilityPack;
using System;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace BookStore.Models
{
    public class BookDbinitializer : DropCreateDatabaseAlways<BookContext>
    {
        
        
       public BookContext addBook(BookContext bc) {

            
                        HtmlWeb website = new HtmlWeb();
                        HtmlDocument document = website.Load("http://www.yakaboo.ua/top100/category/bestsales/id/4723/");

                        HtmlNodeCollection Info = document.DocumentNode.SelectNodes("//div[@class = 'caption']");
                        var images = document.DocumentNode.SelectNodes("//li/a[@class='thumbnail']/img[contains(@src, 'http')]");
            
                        if (document != null)
                        {
                            string pattern = @"\D";
                            foreach (HtmlNode addAuthor in Info)
                            {
                                try
                                {   string path = addAuthor.ChildNodes["table"].InnerText;
                                    string title = addAuthor.ChildNodes["h3"].FirstChild.InnerText;
                                    string author = addAuthor.ChildNodes[5].FirstChild.InnerText;
                                    string remark = addAuthor.ChildNodes[11].FirstChild.InnerText;
                                    double price = Convert.ToInt32(Regex.Replace(path, pattern, String.Empty));
                                    bc.Books.Add(new Book { Name = title, Author = author, Price = price, Remark = remark });
                                }
                                catch (NullReferenceException e)
                                {

                                }
                            }
                        }
            return bc;
        }

        
        protected override void Seed(BookContext db)
        {
            base.Seed(addBook(db));            
        }
    }
}