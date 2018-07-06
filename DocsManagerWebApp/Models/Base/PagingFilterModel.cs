// //PagingFilterModel.cs
// // Copyright (c) 2018 07 07All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

namespace DocsManagerWebApp.Models.Base
{
    public class PagingFilterModel
    {
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                if (value >= 1)
                {
                    _page = value;
                }
            }
        }

        public int Offset => (Page - 1) * CountOnPage;

        public int CountOnPage
        {
            get
            {
                return _countOnPage;
            }
            set
            {
                if (value >= 1 && value < 101) // prevent hacker to load cpu
                {
                    _countOnPage = value;
                }
            }
        }

        private int _page = 1;
        private int _countOnPage = 10;
    }
}