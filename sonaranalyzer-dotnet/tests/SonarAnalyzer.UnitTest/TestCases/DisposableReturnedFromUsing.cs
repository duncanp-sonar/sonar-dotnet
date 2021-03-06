﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests.Diagnostics
{
    public class DisposableReturnedFromUsing
    {
        public FileStream WriteToFile(string path, string text)
        {
            using (var fs = File.Create(path)) // Noncompliant {{Remove the 'using' statement; it will cause automatic disposal of 'fs'.}}
//          ^^^^^
            {
                var bytes = Encoding.UTF8.GetBytes(text);
                fs.Write(bytes, 0, bytes.Length);
                return fs;
            }
        }

        private FileStream fs;
        public FileStream WriteToFile2(string path, string text)
        {
            using (fs = File.Create(path)) // Noncompliant
            {
                var bytes = Encoding.UTF8.GetBytes(text);
                fs.Write(bytes, 0, bytes.Length);
                return fs;
            }
        }

        public FileStream WriteToFile3(string path, string text)
        {
            var fs = File.Create(path);
            var bytes = Encoding.UTF8.GetBytes(text);
            fs.Write(bytes, 0, bytes.Length);
            return fs;
        }

        public void WriteToFile4(string path, string text)
        {
            using (fs = File.Create(path))
            {
                var f = new Func<FileStream>(() =>
                {
                    return fs;
                });
                f();

                var bytes = Encoding.UTF8.GetBytes(text);
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        public FileStream Method(string path, string text)
        {
            using var fs = File.Create(path); // Compliant - FN the resource is returned already disposed

            return fs;
        }

        public ref struct Struct
        {
            public void Dispose()
            {
            }
        }

        public Struct Foo(string path, string text)
        {
            using (var disposableRefStruct = new Struct()) // Noncompliant {{Remove the 'using' statement; it will cause automatic disposal of 'disposableRefStruct'.}}
            {
                return disposableRefStruct;
            }
        }

        public Struct Bar(string path, string text)
        {
            using var disposableRefStruct = new Struct(); // Compliant - FN the resource is returned already disposed

            return disposableRefStruct;
        }
    }
}
