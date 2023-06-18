using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Project2DExample.Saver.Objects
{
    public class SaverManager
    {
        XmlSerializer _xmlSerializer;
        public XmlSerializer XmlSerializer
        {
            get { return _xmlSerializer; }
            set { _xmlSerializer = value; }
        }
        string _appPath;
        string _relativePath;
        public string RelativePath
        {
            get { return _relativePath; }
            set { _relativePath = value; }
        }
        public SaverManager(XmlSerializer xmlSerializer, string relativePath)
        {
            _xmlSerializer = xmlSerializer;
            _relativePath = relativePath;
        }

        public void Save(object o)
        {
            _appPath = Application.dataPath;
            using (FileStream fs = new FileStream(Path.Combine(_appPath, _relativePath), FileMode.OpenOrCreate))
            {
                _xmlSerializer.Serialize(fs, o);
            }
        }
        public object Load()
        {
            _appPath = Application.dataPath;
            object o;
            using (FileStream fs = new FileStream(Path.Combine(_appPath, _relativePath), FileMode.Open))
            {
                o = _xmlSerializer.Deserialize(fs);
            }
            return o;
        }
    }
}
