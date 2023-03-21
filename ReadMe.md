# ������ "TravelAgency" :airplane:

![image](https://f.partnerkin.com/uploads/storage/files/file_1622378162.gif)


������ �� �������� `���������� ����������� �������` - <b>������������� ��������</b>

## ��� �������� � �������� :wrench:

�������� ������ ����� Visual Studio. ��� ����� ��� ���������� <b>����� � Visual Studio</b>, ����� <b>������������ � GitHub</b> � <b>�������� ������</b> ����� �������: https://github.com/KonstantinovAnton/KonstantinovAnton

[![video](https://github.githubassets.com/images/modules/logos_page/GitHub-Mark.png)](https://www.youtube.com/watch?v=SqarOBqIlpU)

��� �������� <b>zip-�����</b>. ��� �����:
1. �������� ������ �� github: https://github.com/KonstantinovAnton/KonstantinovAnton
2. ������� �� ������� ������ "<> Code" � ������ ������� ����
3. �������� Download ZIP

����� ����� �������������� ZIP-����� � �������� ���� � ���������� <i>.sln</i>

## �������� ������� � ���������� :eyes:

<b>�������� �������� ����������</b>
+ �������� ��������������
  + PageAdminTour
  + PageAdminAddTour
  + PageAdminMenu
  + PageAdminSale
  + PageAdminShowData
+ �������� ������������
  + PageUserMenu
+ ����� ��������
  + PageRegistration
  + PageAuthorization

<b>��� ����� � ����������</b> �������������� ����������� ������� � �������, ���������� �� ������� �������� <i>MainWindow.xml</i>
```xml
<!--
    ����� ��������������: admin
    ������ ��������������: 1234
 -->
    
    <Window x:Class="TravelAgency.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:TravelAgency"
        mc:Ignorable="d"
        Title="�����������" Height="530" Width="800"
        Background="#FF3F3F46"    
            >
    <Grid>
```

����������� � ��
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

## ����� :man_with_turban:

 :neckbeard: **������������ �����** - *Travel Agency* - [��� ������� �� GitHub](https://github.com/KonstantinovAnton)

 :e-mail: ������� ����� - akonstantinov.2003.sokol@gmail.com
