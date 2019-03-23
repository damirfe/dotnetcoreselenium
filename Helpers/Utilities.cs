using System;
using System.Net;
using System.Net.Mail;

public class Utilities
{
    private static readonly Random RandomName = new Random();
    public string GenerateRandomEmail()
    {
        return string.Format("email{0}@mailinator.com", RandomName.Next(100000, 10000000));
    }

    public static void SendScreenshotEmail(string screenshotPath)
    {
        MailMessage mail = new MailMessage
        {
            From = new MailAddress("milosevic.edu@gmail.com"),
            Subject = "Test Mail - 1",
            Body = "mail with attachment"
        };
        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("milosevic.edu@gmail.com", "********")
        };
        Attachment attachment = new Attachment(screenshotPath);
        mail.To.Add("symphony@mailinator.com");
        mail.Attachments.Add(attachment);

        //smtp.Send(mail);
    }
}

