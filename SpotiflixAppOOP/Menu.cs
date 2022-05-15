namespace SpotiflixAppOOP
{

    internal class Menu : Content
    {
        Data? data = new Data();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/SpotiflixContent.json";

        //Constructor - Checks if file "SpotiflixContent.json" already exists. If not, a new one is created.
        //If it already exists, the data from the file is loaded.
        public Menu()
        {

            if (File.Exists(path))
            {
                data = new FileHandler().LoadData<Data>(path);
            }

            //Makes new lists if files doesnt exist, and saves the to .json file
            else
            {
                data.MusicList = new List<Music>();
                data.SeriesList = new List<Series>();
                data.MoviesList = new List<Movies>();
                new FileHandler().SaveData(path, data);
            }
        }

        // Enters the menu to start using application
        public void Start()
        {
            data.MoviesList = new List<Movies>();
            data.SeriesList = new List<Series>();
            data.MusicList = new List<Music>();

            Console.WriteLine("Welcome to Spotiflix. Here you can add your favourite movies, series and music!");
            while (true)
            {
                Console.WriteLine("\nChoose an action:\n--- Press 1 To Add content to your Spotiflix List ---\n" +
                    "--- Press 2 to View your List of content ---\n" +
                    "--- Press 3 to Search in your colletction of awesome stuff! ---");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        AddNewContent();
                        break;
                    case ConsoleKey.D2:
                        ViewAllContent();
                        break;
                    case ConsoleKey.D3:
                        ShowSearchResults();
                        break;
                    default:
                        break;
                }

            }

        }

        // Method to add new content to either movies, series or music.
        public void AddNewContent()
        {
            Console.Clear();
            Console.WriteLine("Press the corresponding key to choose the type of content you're adding:\n\n" +
                "--- 1: Movie ---\n" +
                "--- 2: Series ---\n" +
                "--- 3: Music ---\n\n" +
                "--- 0: Exit to main menu ---");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    AddMovieToList();
                    break;
                case ConsoleKey.D2:
                    AddSeriesToList();
                    break;
                case ConsoleKey.D3:
                    AddMusicToList();
                    break;
                case ConsoleKey.D0:
                    Console.Clear();
                    return;
                default:
                    break;
            }

        }

        // Adds Movies to List
        public void AddMovieToList()
        {
            Console.Clear();
            Console.Write("Enter Movie Title:  ");
            string movieTitle = Console.ReadLine();

            Console.WriteLine("\nSelect Movie Genre:");
            foreach (var item in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine((int)item + " " + item.ToString());
            }
            int movieGenre = (int)Console.ReadKey(true).Key - 48;


            Console.Write("Movie length (hh:mm):  ");
            string[]? input = Console.ReadLine().Split(":");
            int playTime = HoursAndMinutesToSeconds(int.Parse(input[0]), int.Parse(input[1]));

            Console.Write("Release date (yyyy-mm-dd):  ");
            DateTime release = DateTime.Parse(Console.ReadLine());

            Console.Write("Streaming service:  ");
            string? streamingService = Console.ReadLine();


            Movies movie = new Movies()
            {
                Title = movieTitle,
                Genre = (Genre)movieGenre,
                PlayTime = playTime,
                StreamingService = streamingService,
                ReleaseDate = release
            };

            data.MoviesList.Add(movie);
            new FileHandler().SaveData(path, data);

            Console.WriteLine($"{movieTitle} was Added to your list!\n-----------------------------------------");



        }


        // Adds Series to List
        public void AddSeriesToList()
        {
            Console.Clear();
            Console.Write("Enter Series Title: ");
            string? seriesTitle = Console.ReadLine();

            Console.WriteLine("Choose Series Genre:");
            foreach (var item in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine((int)item + " " + item.ToString());
            }
            int seriesGenre = (int)Console.ReadKey(true).Key - 48;

            Console.Write("Number of Episodes:  ");
            int numberOfEpisodes = int.Parse(Console.ReadLine());

            Console.Write("Number of Seasons:  ");
            int numberOfSeasons = int.Parse(Console.ReadLine());

            Console.Write("Average Episode Length (hh:mm):  ");
            string[]? input = Console.ReadLine().Split(":");
            int playTime = HoursAndMinutesToSeconds(int.Parse(input[0]), int.Parse(input[1]));

            Console.Write("Release Date (yyyy-mm-dd):  ");
            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Streaming Service:  ");
            string? streamingService = Console.ReadLine();
            Console.WriteLine($"{seriesTitle} was Added to your list!\n-----------------------------------------");


            Series series = new Series()
            {
                Title = seriesTitle,
                Genre = (Genre)seriesGenre,
                NumberOfEpisodes = numberOfEpisodes,
                SeasonNumber = numberOfSeasons,
                PlayTime = playTime,
                ReleaseDate = releaseDate,
                StreamingService = streamingService
            };
            data.SeriesList.Add(series);
            new FileHandler().SaveData(path, data);
        }

        // Adds songs to List
        public void AddMusicToList()
        {
            Console.Clear();
            Console.Write("Song Title:  ");
            string? songTitle = Console.ReadLine();
            Console.Write("Artist:  ");
            string? artistName = Console.ReadLine();

            Console.WriteLine("Choose Series Genre:");
            foreach (var item in Enum.GetValues(typeof(MusicGenre)))
            {
                Console.WriteLine((int)item + " " + item.ToString());
            }
            int musicGenre = (int)Console.ReadKey(true).Key - 48;

            Console.Write("Album Title:  ");
            string? albumTitle = Console.ReadLine();

            Console.WriteLine("Song Length (mm:ss)");
            string[]? input = Console.ReadLine().Split(":");
            int playTime = MinutesAndSecondsToSeconds(int.Parse(input[0]), int.Parse(input[1]));

            Console.Write("Release Date (yyyy-mm-dd):  ");
            DateTime release = DateTime.Parse(Console.ReadLine());

            Console.Write("Streaming Service:  ");
            string? streamingService = Console.ReadLine();
            Console.WriteLine($"{songTitle} was Added to your list!\n-----------------------------------------");


            Music music = new Music()
            {
                Title = songTitle,
                Artist = artistName,
                MusicGenre = (MusicGenre)musicGenre,
                Album = albumTitle,
                PlayTime = playTime,
                ReleaseDate = release,
                StreamingService = streamingService
            };

            data.MusicList.Add(music);
            new FileHandler().SaveData(path, data);
        }



        // Shows the data saved in Lists
        public void ViewAllContent()
        {
            Console.Clear();
            Console.WriteLine("************ Movies ************");

            foreach (Movies movie in data.MoviesList)
            {
                Console.WriteLine(
                    $"------------------------------------\n" +
                    $"Title: {movie.Title}\n" +
                    $"Genre: {movie.Genre}\n" +
                    $"Total lenghts: {movie.PlayTime.ToString(@"hh:\mm:\ss")}\n" +
                    $"Released: {movie.ReleaseDate}\n" +
                    $"Available at: {movie.StreamingService}\n");

            }

            Console.WriteLine("************ Series ************");
            foreach (Series series in data.SeriesList)
            {
                Console.WriteLine(
                    $"------------------------------------\n" +
                    $"Title: {series.Title}\n" +
                    $"Number of Episodes: {series.NumberOfEpisodes}\n" +
                    $"Number of Seasons: {series.SeasonNumber}\n" +
                    $"Genre: {series.Genre}\n" +
                    $"Total length in seconds: {series.PlayTime}\n" +
                    $"Released: {series.ReleaseDate}\n" +
                    $"Available at: {series.StreamingService}");
            }

            Console.WriteLine("************ Songs ************");
            foreach (Music music in data.MusicList)
            {
                Console.WriteLine(
                    $"------------------------------------\n" +
                    $"Title: {music.Title}\n" +
                    $"Artist: {music.Artist}\n" +
                    $"Genre:{music.MusicGenre}\n" +
                    $"Album: {music.Album}\n" +
                    $"Song Lenght in seconds: {music.PlayTime}\n" +
                    $"Released: {music.ReleaseDate}");
            }

        }

        // Converts the input to seconds
        public int HoursAndMinutesToSeconds(int hours, int mins)
        {
            return hours * 3600 + mins * 60;
        }
        // Same
        public int MinutesAndSecondsToSeconds(int mins, int secs)
        {
            return secs + mins * 60;
        }


        public void ShowSearchResults()
        {
            Console.WriteLine("search for title:");
            string? input = Console.ReadLine();
            SearchEngine(input);
        }


        // Very simple search method where you can only serach the titles, and get the titles that match. 
        // TODO Improve search engine.
        public void SearchEngine(string query)
        {
            Console.WriteLine(" >>>> Movies results <<<<");
            foreach (var movie in data.MoviesList)
            {
                bool containsResult = movie.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase);
                if (containsResult)
                    Console.WriteLine($"Title: {movie.Title}");
            }
            Console.WriteLine(" >>>> Series results <<<<");
            foreach (var series in data.SeriesList)
            {
                bool containsResult = series.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase);
                if (containsResult)
                    Console.WriteLine($"Title: {series.Title}");

            }
            Console.WriteLine(" >>>> Music results <<<<");
            foreach (var song in data.MusicList)
            {
                bool containsResult = song.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase);
                if (containsResult)
                    Console.WriteLine($"Title: {song.Title}");
            }


        }


    }
}

