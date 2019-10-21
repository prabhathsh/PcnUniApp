using PcnUniApp.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PcnUniApp.ApplicationCore.Services
{
    public class UriComposer : IUriComposer
    {
        private readonly UniversitySettings _universitySettings;

        public UriComposer(UniversitySettings universitySettings) => _universitySettings = universitySettings;
        public string ComposePicUri(string uriTemplate)
        {
            throw new NotImplementedException();
        }
    }
}
