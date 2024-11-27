namespace FilmsPerActor
{
    internal class ActorFilmsApp
    {
        public UserInterface Ui { get; set; }
        public FilmDBService FilmDBService { get; set; }
        public ActorFilmsApp(string connectionString)
        {
            FilmDBService = new FilmDBService(connectionString);
            Ui = new UserInterface(FilmDBService);
        }

        public void run()
        {
            Ui.StartDialog();
        }

    }
}
