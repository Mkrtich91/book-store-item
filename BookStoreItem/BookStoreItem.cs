using System.Diagnostics.CodeAnalysis;
using System.Globalization;

[assembly: CLSCompliant(true)]

namespace BookStoreItem
{
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1117:ParametersMustBeOnSameLineOrSeparateLines", Justification = "Reviewed.")]
    public class BookStoreItem
    {
        private readonly string authorName;
        private readonly string? isni;
        private readonly bool hasIsni;
        private decimal price;
        private string currency;
        private int amount;

        private static bool ValidateIsni(string? isni)
        {
            if (isni == null)
            {
                return false;
            }

            if (isni.Length != 16)
            {
                return false;
            }

            foreach (char c in isni)
            {
                if (!char.IsDigit(c) && c != 'X')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateIsbnFormat(string? isbn)
        {
            if (isbn == null)
            {
                return false;
            }

            if (isbn.Length != 10)
            {
                return false;
            }

            foreach (char c in isbn)
            {
                if (!char.IsDigit(c) && c != 'X')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateIsbnChecksum(string isbn)
        {
            if (!ValidateIsbnFormat(isbn))
            {
                return false;
            }

            int checksum = 0;
            for (int i = 0; i < isbn.Length; i++)
            {
#pragma warning disable CA1305
                int value = isbn[i] == 'X' ? 10 : int.Parse(isbn[i].ToString(CultureInfo.InvariantCulture));
#pragma warning restore CA1305
                checksum += (10 - i) * value;
            }

            return checksum % 11 == 0;
        }

        private static void ThrowExceptionIfCurrencyIsNotValid(string currency)
        {
            if (currency.Length != 3)
            {
                throw new ArgumentException("Invalid currency code.", nameof(currency));
            }

            foreach (char c in currency)
            {
                if (!char.IsLetter(c))
                {
                    throw new ArgumentException("Invalid currency code.", nameof(currency));
                }
            }
        }

        public string AuthorName => this.authorName;

        public string? Isni => this.isni;

        public bool HasIsni => this.hasIsni;

        public string Title { get; private set; }

        public string Publisher { get; private set; }

        public string Isbn { get; private set; }

        public DateTime? Published { get; set; }

        public string BookBinding { get; set; }

        public decimal Price
        {
            get => this.price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Price must be a non-negative value.");
                }

                this.price = value;
            }
        }

        public string Currency
        {
            get => this.currency;
            set
            {
                ThrowExceptionIfCurrencyIsNotValid(value);
                this.currency = value;
            }
        }

        public int Amount
        {
            get => this.amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Amount must be a non-negative value.");
                }

                this.amount = value;
            }
        }

        public BookStoreItem(string authorName, string title, string publisher, string isbn)
            : this(authorName, null, title, publisher, isbn, null, string.Empty, 0m, "USD", 0)
        {
        }

        public BookStoreItem(string authorName, string? isni, string title, string publisher, string isbn)
            : this(authorName, isni, title, publisher, isbn, null, string.Empty, 0m, "USD", 0)
        {
        }

        public BookStoreItem(string authorName, string title, string publisher, string isbn, DateTime? published,
            string bookBinding, decimal price, string currency, int amount)
            : this(authorName, null, title, publisher, isbn, published, bookBinding, price, currency, amount)
        {
        }

#pragma warning disable CS8618
        public BookStoreItem(string authorName, string? isni, string title, string publisher, string isbn,
#pragma warning restore CS8618
            DateTime? published, string bookBinding, decimal price, string currency, int amount)
        {
            if (string.IsNullOrWhiteSpace(authorName))
            {
                throw new ArgumentException("Author name must not be empty or whitespace.", nameof(authorName));
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title must not be empty or whitespace.", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(publisher))
            {
                throw new ArgumentException("Publisher must not be empty or whitespace.", nameof(publisher));
            }

            if (!ValidateIsbnFormat(isbn))
            {
                throw new ArgumentException("Invalid ISBN format.", nameof(isbn));
            }

            if (!ValidateIsbnChecksum(isbn))
            {
                throw new ArgumentException("Invalid ISBN checksum.", nameof(isbn));
            }

            if (isni != null && !ValidateIsni(isni))
            {
                throw new ArgumentException("Invalid ISNI format.", nameof(isni));
            }

            this.authorName = authorName;
            this.isni = isni;
            this.hasIsni = ValidateIsni(isni);
            this.Title = title;
            this.Publisher = publisher;
            this.Isbn = isbn;
            this.Published = published;
            this.BookBinding = bookBinding;
            this.Price = price;
            this.Currency = currency;
            this.Amount = amount;
        }

        public Uri GetIsniUri()
        {
            if (this.isni == null)
            {
                throw new InvalidOperationException("ISNI is not set.");
            }

            return new Uri($"https://isni.org/isni/{this.isni}");
        }

        public Uri GetIsbnSearchUri()
        {
            return new Uri($"https://isbnsearch.org/isbn/{this.Isbn}");
        }

        public override string ToString()
        {
            string formattedPrice = this.price.ToString("N2", CultureInfo.InvariantCulture);
#pragma warning disable CS8600
            string isniValue = this.hasIsni ? this.isni : "ISNI IS NOT SET";
#pragma warning restore CS8600
            if (this.currency == "EUR")
            {
                return $"{this.Title}, {this.AuthorName}, {isniValue}, \"{formattedPrice} {this.Currency}\", {this.Amount}";
            }
            else
            {
                return $"{this.Title}, {this.AuthorName}, {isniValue}, {formattedPrice} {this.Currency}, {this.Amount}";
            }
        }
    }
}
