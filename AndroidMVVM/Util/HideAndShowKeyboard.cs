using System;
using Android.Content;
using Android.Views;
using Android.Views.InputMethods;

namespace AndroidMVVM.Util
{
	public class HideAndShowKeyboard
	{
        public void showSoftKeyboard(Android.App.Activity activity, View view)
        {
            InputMethodManager inputMethodManager = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
            view.RequestFocus();
            inputMethodManager.ShowSoftInput(view, 0);
        }

        public void hideSoftKeyboard(Android.App.Activity activity)
        {
            var currentFocus = activity.CurrentFocus;
            if (currentFocus != null)
            {
                InputMethodManager inputMethodManager = (InputMethodManager)activity.GetSystemService(Context.InputMethodService);
                inputMethodManager.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);
            }
        }
    }
}

