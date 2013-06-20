using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using System;
public class Router
{
    public Encoding gb2312 = Encoding.GetEncoding(936);//路由器的web管理系统默认编码为gb2312
    /// <summary>
    /// 使用HttpWebRequest对象发送请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="encoding">编码</param>
    /// <param name="cache">凭证</param>
    /// <returns></returns>
    public static string SendRequest(string url, Encoding encoding, CredentialCache cache)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        if (cache != null)
        {
            request.PreAuthenticate = true;
            request.Credentials = cache;
        }
        string html = null;
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader srd = new StreamReader(response.GetResponseStream(), encoding);
            html = srd.ReadToEnd();
            srd.Close();
            response.Close();
        }
        catch (Exception ex) { html = "FALSE" + ex.Message; }
        return html;
    }
    /// <summary>
    /// 重启路由器
    /// </summary>
    /// <param name="RouterIP">路由IP地址，就是网关地址了，默认192.168.1.1</param>
    /// <param name="UserName">用户名</param>
    /// <param name="Passowrd">密码</param>
    /// <returns></returns>
    public static string RestartRouter(string RouterIP, string UserName, string Passowrd)
    {
        CredentialCache cache = new CredentialCache();
        string url = "http://" + RouterIP + "/userRpm/SysRebootRpm.htm?Reboot=%D6%D8%C6%F4%C2%B7%D3%C9%C6%F7";//
        cache.Add(new Uri(url), "Basic", new NetworkCredential(UserName, Passowrd));
        return SendRequest(url, Encoding.GetEncoding(936), cache);
    }
    public static string getProperties<T>(T t)
    {
        string tStr = string.Empty;
        if (t == null)
        {
            return tStr;
        }
        System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

        if (properties.Length <= 0)
        {
            return tStr;
        }
        foreach (System.Reflection.PropertyInfo item in properties)
        {
            string name = item.Name;
            object value = item.GetValue(t, null);
            if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
            {
                tStr += string.Format("{0}:{1},", name, value);
            }
            else
            {
                getProperties(value);
            }
        }
        return tStr;
    }
}