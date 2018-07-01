// //BuisnessLogic.cs
// // Copyright (c) 2018 06 30All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

namespace DocsManager.Domain.Verification
{
    public static class BusinessLogic
    {
        public static void RequiresThat(bool condition, string errorMessage)
        {
            if (!condition)
            {
                throw new ServiceException(errorMessage);
            }
        }
    }
}