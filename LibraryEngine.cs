namespace Session_11
{
    // User-defined delegate, same signature as the methods in BookFunctions
    public delegate string BookDelegate(Book B);

    public class LibraryEngine
    {
        // Case 1: user-defined delegate
        public static void ProcessBooks(List<Book> bList, BookDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // Case 2: built-in delegate (Func<Book, string>)
        public static void ProcessBooksFunc(List<Book> bList, Func<Book, string> fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
