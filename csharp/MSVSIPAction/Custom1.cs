using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Windows.Forms;

namespace MSVSIPAction
{
    [RunInstaller(true)]
    public partial class Custom1 : Installer
    {
        public Custom1()
        {
            InitializeComponent();
        }


        public override void Install(IDictionary stateSaver)
        {
            MessageBox.Show($"{nameof(Custom1)} :: {nameof(Install)}");
            base.Install(stateSaver);
        }

        public override void Commit(IDictionary savedState)
        {
            MessageBox.Show($"{nameof(Custom1)} :: {nameof(Commit)}");
            base.Commit(savedState);
        }

        public override void Rollback(IDictionary savedState)
        {
            MessageBox.Show($"{nameof(Custom1)} :: {nameof(Rollback)}");
            base.Rollback(savedState);
        }

        public override void Uninstall(IDictionary savedState)
        {
            MessageBox.Show($"{nameof(Custom1)} :: {nameof(Uninstall)}");
            base.Uninstall(savedState);
        }
    }
}
