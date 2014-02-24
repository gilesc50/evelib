﻿using System;
using System.Net;

namespace eZet.Eve.EoLib.Entity {
    public class Image {

        public enum CharacterPortraitSize {
            X30 = 30,
            X32 = 32,
            X64 = 64,
            X128 = 128,
            X200 = 200,
            X256 = 256,
            X512 = 512,
            X1024 = 1024
        }

        public enum CorporationLogoSize {
            X30 = 30,
            X32 = 32,
            X64 = 64,
            X128 = 128,
            X256 = 256,
        }

        public enum AllianceLogoSize {
            X30 = 30,
            X32 = 32,
            X64 = 64,
            X128 = 128,
        }

        public enum TypeIconSize {
            X32 = 32,
            X64 = 64,
        }

        public enum RenderSize {
            X32 = 32,
            X64 = 64,
            X128 = 128,
            X256 = 256,
            X512 = 512,
        }

        private readonly Uri baseUri = new Uri("http://image.eveonline.com");

        public IImageRequester ImageRequester { get; private set; }

        public Image() {
            ImageRequester = new ImageRequester();
        }

        /// <summary>
        /// Returns the string path to the image file
        /// </summary>
        public string GetCharacterPortrait(long characterId, CharacterPortraitSize size) {
            const string relUri = "/Character";
            const string ext = ".jpg";
            return requestImage(relUri, characterId, (int)size, ext);
        }

        /// <summary>
        /// Returns the character portrait data
        /// </summary>
        public byte[] GetCharacterPortraitData(long characterId, CharacterPortraitSize size) {
            const string relUri = "/Character";
            const string ext = ".jpg";
            return requestImageData(relUri, characterId, (int)size, ext);
        }

        /// <summary>
        /// Returns the corporation logo path
        /// </summary>
        public string GetCorporationLogo(long corporationId, CorporationLogoSize size) {
            const string relUri = "/Corporation";
            const string ext = ".png";
            return requestImage(relUri, corporationId, (int) size, ext);
        }

        /// <summary>
        /// Returns the corporation logo
        /// </summary>
        public byte[] GetCorporationLogoData(long corporationId, CorporationLogoSize size) {
            const string relUri = "/Corporation";
            const string ext = ".png";
            return requestImageData(relUri, corporationId, (int)size, ext);

        }

        /// <summary>
        /// Returns the alliance logo path
        /// </summary>
        public string GetAllianceLogo(long allianceId, AllianceLogoSize size) {
            const string relUri = "/Alliance";
            const string ext = ".png";
            return requestImage(relUri, allianceId, (int)size, ext);
        }

        /// <summary>
        /// Returns the alliance logo
        /// </summary>
        public byte[] GetAllianceLogoData(long allianceId, AllianceLogoSize size) {
            const string relUri = "/Alliance";
            const string ext = ".png";
            return requestImageData(relUri, allianceId, (int)size, ext);
        }

        /// <summary>
        /// Returns the type icon path
        /// </summary>
        public string GetTypeIcon(long typeId, TypeIconSize size) {
            const string relUri = "/InventoryType";
            const string ext = ".png";
            return requestImage(relUri, typeId, (int)size, ext);
        }

        /// <summary>
        /// Returns the type icon 
        /// </summary>
        public byte[] GetTypeIconData(long typeId, TypeIconSize size) {
            const string relUri = "/InventoryType";
            const string ext = ".png";
            return requestImageData(relUri, typeId, (int)size, ext);
        }

        /// <summary>
        /// Returns the render image path
        /// </summary>
        public string GetRender(long typeId, RenderSize size ) {
            const string relUri = "/Render";
            const string ext = ".png";
            return requestImage(relUri, typeId, (int)size, ext);
        }

        /// <summary>
        /// Returns the render image
        /// </summary>
        public byte[] GetRenderData(long typeId, RenderSize size) {
            const string relUri = "/Render";
            const string ext = ".png";
            return requestImageData(relUri, typeId, (int)size, ext);
        }

        public byte[] requestImageData(string relPath, long id, int size, string extension) {
            var fileName = id + "_" + size + extension;
            var uri = new Uri(baseUri, relPath + "\\" + fileName);
            var data = ImageRequester.RequestImageData(uri);
            return data;
        }

        public string requestImage(string relPath, long id, int size, string extension) {
            var fileName = id + "_" + size + extension;
            var uri = new Uri(baseUri, relPath + "\\" + fileName);
            var file = Configuration.FileDir + "\\" + fileName;
            ImageRequester.RequestImage(uri, file);
            return file;
        }
    }

    public interface IImageRequester {

        byte[] RequestImageData(Uri uri);

        void RequestImage(Uri uri, string file);
    }

    public class ImageRequester : IImageRequester {
        public byte[] RequestImageData(Uri uri) {
            var client = new WebClient();
            var data = client.DownloadData(uri);
            return data;
        }

        public void RequestImage(Uri uri, string file) {
            var client = new WebClient();
            client.DownloadFile(uri, file);
        }
    }

}
