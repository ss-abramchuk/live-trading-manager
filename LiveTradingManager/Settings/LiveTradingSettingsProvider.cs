using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using log4net;

using WLDSolutions.LiveTradingManager.Abstract;

namespace WLDSolutions.LiveTradingManager.Settings
{
    public class LiveTradingSettingsProvider : ILTSettingsProvider
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(LiveTradingSettingsProvider));

        // Конфигурационный файл
        //
        private XDocument _configFile;

        private string _dataPath;
        private string _fileName;

        // Базовые элементы
        //
        private string _configRootArea = "LTProductSettings";
        private string _configSettingsArea = "Settings";

        private object _locker = new object();

        public LiveTradingSettingsProvider(string dataPath, string fileName)
        {
            _dataPath = dataPath;
            _fileName = fileName;

            try
            {
                if (_dataPath == null)
                    throw new ArgumentNullException("DataPath", "Значение DataPath == null не допускается.");

                if (_fileName == null)
                    throw new ArgumentNullException("FileName", "Значение FileName == null не допускается.");

                _configFile = XDocument.Load(_dataPath + _fileName);
            }
            catch (FileNotFoundException)
            {
                _configFile = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(_configRootArea,
                    new XElement(_configSettingsArea)));

                lock (_locker)
                    _configFile.Save(_dataPath + _fileName);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public void SetParameter(string parameter, string value)
        {
            SaveParameter(parameter, value);
        }

        public void SetParameter(string parameter, double value)
        {
            SaveParameter(parameter, value.ToString());
        }

        public void SetParameter(string parameter, int value)
        {
            SaveParameter(parameter, value.ToString());
        }

        public void SetParameter(string parameter, bool value)
        {
            SaveParameter(parameter, value.ToString());
        }

        public string GetParameter(string parameter, string defaultValue)
        {
            string result = ReadParameter(parameter);

            if (string.IsNullOrWhiteSpace(result))
                return defaultValue;
            else
                return result;
        }

        public double GetParameter(string parameter, double defaultValue)
        {
            try
            {
                string result = ReadParameter(parameter);

                if (string.IsNullOrWhiteSpace(result))
                    return defaultValue;
                else
                    return Convert.ToDouble(ReadParameter(parameter));
            }
            catch 
            {
                return defaultValue;
            }
        }

        public int GetParameter(string parameter, int defaultValue)
        {
            try
            {
                string result = ReadParameter(parameter);

                if (string.IsNullOrWhiteSpace(result))
                    return defaultValue;
                else
                    return Convert.ToInt32(ReadParameter(parameter));
            }
            catch
            {
                return defaultValue;
            }
        }

        public bool GetParameter(string parameter, bool defaultValue)
        {
            try
            {
                string result = ReadParameter(parameter);

                if (string.IsNullOrWhiteSpace(result))
                    return defaultValue;
                else
                    return Convert.ToBoolean(ReadParameter(parameter));
            }
            catch
            {
                return defaultValue;
            }
        }

        public void SaveObject(string objectID, object value)
        {
            try
            {
                if (value == null)
                    throw new ArgumentNullException("Value", "Значение Value == null не допускается.");

                if(_configFile == null)
                    throw new ArgumentNullException("Config File", "Config File не определен.");

                if (string.IsNullOrWhiteSpace(objectID))
                    throw new ArgumentNullException("ObjectID", "Значение ObjectID == null или empty не допускается.");

                XmlSerializer xmlSerializer = new XmlSerializer(value.GetType());

                XmlSerializerNamespaces xmlNameSpaces = new XmlSerializerNamespaces();
                xmlNameSpaces.Add("", "");

                XElement serializedObject;

                using (StringWriter stringWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(stringWriter, value, xmlNameSpaces);

                    using (StringReader stringReader = new StringReader(stringWriter.ToString()))
                    {
                        serializedObject = XElement.Load(stringReader);
                    }
                }

                if (serializedObject == null)
                    throw new ArgumentNullException("SerializedObject", "Значение SerializedObject == null не допускается.");

                XElement element = _configFile.Element(_configRootArea).Element(objectID);

                if (element == null)
                {
                    element = new XElement(objectID);
                    _configFile.Element(_configRootArea).Add(element);
                }

                element.ReplaceAll(serializedObject);

                lock (_locker)
                    _configFile.Save(this._dataPath + _fileName);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }

        public object GetObject(string objectID, Type objectType)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objectType);

            try
            {
                XNode element = _configFile.Element(_configRootArea).Element(objectID).FirstNode;

                using (XmlReader stringReader = element.CreateReader())
                {
                    return xmlSerializer.Deserialize(stringReader);
                }
            }
            catch (Exception ex)
            {
                if(!(ex is NullReferenceException))
                    logger.Error(ex);

                return null;
            }
        }

        private string ReadParameter(string parameter)
        {
            try
            {
                XElement element = _configFile.Element(_configRootArea).Element(_configSettingsArea).Element(parameter);

                return (string)element;
            }
            catch
            {
                return string.Empty;
            }
        }

        private void SaveParameter(string parameter, string value)
        {
            XElement element = _configFile.Element(_configRootArea).Element(_configSettingsArea).Element(parameter);

            if (element != null)
                element.Value = value;
            else
            {
                element = new XElement(parameter, value);
                _configFile.Element(_configRootArea).Element(_configSettingsArea).Add(element);
            }

            lock (_locker)
                _configFile.Save(this._dataPath + _fileName);
        }
    }
}
