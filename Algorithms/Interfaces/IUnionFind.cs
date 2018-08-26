namespace Algorithms
{
    public interface IUnionFind
    {
        bool Connected(int p, int q);
        int Count();
        int Find(int p);
        void Union(int p, int q);
    }
}