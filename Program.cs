using System;
using System.Net.Mail;
using System.Net;

namespace Mail2
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.wp.pl")
            {
                Port = 587,
                Credentials = new NetworkCredential("nicek1988@wp.pl", "PiotrNicewicz1988"),
                EnableSsl = true,
            };
            
            //smtpClient.Send("nicek1988@wp.pl", "nicewicz.piotr@gmail.com", "subject", "body");

            var mailMessage = new MailMessage
            {
                From = new MailAddress("nicek1988@wp.pl", "Marek"),
                Subject = "Przykładowy email",
                Body = @"<p><b>Drogi Panie, </b></p>
                         <p>To jest krótka wiadomość email.</p>
                         <p>Z poważaniem,<br>- Marek</br></p>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add("nicewicz.piotr@gmail.com");

            Attachment attachment = new Attachment("20180821_210522.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            
            mailMessage.Attachments.Add(attachment);
            
            try
            {
                smtpClient.Send(mailMessage);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}", e.ToString());
            }   

            Console.WriteLine("Email wysłany");

        }
    }
}
