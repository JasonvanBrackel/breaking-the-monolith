using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoreHumanSoftware.Chat.API.Repositories
{
    public class ChatAppBackedMessageRepository : IMessageRepository
    {

        public ChatAppBackedMessageRepository()
        {
        }

        public IEnumerable<Message> List()
        {
            var messages = new List<Message>();
            var timeRegex = new Regex("^(0[0-9]|1[0-9]|2[0-3]|[0-9]):[0-5][0-9]*");
            var client = new WebClient();
            var page = client.DownloadString("http://localhost/display.asp");
            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(page);

            var rows = document.DocumentNode.SelectNodes("//table/tr");

            foreach (var row in rows)
            {
                if (row.ChildNodes.Count > 1)
                {
                    var hasTime = timeRegex.IsMatch(row.ChildNodes[1].InnerText);


                    if (hasTime)
                    {
                        var columns = row.SelectNodes("td");
                        var message = new Message()
                        {
                            Timestamp = (Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " +
                                                            columns[1].InnerText.TrimEnd("&nbsp;".ToCharArray()))),
                            Username = columns[2].InnerText.TrimEnd("&nbsp;".ToCharArray()),
                            Text = columns[3].InnerText.TrimEnd("&nbsp;".ToCharArray())
                        };
                        messages.Add(message);
                    }
                }
            }

            return messages;
        }

        public void StoreMessage(ReceivedMessage message)
        {
            var client = new HttpClient();

            IList<KeyValuePair<string, string>> formItems = new List<KeyValuePair<string, string>>();
            formItems.Add(new KeyValuePair<string, string>("username", message.Username));
            formItems.Add(new KeyValuePair<string, string>("message", message.Message));
            var content = new FormUrlEncodedContent(formItems);
            var response = client.PostAsync("http://localhost/message.asp", content).Result;
        }
    }
}
