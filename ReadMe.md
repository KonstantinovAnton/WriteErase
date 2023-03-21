# Проект "TravelAgency" :airplane:

![image](https://f.partnerkin.com/uploads/storage/files/file_1622378162.gif)


Проект по предмету `Разработка программных модулей` - <b>Туристическое агенство</b>

## Как работать с проектом :wrench:

Откройте проект через Visual Studio. Для этого Вам необходимо <b>зайти в Visual Studio</b>, затем <b>подключиться к GitHub</b> и <b>вставить ссылку</b> этого проекта: https://github.com/KonstantinovAnton/KonstantinovAnton

[![video](https://github.githubassets.com/images/modules/logos_page/GitHub-Mark.png)](https://www.youtube.com/watch?v=SqarOBqIlpU)

Или скачайте <b>zip-архив</b>. Для этого:
1. Откройте проект на github: https://github.com/KonstantinovAnton/KonstantinovAnton
2. Нажмите на зеленую кнопку "<> Code" в правом верхнем углу
3. Выберите Download ZIP

После этого разархивируйте ZIP-архив и откройте файл с расширение <i>.sln</i>

## Основные моменты в приложении :eyes:

<b>Основные страницы приложения</b>
+ Страницы администратора
  + PageAdminTour
  + PageAdminAddTour
  + PageAdminMenu
  + PageAdminSale
  + PageAdminShowData
+ Страницы пользователя
  + PageUserMenu
+ Общие страницы
  + PageRegistration
  + PageAuthorization

<b>Для входа в приложение</b> воспользуйтесь акутальными логином и паролем, указанными на главной странице <i>MainWindow.xml</i>
```xml
<!--
    ЛОГИН АДМИНИСТРАТОРА: admin
    ПАРОЛЬ АДМИНИСТРАТОРА: 1234
 -->
    
    <Window x:Class="TravelAgency.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:TravelAgency"
        mc:Ignorable="d"
        Title="ТурАгенство" Height="530" Width="800"
        Background="#FF3F3F46"    
            >
    <Grid>
```

Подключение к БД
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

## Автор :man_with_turban:

 :neckbeard: **Константинов Антон** - *Travel Agency* - [Мой аккаунт на GitHub](https://github.com/KonstantinovAnton)

 :e-mail: Рабочая почта - akonstantinov.2003.sokol@gmail.com
