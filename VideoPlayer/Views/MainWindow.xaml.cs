using System.IO;
using System.Windows;
using System.Windows.Controls;
using VideoPlayer.ViewModels;

namespace VideoPlayer.Views;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		
		MainViewModel vm = new();
		this.DataContext = vm;
		vm.PlayRequested += (sender, e) =>
		{
			Player.Play();
		};
	}
}
