using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PubnubApi;
using System.Diagnostics;
using System.Threading;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace App1.Websocket
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PubNub : ContentPage
	{
        public PNConfiguration pnConfiguration = new PNConfiguration();
        public Pubnub pubnub;
        Dictionary<string, string> messages = new Dictionary<string, string>();
        public ObservableCollection<MessageChat> MyListCollector { get; set; }

        public PubNub ()
		{
			InitializeComponent ();

            MyListCollector = new ObservableCollection<MessageChat>()
            {
                new MessageChat(){
                    pesan = "ini pesan" ,
                },
            };

            BindingContext = this;
            PublishPubNub.Clicked += PublishPub;

            Console.WriteLine("Server started.");
            StartClient();

        }

        public static void StartClient()
        {
            Thread ctThread = new Thread(Chat);
            ctThread.Start();
        }

        
        public static void Chat()
        {
            PNConfiguration pnConfiguration = new PNConfiguration();
            pnConfiguration.SubscribeKey = "sub-c-d6bb8a4e-4a5d-11e6-bfbb-02ee2ddab7fe";
            pnConfiguration.PublishKey = "pub-c-c48d7308-3897-43a7-a391-50b439aa9b54";
            pnConfiguration.SecretKey = "sec-c-ODQxOTE3ZjgtNzA2YS00YWM4LTljMjktN2Y2Njc0ZDJlNzFm";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
            pnConfiguration.Uuid = "PubNubCSharpExampletesttste";
            Pubnub pubnub = new Pubnub(pnConfiguration);

            SubscribeCallbackExt subscribeCallback = new SubscribeCallbackExt(
                (pubnubObj, messageResult) => {
                    if (messageResult != null)
                    {
                        Debug.WriteLine("In Example, SusbcribeCallback received PNMessageResult");
                        Debug.WriteLine("In Example, SusbcribeCallback messsage channel = " + messageResult.Channel);
                        Debug.WriteLine("In Example, SusbcribeCallback messsage channelGroup = " + messageResult.Subscription);
                        Debug.WriteLine("In Example, SusbcribeCallback messsage publishTimetoken = " + messageResult.Timetoken);
                        Debug.WriteLine("In Example, SusbcribeCallback messsage publisher = " + messageResult.Publisher);
                        string jsonString = messageResult.Message.ToString();
                        Dictionary<string, string> msg = pubnub.JsonPluggableLibrary.DeserializeToObject<Dictionary<string, string>>(jsonString);
                        Debug.WriteLine(jsonString);
                        Debug.WriteLine(msg);

                        

                        //var testc = new PubNub();
                        //testc.MyListCollector = new ObservableCollection<MessageChat>()
                        //{
                        //    new MessageChat(){
                        //        pesan = msg.ToString() ,
                        //    },
                        //};
                    }
                },
                (pubnubObj, presencResult) => {
                    if (presencResult != null)
                    {
                        Debug.WriteLine("In Example, SusbcribeCallback received PNPresenceEventResult");
                        Debug.WriteLine(presencResult.Channel + " " + presencResult.Occupancy + " " + presencResult.Event);
                    }
                },
                (pubnubObj, statusResult) => {

                    switch (statusResult.Operation)
                    {
                        // let's combine unsubscribe and subscribe handling for ease of use
                        case PNOperationType.PNSubscribeOperation:
                        case PNOperationType.PNUnsubscribeOperation:
                            // note: subscribe statuses never have traditional
                            // errors, they just have categories to represent the
                            // different issues or successes that occur as part of subscribe
                            switch (statusResult.Category)
                            {
                                case PNStatusCategory.PNConnectedCategory:
                                    // this is expected for a subscribe, this means there is no error or issue whatsoever
                                    break;
                                case PNStatusCategory.PNReconnectedCategory:
                                    // this usually occurs if subscribe temporarily fails but reconnects. This means
                                    // there was an error but there is no longer any issue
                                    break;
                                case PNStatusCategory.PNDisconnectedCategory:
                                    // this is the expected category for an unsubscribe. This means there
                                    // was no error in unsubscribing from everything
                                    break;
                                case PNStatusCategory.PNUnexpectedDisconnectCategory:
                                    // this is usually an issue with the internet connection, this is an error, handle appropriately
                                    break;
                                case PNStatusCategory.PNAccessDeniedCategory:
                                    // this means that PAM does allow this client to subscribe to this
                                    // channel and channel group configuration. This is another explicit error
                                    break;
                                default:
                                    // More errors can be directly specified by creating explicit cases for other
                                    // error categories of `PNStatusCategory` such as `PNTimeoutCategory` or `PNMalformedFilterExpressionCategory` or `PNDecryptionErrorCategory`
                                    break;
                            }
                            break;
                        case PNOperationType.PNHeartbeatOperation:
                            // heartbeat operations can in fact have errors, so it is important to check first for an error.
                            if (statusResult.Error)
                            {
                                // There was an error with the heartbeat operation, handle here
                            }
                            else
                            {
                                // heartbeat operation was successful
                            }
                            break;
                        default:
                            // Encountered unknown status type
                            break;
                    }
                }
            );

            pubnub.AddListener(subscribeCallback);
            pubnub.Subscribe<string>()
            .ChannelGroups(new string[] {
                 // subscribe to channel groups
                "channel_group"
            })
            .Channels(new string[]{
                    "Channel-r03qex9fw"
            }).Execute();
        }

        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                // Yield the rest of the time slice.
                Thread.Sleep(0);
            }
        }


        void PublishPub(object obj, EventArgs args)
        {
            var Pesan = message.Text;
            //string[] arrayMessage = new string[] {
            //    "Asdan",
            //    "Pesan"
            //};
            var arrayMessage = new List<MessageChat> {
                new MessageChat()
                {
                    pesan = Pesan
                },
            };

            
            message.Text = "";

            pnConfiguration.SubscribeKey = "sub-c-d6bb8a4e-4a5d-11e6-bfbb-02ee2ddab7fe";
            pnConfiguration.PublishKey = "pub-c-c48d7308-3897-43a7-a391-50b439aa9b54";
            pnConfiguration.SecretKey = "sec-c-ODQxOTE3ZjgtNzA2YS00YWM4LTljMjktN2Y2Njc0ZDJlNzFm";
            pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
            pnConfiguration.Uuid = "PubNubCSharpExampletesttste";

            Pubnub pubnub = new Pubnub(pnConfiguration);

            pubnub.Publish()
                .Channel("Channel-r03qex9fw")
                .Message(arrayMessage.ToList())
                .Async(new PNPublishResultExt(
                    (result, status) => {
                        //Debug.WriteLine(result);
                    }
                ));

            var v = ChatListView.ItemsSource.Cast<object>().LastOrDefault();
            ChatListView.ScrollTo(v, ScrollToPosition.End, true);
        }

    }
}