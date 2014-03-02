﻿using System;
using eZet.Eve.EveLib.Model.EveCentral;
using eZet.Eve.EveLib.Util;

namespace eZet.Eve.EveLib.Entity.EveCentral {
    public class EveCentral {

        protected Uri BaseUri { get; set; }

        public IRequestHandler RequestHandler { get; set; }

        internal EveCentral() {
            BaseUri = new Uri("http://api.eve-central.com");
            RequestHandler = new RequestHandler(new XmlSerializerWrapper());
        }

        /// <summary>
        /// Returns aggregate statistics for the items specified.
        /// </summary>
        /// <param name="options">Valid options; Types, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public MarketStatResponse GetMarketStat(EveCentralOptions options) {
            const string relUri = "/api/marketstat";
            var queryString = options.TypeQuery("typeid") + options.HourQuery("hours") + options.MinQuantityQuery("minQ") +
                             options.RegionQuery("regionlimit") + options.SystemQuery("usesystem");
            return request<MarketStatResponse>(relUri, queryString);
        }

        /// <summary>
        /// Returns all of the available market orders, including prices, stations, order IDs, volumes, etc.
        /// </summary>
        /// <param name="options">Valid options; Types, HourLimit, MinQuantity, Regions, Systems</param>
        /// <returns></returns>
        public QuicklookResponse GetQuicklook(EveCentralOptions options) {
            const string relUri = "/api/quicklook";
            var queryString = options.TypeQuery("typeid") + options.HourQuery("sethours") + options.MinQuantityQuery("setminQ") +
                      options.RegionQuery("regionlimit") + options.SystemQuery("usesystem");
            return request<QuicklookResponse>(relUri, queryString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startSystem">SystemID or System name</param>
        /// <param name="endSystem">SystemID or System name</param>
        /// <param name="typeId">Type ID</param>
        /// <param name="options">Optional; Valid options: HourLimit, MinQuantity.</param>
        /// <returns></returns>
        public QuicklookResponse GetQuicklookPath(object startSystem, object endSystem, long typeId,
            EveCentralOptions options = null) {
            var relUri = "/api/quicklook/onpath";
            relUri += "/from/" + startSystem + "/to/" + endSystem + "/fortype/" + typeId;
            var queryString = "";
            if (options != null) {
                queryString = options.HourQuery("sethours");
                queryString += options.MinQuantityQuery("setminQ");
            }
            return request<QuicklookResponse>(relUri, queryString);

        }

        public void GetHistory() {
            throw new NotImplementedException();
        }

        private T request<T>(string relUri, string queryString) {
            var uri = new Uri(BaseUri, relUri + "?" + queryString);
            return RequestHandler.Request<T>(uri);
        }
    }
}