// 
// ImageBuilder.cs
//  
// Author:
//       Lluis Sanchez <lluis@xamarin.com>
// 
// Copyright (c) 2012 Xamarin Inc
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Xwt;
using Xwt.Backends;
using System.Collections.Generic;


namespace Xwt.Drawing
{
	public sealed class ImageBuilder: XwtObject, IDisposable
	{
		Context ctx;
		VectorContextBackend backend;
		double width;
		double height;

		static VectorImageRecorderContextHandler vectorImageRecorderContextHandler = new VectorImageRecorderContextHandler ();
		
		public ImageBuilder (double width, double height)
		{
			backend = new VectorContextBackend ();
			ctx = new Context (backend, ToolkitEngine, vectorImageRecorderContextHandler);
			this.width = width;
			this.height = height;
		}
		
		public double Width {
			get { return width; } 
		}
		
		public double Height {
			get { return height; }
		}
		
		public void Dispose ()
		{
			ctx.Dispose ();
		}

		public Context Context {
			get {
				return ctx;
			}
		}
		
		public Image ToImage ()
		{
			return new VectorImage (new Size (width, height), backend.ToVectorImageData ());
		}
	}

}

