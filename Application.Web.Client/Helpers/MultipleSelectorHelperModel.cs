﻿namespace Application.Web.Client.Helpers
{
    public struct MultipleSelectorHelperModel
    {
        public MultipleSelectorHelperModel(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
