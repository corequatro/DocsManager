// //JsonResultModel.cs
// // Copyright (c) 2018 07 03All Rights Reserved
// //  Bogdan Lyashenko
// // bogdan.lyashenko@gmail.com

namespace DocsManagerWebApp.Helpers
{
    public class JsonResultModel
    {
        public string SuccessHeader { get; set; }
        public string SuccessMessage { get; set; }
        public string WarningHeader { get; set; }
        public string WarningMessage { get; set; }
        public string ErrorHeader { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsValidated { get; set; }
        public string ResultData { get; set; }
    }
}