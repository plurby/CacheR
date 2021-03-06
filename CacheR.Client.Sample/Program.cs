﻿using System;
using CacheR.Client;

namespace CacheR
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new Cache("http://localhost:91");
            cache.Connect();

            Console.WriteLine("Enter 'key=value' to add a value to the cache.");
            Console.WriteLine("Enter 'key' to retrieve a value from the cache.");

            string line = null;
            while ((line = Console.ReadLine()) != null)
            {
                var values = line.Split('=');
                if (values.Length == 2)
                {
                    string key = values[0].Trim();
                    string value = values[1].Trim();
                    cache.Add(key, value).Wait();

                    Console.WriteLine("Added '{0}' to the cache with value '{1}'.", key, value);
                }
                else
                {
                    string key = line.Trim();
                    Console.WriteLine("Value for '{0}' is " + cache.Get(key), key);
                }
            }
        }
    }
}
