namespace Session_11
{
    internal class Section01
    {
        public static void Run()
        {
            List<Book> books = new List<Book>()
            {
                new Book("111", "C# Basics", new string[] { "Ahmed", "Ali" }, new DateTime(2020, 5, 10), 150),
                new Book("222", "Data Structures", new string[] { "Omar" }, new DateTime(2018, 1, 20), 200),
                new Book("333", "SQL Server", new string[] { "Mona", "Sara", "Hany" }, new DateTime(2022, 9, 3), 175)
            };

            #region User-defined delegate
            BookDelegate bookDelegate = new BookDelegate(BookFunctions.GetTitle);
            LibraryEngine.ProcessBooks(books, bookDelegate);
            LibraryEngine.ProcessBooks(books, BookFunctions.GetAuthors);
            LibraryEngine.ProcessBooks(books, BookFunctions.GetPrice);
            #endregion

            #region Built-in delegate
            Func<Book, string> func = BookFunctions.GetTitle;
            LibraryEngine.ProcessBooksFunc(books, func);
            LibraryEngine.ProcessBooksFunc(books, BookFunctions.GetPrice);
            #endregion

            #region Anonymous Method (GetISBN)
            LibraryEngine.ProcessBooks(books, delegate (Book B)
            {
                return B.ISBN;
            });
            #endregion

            #region Lambda Expression (GetPublicationDate)
            LibraryEngine.ProcessBooksFunc(books, B => B.PublicationDate.ToShortDateString());
            #endregion
        }
    }
}
