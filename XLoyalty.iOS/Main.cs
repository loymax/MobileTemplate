namespace <%- namespaceContext %>.iOS
{
    using UIKit;

    public class Application
    {
#if DEBUG
        public static string StylePath;
#endif

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
#if DEBUG
            if (args.Length > 0)
            {
                StylePath = args[0];
            }
#endif

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}