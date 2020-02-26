# How to bind command from ViewModel to external ItemTemplate of Xamarin.Forms ListView ?

You can bind the ViewModel command to external ItemTemplate of Xamarin.Forms SfListView by using RelativeBinding in command binding.

**XAML: ListView definition**
``` XML
<syncfusion:SfListView x:Name="listView"
                       ItemSpacing="1"
                       ItemsSource="{Binding contactsinfo}">
    <syncfusion:SfListView.ItemTemplate >
        <DataTemplate>
            <local:TemplateViewCell/>
        </DataTemplate>
    </syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```
**XAML: ViewCell definition**

Binding the ViewModel command for button in ViewCell using AncestorType in RelativeBinding.

``` C#
<ViewCell xmlns="http://xamarin.com/schemas/2014/forms" 
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="ListViewXamarin.TemplateViewCell">
    <ViewCell.View>
        <Grid x:Name="grid" RowSpacing="0">
            <Grid.RowDefinitions>
                <RowDefinition Height="*" />
                <RowDefinition Height="1" />
            </Grid.RowDefinitions>
            <Grid RowSpacing="0">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="70" />
                    <ColumnDefinition Width="*" />
                    <ColumnDefinition Width="Auto" />
                </Grid.ColumnDefinitions>

                <Image Source="{Binding ContactImage}"
                           VerticalOptions="Center"
                           HorizontalOptions="Center"
                           HeightRequest="50" WidthRequest="50"/>

                <Grid Grid.Column="1"
                          RowSpacing="1"
                          Padding="10,0,0,0"
                          VerticalOptions="Center">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="100" />
                    </Grid.ColumnDefinitions>

                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>

                        <Label LineBreakMode="NoWrap"
                             TextColor="#474747"
                             Text="{Binding ContactName}">

                        </Label>
                        <Label LineBreakMode="NoWrap"
                           TextColor="#474747"
                           Grid.Row="1"
                           Text="{Binding ContactNumber}">

                        </Label>
                    </Grid>

                   <Button Grid.Column="1"
                           Text="Call"
                           Command="{Binding Source={RelativeSource AncestorType={x:Type ContentPage}}, Path=BindingContext.TapCommand}">
</Button>
                </Grid>
                <Grid Grid.Row="0"
                          Grid.Column="2"
                          RowSpacing="0"
                          HorizontalOptions="End" VerticalOptions="Start">

                    <Label LineBreakMode="NoWrap"
                             TextColor="#474747"
                             Text="{Binding ContactType}">
                    </Label>
                </Grid>
            </Grid>
        </Grid>
    </ViewCell.View>
</ViewCell>
```
**C#: ViewModel Command definition**
``` C#
public ObservableCollection<Contacts> contactsinfo { get; set; }


public ContactsViewModel()
{
      contactsinfo = new ObservableCollection<Contacts>();
      TapCommand = new Command(OnTapped);
      GenerateInfo();
}

private void OnTapped(object obj)
{
     App.Current.MainPage.DisplayAlert("Message","Button tapped","Ok");
}
```
