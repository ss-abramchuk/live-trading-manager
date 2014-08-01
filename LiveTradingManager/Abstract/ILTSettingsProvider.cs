using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WLDSolutions.LiveTradingManager.Abstract
{
    public interface ILTSettingsProvider
    {
        void SetParameter(string parameter, string value);
        void SetParameter(string parameter, double value);
        void SetParameter(string parameter, int value);
        void SetParameter(string parameter, bool value);

        string GetParameter(string parameter, string defaultValue);
        double GetParameter(string parameter, double defaultValue);
        int GetParameter(string parameter, int defaultValue);
        bool GetParameter(string parameter, bool defaultValue);

        void SaveObject(string objectID, object value);
        object GetObject(string objectID, Type objectType);
    }
}
