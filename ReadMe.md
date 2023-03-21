# Project "WriteErase" :airplane:

Проект по учебной практике - <b>WriteErase</b>


Ссылка на git: https://github.com/KonstantinovAnton/KonstantinovAnton

[![video](https://github.githubassets.com/images/modules/logos_page/GitHub-Mark.png)](https://www.youtube.com/watch?v=SqarOBqIlpU)

Èëè ñêà÷àéòå <b>zip-àðõèâ</b>. Äëÿ ýòîãî:
1. Îòêðîéòå ïðîåêò íà github: https://github.com/KonstantinovAnton/WriteErase
2. Íàæìèòå íà çåëåíóþ êíîïêó "<> Code" â ïðàâîì âåðõíåì óãëó
3. Âûáåðèòå Download ZIP

Ïîñëå ýòîãî ðàçàðõèâèðóéòå ZIP-àðõèâ è îòêðîéòå ôàéë ñ ðàñøèðåíèå <i>.sln</i>

## Îñíîâíûå ìîìåíòû â ïðèëîæåíèè :eyes:

<b>Îñíîâíûå ñòðàíèöû ïðèëîæåíèÿ</b>
+ Ñòðàíèöû àäìèíèñòðàòîðà
  + PageAdminTour
  + PageAdminAddTour
  + PageAdminMenu
  + PageAdminSale
  + PageAdminShowData
+ Ñòðàíèöû ïîëüçîâàòåëÿ
  + PageUserMenu
+ Îáùèå ñòðàíèöû
  + PageRegistration
  + PageAuthorization

<b>Äëÿ âõîäà â ïðèëîæåíèå</b> âîñïîëüçóéòåñü àêóòàëüíûìè ëîãèíîì è ïàðîëåì, óêàçàííûìè íà ãëàâíîé ñòðàíèöå <i>MainWindow.xml</i>
```xml
<!--
    ËÎÃÈÍ ÀÄÌÈÍÈÑÒÐÀÒÎÐÀ: admin
    ÏÀÐÎËÜ ÀÄÌÈÍÈÑÒÐÀÒÎÐÀ: 1234
 -->
    
    <Window x:Class="TravelAgency.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:TravelAgency"
        mc:Ignorable="d"
        Title="ÒóðÀãåíñòâî" Height="530" Width="800"
        Background="#FF3F3F46"    
            >
    <Grid>
```

Ïîäêëþ÷åíèå ê ÁÄ
```C#
namespace TravelAgency
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities1 : DbContext
    {
        public Entities1()
            : base("name=Entities1"){
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Nutrition> Nutrition { get; set; }
        public virtual DbSet<Payment_Type> Payment_Type { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<Tour_Type> Tour_Type { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
```

## Àâòîð :man_with_turban:

 :neckbeard: **Êîíñòàíòèíîâ Àíòîí** - *Travel Agency* - [Ìîé àêêàóíò íà GitHub](https://github.com/KonstantinovAnton)

 :e-mail: Ðàáî÷àÿ ïî÷òà - akonstantinov.2003.sokol@gmail.com
