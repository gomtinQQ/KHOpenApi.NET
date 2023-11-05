using KFOpenApi.NET;
using KHOpenApi.NET;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ocx�������̽� �߰�
        private AxKHOpenAPI axKHOpenAPI; // ���� (������)
        private AxKFOpenAPI axKFOpenAPI; // �ؿ� (������ �۷ι�)

        public Form1()
        {
            InitializeComponent();

            Text = "WinForm " + (Environment.Is64BitProcess ? "(64��Ʈ)" : "(32��Ʈ)");

            // ActiveX ����
            axKHOpenAPI = new AxKHOpenAPI(Handle);
            axKHOpenAPI.OnEventConnect += axKHOpenAPI_OnEventConnect;
            button_login_KH.Enabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            axKFOpenAPI.OnEventConnect += axKFOpenAPI_OnEventConnect;
            button_login_KF.Enabled = axKFOpenAPI.Created;
        }

        // �����α��� �̺�Ʈ �ڵ鷯
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox1.Text = "�α��� ����";
            }
            else
            {
                textBox1.Text = "�α��� ����";
            }
        }

        // �ؿܷα��� �̺�Ʈ �ڵ鷯
        private void axKFOpenAPI_OnEventConnect(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox2.Text = "�α��� ����";
            }
            else
            {
                textBox2.Text = "�α��� ����";
            }
        }

        private void button_login_KH_Click(object sender, EventArgs e)
        {
            // ���� �α��� ��û
            axKHOpenAPI.CommConnect();
        }

        private void button_login_KF_Click(object sender, EventArgs e)
        {
            // �ؿ� �α��� ��û
            axKFOpenAPI.CommConnect(1);
        }
    }
}
