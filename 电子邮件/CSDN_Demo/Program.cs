using System.Net.Mail;

SendMailLocalhost();

void SendMailLocalhost()
{
    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
    // msg.To.Add("a@a.com");
    msg.To.Add("hol.won@qq.com");
    /* msg.To.Add("b@b.com");  
    * msg.To.Add("b@b.com");  
    * msg.To.Add("b@b.com");可以发送给多人  
    */
    // msg.CC.Add("c@c.com");
    /*  
    * msg.CC.Add("c@c.com");  
    * msg.CC.Add("c@c.com");可以抄送给多人  
    */
    msg.From = new MailAddress("hol.won@qq.com", "AlphaWu", System.Text.Encoding.UTF8);
    /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
    msg.Subject = "这是测试邮件";//邮件标题  
    msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码  
    msg.Body = "邮件内容";//邮件内容  
    msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码  
    msg.IsBodyHtml = false;//是否是HTML邮件  
    msg.Priority = MailPriority.High;//邮件优先级 

    SmtpClient client = new SmtpClient();
    client.Host = "localhost";
    object userState = msg;
    try
    {
        client.SendAsync(msg, userState);
        //简单一点儿可以client.Send(msg);  
        MessageBox.Show("发送成功");
    }
    catch (System.Net.Mail.SmtpException ex)
    {
        MessageBox.Show(ex.Message, "发送邮件出错");
    }
}


void SendMailLocalhost2()
{
    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
    msg.To.Add("a@a.com");
    msg.To.Add("b@b.com");
    /* msg.To.Add("b@b.com");  
    * msg.To.Add("b@b.com");  
    * msg.To.Add("b@b.com");可以发送给多人  
    */
    msg.CC.Add("c@c.com");
    /*  
    * msg.CC.Add("c@c.com");  
    * msg.CC.Add("c@c.com");可以抄送给多人  
    */
    msg.From = new MailAddress("master@boys90.com", "dulei", System.Text.Encoding.UTF8);
    /* 上面3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
    msg.Subject = "这是测试邮件";//邮件标题  
    msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码  
    msg.Body = "邮件内容";//邮件内容  
    msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码  
    msg.IsBodyHtml = false;//是否是HTML邮件  
    msg.Priority = MailPriority.High;//邮件优先级 
    SmtpClient client = new SmtpClient();
    client.Host = "localhost";
    object userState = msg;
    try
    {
        client.SendAsync(msg, userState);
        //简单一点儿可以client.Send(msg);  
        MessageBox.Show("发送成功");
    }
    catch (System.Net.Mail.SmtpException ex)
    {
        MessageBox.Show(ex.Message, "发送邮件出错");
    }
}
public static class MessageBox
{
    public static void Show(string message)
    {
        Console.WriteLine("Message: " + message);
    }
    public static void Show(string message, string userState)
    {
        Console.WriteLine($"UserState: {userState},Message: {message}");
    }
}