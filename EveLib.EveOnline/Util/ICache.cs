﻿using System;

namespace eZet.EveLib.Modules.Util {
    public interface ICache {
        bool TryGet(Uri uri, out string data);

        void Insert(Uri uri, string data);
    }
}