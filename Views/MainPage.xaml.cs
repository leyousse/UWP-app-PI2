using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.SpeechSynthesis;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Translation;
using Demoo.ViewModels;

namespace Demoo.Views
{

    public sealed partial class MainPage : Page
    {
        public VoiceInformation SelectedVoice { get; set; }
        public string TextInput { get; set; }
        private Stream stream = null;
        public MainPage()
        {
            this.InitializeComponent();
        }

        public class Question
        {
            public string id { get; set; }
            public string texte { get; set; }

        }
        private async Task TryPostJsonAsync(string jsonSerializedObj)
        {
            try
            {
                // Construct the HttpClient and Uri. This endpoint is for test purposes only.
                HttpClient httpClient = new HttpClient();
                Uri uri = new Uri("https://localhost:8080");

                // Construct the JSON to post.
                HttpStringContent content = new HttpStringContent(jsonSerializedObj);

                // Post the JSON and wait for a response.
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(
                    uri,
                    content);

                // Make sure the post succeeded, and write out the response.
                httpResponseMessage.EnsureSuccessStatusCode();
                var httpResponseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                //Debug.WriteLine(httpResponseBody);
                Debug.WriteLine("httpResponseBody");
            }
            catch (Exception ex)
            {
                // Write out any exceptions.
                Debug.WriteLine(ex);
            }
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (stream != null)
                {
                    var filePicker = new FileSavePicker()
                    {
                        CommitButtonText = "Save",
                    };
                    filePicker.FileTypeChoices.Add("wav", new List<string>() { ".wav" });
                    var file = await filePicker.PickSaveFileAsync();
                    if (file != null)
                    {
                        var _stream = await file.OpenStreamForWriteAsync();
                        await stream.CopyToAsync(_stream);
                        await _stream.FlushAsync();
                        var dlg = new MessageDialog("File saved.", Package.Current.DisplayName);
                        var cmd = await dlg.ShowAsync();
                    }
                }
            }
            catch (Exception exception)
            {
                var dlg = new MessageDialog(exception.Message, Package.Current.DisplayName);
                var cmd = await dlg.ShowAsync();
            }
        }

        private async void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var synthesizer = new Windows.Media.SpeechSynthesis.SpeechSynthesizer())
                {
                    synthesizer.Voice = SelectedVoice ?? Windows.Media.SpeechSynthesis.SpeechSynthesizer.DefaultVoice;

                    var synStream = await synthesizer.SynthesizeTextToStreamAsync(TextInput);

                    mPlayerElement.Source = MediaSource.CreateFromStream(synStream, synStream.ContentType);

                    stream = synStream.AsStream();
                    stream.Position = 0;

                    var dlg = new MessageDialog("Conversion succeeded.", Package.Current.DisplayName);
                    var cmd = await dlg.ShowAsync();
                }
            }
            catch (Exception exception)
            {
                var dlg = new MessageDialog(exception.Message, Package.Current.DisplayName);
                var cmd = await dlg.ShowAsync();
            }
        }

        private async void SpeechRecognitionFromMicrophone_ButtonClicked(object sender, RoutedEventArgs e)
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription("1c514fb1fea2465a882f0fae12242cc0", "francecentral");
            config.SpeechRecognitionLanguage = "fr-FR";

            try
            {
                // Creates a speech recognizer using microphone as audio input.
                using (var recognizer = new SpeechRecognizer(config))
                {
                    // Starts speech recognition, and returns after a single utterance is recognized. The end of a
                    // single utterance is determined by listening for silence at the end or until a maximum of 15
                    // seconds of audio is processed.  The task returns the recognition text as result.
                    // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
                    // shot recognition like command or query.
                    // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
                    var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                    // Checks result.
                    StringBuilder sb = new StringBuilder();
                    if (result.Reason == ResultReason.RecognizedSpeech)
                    {
                        sb.AppendLine($"{result.Text}");
                    }
                    else if (result.Reason == ResultReason.NoMatch)
                    {
                        sb.AppendLine($"NOMATCH: Speech could not be recognized.");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = CancellationDetails.FromResult(result);
                        sb.AppendLine($"CANCELED: Reason={cancellation.Reason}");

                        if (cancellation.Reason == CancellationReason.Error)
                        {
                            sb.AppendLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                            sb.AppendLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                            sb.AppendLine($"CANCELED: Did you update the subscription info?");
                        }
                    }

                    // Update the UI
                    NotifyUser(sb.ToString(), NotifyType.StatusMessage);

                    //Création de l'objet à séréaliser
                    Question question = new Question()
                    {
                        id = "1234",
                        texte = sb.ToString(),
                    };

                    //Séréalisation de l'objet
                    string jsonSerializedObj = JsonConvert.SerializeObject(question);

                    //Choix du local folder comme emplacement
                    //C:\Users\pauwe\AppData\Local\Packages\b6d47962-7028-4697-b1c3-c39fb3a25c97_npata57gt8602\LocalState\
                    //C:\Users\leays\AppData\Local\Packages\243E158E-1F25-44EF-90FC-68A410B06C6D_kqh4kznn2n4py\LocalState\
                    Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

                    //Création du fichier json contenant l'id de l'interlocuteur et son texte
                    Windows.Storage.StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.json",
                     Windows.Storage.CreationCollisionOption.ReplaceExisting);

                    //Ecriture dans le fichier json
                    await Windows.Storage.FileIO.WriteTextAsync(sampleFile, jsonSerializedObj);
                    //Envoi de la requête
                    await TryPostJsonAsync(jsonSerializedObj);
                }
            }
            catch (Exception ex)
            {
                NotifyUser($"Enable Microphone First.\n {ex.ToString()}", NotifyType.ErrorMessage);
            }
        }

        private enum NotifyType
        {
            StatusMessage,
            ErrorMessage
        };

        public static async Task SpeakerVerify(SpeechConfig config, VoiceProfile profile, Dictionary<string, string> profileMapping)
        {
            var speakerRecognizer = new SpeakerRecognizer(config, AudioConfig.FromDefaultMicrophoneInput());
            var model = SpeakerVerificationModel.FromProfile(profile);

            Console.WriteLine("Speak the passphrase to verify: \"My voice is my passport, please verify me.\"");
            var result = await speakerRecognizer.RecognizeOnceAsync(model);
            Console.WriteLine($"Verified voice profile for speaker {profileMapping[result.ProfileId]}, score is {result.Score}");
        }

        private async Task VerificationEnroll(SpeechConfig config, Dictionary<string, string> profileMapping)
        {

            using (var client = new VoiceProfileClient(config))
            using (var profile = await client.CreateProfileAsync(VoiceProfileType.TextDependentVerification, "en-us"))
            {
                using (var audioInput = AudioConfig.FromDefaultMicrophoneInput())
                {
                    Console.WriteLine($"Enrolling profile id {profile.Id}.");
                    // give the profile a human-readable display name
                    profileMapping.Add(profile.Id, "Your Name");

                    VoiceProfileEnrollmentResult result = null;
                    while (result is null || result.RemainingEnrollmentsCount > 0)
                    {
                        Console.WriteLine("Speak the passphrase, \"My voice is my passport, verify me.\"");
                        result = await client.EnrollProfileAsync(profile, audioInput);
                        Console.WriteLine($"Remaining enrollments needed: {result.RemainingEnrollmentsCount}");
                        Console.WriteLine("");
                    }

                    if (result.Reason == ResultReason.EnrolledVoiceProfile)
                    {
                        await SpeakerVerify(config, profile, profileMapping);
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = VoiceProfileEnrollmentCancellationDetails.FromResult(result);
                        Console.WriteLine($"CANCELED {profile.Id}: ErrorCode={cancellation.ErrorCode} ErrorDetails={cancellation.ErrorDetails}");
                    }
                }
            }
        }

        private async void VoiceRecognition(object sender, RoutedEventArgs e)
        {

            string subscriptionKey = "c06aeb4d93b24003a125aa2adef59aaa";
            string region = "francecentral";
            var config = SpeechConfig.FromSubscription(subscriptionKey, region);

            // persist profileMapping if you want to store a record of who the profile is
            var profileMapping = new Dictionary<string, string>();
            await VerificationEnroll(config, profileMapping);

            Console.ReadLine();
        }

        private void NotifyUser(string strMessage, NotifyType type)
        {
            // If called from the UI thread, then update immediately.
            // Otherwise, schedule a task on the UI thread to perform the update.
            if (Dispatcher.HasThreadAccess)
            {
                UpdateStatus(strMessage, type);
            }
            else
            {
                var task = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => UpdateStatus(strMessage, type));
            }
        }

        private void UpdateStatus(string strMessage, NotifyType type)
        {
            switch (type)
            {
                case NotifyType.StatusMessage:
                    StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    break;
                case NotifyType.ErrorMessage:
                    StatusBorder.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;
            }
            StatusBlock.Text += string.IsNullOrEmpty(StatusBlock.Text) ? strMessage : "\n" + strMessage;

            // Collapse the StatusBlock if it has no text to conserve real estate.
            StatusBorder.Visibility = !string.IsNullOrEmpty(StatusBlock.Text) ? Visibility.Visible : Visibility.Collapsed;
            if (!string.IsNullOrEmpty(StatusBlock.Text))
            {
                StatusBorder.Visibility = Visibility.Visible;
                StatusPanel.Visibility = Visibility.Visible;
            }
            else
            {
                StatusBorder.Visibility = Visibility.Collapsed;
                StatusPanel.Visibility = Visibility.Collapsed;
            }
            // Raise an event if necessary to enable a screen reader to announce the status update.
            var peer = Windows.UI.Xaml.Automation.Peers.FrameworkElementAutomationPeer.FromElement(StatusBlock);
            if (peer != null)
            {
                peer.RaiseAutomationEvent(Windows.UI.Xaml.Automation.Peers.AutomationEvents.LiveRegionChanged);
            }
        }

    }

}
