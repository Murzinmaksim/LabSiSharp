using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;


namespace Prog_it_6
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Assembly SampleAssembly = Assembly.LoadFrom(@"../../../../TelephoneLib/bin/Debug/net5.0/Prog_it_6_Lib.dll");
        Type TypeClass;

        private void Form1_Load(object sender, EventArgs e)
        {
            var test = GetTypesWithInterface(SampleAssembly);
            var true_class = test.Where(elem => elem.GetInterface("ITelephone") != null).ToList();
            foreach (var i in true_class)
            {
                comboBox1.Items.Add(i.ToString());
            }
        }


        private IEnumerable<Type> GetTypesWithInterface(Assembly asm)
        {
            var it = typeof(TelephoneLib.ITelephone);
            return asm.GetLoadableTypes().Where(it.IsAssignableFrom).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeClass = SampleAssembly.GetType(comboBox1.SelectedItem.ToString());
            var main = TypeClass.GetMethods().Where(p =>  p.ReturnType == typeof(string)
            && p.Name != "ToString" && p.Name.Substring(0, 4) != "get_");
            listBox1.Items.Clear();
            foreach (var mi in main)
            {
                listBox1.Items.Add(mi.ToString());
            }
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            if(!TypeClass.IsAbstract)
            {
                object myObj = Activator.CreateInstance(TypeClass, new object[] { });
                MessageBox.Show("Содан объект класса " + myObj.ToString());
                int start = listBox1.SelectedItem.ToString().IndexOf(' ') + 1;
                int end = listBox1.SelectedItem.ToString().IndexOf('(') - start;
                var par = TypeClass.GetMethod(listBox1.SelectedItem.ToString().Substring(start, end));
                ParameterInfo[] pi = par.GetParameters();
                object[] args = new object[1];
                if (pi.Length == 0)
                {
                    MessageBox.Show(par.Invoke(myObj, null).ToString());
                }
                else
                {
                    if (pi[0].ParameterType == typeof(bool))
                    {
                        args[0] = new Random().Next(2) == 0 ? false : true;
                        MessageBox.Show(par.Invoke(myObj, args).ToString());
                    }
                    if (pi[0].ParameterType == typeof(Int32))
                    {
                        args[0] = Convert.ToInt32(textBox1.Text);
                        MessageBox.Show(par.Invoke(myObj, args).ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не можете создать объект абстрактного класса");
            }

        }

      
    }


    public static class TypeLoaderExtensions
    {
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}
