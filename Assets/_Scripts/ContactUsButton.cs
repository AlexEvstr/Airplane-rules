using UnityEngine;
using UnityEngine.Networking;

public class ContactUsButton : MonoBehaviour
{
    private string email = "esmaacar258@gmail.com";
    private string subject = "Support Request";
    private string body = "Please describe your issue here...";

    public void ContactUs()
    {
        string mailto = string.Format("mailto:{0}?subject={1}&body={2}",
            email,
            EscapeURL(subject),
            EscapeURL(body));

        Application.OpenURL(mailto);
    }

    string EscapeURL(string url)
    {
        return UnityWebRequest.EscapeURL(url).Replace("+", "%20");
    }
}