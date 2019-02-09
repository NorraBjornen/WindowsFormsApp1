using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Source.Model {
    class Constants {
        public const String DISPATCHER = "dsp";
        public const String DRIVER = "drv";
        /*public static final String REFUSE_ORDER = "ref";
        public static final String COMPLETE_ORDER = "compl";*/
        public const char COMMAND_DELIMITER = '~';
        public const char ELEMENT_DELIMITER = '$';
        public const char TOKEN_DELIMITER = '|';

        public const String COMMAND_I = "i";
        public const String COMMAND_GET = "get";
        public const String COMMAND_NEW = "new";
        public const String COMMAND_UPDATE = "upd";
        public const String COMMAND_DELETE = "del";
        public const String COMMAND_GO = "go";
        public const String COMMAND_GET_OFFERED_PRICES = "getoff";
        public const String COMMAND_PING = "ping";
        public const String COMMAND_REGISTRATION = "reg";
        public const String COMMAND_ONLINE = "online";
        public const String COMMAND_AUTH = "auth";
        public const String COMMAND_OFFER = "offer";
        public const String COMMAND_EXIT = "exit";
        public const String COMMAND_UPDATE_PRICE = "updoff";
        public const String COMMAND_CHECK_MARKET = "check";
        public const String COMMAND_ACCEPT = "acc";
        public const String COMMAND_REFUSE = "ref";
        public const String COMMAND_HURRY = "hur";
        public const String COMMAND_COMPLETED = "comp";
        public const String COMMAND_GET_DRIVERS = "getdrv";
        public const String COMMAND_STREETS = "str";
        public const String COMMAND_GEO = "geo";
        public const String COMMAND_FREE_ID = "fid";
    }
}
