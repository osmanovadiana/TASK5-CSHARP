namespace Task5
{
    public class Closet : IFurniture
    {
        public Material Material { get; set; }
        protected int Width { get; set; }
        protected int Height { get; set; }


        public Closet(Material material, int width, int height)
        {
            Material = material;
            Width = width;
            Height = height;
        }

        public int GetPriceCoefficient()
        {
            return (int) Material * Width * Height / 1000;
        }

        public virtual int CompareTo(IFurniture other)
        {
            if (Material.CompareTo(other.Material) == 0)
            {
                Closet c = (Closet) other;

                if (Width.CompareTo(c.GetWidth()) == 0)
                {
                    return Height.CompareTo(c.GetHeight());
                }

                return Width.CompareTo(c.GetWidth());
            }

            return Material.CompareTo(other.Material);
        }

        public int GetWidth()
        {
            return Width;
        }

        public int GetHeight()
        {
            return Height;
        }
    }
}