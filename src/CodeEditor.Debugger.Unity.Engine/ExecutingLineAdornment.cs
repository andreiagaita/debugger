﻿using System;
using CodeEditor.Composition;
using CodeEditor.Text.UI.Unity.Engine;
using Mono.Debugger.Soft;
using UnityEngine;

namespace CodeEditor.Debugger.Unity.Engine
{
	[Export(typeof(ITextViewAdornment))]
	class ExecutingLineAdornment : ITextViewAdornment
	{
		private Texture2D _texture;
		private GUIStyle _text;

		[Import]
		private ExecutingLineProvider ExecutingLineProvider { get; set; }

		public ExecutingLineAdornment()
		{
			_texture = new Texture2D(1, 1);
			_texture.SetPixel(0,0,new Color(1f,.5f,.5f,.5f));
		}

		public void Draw(ITextViewLine line, Rect lineRect)
		{
			Console.WriteLine("line.LineNumber = "+line.LineNumber);
			Console.WriteLine("ExecutingLineProvider.LineNumber = " + ExecutingLineProvider.LineNumber);
			
			if (line.LineNumber == ExecutingLineProvider.LineNumber)
				Draw(lineRect);
		}

		private void Draw(Rect lineRect)
		{
			GUI.DrawTexture(lineRect,_texture, ScaleMode.StretchToFill, false);
		}
	}
}
