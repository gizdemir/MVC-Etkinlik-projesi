using System.Text;

namespace etkinlikk.Helpers
{
    public class EmailOperations
    {



        public static void SendActivationMail(string toEmail)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(toEmail);
            mail.From = new System.Net.Mail.MailAddress("turkiyedb@hotmail.com");
            mail.Subject = "turkiyedb.xyz Kullanıcı Aktivasyon";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            string linkk = "https://localhost:7117/Hesap/Aktivasyon?kkk=" + Criyptoo.Encrypted(toEmail);


            var HtmlBody = new StringBuilder();
            HtmlBody.AppendFormat("Hoşgeldiniz , {0}\n", "Sevgili Kullanıcımız");
            HtmlBody.AppendLine("Hesabınızı aktive etmek için aşağıdaki bağlantıya tıklayın.");
            HtmlBody.AppendLine("<a href=\"" + linkk + "\">AKTİVASYON</a>");
            mail.Body = HtmlBody.ToString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.Normal;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("turkiyedb@hotmail.com", "Sifre123!");
            client.EnableSsl = true;
            //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network; 
            
            try
            {
                client.Send(mail);

            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }

            }
        }


        //public static void SifremiYenileMailiGonder(string alici)
        //{

        //    string linkk = "https://www.alicidann.com/Hesap/SifremiSifirla?yyy=" + Sifreleme.Sifrele(alici);


        //    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //    mail.To.Add(alici);
        //    mail.From = new System.Net.Mail.MailAddress("info@alicidann.com");
        //    mail.Subject = "alıcıdan şifremi yenile bağlantısı";
        //    mail.SubjectEncoding = System.Text.Encoding.UTF8;
        //    var HtmlBody = new StringBuilder();
        //    HtmlBody.AppendFormat("Hoşgeldiniz , {0}\n", "Sevgili Kullanıcımız");
        //    HtmlBody.AppendLine(@"Şifrenizi yenilemek için ");
        //    HtmlBody.AppendLine("<a href=\"" + linkk + "\">BURAYA BASINIZ.</a>");
        //    mail.Body = HtmlBody.ToString();
        //    mail.BodyEncoding = System.Text.Encoding.UTF8;
        //    mail.IsBodyHtml = true;
        //    mail.Priority = System.Net.Mail.MailPriority.High;
        //    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();


        //    client.Credentials = new System.Net.NetworkCredential("info@zodyakcta.com", "Sifre1717!");
        //    client.Port = 3535;
        //    client.Host = "smtpout.secureserver.net";
        //    client.EnableSsl = true;
        //    try
        //    {
        //        client.Send(mail);

        //    }
        //    catch (Exception ex)
        //    {
        //        Exception ex2 = ex;
        //        string errorMessage = string.Empty;
        //        while (ex2 != null)
        //        {
        //            errorMessage += ex2.ToString();
        //            ex2 = ex2.InnerException;
        //        }

        //    }
        //}


    }
}
