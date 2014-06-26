﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageFactoryUnitTests.cs" company="James South">
//   Copyright (c) James South.
//   Licensed under the Apache License, Version 2.0.
// </copyright>
// <summary>
//   Unit tests for the ImageFactory (loading of images)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageProcessor.UnitTests
{
    using System;
    using System.IO;
    using NUnit.Framework;

    /// <summary>
    /// Test harness for the image factory
    /// </summary>
    [TestFixture]
    public class ImageFactoryUnitTests
    {
        /// <summary>
        /// The path to the binary's folder
        /// </summary>
        private readonly string localPath = Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);

        /// <summary>
        /// Tests the loading of image from a file
        /// </summary>
        /// <param name="fileName">
        /// The file Name.
        /// </param>
        /// <param name="expectedMime">
        /// The expected mime type.
        /// </param>
        [Test]
        [TestCase("Chrysanthemum.jpg", "image/jpeg")]
        [TestCase("Desert.jpg", "image/jpeg")]
        [TestCase("cmyk.png", "image/png")]
        [TestCase("Penguins.bmp", "image/bmp")]
        [TestCase("Penguins.gif", "image/gif")]
        public void TestLoadImageFromFile(string fileName, string expectedMime)
        {
            string testPhoto = Path.Combine(this.localPath, string.Format("../../Images/{0}", fileName));
            using (ImageFactory imageFactory = new ImageFactory())
            {
                imageFactory.Load(testPhoto);
                Assert.AreEqual(testPhoto, imageFactory.ImagePath);
                Assert.AreEqual(expectedMime, imageFactory.CurrentImageFormat.MimeType);
                Assert.IsNotNull(imageFactory.Image);
            }
        }
    }
}