﻿using System;
using HTTPbin.Common;
using HTTPbin.Core;
using HTTPbin.Infrastructure;
using static System.Console;

namespace HTTPbin.Console
{
    public class MainView : IDisplayer<string>
    {
        private readonly IQuery<HttpBinPostRequest, string> _interactor =
            new HttpBinPostInteractor(new HttpBinGateway(),
                new HttpBinResponsePresenter());

        public void Display(string value, int requestCode = 0) => Write(value);
        public void Display(Exception error) => Write(error);

        public void Start()
        {
            WriteLine("Term to post? ");
            var term = ReadLine();
            _interactor.Execute(new HttpBinPostRequest {term = term}, Write,
                Write);
            WriteLine("\nAsync operation. Press key to abort");
            ReadKey();
        }
    }
}