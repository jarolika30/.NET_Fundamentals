﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionApp
{
    public class CustomConfigurationComponent : ConfigurationComponentBase
    {
        private string _application;
        private double _amount;
        private int _files;

        [ConfigurationManagerItem("application")]
        public string Application {
            get
            {
                return _application;
            }

            set
            {
                _application = value;
            }
        }

        [ConfigurationManagerItem("amount")]
        public double Amount {
            get
            {
                return _amount;
            }

            set
            {
                _amount = value;
            }
        }

        [ConfigurationManagerItem("files")]
        public int Files {
            get
            {
                return _files;
            }

            set
            {
                _files = value;
            }
        }
    }
}