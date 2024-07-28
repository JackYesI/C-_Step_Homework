//using System.Net.Mail;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;

internal class Program
{
    const string user = "mosiichuk.d_ak19@nuwm.edu.ua";
    const string password = "pspo tsxg gdwk ssek";

    static void ShowFolders(ImapClient client)
    {
        var folders = client.GetFolders(client.PersonalNamespaces[0]);
        foreach (var item in folders)
        {
            Console.WriteLine($"Folder: {item.Name}");
        }
    }
    static void ShowMessagesFull(IMailFolder folder)
    {
        folder.Open(FolderAccess.ReadOnly);

        var uids = folder.Search(SearchQuery.All);

        foreach (var uid in uids)
        {
            var message = folder.GetMessage(uid);
            Console.WriteLine($"Subject: {message.Subject}");
            Console.WriteLine($"From: {string.Join(", ", message.From)}");
            Console.WriteLine($"Date: {message.Date}");
            Console.WriteLine($"Body: {message.TextBody}");
            if (message.Attachments != null)
            {
                foreach (var attachment in message.Attachments)
                {
                    if (attachment is MimePart mimePart)
                    {
                        Console.WriteLine($"Attachment: {mimePart.FileName}");
                    }
                    else if (attachment is MessagePart rfc822Part)
                    {
                        Console.WriteLine($"Attached message: {rfc822Part.Message.Subject}");
                    }
                }
            }
            Console.WriteLine(new string('-', 50));
        }
    }
    static void ShowMessages(IMailFolder folder)
    {
        folder.Open(FolderAccess.ReadOnly);

        var uids = folder.Search(SearchQuery.All);

        foreach (var uid in uids)
        {
            var message = folder.GetMessage(uid);
            Console.WriteLine($"Subject: {message.Subject}");
        }
    }
    static MimeMessage GetFirstMessageToReply(ImapClient client)
    {
        var inbox = client.Inbox;
        inbox.Open(MailKit.FolderAccess.ReadOnly);

        var uids = inbox.Search(SearchQuery.All).ToList();
        if (uids.Count > 0)
        {
            var firstMessage = inbox.GetMessage(uids[0]);
            return firstMessage;
        }
        return null;
        //var inbox = client.Inbox;
        //inbox.Open(MailKit.FolderAccess.ReadOnly);


        //var uids = inbox.Search(SearchQuery.All).ToList();
        //if (uids.Count > 0)
        //{
        //    var firstMessage = inbox.GetMessage(uids[0]);
        //    return firstMessage;
        //}
        //return null;
    }
    static void SendMessage(string smtpServer, int smtpPort, string user, string password, string recipient, string subject, string body, List<string> attachmentPaths)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Jack", user));
        message.To.Add(new MailboxAddress("Yes I", user));
        message.Subject = "Hello ?";
        message.Importance = MessageImportance.High;
        var bodyBuilder = new BodyBuilder
        {
            TextBody = body
        };

        AddAttachments(bodyBuilder, attachmentPaths);

        message.Body = bodyBuilder.ToMessageBody();
        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
            client.Authenticate(user, password);
            client.Send(message);
            client.Disconnect(true);
        }

    }
    static void AddAttachments(BodyBuilder bodyBuilder, List<string> attachmentPaths)
    {
        foreach (var path in attachmentPaths)
        {
            bodyBuilder.Attachments.Add(path);
        }
    }
    static void ReplyToMessage(string smtpServer, int smtpPort, string user, string password, MimeMessage originalMessage, string replyBody, List<string> attachmentPaths)
    {
        var replyMessage = new MimeMessage();
        replyMessage.From.Add(new MailboxAddress("Jack", user));
        replyMessage.To.AddRange(originalMessage.From);
        replyMessage.Subject = "Re: " + originalMessage.Subject;
        replyMessage.InReplyTo = originalMessage.MessageId;
        replyMessage.References.Add(originalMessage.MessageId);

        var bodyBuilder = new BodyBuilder
        {
            TextBody = replyBody
        };

        AddAttachments(bodyBuilder, attachmentPaths);

        replyMessage.Body = bodyBuilder.ToMessageBody();

        using (var client = new SmtpClient())
        {
            client.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
            client.Authenticate(user, password);
            client.Send(replyMessage);
            client.Disconnect(true);
        }
    }
    private static void Main(string[] args)
    {
        Console.WriteLine("1) gmail;\t 2) ukr.net;\t 3) iCloud;");
        int sw;
        string ip = "";
        try
        {
            sw = Int32.Parse(Console.ReadLine()!);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            sw = 1;
        }
        switch (sw)
        {
            case 1:
                sw = 993;
                ip = "imap.gmail.com";
                break;
            case 2:
                ip = "imap.ukr.net";
                sw = 993;
                break;
            case 3:
                sw = 993; ip = "imap.mail.me.com"; break;
            default:
                break;
        }

        // get
        using (var client_ = new ImapClient())
        {
            client_.Connect(ip, sw, MailKit.Security.SecureSocketOptions.SslOnConnect);
            client_.Authenticate(user, password);

            ShowFolders(client_);


            var folder = client_.GetFolder(MailKit.SpecialFolder.Sent);
            ShowMessages(folder);
            ShowMessagesFull(folder);

            client_.Disconnect(true);
        }


        // send

        List<string> attachmentPaths = new List<string>
            {
                @"C:\Users\Денис\Desktop\test_pic.jpg",
                @"C:\Users\Денис\Desktop\IMG_0702.MP4"
            };
        SendMessage(ip, sw, user, password, user, "Subject of the message", "Body of the message", attachmentPaths);


        // reply
        MimeMessage firstMessage = null;
        using (var client_ = new ImapClient())
        {
            client_.Connect(ip, sw, MailKit.Security.SecureSocketOptions.SslOnConnect);
            client_.Authenticate(user, password);
            firstMessage = GetFirstMessageToReply(client_);
        }
        ReplyToMessage(ip, sw, user, password, firstMessage, "This is a reply message body", attachmentPaths);



        //var message = new MimeMessage();
        //message.From.Add(new MailboxAddress("Jack", user));
        //message.To.Add(new MailboxAddress("Yes I", user));
        //message.Subject = "Hello ?";
        //message.Importance = MessageImportance.High;
        //message.Body = new TextPart()
        //{
        //    Text = @"Hello my dear
        //                friend
        //                :)",
        //};


        //// Send

        //using (var client = new SmtpClient())
        //{
        //    client.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
        //    client.Authenticate(user, password);
        //    client.Send(message);

        //}

        // get message

        ////        using (var client_ = new ImapClient())
        ////    {
        ////        client_.Connect("imap.gmail.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect);
        ////        client_.Authenticate(user, password);

        ////        var folders = client_.GetFolders(client_.PersonalNamespaces[0]);
        ////        foreach (var item in folders)
        ////        {
        ////            Console.WriteLine($"Folder : {item.Name}");
        ////        }

        ////        var folder_ = client_.GetFolder(MailKit.SpecialFolder.Sent);
        ////        //folder_.Open(MailKit.FolderAccess.ReadOnly);
        ////        folder_.Open(MailKit.FolderAccess.ReadWrite);

        ////        var id = folder_.Search(SearchQuery.All).LastOrDefault();

        ////        var mail = folder_.GetMessage(id);
        ////        Console.WriteLine(mail.Date + " " + mail.Subject + " " + mail.TextBody);

        ////        // delete

        ////        //folder_.MoveTo(id, client_.GetFolder(MailKit.SpecialFolder.Junk)); // trash
        ////        //folder_.AddFlags(id, MessageFlags.Deleted, true);
        ////        folder_.Expunge();
        ////    }
    }
}