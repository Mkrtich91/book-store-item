using System.Globalization;
using System.Text.RegularExpressions;

[assembly: CLSCompliant(true)]

namespace BookStoreItem
{
    /// <summary>
    /// Represents an item in a book store.
    /// </summary>
    // TODO Declare a class.
    public class BookStoreItem
    {
        // TODO Add fields.
        private readonly string authorName;
        private readonly string? isni;
        private readonly bool hasIsni;
        private decimal price;
        private string currency;
        private int amount;
        // private string title;
        // public string AuthorName { get; }
        // public string? Isni { get; }
        //  public bool HasIsni { get; }
        // public string Title { get; private set; }
        // public string Publisher { get; private set; }
        // public string Isbn { get; private set; }
        // public DateTime? Published { get; set; }
        // public string BookBinding { get; private set; }
        //  public decimal Price { get; set; }
        // public string Currency { get; set; }
        // public int Amount { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        // TODO Add a constructor.
        public BookStoreItem(string authorName, string title, string publisher, string? isbn)
        {
            AuthorName = authorName;
            Title = title;
            Publisher = publisher;
            Isbn = isbn;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        // TODO Add a constructor.
        public BookStoreItem(string authorName, string isni, string title, string publisher, string? isbn)
        {
            this.authorName = authorName;
            Isni = isni;
            Title = title;
            Publisher = publisher;
            Isbn = isbn;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        // TODO Add a constructor.
        public BookStoreItem(string authorName, string title, string publisher, string isbi, DateTime? published, string bookBinding, decimal price, string currency, int amount)
        {
            AuthorName = authorName;
            Title = title;
            Publisher = publisher;
            Isbn = isbi;
            Published = published;
            BookBinding = bookBinding;
            Price = price;
            Currency = currency;
            Amount = amount;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isni"/>, <paramref name="title"/>, <paramref name="publisher"/> and <paramref name="isbn"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="price"/>, <paramref name="currency"/> and <paramref name="amount"/>.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="isni">A book author's ISNI.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="isbn">A book ISBN.</param>
        /// <param name="published">A book publishing date.</param>
        /// <param name="bookBinding">A book binding type.</param>
        /// <param name="price">An amount of money that a book costs.</param>
        /// <param name="currency">A price currency.</param>
        /// <param name="amount">An amount of books in the store's stock.</param>
        // TODO Add a constructor.
        public BookStoreItem(string authorName, string isbi, string title, string publisher, string isbn, DateTime? published, string bookBinding, decimal price, string currency, int amount)
        {
            AuthorName = authorName;
            Isbn = isbi;
            Title = title;
            Publisher = publisher;
            Isbn = isbn;
            Published = published;
            BookBinding = bookBinding;
            Price = price;
            Currency = currency;
            Amount = amount;
        }
        /// <summary>
        /// Gets a book author's name.
        /// </summary>
        // TODO Add a property.
        public string AuthorName { get; }
        /// <summary>
        /// Gets an International Standard Name Identifier (ISNI) that uniquely identifies a book author.
        /// </summary>
        // TODO Add a property.
        public string? Isni { get; }
        /// <summary>
        /// Gets a value indicating whether an author has an International Standard Name Identifier (ISNI).
        /// </summary>
        // TODO Add a property.
        public string Title { get; private set; }
        /// <summary>
        /// Gets a book title.
        /// </summary>
        // TODO Add a property.
        public string Publisher { get; private set; }
        /// <summary>public string Publisher { get; set; }
        /// Gets a book publisher.
        /// </summary>
        // TODO Add a property.
        public string Isbn { get; private set; }
        /// <summary>
        /// Gets a book International Standard Book Number (ISBN).
        /// </summary>
        // TODO Add a property.
        public DateTime? Published { get; set; }
        /// <summary>
        /// Gets or sets a book publishing date.
        /// </summary>
        // TODO Add a property.
        public string BookBinding { get; private set; }
        /// <summary>
        /// Gets or sets a book binding type.
        /// </summary>
        // TODO Add a property.
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets an amount of money that a book costs.
        /// </summary>
        // TODO Add a property.
        public bool HasIsni { get; }
        /// <summary>
        /// Gets or sets a price currency.
        /// </summary>
        // TODO Add a property.
        public string Currency { get; set; }
        /// <summary>
        /// Gets or sets an amount of books in the store's stock.
        /// </summary>
        // TODO Add a property.
        public int Amount { get; set; }
        /// <summary>
        /// Gets a <see cref="Uri"/> to the contributor's page at the isni.org website.
        /// </summary>
        /// <returns>A <see cref="Uri"/> to the contributor's page at the isni.org website.</returns>
        // TODO Add an instance method.
        public Uri GetIsniUri()
        {
            if (string.IsNullOrEmpty(Isni))
            {
                throw new InvalidOperationException("ISNI is not set.");
            }

            return new Uri($"https://isni.org/isni/{Isni}");
        }
        /// <summary>
        /// Gets an <see cref="Uri"/> to the publication page on the isbnsearch.org website.
        /// </summary>
        /// <returns>an <see cref="Uri"/> to the publication page on the isbnsearch.org website.</returns>
        // TODO Add an instance method.
        public Uri GetIsbnSearchUri()
        {
            return new Uri("https://www.isbnsearch.org/search?s=" + Title);
        }
        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        // TODO Add an instance method.
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Isni))
            {
                return $"{Title}, {AuthorName}, ISNI IS NOT SET, {Price:F2} {Currency}, {Amount}";
            }
            else
            {
                return $"{Title}, {AuthorName}, {Isni}, {Price:F2} {Currency}, {Amount}";
            }
        }
        // TODO Add a static method.
        private static bool ValidateIsni(string isni)
        {
            throw new NotImplementedException();
        }
        // TODO Add a static method.
        private static bool ValidateIsbnFormat(string isbn)
        {
            throw new NotImplementedException();
        }
        // TODO Add a static method.
        private static bool ValidateIsbnChecksum(string isbn)
        {
            throw new NotImplementedException();
        }
        // TODO Add a static method.
        private static void ThrowExceptionIfCurrencyIsNotValid(string currency)
        {
            if (currency != "USD" && currency != "EUR" && currency != "GBP")
            {
                throw new ArgumentException("Invalid currency");
            }
        }
    }
}
