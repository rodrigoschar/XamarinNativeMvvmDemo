using System;
using CommunityToolkit.Mvvm.Messaging.Messages;
using SharedCode.Models;

namespace SharedCode.Utils
{
	public class SelectedItemMessage : ValueChangedMessage<ListResponse>
	{
		public SelectedItemMessage(ListResponse value) : base(value)
		{
		}
	}

    public class SelectedSrtItemMessage : ValueChangedMessage<string> //
    {
        public SelectedSrtItemMessage(string value) : base(value)
        {
        }
    }
}

