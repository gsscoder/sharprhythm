namespace SharpRhythm.Tests
{
    static class Integers
    {
        public static int[] Unsorted = {
            15, 8, 5, 12, 10, 1, 16, 9, 11, 7, 20, 3, 2, 6, 17, 18, 4, 13, 14, 19 };
        
        public static int[] Sorted = {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        
        public static int[] NegativeUnsorted = {
            -1, 0, 5, -10, 20, 13, -7, 3, 2, -3 };

        public static int[] NegativeSorted = {
            -10, -7, -3, -1, 0, 2, 3, 5, 13, 20 };
    }

    static class Strings
    {
        public static string[] Unsorted = {
            "beta", "alpha", "theta", "delta", "omega", "chi" };
        
        public static string[] Sorted = {
            "alpha", "beta", "chi", "delta", "omega", "theta" };
    }
}