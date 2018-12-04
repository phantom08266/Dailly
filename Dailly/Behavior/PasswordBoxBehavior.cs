using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

/*
 * PasswordBox의 Password는 DP가 아님으로 바인딩 걸 수 없음
 * PasswordBox는 Text를 입력받는 공간에 SecurePassword가 함께 Setting되어
 * 암호화되어 메모리에 보관한다.
 * 그래서 보통 AttachedProeprty를 이용한다.
 * xaml에서 이 behavior를 직접 사용하기 위해 만듦.
 * Password라는 DP를 추가하고 Binding기능을 준비해두고
 * Behavior가 Attach 될때 PasswordChanged이벤트를 받아서 Password DP에 set하는 것이 전부임.
 */
namespace Dailly.Behavior
{
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        public static DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password",
            typeof(string),
            typeof(PasswordBoxBehavior),
            new FrameworkPropertyMetadata(
                string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );

        public string Password
        {
            get
            {
                return this.GetValue(PasswordProperty) as string;
            }
            set
            {
                this.SetValue(PasswordProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += OnPasswordChange;
        }

        private void OnPasswordChange(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if(passwordBox == null)
            {
                return;
            }
            this.Password = passwordBox.Password;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= OnPasswordChange;
        }
    }
}
