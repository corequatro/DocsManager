// //PageCollectionViewModel.cs
// // Copyright (c) 2018 07 07All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

using System;
using System.Collections.Generic;
using System.Linq;

namespace DocsManagerWebApp.Models.Base
{
    public interface IPageCollectionViewModel<T>
    {
        ICollection<T> Items { get; }
        int Count { get; }
    }

    public class PageCollectionViewModel<T> : IPageCollectionViewModel<T>
    {
        public PageCollectionViewModel(ICollection<T> items, int count)
        {
            Items = items;
            Count = count;
        }
        public int Count { get; }
        public ICollection<T> Items { get; }

        public PageCollectionViewModel<TX> Convert<TX>(Func<T, TX> convertFunc)
        {
            return new PageCollectionViewModel<TX>(Items.Select(convertFunc).ToList(), Count);
        }
    }
}