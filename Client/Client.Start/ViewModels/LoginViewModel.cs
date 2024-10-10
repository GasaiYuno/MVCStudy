using Client.IBLL;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Windows.Input;

namespace Client.Start.ViewModels
{
    public class LoginViewModel:BindableBase
    {
        private string _username;
        public string Username { get { return _username; } set { SetProperty<string>(ref _username, value); } }

        private string _password;
        public string Password { get { return _password; } set { SetProperty<string>(ref _password, value); } }

        private string _errorMsg;
        public string ErrorMsg { get { return _errorMsg; } set { SetProperty<string>(ref _errorMsg, value); } }    

        public ICommand LoginCommand
        {
            get =>new DelegateCommand<object>(Login);
        }

        private ILoginBLL _iLoginBLL;
        public LoginViewModel(ILoginBLL ILoginBLL)
        {
            this._iLoginBLL = ILoginBLL;
        }

        private void Login(object obj)
        {
            int[] array = new int[] { 10, 1, 5, 7, 4, 3, 2, 9 };

            BubbleSort(array);

            System.Console.WriteLine(array);

            try
            {
                if(string.IsNullOrEmpty(_username)) 
                {
                    this._errorMsg = "用户名为空";
                    return;
                }
                if (string.IsNullOrEmpty(_password))
                {
                    this._errorMsg = "密码为空";
                    return;
                }
                //检验登录账号密码
                if (_iLoginBLL.Login(_username, _password).GetAwaiter().GetResult())
                {

                }
                else
                {
                    this.ErrorMsg = "用户名或者密码错误";
                    return;
                }


            }catch(Exception ex)
            {

            }
        }

        //归治排序
        private void MergeSort(int[] array)
        {
            //判断数组是否为空或者数量为一，已经有序返回
            if (array == null || array.Length == 1)
            {
                return;
            }

            //创建一个新数组用于存取数据
            int[] temparray=new int[array.Length];

            Sort(array, temparray, 0, array.Length - 1);

        }
        private void Sort(int[] array, int[] temparray,int left,int right)
        {
            if(left< right)
            {
                //把数据分成两份
                int mid = (left + right) / 2;

                Sort(array, temparray, left, mid);
                Sort(array, temparray, mid + 1, right);

                //合并两个数据
                Merge(array, temparray, left, mid, right);
            }
        }

        private void Merge(int[] array, int[] temparray,int left,int mid,int right)
        {
            int i = left;
            int j = mid + 1;
            int k = left;

            while(i<=mid&& j<=right)
            {
                if (array[i] <= array[j])
                {
                    temparray[k++] = array[i++];
                }
                else
                {
                    temparray[k++] = array[j++];
                }
            }
            while (i <= mid)
            {
                temparray[k++] = array[i++];
            }
            while (j <= right)
            {
                temparray[k++] = array[j++];
            }

            for(int w = left; w <= right; w++)
            {
                array[w] = temparray[w];
            }
        }
        //二分插入排序
        private void BinarySort(int[] array)
        {
            for(int i = 1; i < array.Length; i++)
            {
                int persent = array[i];
                int pos = Binary(array, persent, 0, i - 1);
                for(int j = i; j > pos; j--)
                {
                    array[j] = array[j - 1];
                }
                array[pos] = persent;
            }
        }

        private int Binary(int[] array, int item,int low,int high)
        {
            while (low <= high)
            {
                int mid = low + (high -low) / 2;
                if (item == array[mid])
                {
                    return mid;
                }
                else if (item < array[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low;
        }

        //冒泡排序
        private void BubbleSort(int[] array)
        {
            bool change;
            for(int i = 0; i < array.Length-1; i++)
            {
                change = false;
                for(int j = 0; j < array.Length -1- i; j++)
                {
                    if (array[j] >= array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        change = true;
                    }
                }
                if (!change)
                {
                    break;
                }
            }
        }
    }
}
