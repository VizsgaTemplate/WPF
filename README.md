# Hasznos tippek:

- Telepítsd BP Jedlik.EntityFramework.Helper nugetpackage-ét!!
- A console-ból lopd el a modeljeidet
- Csinálj egy egyszerű, JedlikDbContext-ből származtatott DataContextet pl:
```
using Jedlik.EntityFramework.Helper;

namespace WPF
{
    public class DataContext: JedlikDbContext
    {
        public DbSet<Ad> realestates { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Seller> sellers { get; set; }

        private readonly string connStr;

        public DataContext()
        {            
            connStr = "server=localhost;database=ingatlan;uid=root;pwd=;";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(connStr))
                optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        }
    }
}

```
amibe beleírod a modelljeidet így: 
``public DbSet<Category> categories { get; set; }``, vagy ha a modell neve és a táblázat neve eltérő, csak nevezd át a DbSet-et, pl: ``public DbSet<Ad> realestates { get; set; }``


Ha kellenek minta adatok, akkor:
```
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Osztály>().HasData
            (
                new () { id = 1, name = "Számítástechnikai"},
                new () { id = 2, name = "Építészi"},
                new () { id = 3, name = "Javítási"},
                new () { id = 4, name = "Dekorációs"},
                new () { id = 5, name = "Egyéb"}
            );
        }
```

Ezt csak így itt hagyom, hasznos lesz:
```
        private readonly DataContext _dataContext;
        ObservableCollection<Seller> sellers = new();
        public SellerRepository repository { get; set; }
        public MainWindow()
        {
            _dataContext = new();
            repository = new (_dataContext);
            sellers = new ObservableCollection<Seller>(repository.GetAll());
            InitializeComponent();
            lbSellers.ItemsSource = sellers;
        }
```


Ha bármi olyat kell lekérdezned, amiben szerepel egy kapcsolat, akkor használd az ``Include()`` metódust! Pl.:
```
           lblCount.Content = _dataContext
                .realestates //realestates táblázat
                .Include(a => a.seller) //seller kapcsolatot is lekérdezi
                .Where(a => a.seller == lbSellers.SelectedItem) //ahol a seller megegyezik a kijelölt sellerrel
                .Count() //megszámlálja
                .ToString(); //átalakítja stringgé
```



## Binding tippek
Először is, ha nem megy a binding, ne szórakozz vele, használd a jó öreg ``valami.Text = "blabla";``-t!

Ha ListBox.ItemTemplate-tel dolgozol, és a kijelölt modell adatait akarod valamibe bindingolni, akkor:
```
        <ListBox x:Name="listbox">
            <ListBox.ItemTemplate>
                <DataTemplate >
                    <StackPanel>
                        <TextBlock Text="{Binding Path=name}" />
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
        
        
        <Grid Grid.Column="1" DataContext="{Binding ElementName=listbox, Path=SelectedItem}">
          <Label Content="{Binding name}"/>
        </Grid>
```
