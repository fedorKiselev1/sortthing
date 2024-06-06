using classes;
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

namespace sorting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Firm> FirmArr = new List<Firm>() { new Firm("cool", new List<classes.Section>() 
                                                              { new classes.Section("epic", new List<Employee>() 
                                                              { new Employee("guy", "jedi", 99), new FullTimer("sol", "cool", 999, 999) }),
                                                              new classes.Section("agoo", new List<Employee>() {new Contracter("man", "superman", 1001)} )} )};
        
        public MainWindow()
        {
            FirmArr.Add(new Firm("cooler2", new List<classes.Section>()
                                                              { new classes.Section("epicer2", new List<Employee>()
                                                              { new Employee("guyer2", "jedier2", 9459), new FullTimer("soler2", "cooler2", 90, 99) }),
                                                              new classes.Section("gooer2", new List<Employee>() {new Contracter("maner2", "supermaner2", 1)} )}));
            InitializeComponent();
            firms.ItemsSource = FirmArr;
        }

        private void firms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((firms.SelectedItem as classes.Firm) != null)
            {
                sections.ItemsSource = (firms.SelectedItem as classes.Firm).SectionList;
            } else
            {
                sections.ItemsSource = null;
            }
        }

        private void sections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool flag = false;
            if ((sections.SelectedItem as classes.Section) != null)
            {
                flag = true;
            }
            if (sections.SelectedItem != null || flag == true)
            {
                employees.ItemsSource = (sections.SelectedItem as classes.Section).EmployeeList;
            } else
            {
                employees.ItemsSource = null;
            }
            
        }

        private void SectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (firms.SelectedItem != null)
            {
                switch(sectioncombo.SelectedIndex)
                    {
                        case 0:
                            FirmArr[firms.SelectedIndex].SectionList = FirmArr[firms.SelectedIndex].SectionList.OrderBy(x => x.Name).ToList();
                            sections.ItemsSource = (firms.SelectedItem as classes.Firm).SectionList;
                            break;
                        case 1:
                            FirmArr[firms.SelectedIndex].SectionList = FirmArr[firms.SelectedIndex].SectionList.OrderBy(x => x.EmployeeCount).ToList();
                            sections.ItemsSource = (firms.SelectedItem as classes.Firm).SectionList;
                            break;
                    }
            }
            
                
            
        }

        private void EmployeeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sections.SelectedItem != null)
            {
                switch (employeecombo.SelectedIndex)
                {
                    case 0:
                        FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList = FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList.OrderBy(x => x.Name).ToList();
                        employees.ItemsSource = (sections.SelectedItem as classes.Section).EmployeeList;
                        break;
                    case 1:
                        FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList = FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList.OrderBy(x => x.Duty).ToList();
                        employees.ItemsSource = (sections.SelectedItem as classes.Section).EmployeeList;
                        break;
                    case 2:
                        FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList = FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList.OrderBy(x => x.Salary).ToList();
                        employees.ItemsSource = (sections.SelectedItem as classes.Section).EmployeeList;
                        break;
                    case 3:
                        FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList = FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList.OrderBy(x => x is FullTimer ? ((FullTimer)x).Prize : -1).ToList();
                                                                                                                                                                                     
                        employees.ItemsSource = (sections.SelectedItem as classes.Section).EmployeeList;
                        break;
                }
            }
            
        }

        private void Firm_Creation_Button_Click(object sender, RoutedEventArgs e)
        {
            if (firmcr.Text != "")
            {
                FirmArr.Add(new Firm(firmcr.Text, new List<classes.Section>()));
                firmcr.Text = null;
                firms.ItemsSource = null;
                firms.ItemsSource = FirmArr;
            }
        }

        private void Section_Creating_Button_Click(object sender, RoutedEventArgs e)
        {
            if (sectioncr.Text != "" && firms.SelectedItem != null)
            {
                FirmArr[firms.SelectedIndex].SectionList.Add(new classes.Section(sectioncr.Text, new List<Employee>()));
                sectioncr.Text = null;
                sections.ItemsSource = null;
                sections.ItemsSource = FirmArr[firms.SelectedIndex].SectionList;
            }
            
        }

        private void Create_Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            try
            {
                Convert.ToInt32(empcrsalary.Text);
            }
            catch
            {
                flag = true;
            }
            if (empcrname.Text != "" && empcrduty.Text != "" && empcrsalary.Text != "" && sections.SelectedItem != null && flag == false)
            {
                
                FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList.Add(new Employee(empcrname.Text, empcrduty.Text, Convert.ToInt32(empcrsalary.Text)));
                empcrname.Text = null;
                empcrduty.Text = null;
                empcrsalary.Text = null;
                empcrprize.Text = null;
                FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].UpdateCount();
                employees.ItemsSource = null;
                employees.ItemsSource = FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList;
            }
        }

        private void Create_Contracter_Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            try
            {
                Convert.ToInt32(empcrsalary.Text);
            }
            catch
            {
                flag = true;
            }
            if (empcrname.Text != "" && empcrduty.Text != "" && empcrsalary.Text != "" && sections.SelectedItem != null && flag == false)
            {
                FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList.Add(new Contracter(empcrname.Text, empcrduty.Text, Convert.ToInt32(empcrsalary.Text)));
                empcrname.Text = null;
                empcrduty.Text = null;
                empcrsalary.Text = null;
                empcrprize.Text = null;
                FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].UpdateCount();
                employees.ItemsSource = null;
                employees.ItemsSource = FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList;
            }
        }

        private void Create_FullTimer_Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            try
            {
                Convert.ToInt32(empcrsalary.Text);
                Convert.ToInt32(empcrprize.Text);
            }
            catch
            {
                flag = true;
            }
            if (empcrname.Text != "" && empcrduty.Text != "" && empcrsalary.Text != "" && empcrprize.Text != "" && sections.SelectedItem != null && flag == false)
            {
                FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].EmployeeList.Add(new FullTimer(empcrname.Text, empcrduty.Text, Convert.ToInt32(empcrsalary.Text), Convert.ToInt32(empcrprize.Text)));
                empcrname.Text = null;
                empcrduty.Text = null;
                empcrsalary.Text = null;
                empcrprize.Text = null;
                FirmArr[firms.SelectedIndex].SectionList[sections.SelectedIndex].UpdateCount();
                employees.ItemsSource = null;
                employees.ItemsSource = (sections.SelectedItem as classes.Section).EmployeeList;
            }
        }
    }
}
