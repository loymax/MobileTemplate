namespace <%- namespaceContext %>.iOS.NotificationServiceExtension
{
    using System;
    using Foundation;
    using PushNotification.Service.iOS;

    [Register("NotificationService")]
    public class NotificationService : BaseNotificationService
    {
        protected NotificationService(IntPtr handle) 
            : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
