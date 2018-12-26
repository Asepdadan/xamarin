using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.Hardware.Camera2;

using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using App1.CustomRender;
using App1.Droid;
using CarouselView.FormsPlugin.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;



[assembly: ExportRenderer(typeof(CustomContentPageCS), typeof(CameraPageRenderer))]
namespace App1.Droid
{

    public class CameraPageRenderer : PageRenderer, TextureView.ISurfaceTextureListener
    {
        global::Android.Hardware.Camera camera;


        global::Android.Hardware.Camera2.CameraDevice.StateCallback StateCallback;
        global::Android.Hardware.Camera2.CameraManager cameraManager;
        global::Android.Hardware.Camera2.CameraCharacteristics cameraCharacteristics;
        global::Android.Hardware.Camera2.CameraAccessException accessException;
        global::Android.Hardware.Camera2.CameraCaptureSession captureSession;
        global::Android.Hardware.Camera2.CameraDevice cameraDevice;
        global::Android.Hardware.Camera2.CameraMetadata cameraMetadata;
        global::Android.Hardware.Camera2.CaptureRequest captureRequest;
        global::Android.Hardware.Camera2.TotalCaptureResult captureResult;
        global::Android.Hardware.Camera2.Params.StreamConfigurationMap configurationMap;
        global::Android.Widget.Button takePhotoButton;
        global::Android.Widget.Button toggleFlashButton;
        global::Android.Widget.Button switchCameraButton;
        global::Android.Views.View view;
        global::Android.Graphics.ImageFormat imageFormat;

        Activity activity;
        CameraFacing cameraType;
        CameraManager cameraId;
        TextureView textureView;
        SurfaceTexture surfaceTexture;
        CameraCaptureSession cameraCaptureSession;
        public List<Android.Hardware.Camera.Area> getFocusAreas;
        bool flashOn;
        Android.Hardware.Camera2.Params.StreamConfigurationMap map;

        private String cameraId2;
        protected CameraDevice cameraDevice2;
        protected CameraCaptureSession cameraCaptureSessions2;
        protected CaptureRequest captureRequest2;
        protected CaptureRequest.Builder captureRequestBuilder2;
        Thread thread;
        public Handler mHandler;
        

        public CameraPageRenderer(Context context) : base(context)
        {
            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();
            Looper.Prepare();
            mHandler = new Handler()
            {

            };

            Looper.Loop();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                SetupUserInterface();
                SetupEventHandlers();
                AddView(view);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"            ERROR: ", ex.Message);
            }
        }

        void SetupUserInterface()
        {
            activity = this.Context as Activity;
            view = activity.LayoutInflater.Inflate(Resource.Layout.CameraLayout, this, false);
            cameraType = CameraFacing.Back;


            textureView = view.FindViewById<TextureView>(Resource.Id.textureView);
            textureView.SurfaceTextureListener = this;



        }

        void SetupEventHandlers()
        {
            takePhotoButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.takePhotoButton);
            takePhotoButton.Click += TakePhotoButtonTapped;

            switchCameraButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.switchCameraButton);
            switchCameraButton.Click += SwitchCameraButtonTapped;

            toggleFlashButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.toggleFlashButton);
            toggleFlashButton.Click += ToggleFlashButtonTapped;


        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {

        }

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {


            //camera = global::Android.Hardware.Camera.Open((int)cameraType);
            //textureView.LayoutParameters = new FrameLayout.LayoutParams(width, height);
            //surfaceTexture = surface;

            //camera.SetPreviewTexture(surface);
            openCamera();
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


        private void openCamera()
        {
            CameraManager manager = (CameraManager)activity.GetSystemService(Context.CameraService);
            Log.Info("tes", "Camera Open");

            try
            {
                cameraId2 = manager.GetCameraIdList()[0];
                CameraCharacteristics characteristics = manager.GetCameraCharacteristics(cameraId2);
                Log.Info("tes", "masuk ke sini bos");
                Log.Info("tes", cameraId2);

                
                                
                //lock (mCameraStateLock)
                //{
                //    cameraId = mCameraId;
                //    backgroundHandler = mBackgroundHandler;
                //}
                //if (ActivityCompat.checkSelfPermission(this, Manifest.permission.CAMERA) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.WRITE_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED) {
                //    ActivityCompat.requestPermissions(AndroidCameraApi.this, new String[] { Manifest.permission.CAMERA, Manifest.permission.WRITE_EXTERNAL_STORAGE }, REQUEST_CAMERA_PERMISSION);
                //return;
                //}

                //if (ActivityCompat.checkSelfPermission(this, android.Manifest.permission.CAMERA)
                //    == PackageManager.PERMISSION_GRANTED)
                //{
                //    cameraManager.openCamera(cameraId, stateCallback, backgroundHandler);
                //}

                manager.OpenCamera(cameraId2, StateCallback, null);
                //openCamera(cameraId, cameraDevice, null);
            }
            catch (CameraAccessException e)
            {
                e.PrintStackTrace();
            }

            //Log.e(TAG, "openCamera X");
        }

        


        //private CameraManager getSystemService(object CameraService)
        //{
        //    throw new NotImplementedException();

        //}

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            camera.StopPreview();
            camera.Release();
            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
            PrepareAndStartCamera();
        }

        void PrepareAndStartCamera()
        {
            camera.StopPreview();

            var display = activity.WindowManager.DefaultDisplay;
            if (display.Rotation == SurfaceOrientation.Rotation0)
            {
                camera.SetDisplayOrientation(90);
            }

            if (display.Rotation == SurfaceOrientation.Rotation270)
            {
                camera.SetDisplayOrientation(180);
            }

            camera.StartPreview();

        }

        void ToggleFlashButtonTapped(object sender, EventArgs e)
        {
            flashOn = !flashOn;
            if (flashOn)
            {
                if (cameraType == CameraFacing.Back)
                {
                    toggleFlashButton.SetBackgroundResource(Resource.Drawable.FlashButton);
                    cameraType = CameraFacing.Back;

                    camera.StopPreview();
                    camera.Release();
                    camera = global::Android.Hardware.Camera.Open((int)cameraType);
                    var parameters = camera.GetParameters();
                    parameters.FlashMode = global::Android.Hardware.Camera.Parameters.FlashModeTorch;
                    camera.SetParameters(parameters);
                    camera.SetPreviewTexture(surfaceTexture);

                    PrepareAndStartCamera();

                }
            }
            else
            {
                toggleFlashButton.SetBackgroundResource(Resource.Drawable.NoFlashButton);
                camera.StopPreview();
                camera.Release();

                camera = global::Android.Hardware.Camera.Open((int)cameraType);


                var infoFocusCalibration = global::Android.Hardware.Camera2.CameraCharacteristics.LensInfoFocusDistanceCalibration;
                var infoSupportHardLevel = global::Android.Hardware.Camera2.CameraCharacteristics.InfoSupportedHardwareLevel;
                var infoMinimumFocus = global::Android.Hardware.Camera2.CameraCharacteristics.LensPoseRotation;
                var infoSensorActiveArraySize = global::Android.Hardware.Camera2.CameraCharacteristics.SensorInfoActiveArraySize;

                //var paramters2 = camera2.

                var parameters = camera.GetParameters();

                parameters.FlashMode = global::Android.Hardware.Camera.Parameters.FlashModeOff;
                parameters.FocusMode = global::Android.Hardware.Camera.Parameters.FocusModeAuto;

                camera.SetParameters(parameters);
                camera.SetPreviewTexture(surfaceTexture);
                camera.SetDisplayOrientation(100);
                var max = camera.GetParameters().MaxNumFocusAreas;

                PrepareAndStartCamera();
                camera.StartFaceDetection();

            }
        }




        void SwitchCameraButtonTapped(object sender, EventArgs e)
        {
            if (cameraType == CameraFacing.Front)
            {
                cameraType = CameraFacing.Back;

                camera.StopPreview();
                camera.Release();
                camera = global::Android.Hardware.Camera.Open((int)cameraType);
                camera.SetPreviewTexture(surfaceTexture);
                PrepareAndStartCamera();
            }
            else
            {
                cameraType = CameraFacing.Front;

                camera.StopPreview();
                camera.Release();
                camera = global::Android.Hardware.Camera.Open((int)cameraType);
                camera.SetPreviewTexture(surfaceTexture);
                PrepareAndStartCamera();
            }
        }

        async void TakePhotoButtonTapped(object sender, EventArgs e)
        {
            camera.StopPreview();

            var image = textureView.Bitmap;

            try
            {
                var absolutePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath;
                var folderPath = absolutePath + "/Camera";
                var filePath = System.IO.Path.Combine(folderPath, string.Format("photo_{0}.jpg", Guid.NewGuid()));

                var fileStream = new FileStream(filePath, FileMode.Create);
                await image.CompressAsync(Bitmap.CompressFormat.Jpeg, 50, fileStream);
                fileStream.Close();
                image.Recycle();

                var intent = new Android.Content.Intent(Android.Content.Intent.ActionMediaScannerScanFile);
                var file = new Java.IO.File(filePath);
                var uri = Android.Net.Uri.FromFile(file);
                intent.SetData(uri);
                MainActivity.Instance.SendBroadcast(intent);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"				", ex.Message);
            }

            camera.StartPreview();
        }
    }

    
}