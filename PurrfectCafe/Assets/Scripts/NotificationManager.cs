using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;


public class NotificationManager : MonoBehaviour
{
    static string ChanelID = "channel_id";
    // Start is called before the first frame update
    private void Awake()
    {
#if UNITY_ANDROID

        var channel = new AndroidNotificationChannel()
        {
            Id = ChanelID,
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
#endif
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void CreateNotification(string title,string text, double minutes)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;

        notification.FireTime = System.DateTime.Now.AddMinutes(minutes);

        AndroidNotificationCenter.SendNotification(notification, ChanelID);
    }
}
