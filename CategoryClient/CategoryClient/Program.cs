using System;
using System.Collections.Generic;
using System.IO;
using Grpc.Core;
using Grpc.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CategoryService.Protos;
using Grpc.Net.Client;

namespace CategoryClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int id = Convert.ToInt32(Console.ReadLine());
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Shop.ShopClient(channel);
            var reply = client.GetProductById(new ProductLookup{ Id = id});
            Console.WriteLine($"{reply.Id} {reply.Name} {reply.Price}");
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
    }
}
