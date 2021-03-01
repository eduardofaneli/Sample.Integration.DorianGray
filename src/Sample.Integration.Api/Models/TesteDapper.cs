using Newtonsoft.Json;
using Sample.Integration.Api.Extensions;
using System;

namespace Sample.Integration.Api.Models
{
    public class TesteDapper
    {        
        public string Descricao { get; set; }

        private Byte[] _Id;
        private Byte[] IdHex
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Id
        {
            get
            {
                if (_Id != null)
                {
                    string text = new Guid(_Id).ToString("N").ToUpperInvariant();
                    byte[] bytes = text.ToByte();

                    return new Guid(bytes).ToString("N").ToUpperInvariant();
                }
                return null;
            }
        }
    }
}
