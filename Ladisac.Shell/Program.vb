Imports Microsoft.Practices.Unity
Namespace Ladisac.Shell
    Module Program
        <STAThread()> _
        Sub Main()

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Dim boot As New Ladisac.Shell.Bootstrapper
            boot.Run(False)
            System.Windows.Forms.Application.Run(boot.MainForm)

        End Sub
    End Module
End Namespace
