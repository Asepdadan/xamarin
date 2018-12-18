using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PubnubApi;
using System.Diagnostics;

namespace App1.Websocket
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PubNub : ContentPage
	{
        PNConfiguration pnConfiguration = new PNConfiguration();

        public PubNub ()
		{
			InitializeComponent ();


            pnConfiguration.SubscribeKey = "sub-c-2db0981c-dcbf-11e8-89fc-d641165b92ba";
            pnConfiguration.PublishKey = "pub-c-232f7c9d-224d-4094-8810-3a164fa25481";
            pnConfiguration.SecretKey = "sec-c-ZTg3MzkzNzMtNWI5Mi00NTcwLWE4M2EtZWM5ZDViYzAyZGZm";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
            pnConfiguration.Uuid = "PubNubCSharpExample";

            Dictionary<string, string> message = new Dictionary<string, string>();
            message.Add("msg", "hello");

            Pubnub pubnub = new Pubnub(pnConfiguration);

            SubscribeCallbackExt subscribeCallback = new SubscribeCallbackExt(
                (pubnubObj, messageResult) =>
                {
                    if (messageResult != null)
                    {
                        Debug.WriteLine("In Example, SusbcribeCallback received PNMessageResult");
                        Debug.WriteLine("In Example, SusbcribeCallback messsage channel = " + messageResult.Channel);
                        Debug.WriteLine("In Example, SusbcribeCallback messsage channelGroup = " + messageResult.Subscription);
                        Debug.WriteLine("In Example, SusbcribeCallback messsage publishTimetoken = " + messageResult.Timetoken);
                        Debug.WriteLine("In Example, SusbcribeCallback messsage publisher = " + messageResult.Publisher);
                        string jsonString = messageResult.Message.ToString();
                        Dictionary<string, string> msg = pubnub.JsonPluggableLibrary.DeserializeToObject<Dictionary<string, string>>(jsonString);
                        Debug.WriteLine("msg: " + msg["msg"]);
                    }
                },
                (pubnubObj, presencResult) =>
                {
                    if (presencResult != null)
                    {
                        Debug.WriteLine("In Example, SusbcribeCallback received PNPresenceEventResult");
                        Debug.WriteLine(presencResult.Channel + " " + presencResult.Occupancy + " " + presencResult.Event);
                    }
                },
                (pubnubObj, statusResult) =>
                {
                    if (statusResult.Category == PNStatusCategory.PNConnectedCategory)
                    {
                        pubnub.Publish()
                        .Channel("my_channel")
                        .Message(message)
                        .Async(new PNPublishResultExt((publishResult, publishStatus) =>
                        {
                            if (!publishStatus.Error)
                            {
                                Debug.WriteLine(string.Format("DateTime {0}, In Publish Example, Timetoken: {1}", DateTime.UtcNow, publishResult.Timetoken));
                            }
                            else
                            {
                                Debug.WriteLine(publishStatus.Error);
                                Debug.WriteLine(publishStatus.ErrorData.Information);
                            }
                        }));
                    }
                }
            );

            pubnub.AddListener(subscribeCallback);

            pubnub.Subscribe<string>()
                .Channels(new string[]{
            "Channel-r03qex9fw"
                }).Execute();

            PublishPubNub.Clicked += PublishPub;

        }

        void PublishPub(object obj, EventArgs args)
        {
            var Pesan = message.Text;
            string[] arrayMessage = new string[] {
               Pesan
            };

            pnConfiguration.SubscribeKey = "sub-c-d6bb8a4e-4a5d-11e6-bfbb-02ee2ddab7fe";
            pnConfiguration.PublishKey = "pub-c-c48d7308-3897-43a7-a391-50b439aa9b54";
            pnConfiguration.SecretKey = "sec-c-ODQxOTE3ZjgtNzA2YS00YWM4LTljMjktN2Y2Njc0ZDJlNzFm";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
            pnConfiguration.Uuid = "PubNubCSharpExampletest";

            Pubnub pubnub = new Pubnub(pnConfiguration);            

            pubnub.Publish()
                .Channel("Channel-r03qex9fw")
                .Message(arrayMessage.ToList())
                .Async(new PNPublishResultExt(
                    (result, status) => {
                        Debug.WriteLine(status);
                        
                    }
                ));

            Debug.WriteLine("hello bos");
        }

    }
}