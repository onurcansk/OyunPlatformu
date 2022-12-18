using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            long tcno = long.Parse(textBox3.Text);
            DateTime dt = dateTimePicker1.Value;

            UserDetail userDetail = new UserDetail()
            {
                BirthDate = dt,
                FirstName = name,
                LastName = surname,
                TcNo = tcno
            };

            UserDetailManager userDetailManager = new UserDetailManager(new EfUserDetailDal());

            var result = userDetailManager.Add(userDetail);
            MessageBox.Show(result.Message);

        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }
    }

}