using WetProPointData;

namespace WetProPoint
{
    public class MainWindowViewModel : Notify
    {
        private Utilisateur utilisateur;
        public Utilisateur Utilisateur
        {
            get { return utilisateur; }
            set { utilisateur = value; }
        }

        public Database Database
        {
            get
            {
                return database;
            }

            set
            {
                database = value;
                OnPropertyChanged("Database");
            }
        }

        private Ingredient ingredient = new Ingredient();
        public WetProPointData.Ingredient Ingredient
        {
            get { return ingredient; }
            set { ingredient = value;
                OnPropertyChanged("Ingredient");
            }
        }

        private Database database = new Database();

    }
}
