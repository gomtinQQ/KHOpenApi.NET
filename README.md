# KHOpenApi.NET 테스트

## 1. WinForms (NET6.0), WinForm_NET48
---------------

#### Form1.cs

```c#
    public partial class Form1 : Form
    {
        // ocx인터페이스 추가
        AxKHOpenAPI axKHOpenAPI;

        public Form1()
        {
            InitializeComponent();
            // 새로 추가
            axKHOpenAPI = new AxKHOpenAPI( Handle );
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(axKHOpenAPI_OnEventConnect);

            button_login.Enabled = axKHOpenAPI.Created;
        }

        // 로그인 이벤트 핸들러
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox1.Text = "로그인 성공";
            }
            else
            {
                textBox1.Text = "로그인 실패";
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            // 로그인 요청
            axKHOpenAPI.CommConnect();
        }
    }
```

## 2. WPF (NET6.0), WPF_NET48
---------------
#### MainWindow.xaml.cs

```c#
    public partial class MainWindow : Window
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI;

        public MainWindow()
        {
            InitializeComponent();
            // ActiveX 세팅
            axKHOpenAPI = new AxKHOpenAPI( new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle() );
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI_OnEventConnect);

            button_login.IsEnabled = axKHOpenAPI.Created;
        }

        // 로그인 이벤트 핸들러
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox1.Text = "로그인 성공";
            }
            else
            {
                textBox1.Text = "로그인 실패";
            }
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            // 로그인 요청
            axKHOpenAPI.CommConnect();
        }
    }

```

## 3. WinUI3
---------------
#### MainWindow.xaml.cs

```c#
    public sealed partial class MainWindow : Window
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI;

        public MainWindow()
        {
            this.InitializeComponent();
            // ActiveX 세팅
            axKHOpenAPI = new AxKHOpenAPI( WinRT.Interop.WindowNative.GetWindowHandle(this) );
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI_OnEventConnect);

            myButton.IsEnabled = axKHOpenAPI.Created;
        }

        // 로그인 이벤트 핸들러
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox1.Text = "로그인 성공";
            }
            else
            {
                textBox1.Text = "로그인 실패";
            }
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            // 로그인 요청
            axKHOpenAPI.CommConnect();
        }
    }

```