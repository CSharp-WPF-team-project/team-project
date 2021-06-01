using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Notice.View
{
	/// <summary>
	/// Notice.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class Notice : Page
	{
		

		//int grade = 0;
		public Notice()
		{
			
			InitializeComponent();
			click.Click += button1_Initialized;

		}
		
		public void button1_Initialized(object sender, EventArgs e)
		{
			
			
			// 학점선택 체크박스
			IEnumerable<CheckBox> ChkBoxes = from checkbox in this.StackPanelGroup1.Children.OfType<CheckBox>()
												 // where checkbox.IsChecked.Value 체크된 Checkbox 만 선택할때
											 select checkbox;
			// 체크된 content 값 가져오기
			foreach (CheckBox Chkbox in ChkBoxes)
			{
				if (Chkbox.IsChecked == true)
				{
					if (Chkbox.Content.ToString() == "21.5학점")
					{
						//vm.grade.GradeNumber = 21;
					}
					if (Chkbox.Content.ToString() == "18.5학점")
					{
						//vm.grade.GradeNumber = 18;
					}
					if (Chkbox.Content.ToString() == "15.5학점")
					{
						//vm.grade.GradeNumber = 15;
					}
				}
			}
		}

	}
}
