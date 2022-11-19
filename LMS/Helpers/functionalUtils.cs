namespace LMS.Helpers
{
    public class functionalUtils
    {
        public static string encodeString(string filename) {
            return System.Web.HttpUtility.UrlEncode(filename);
        }
    }
}
