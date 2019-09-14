namespace MovieRental.Movies
{
    public class MovieFactory
    {
        public static IMovie CreateRegularMovie(string title) => new RegularMovie(title);
        public static IMovie CreateChildrensMovie(string title) => new ChildrenMovie(title);
        public static IMovie CreateNewReleaseMovie(string title) => new NewReleaseMovie(title);
    }
}