namespace Session_11
{
    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }

        public static string GetAuthors(Book B)
        {
            return string.Join(", ", B.Authors);
        }

        public static string GetPrice(Book B)
        {
            return B.Price.ToString();
        }

        // GetISBN and GetPublicationDate are written inside Section01 (anonymous method and lambda)
    }
}
