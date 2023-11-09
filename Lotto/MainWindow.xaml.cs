using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace Lotto
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		DispatcherTimer timer = new DispatcherTimer();
		TimeSpan currentTime = TimeSpan.Zero;
		DateTime startTime = new DateTime();
		int counter = 0;
		Random rnd = new Random();

		public MainWindow()
		{
			InitializeComponent();
			timer.Tick += new EventHandler(tiTick);
			timer.Interval = new TimeSpan(0, 0, 1);
		}
		int[] usedNum = {};
		private void tiTick(object? sender, EventArgs e)
		{
			int num = rnd.Next(1, 100);
			usedNum[counter] = num;
			txtRolling.Text = Convert.ToString(num);
			switch (counter)
			{
				case 0:
					counter++;
					while (usedNum.Contains(num))
					{
						rnd.Next(1, 100);
					}
					usedNum[counter] = num;
					txtResult1.Text = Convert.ToString(num);
					break;
				case 1:
					counter++;
					while (usedNum.Contains(num))
					{
						rnd.Next(1, 100);
					}
					usedNum[counter] = num;
					txtResult2.Text = Convert.ToString(num);
					break;
				case 2:
					counter++;
					while (usedNum.Contains(num))
					{
						rnd.Next(1, 100);
					}
					usedNum[counter] = num;
					txtResult3.Text = Convert.ToString(num);
					break;
				case 3:
					counter++;
					while (usedNum.Contains(num))
					{
						rnd.Next(1, 100);
					}
					usedNum[counter] = num;
					txtResult4.Text = Convert.ToString(num);
					break;
				case 4:
					counter = 0;
					while (usedNum.Contains(num))
					{
						rnd.Next(1, 100);
					}
					usedNum[counter] = num;
					txtResult5.Text = Convert.ToString(num);
					timer.Stop();
					break;
			}
		}

		private void btnLotto_Click(object sender, RoutedEventArgs e)
		{
			txtRolling.Text = "";
			txtResult1.Text = "";
			txtResult2.Text = "";
			txtResult3.Text = "";
			txtResult4.Text = "";
			txtResult5.Text = "";
			startTime = DateTime.Now;
			timer.Start();
		}
	}
}
