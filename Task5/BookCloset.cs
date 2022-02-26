namespace Task5
{
    public class BookCloset : Closet
    {
        private const int HeightForShelf = 150;
        private const int BooksForShelf = 10;

        protected int ShelvesCount { get; set; }
        protected int BooksCount { get; set; }

        public BookCloset(Material material, int width, int height, int shelvesCount) : base(material, width, height)
        {
            if (shelvesCount < 0 || shelvesCount > Height / HeightForShelf)
            {
                ShelvesCount = 0;
            }
            else
            {
                ShelvesCount = shelvesCount;
            }
        }

        public int AddShelf()
        {
            if (ShelvesCount + 1 <= Height / HeightForShelf)
            {
                ShelvesCount++;
            }

            return ShelvesCount;
        }

        public int RemoveShelf()
        {
            if (ShelvesCount > 0)
            {
                ShelvesCount--;
            }

            return ShelvesCount;
        }

        public int GetShelvesCount()
        {
            return ShelvesCount;
        }

        public int AddBook()
        {
            if (BooksCount + 1 <= ShelvesCount * BooksForShelf)
            {
                BooksCount++;
            }

            return BooksCount;
        }

        public int RemoveBook()
        {
            if (BooksCount > 0)
            {
                BooksCount--;
            }

            return BooksCount;
        }

        public int GetBooksCount()
        {
            return BooksCount;
        }

        public override int CompareTo(IFurniture other)
        {
            if (Material.CompareTo(other.Material) == 0)
            {
                Closet c = (Closet) other;

                if (Width.CompareTo(c.GetWidth()) == 0)
                {
                    if (Height.CompareTo(c.GetHeight()) == 0)
                    {
                        BookCloset bc = (BookCloset) other;
                        if (ShelvesCount.CompareTo(bc.ShelvesCount) == 0)
                        {
                            return BooksCount.CompareTo(bc.BooksCount);
                        }

                        return ShelvesCount.CompareTo(bc.ShelvesCount);
                    }

                    return Height.CompareTo(c.GetHeight());
                }

                return Width.CompareTo(c.GetWidth());
            }

            return Material.CompareTo(other.Material);
        }
    }
}