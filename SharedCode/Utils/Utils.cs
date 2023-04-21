using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Mvvm.Messaging.Messages;
using SharedCode.Models;

namespace SharedCode.Utils
{
	public static class Utils
	{
		public static int ConvertKelvinToCelsius(double kelvin)
		{
			var result = kelvin - 273.15;
			var intRes = Convert.ToInt32(result);
			return intRes;
		}

        public static Collection<T> ToCollection<T>(this List<T> items)
        {
            Collection<T> collection = new Collection<T>();

            for (int i = 0; i < items.Count; i++)
            {
                collection.Add(items[i]);
            }

            return collection;
        }

        public static ICollection<T> AddRange<T>(this ICollection<T> source, IEnumerable<T> addSource)
        {
            foreach (T item in addSource)
            {
                source.Add(item);
            }

            return source;
        }
    }

    public class ExtendedObservableCollection<T> : ObservableCollection<T>
    {
        public void Execute(Action<IList<T>> itemsAction)
        {
            itemsAction(Items);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }

    // A sample message with a username value
    public sealed class WeatherChangedMessage : ValueChangedMessage<ListResponse>
    {
        public WeatherChangedMessage(ListResponse value) : base(value)
        {
        }
    }

    // A sample request message to get the current username
    public sealed class CurrentWeatherRequestMessage : RequestMessage<ListResponse>
    {
    }
}

