// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.VisualBasic;

const string connectionstring = "Endpoint=sb://pkeventhubnamespace.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=gERd/Lm2oqDv62D2xEF5b0r1J7xgAJf6zOs8OD/q4Zk=";
const string eventhubname= "pkeventhub";
await using var productclient = new EventHubProducerClient(connectionstring, eventhubname);
using EventDataBatch eventbatch = await productclient.CreateBatchAsync();
eventbatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First Event")));
eventbatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second Event")));
eventbatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Third Event")));
await productclient.SendAsync(eventbatch);
Console.WriteLine("A batch of 3 event has been publish");
Console.ReadLine();
