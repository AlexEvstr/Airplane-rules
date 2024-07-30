using UnityEngine;

public class PrivacyBtn : MonoBehaviour
{
    private string url = "https://www.freeprivacypolicy.com/live/a757309a-b486-4444-a49d-b7efdea6a12d";

    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}