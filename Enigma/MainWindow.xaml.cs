using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace Enigma
{
    public partial class MainWindow : Window
    {
        // This variable tracks whether the "Set" button has been clicked
        public static bool btnSetIsClicked = false;
        
        // SolidColorBrush instances for controlling colors
        SolidColorBrush outputColor = new SolidColorBrush();
        SolidColorBrush originalColor = new SolidColorBrush();
        SolidColorBrush labelOutputColor = new SolidColorBrush();
        SolidColorBrush labelOriginalColor = new SolidColorBrush();
        
        // Arrays for storing labels and ellipses
        Label[] keyLabels = new Label[93];
        Ellipse[] key = new Ellipse[93];
        
        // A dictionary to associate keyboard keys with ellipses
        private Dictionary<Key, Ellipse> keyEllipseDictionary = new Dictionary<Key, Ellipse>();

        public MainWindow() // This method has the arrays and the dictionary inside it
        {
            InitializeComponent();

            keyEllipseDictionary[Key.A] = ell40;
            keyEllipseDictionary[Key.B] = ell60;
            keyEllipseDictionary[Key.C] = ell58;
            keyEllipseDictionary[Key.D] = ell42;
            keyEllipseDictionary[Key.E] = ell23;
            keyEllipseDictionary[Key.F] = ell43;
            keyEllipseDictionary[Key.G] = ell44;
            keyEllipseDictionary[Key.H] = ell45;
            keyEllipseDictionary[Key.I] = ell28;
            keyEllipseDictionary[Key.J] = ell46;
            keyEllipseDictionary[Key.K] = ell47;
            keyEllipseDictionary[Key.L] = ell48;
            keyEllipseDictionary[Key.M] = ell62;
            keyEllipseDictionary[Key.N] = ell61;
            keyEllipseDictionary[Key.O] = ell29;
            keyEllipseDictionary[Key.P] = ell30;
            keyEllipseDictionary[Key.Q] = ell21;
            keyEllipseDictionary[Key.R] = ell24;
            keyEllipseDictionary[Key.S] = ell41;
            keyEllipseDictionary[Key.T] = ell25;
            keyEllipseDictionary[Key.U] = ell27;
            keyEllipseDictionary[Key.V] = ell59;
            keyEllipseDictionary[Key.W] = ell22;
            keyEllipseDictionary[Key.X] = ell57;
            keyEllipseDictionary[Key.Y] = ell26;
            keyEllipseDictionary[Key.Z] = ell56;
            keyEllipseDictionary[Key.D1] = ell84;
            keyEllipseDictionary[Key.D2] = ell85;
            keyEllipseDictionary[Key.D3] = ell86;
            keyEllipseDictionary[Key.D4] = ell87;
            keyEllipseDictionary[Key.D5] = ell88;
            keyEllipseDictionary[Key.D6] = ell89;
            keyEllipseDictionary[Key.D7] = ell90;
            keyEllipseDictionary[Key.D8] = ell91;
            keyEllipseDictionary[Key.D9] = ell92;
            keyEllipseDictionary[Key.D0] = ell93;
            keyEllipseDictionary[Key.Subtract] = ell64;
            keyEllipseDictionary[Key.OemPlus] = ell65;
            keyEllipseDictionary[Key.Oem4] = ell71;
            keyEllipseDictionary[Key.Oem6] = ell72;
            keyEllipseDictionary[Key.Oem5] = ell73;
            keyEllipseDictionary[Key.Oem1] = ell75;
            keyEllipseDictionary[Key.OemQuotes] = ell82;
            keyEllipseDictionary[Key.OemComma] = ell79;
            keyEllipseDictionary[Key.OemPeriod] = ell80;
            keyEllipseDictionary[Key.Oem2] = ell81;

            outputColor.Color = Color.FromRgb(3, 252,240);
            originalColor.Color = Color.FromRgb(79, 79, 79);
            labelOutputColor.Color = Color.FromRgb(0, 0, 0);
            labelOriginalColor.Color = Color.FromRgb(255, 255, 255);

            key[0] = ellipse1;
            key[1] = ellipse2;
            key[2] = ellipse3;
            key[3] = ellipse4;
            key[4] = ellipse5;
            key[5] = ellipse6;
            key[6] = ellipse7;
            key[7] = ellipse8;
            key[8] = ellipse9;
            key[9] = ellipse10;
            key[10] = ellipse11;
            key[11] = ellipse12;
            key[12] = ellipse13;
            key[13] = ellipse14;
            key[14] = ellipse15;
            key[15] = ellipse16;
            key[16] = ellipse17;
            key[17] = ellipse18;
            key[18] = ellipse19;
            key[19] = ellipse20;
            key[20] = ellipse21;
            key[21] = ellipse22;
            key[22] = ellipse23;
            key[23] = ellipse24;
            key[24] = ellipse25;
            key[25] = ellipse26;
            key[26] = ellipse27;
            key[27] = ellipse28;
            key[28] = ellipse29;
            key[29] = ellipse30;
            key[30] = ellipse31;
            key[31] = ellipse32;
            key[32] = ellipse33;
            key[33] = ellipse34;
            key[34] = ellipse35;
            key[35] = ellipse36;
            key[36] = ellipse37;
            key[37] = ellipse38;
            key[38] = ellipse39;
            key[39] = ellipse40;
            key[40] = ellipse41;
            key[41] = ellipse42;
            key[42] = ellipse43;
            key[43] = ellipse44;
            key[44] = ellipse45;
            key[45] = ellipse46;
            key[46] = ellipse47;
            key[47] = ellipse48;
            key[48] = ellipse49;
            key[49] = ellipse50;
            key[50] = ellipse51;
            key[51] = ellipse52;
            key[52] = ellipse53;
            key[53] = ellipse54;
            key[54] = ellipse55;
            key[55] = ellipse56;
            key[56] = ellipse57;
            key[57] = ellipse58;
            key[58] = ellipse59;
            key[59] = ellipse60;
            key[60] = ellipse61;
            key[61] = ellipse62;
            key[62] = ellipse63;
            key[63] = ellipse64;
            key[64] = ellipse65;
            key[65] = ellipse66;
            key[66] = ellipse67;
            key[67] = ellipse68;
            key[68] = ellipse69;
            key[69] = ellipse70;
            key[70] = ellipse71;
            key[71] = ellipse72;
            key[72] = ellipse73;
            key[73] = ellipse74;
            key[74] = ellipse75;
            key[75] = ellipse76;
            key[76] = ellipse77;
            key[77] = ellipse78;
            key[78] = ellipse79;
            key[79] = ellipse80;
            key[80] = ellipse81;
            key[81] = ellipse82;
            key[82] = ellipse83;
            key[83] = ellipse84;
            key[84] = ellipse85;
            key[85] = ellipse86;
            key[86] = ellipse87;
            key[87] = ellipse88;
            key[88] = ellipse89;
            key[89] = ellipse90;
            key[90] = ellipse91;
            key[91] = ellipse92;
            key[92] = ellipse93;
            
            keyLabels[0] = lbl1;
            keyLabels[1] = lbl2;
            keyLabels[2] = lbl3;
            keyLabels[3] = lbl4;
            keyLabels[4] = lbl5;
            keyLabels[5] = lbl6;
            keyLabels[6] = lbl7;
            keyLabels[7] = lbl8;
            keyLabels[8] = lbl9;
            keyLabels[9] = lbl10;
            keyLabels[10] = lbl11;
            keyLabels[11] = lbl12;
            keyLabels[12] = lbl13;
            keyLabels[13] = lbl14;
            keyLabels[14] = lbl15;
            keyLabels[15] = lbl16;
            keyLabels[16] = lbl17;
            keyLabels[17] = lbl18;
            keyLabels[18] = lbl19;
            keyLabels[19] = lbl20;
            keyLabels[20] = lbl21;
            keyLabels[21] = lbl22;
            keyLabels[22] = lbl23;
            keyLabels[23] = lbl24;
            keyLabels[24] = lbl25;
            keyLabels[25] = lbl26;
            keyLabels[26] = lbl27;
            keyLabels[27] = lbl28;
            keyLabels[28] = lbl29;
            keyLabels[29] = lbl30;
            keyLabels[30] = lbl31;
            keyLabels[31] = lbl32;
            keyLabels[32] = lbl33;
            keyLabels[33] = lbl34;
            keyLabels[34] = lbl35;
            keyLabels[35] = lbl36;
            keyLabels[36] = lbl37;
            keyLabels[37] = lbl38;
            keyLabels[38] = lbl39;
            keyLabels[39] = lbl40;
            keyLabels[40] = lbl41;
            keyLabels[41] = lbl42;
            keyLabels[42] = lbl43;
            keyLabels[43] = lbl44;
            keyLabels[44] = lbl45;
            keyLabels[45] = lbl46;
            keyLabels[46] = lbl47;
            keyLabels[47] = lbl48;
            keyLabels[48] = lbl49;
            keyLabels[49] = lbl50;
            keyLabels[50] = lbl51;
            keyLabels[51] = lbl52;
            keyLabels[52] = lbl53;
            keyLabels[53] = lbl54;
            keyLabels[54] = lbl55;
            keyLabels[55] = lbl56;
            keyLabels[56] = lbl57;
            keyLabels[57] = lbl58;
            keyLabels[58] = lbl59;
            keyLabels[59] = lbl60;
            keyLabels[60] = lbl61;
            keyLabels[61] = lbl62;
            keyLabels[62] = lbl63;
            keyLabels[63] = lbl64;
            keyLabels[64] = lbl65;
            keyLabels[65] = lbl66;
            keyLabels[66] = lbl67;
            keyLabels[67] = lbl68;
            keyLabels[68] = lbl69;
            keyLabels[69] = lbl70;
            keyLabels[70] = lbl71;
            keyLabels[71] = lbl72;
            keyLabels[72] = lbl73;
            keyLabels[73] = lbl74;
            keyLabels[74] = lbl75;
            keyLabels[75] = lbl76;
            keyLabels[76] = lbl77;
            keyLabels[77] = lbl78;
            keyLabels[78] = lbl79;
            keyLabels[79] = lbl80;
            keyLabels[80] = lbl81;
            keyLabels[81] = lbl82;
            keyLabels[82] = lbl83;
            keyLabels[83] = lbl84;
            keyLabels[84] = lbl85;
            keyLabels[85] = lbl86;
            keyLabels[86] = lbl87;
            keyLabels[87] = lbl88;
            keyLabels[88] = lbl89;
            keyLabels[89] = lbl90;
            keyLabels[90] = lbl91;
            keyLabels[91] = lbl92;
            keyLabels[92] = lbl93;
        }


        void ringSelectorChecker()
        {
            // Check if any of the ring selections are the same.
            if (Settings.ringSelection[0] == Settings.ringSelection[1] || Settings.ringSelection[1] == Settings.ringSelection[2] || Settings.ringSelection[0] == Settings.ringSelection[2])
            {
                // If there's a conflict in ring selection, disable certain controls.
                btnPlusSeconds2.IsEnabled = false;
                btnPlusMinutes2.IsEnabled = false;
                btnPlusHours2.IsEnabled = false;
                btnMinusSeconds2.IsEnabled = false;
                btnMinusMinutes2.IsEnabled = false;
                btnMinusHours2.IsEnabled = false;
                btnSet.IsEnabled = false;
            }
            else
            {
                // If there's no conflict in ring selection, enable the controls.
                btnPlusSeconds2.IsEnabled = true;
                btnPlusMinutes2.IsEnabled = true;
                btnPlusHours2.IsEnabled = true;
                btnMinusSeconds2.IsEnabled = true;
                btnMinusMinutes2.IsEnabled = true;
                btnMinusHours2.IsEnabled = true;
                btnSet.IsEnabled = true;
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnSetIsClicked)
            {
                bool isCapsLockOn = Console.CapsLock;
                if (e.KeyboardDevice.Modifiers == ModifierKeys.Shift || isCapsLockOn)
                {
                    switch (e.Key)
                    {
                        case Key.A:
                            tbxInput.Text += 'A';
                            tbxOutput.Text += Settings.encrypted('A');
                            keyLightUp();
                            break;
                        case Key.B:
                            tbxInput.Text += 'B';
                            tbxOutput.Text += Settings.encrypted('B');
                            keyLightUp();
                            break;
                        case Key.C:
                            tbxInput.Text += 'C';
                            tbxOutput.Text += Settings.encrypted('C');
                            keyLightUp();
                            break;
                        case Key.D:
                            tbxInput.Text += 'D';
                            tbxOutput.Text += Settings.encrypted('D');
                            keyLightUp();
                            break;
                        case Key.E:
                            tbxInput.Text += 'E';
                            tbxOutput.Text += Settings.encrypted('E');
                            keyLightUp();
                            break;
                        case Key.F:
                            tbxInput.Text += 'F';
                            tbxOutput.Text += Settings.encrypted('F');
                            keyLightUp();
                            break;
                        case Key.G:
                            tbxInput.Text += 'G';
                            tbxOutput.Text += Settings.encrypted('G');
                            keyLightUp();
                            break;
                        case Key.H:
                            tbxInput.Text += 'H';
                            tbxOutput.Text += Settings.encrypted('H');
                            keyLightUp();
                            break;
                        case Key.I:
                            tbxInput.Text += 'I';
                            tbxOutput.Text += Settings.encrypted('I');
                            keyLightUp();
                            break;
                        case Key.J:
                            tbxInput.Text += 'J';
                            tbxOutput.Text += Settings.encrypted('J');
                            keyLightUp();
                            break;
                        case Key.K:
                            tbxInput.Text += 'K';
                            tbxOutput.Text += Settings.encrypted('K');
                            keyLightUp();
                            break;
                        case Key.L:
                            tbxInput.Text += 'L';
                            tbxOutput.Text += Settings.encrypted('L');
                            keyLightUp();
                            break;
                        case Key.M:
                            tbxInput.Text += 'M';
                            tbxOutput.Text += Settings.encrypted('M');
                            keyLightUp();
                            break;
                        case Key.N:
                            tbxInput.Text += 'N';
                            tbxOutput.Text += Settings.encrypted('N');
                            keyLightUp();
                            break;
                        case Key.O:
                            tbxInput.Text += 'O';
                            tbxOutput.Text += Settings.encrypted('O');
                            keyLightUp();
                            break;
                        case Key.P:
                            tbxInput.Text += 'P';
                            tbxOutput.Text += Settings.encrypted('P');
                            keyLightUp();
                            break;
                        case Key.Q:
                            tbxInput.Text += 'Q';
                            tbxOutput.Text += Settings.encrypted('Q');
                            keyLightUp();
                            break;
                        case Key.R:
                            tbxInput.Text += 'R';
                            tbxOutput.Text += Settings.encrypted('R');
                            keyLightUp();
                            break;
                        case Key.S:
                            tbxInput.Text += 'S';
                            tbxOutput.Text += Settings.encrypted('S');
                            keyLightUp();
                            break;
                        case Key.T:
                            tbxInput.Text += 'T';
                            tbxOutput.Text += Settings.encrypted('T');
                            keyLightUp();
                            break;
                        case Key.U:
                            tbxInput.Text += 'U';
                            tbxOutput.Text += Settings.encrypted('U');
                            keyLightUp();
                            break;
                        case Key.V:
                            tbxInput.Text += 'V';
                            tbxOutput.Text += Settings.encrypted('V');
                            keyLightUp();
                            break;
                        case Key.W:
                            tbxInput.Text += 'W';
                            tbxOutput.Text += Settings.encrypted('W');
                            keyLightUp();
                            break;
                        case Key.X:
                            tbxInput.Text += 'X';
                            tbxOutput.Text += Settings.encrypted('X');
                            keyLightUp();
                            break;
                        case Key.Y:
                            tbxInput.Text += 'Y';
                            tbxOutput.Text += Settings.encrypted('Y');
                            keyLightUp();
                            break;
                        case Key.Z:
                            tbxInput.Text += 'Z';
                            tbxOutput.Text += Settings.encrypted('Z');
                            keyLightUp();
                            break;
                        case Key.D0:
                            tbxInput.Text += ')';
                            tbxOutput.Text += Settings.encrypted(')');
                            keyLightUp();
                            break;
                        case Key.D1:
                            tbxInput.Text += '!';
                            tbxOutput.Text += Settings.encrypted('!');
                            keyLightUp();
                            break;
                        case Key.D2:
                            tbxInput.Text += '@';
                            tbxOutput.Text += Settings.encrypted('@');
                            keyLightUp();
                            break;
                        case Key.D3:
                            tbxInput.Text += '#';
                            tbxOutput.Text += Settings.encrypted('#');
                            keyLightUp();
                            break;
                        case Key.D4:
                            tbxInput.Text += '$';
                            tbxOutput.Text += Settings.encrypted('$');
                            keyLightUp();
                            break;
                        case Key.D5:
                            tbxInput.Text += '%';
                            tbxOutput.Text += Settings.encrypted('%');
                            keyLightUp();
                            break;
                        case Key.D6:
                            tbxInput.Text += '^';
                            tbxOutput.Text += Settings.encrypted('^');
                            keyLightUp();
                            break;
                        case Key.D7:
                            tbxInput.Text += '&';
                            tbxOutput.Text += Settings.encrypted('&');
                            keyLightUp();
                            break;
                        case Key.D8:
                            tbxInput.Text += '*';
                            tbxOutput.Text += Settings.encrypted('*');
                            keyLightUp();
                            break;
                        case Key.D9:
                            tbxInput.Text += '(';
                            tbxOutput.Text += Settings.encrypted('(');
                            keyLightUp();
                            break;
                        case Key.Oem1:
                            tbxInput.Text += ':';
                            tbxOutput.Text += Settings.encrypted(':');
                            keyLightUp();
                            break;
                        case Key.Oem2:
                            tbxInput.Text += '?';
                            tbxOutput.Text += Settings.encrypted('?');
                            keyLightUp();
                            break;
                        case Key.Oem4:
                            tbxInput.Text += '{';
                            tbxOutput.Text += Settings.encrypted('{');
                            keyLightUp();
                            break;
                        case Key.Oem5:
                            tbxInput.Text += '|';
                            tbxOutput.Text += Settings.encrypted('|');
                            keyLightUp();
                            break;
                        case Key.Oem6:
                            tbxInput.Text += '}';
                            tbxOutput.Text += Settings.encrypted('}');
                            keyLightUp();
                            break;
                        case Key.OemComma:
                            tbxInput.Text += '<';
                            tbxOutput.Text += Settings.encrypted('<');
                            keyLightUp();
                            break;
                        case Key.OemPeriod:
                            tbxInput.Text += '>';
                            tbxOutput.Text += Settings.encrypted('>');
                            keyLightUp();
                            break;
                        case Key.OemMinus:
                            tbxInput.Text += '_';
                            tbxOutput.Text += Settings.encrypted('_');
                            keyLightUp();
                            break;
                        case Key.OemPlus:
                            tbxInput.Text += '+';
                            tbxOutput.Text += Settings.encrypted('+');
                            keyLightUp();
                            break;
                        case Key.OemQuotes:
                            tbxInput.Text += '"';
                            tbxOutput.Text += Settings.encrypted('"');
                            keyLightUp();
                            break;
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Key.A:
                            tbxInput.Text += 'a';
                            tbxOutput.Text += Settings.encrypted('a');
                            keyLightUp();
                            break;
                        case Key.B:
                            tbxInput.Text += 'b';
                            tbxOutput.Text += Settings.encrypted('b');
                            keyLightUp();
                            break;
                        case Key.C:
                            tbxInput.Text += 'c';
                            tbxOutput.Text += Settings.encrypted('c');
                            keyLightUp();
                            break;
                        case Key.D:
                            tbxInput.Text += 'd';
                            tbxOutput.Text += Settings.encrypted('d');
                            keyLightUp();
                            break;
                        case Key.E:
                            tbxInput.Text += 'e';
                            tbxOutput.Text += Settings.encrypted('e');
                            keyLightUp();
                            break;
                        case Key.F:
                            tbxInput.Text += 'f';
                            tbxOutput.Text += Settings.encrypted('f');
                            keyLightUp();
                            break;
                        case Key.G:
                            tbxInput.Text += 'g';
                            tbxOutput.Text += Settings.encrypted('g');
                            keyLightUp();
                            break;
                        case Key.H:
                            tbxInput.Text += 'h';
                            tbxOutput.Text += Settings.encrypted('h');
                            keyLightUp();
                            break;
                        case Key.I:
                            tbxInput.Text += 'i';
                            tbxOutput.Text += Settings.encrypted('i');
                            keyLightUp();
                            break;
                        case Key.J:
                            tbxInput.Text += 'j';
                            tbxOutput.Text += Settings.encrypted('j');
                            keyLightUp();
                            break;
                        case Key.K:
                            tbxInput.Text += 'k';
                            tbxOutput.Text += Settings.encrypted('k');
                            keyLightUp();
                            break;
                        case Key.L:
                            tbxInput.Text += 'l';
                            tbxOutput.Text += Settings.encrypted('l');
                            keyLightUp();
                            break;
                        case Key.M:
                            tbxInput.Text += 'm';
                            tbxOutput.Text += Settings.encrypted('m');
                            keyLightUp();
                            break;
                        case Key.N:
                            tbxInput.Text += 'n';
                            tbxOutput.Text += Settings.encrypted('n');
                            keyLightUp();
                            break;
                        case Key.O:
                            tbxInput.Text += 'o';
                            tbxOutput.Text += Settings.encrypted('o');
                            keyLightUp();
                            break;
                        case Key.P:
                            tbxInput.Text += 'p';
                            tbxOutput.Text += Settings.encrypted('p');
                            keyLightUp();
                            break;
                        case Key.Q:
                            tbxInput.Text += 'q';
                            tbxOutput.Text += Settings.encrypted('q');
                            keyLightUp();
                            break;
                        case Key.R:
                            tbxInput.Text += 'r';
                            tbxOutput.Text += Settings.encrypted('r');
                            keyLightUp();
                            break;
                        case Key.S:
                            tbxInput.Text += 's';
                            tbxOutput.Text += Settings.encrypted('s');
                            keyLightUp();
                            break;
                        case Key.T:
                            tbxInput.Text += 't';
                            tbxOutput.Text += Settings.encrypted('t');
                            keyLightUp();
                            break;
                        case Key.U:
                            tbxInput.Text += 'u';
                            tbxOutput.Text += Settings.encrypted('u');
                            keyLightUp();
                            break;
                        case Key.V:
                            tbxInput.Text += 'v';
                            tbxOutput.Text += Settings.encrypted('v');
                            keyLightUp();
                            break;
                        case Key.W:
                            tbxInput.Text += 'w';
                            tbxOutput.Text += Settings.encrypted('w');
                            keyLightUp();
                            break;
                        case Key.X:
                            tbxInput.Text += 'x';
                            tbxOutput.Text += Settings.encrypted('x');
                            keyLightUp();
                            break;
                        case Key.Y:
                            tbxInput.Text += 'y';
                            tbxOutput.Text += Settings.encrypted('y');
                            keyLightUp();
                            break;
                        case Key.Z:
                            tbxInput.Text += 'z';
                            tbxOutput.Text += Settings.encrypted('z');
                            keyLightUp();
                            break;
                        case Key.Oem1:
                            tbxInput.Text += ';';
                            tbxOutput.Text += Settings.encrypted(';');
                            keyLightUp();
                            break;
                        case Key.Divide:
                        case Key.Oem2:
                            tbxInput.Text += '/';
                            tbxOutput.Text += Settings.encrypted('/');
                            keyLightUp();
                            break;
                        case Key.Oem4:
                            tbxInput.Text += '[';
                            tbxOutput.Text += Settings.encrypted('[');
                            keyLightUp();
                            break;
                        case Key.Oem5:
                            tbxInput.Text += '\\';
                            tbxOutput.Text += Settings.encrypted('\\');
                            keyLightUp();
                            break;
                        case Key.Oem6:
                            tbxInput.Text += ']';
                            tbxOutput.Text += Settings.encrypted(']');
                            keyLightUp();
                            break;
                        case Key.OemComma:
                            tbxInput.Text += ',';
                            tbxOutput.Text += Settings.encrypted(',');
                            keyLightUp();
                            break;
                        case Key.OemPeriod:
                        case Key.Decimal:
                            tbxInput.Text += '.';
                            tbxOutput.Text += Settings.encrypted('.');
                            keyLightUp();
                            break;
                        case Key.Subtract:
                        case Key.OemMinus:
                            tbxInput.Text += '-';
                            tbxOutput.Text += Settings.encrypted('-');
                            keyLightUp();
                            break;
                        case Key.OemPlus:
                            tbxInput.Text += '=';
                            tbxOutput.Text += Settings.encrypted('=');
                            keyLightUp();
                            break;
                        case Key.Add:
                            tbxInput.Text += '+';
                            tbxOutput.Text += Settings.encrypted('+');
                            keyLightUp();
                            break;
                        case Key.Multiply:
                            tbxInput.Text += '*';
                            tbxOutput.Text += Settings.encrypted('*');
                            keyLightUp();
                            break;
                        case Key.Oem7:
                            tbxInput.Text += '\'';
                            tbxOutput.Text += Settings.encrypted('\'');
                            keyLightUp();
                            break;
                        case Key.D1:
                            tbxInput.Text += '1';
                            tbxOutput.Text += Settings.encrypted('1');
                            keyLightUp();
                            break;
                        case Key.D2:
                            tbxInput.Text += '2';
                            tbxOutput.Text += Settings.encrypted('2');
                            keyLightUp();
                            break;
                        case Key.D3:
                            tbxInput.Text += '3';
                            tbxOutput.Text += Settings.encrypted('3');
                            keyLightUp();
                            break;
                        case Key.D4:
                            tbxInput.Text += '4';
                            tbxOutput.Text += Settings.encrypted('4');
                            keyLightUp();
                            break;
                        case Key.D5:
                            tbxInput.Text += '5';
                            tbxOutput.Text += Settings.encrypted('5');
                            keyLightUp();
                            break;
                        case Key.D6:
                            tbxInput.Text += '6';
                            tbxOutput.Text += Settings.encrypted('6');
                            keyLightUp();
                            break;
                        case Key.D7:
                            tbxInput.Text += '7';
                            tbxOutput.Text += Settings.encrypted('7');
                            keyLightUp();
                            break;
                        case Key.D8:
                            tbxInput.Text += '8';
                            tbxOutput.Text += Settings.encrypted('8');
                            keyLightUp();
                            break;
                        case Key.D9:
                            tbxInput.Text += '9';
                            tbxOutput.Text += Settings.encrypted('9');
                            keyLightUp();
                            break;
                        case Key.D0:
                            tbxInput.Text += '0';
                            tbxOutput.Text += Settings.encrypted('0');
                            keyLightUp();
                            break;
                    }
                }
            }
            // Check if the pressed key is in the dictionary
            if (keyEllipseDictionary.TryGetValue(e.Key, out Ellipse ell))
            {
                ell.Fill = new SolidColorBrush(Colors.Cyan);
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is in the dictionary
            if (keyEllipseDictionary.TryGetValue(e.Key, out Ellipse ell))
            {
                ell.Fill = new SolidColorBrush(Colors.DarkRed);
            }

            // Check if the Enigma machine configuration has been set
            if (btnSetIsClicked)
            {
                // Determine the action based on the pressed key
                switch (e.Key)
                {
                    case Key.Enter:
                        // Handle the Enter key: input a newline character and update text boxes
                        Settings.inputTextbox('\n');
                        Settings.textboxOutput.Add('\n');
                        tbxInput.Text += '\n';
                        tbxOutput.Text += '\n';
                        // Reset the color of Ellipse buttons and their labels
                        for (int x = 0; x < key.Length; x++)
                        {
                            key[x].Fill = originalColor;
                            keyLabels[x].Foreground = labelOriginalColor;
                        }
                        break;
                    case Key.Tab:
                        // Handle the Tab key: input a tab character and update text boxes
                        Settings.inputTextbox('\t');
                        Settings.textboxOutput.Add('\t');
                        tbxInput.Text += '\t';
                        tbxOutput.Text += '\t';
                        // Reset the color of Ellipse buttons and their labels
                        for (int x = 0; x < key.Length; x++)
                        {
                            key[x].Fill = originalColor;
                            keyLabels[x].Foreground = labelOriginalColor;
                        }
                        break;
                    case Key.Space:
                        // Handle the Space key: input a space character and update the text box, then light up Ellipse buttons
                        tbxInput.Text += ' ';
                        tbxOutput.Text += Settings.encrypted(' ');
                        keyLightUp();
                        break;
                    case Key.Back:
                        // Handle the Backspace key
                        if (tbxInput.Text.Length > 0 && tbxOutput.Text.Length > 0)
                        {
                            // Check if there are characters to delete
                            for (int x = Settings.textboxInput.Count - 1; x >= 0; x--)
                            {
                                if (Settings.textboxInput[x] == '\n')
                                {
                                    // If a newline character is encountered, update the text boxes accordingly
                                    tbxInput.Text = Settings.backspaceInput();
                                    tbxOutput.Text = Settings.backspaceOutput();
                                    break;
                                }
                                else
                                {
                                    // If not a newline character, reverse the rotor settings
                                    Settings.reverseRotors();
                                    tbxInput.Text = Settings.backspaceInput();
                                    tbxOutput.Text = Settings.backspaceOutput();
                                    break;
                                }
                            }
                        }
                        // Reset the color of Ellipse buttons and their labels
                        for (int x = 0; x < key.Length; x++)
                        {
                            key[x].Fill = originalColor;
                            keyLabels[x].Foreground = labelOriginalColor;
                        }
                        break;
                }
            }
        }

        void keyLightUp()
        {
            for (int x = 0; x < keyLabels.Length; x++)
            {
                // Get the label content associated with the key.
                string label = keyLabels[x]?.Content?.ToString();
                
                // Get the last character from the tbxOutput text box.
                string outputLastElement = tbxOutput.Text.Last().ToString();
                
                // Compare the last character from tbxOutput with the label associated with the key.
                if (outputLastElement == label)
                {
                    // If they match, change the key's appearance to indicate it's associated with the output.
                    key[x].Fill = outputColor;
                    keyLabels[x].Foreground = labelOutputColor;
                }
                else if (outputLastElement == " ")
                {
                    // If the last character is a space, handle this case (special logic).
                    for (int y = 0; y < keyLabels.Length; y++)
                    {
                        if (y == 55)
                        {
                            key[55].Fill = outputColor;
                            keyLabels[55].Foreground = labelOutputColor;
                        }
                        else
                        {
                            key[x].Fill = originalColor;
                            keyLabels[x].Foreground = labelOriginalColor;
                        }
                    }
                }
                else if (outputLastElement != label)
                {
                    // If there's no match, reset the key's appearance to its original state.
                    key[x].Fill = originalColor;
                    keyLabels[x].Foreground = labelOriginalColor;
                }
            }
        }
        void updateDisplayCount()
        {
            // Update the labels displaying ring selection values (ring positions).
            lblSelectionSecondsCounter1.Content = Settings.NumberFormatter(Settings.ringSelection[0]);
            lblSelectionMinutesCounter1.Content = Settings.NumberFormatter(Settings.ringSelection[1]);
            lblSelectionHoursCounter1.Content = Settings.NumberFormatter(Settings.ringSelection[2]);

            // Update the labels displaying ring offset values.
            lblSelectionSecondsCounter2.Content = Settings.NumberFormatter(Settings.ringOffset[0]);
            lblSelectionMinutesCounter2.Content = Settings.NumberFormatter(Settings.ringOffset[1]);
            lblSelectionHoursCounter2.Content = Settings.NumberFormatter(Settings.ringOffset[2]);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        //automatically triggered when the window is loaded and is often used for initialization tasks.
        {
            // Create an OpenFileDialog instance to allow the user to select a CSV file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma Separated Values (*.csv;)|*.csv;";
            
            // If the user selects a file and clicks "Open"
            if (ofd.ShowDialog() == true)
            {
                // Set the text in the tbxRingFilePath TextBox to the selected file's path
                tbxRingFilePath.Text = ofd.FileName;
                
                // Check if a file path has been provided
                if (tbxRingFilePath.Text.Length > 0)
                {
                    // Read the contents of the selected CSV file and format them
                    Settings.ReadFiles(tbxRingFilePath.Text);
                    Settings.ringSorter();
                    
                    // Display ring-related information, such as the ring count and character count per ring
                    lblRingCount.Content = "Ring Count : " + Settings.ringCount();
                    lblRingContentCount.Content = "Character Count per Ring :  " + Settings.ringContentCount();
                    
                    // Show a message indicating that the rings file has been read and formatted
                    MessageBox.Show("Rings File has been Read and Formatted. Please Proceed with the setup.", "Enigma", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    // Enable buttons and controls for the user to proceed with the setup
                    btnPlusSeconds1.IsEnabled = true;
                    btnPlusMinutes1.IsEnabled = true;
                    btnPlusHours1.IsEnabled = true;
                    btnMinusSeconds1.IsEnabled = true;
                    btnMinusMinutes1.IsEnabled = true;
                    btnMinusHours1.IsEnabled = true;
                    cbxReflector.IsEnabled = true;
                    btnReset.IsEnabled = true;
                }
            }
        }

        private void btnRingFileSelector_Click(object sender, RoutedEventArgs e)
        //triggered when the user actively clicks a button to select and load a ring settings file, providing manual control over the process.
        {
            // Create an OpenFileDialog instance to allow the user to select a CSV file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Comma Separated Values (*.csv;)|*.csv;";
            
            // If the user selects a file and clicks "Open"
            if (ofd.ShowDialog() == true)
            {
                // Set the text in the tbxRingFilePath TextBox to the selected file's path
                tbxRingFilePath.Text = ofd.FileName;

                // Check if a file path has been provided
                if (tbxRingFilePath.Text.Length > 0)
                {
                    // Clear any existing ring-related data and reset ring selections and offsets
                    Settings.ringLines.Clear();
                    Array.Clear(Settings.groupedRings, 0, Settings.groupedRings.Length);
                    Settings.ringSelection = new int[3] { 0, 0, 0 };
                    Settings.ringOffset = new int[3] { 0, 0, 0 };
                    updateDisplayCount();
                    
                    // Read the contents of the selected CSV file and format them
                    Settings.ReadFiles(tbxRingFilePath.Text);
                    Settings.ringSorter();
                    
                    // Display ring-related information, such as the ring count and character count per ring
                    lblRingCount.Content = "Ring Count : " + Settings.ringCount();
                    lblRingContentCount.Content = "Character Count per Ring : " + Settings.ringContentCount();
                    
                    // Show a message indicating that the rings file has been read and formatted
                    MessageBox.Show("Rings File has been Read and Formatted. Please Proceed with the setup.\nIf you prefer, you can choose another csv file including rings.", "Enigma", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    // Enable buttons and controls for the user to proceed with the setup
                    btnPlusSeconds1.IsEnabled = true;
                    btnPlusMinutes1.IsEnabled = true;
                    btnPlusHours1.IsEnabled = true;
                    btnMinusSeconds1.IsEnabled = true;
                    btnMinusMinutes1.IsEnabled = true;
                    btnMinusHours1.IsEnabled = true;
                    btnRingFileSelector.IsEnabled = true;
                    cbxReflector.IsEnabled = true;
                    btnReset.IsEnabled = true;
                }
            }
        }



        private void btnPlusSeconds1_Click(object sender, RoutedEventArgs e)
        {
            // Increase the selected ring settings for seconds by one position
            Settings.ringSelectionCounter(0, '+');
            
            // Update the display to reflect the new ring settings
            updateDisplayCount();
            
            // Check if the ring selection has reached its maximum position
            ringSelectorChecker();
        }

        private void btnPlusMinutes1_Click(object sender, RoutedEventArgs e)
        {
            // Increase the selected ring settings for minutes by one position
            Settings.ringSelectionCounter(1, '+');
            
            // Update the display to reflect the new ring settings
            updateDisplayCount();
            
            // Check if the ring selection has reached its maximum position
            ringSelectorChecker();
        }

        private void btnPlusHours1_Click(object sender, RoutedEventArgs e)
        {
            // Increase the selected ring settings for minutes by one position
            Settings.ringSelectionCounter(2, '+');
            
            // Update the display to reflect the new ring settings
            updateDisplayCount();
            
            // Check if the ring selection has reached its maximum position
            ringSelectorChecker();
        }

        private void btnMinusSeconds1_Click(object sender, RoutedEventArgs e)
        {
            // Decrease the selected ring position for seconds by one
            Settings.ringSelectionCounter(0, '-');
            
            // Update the display to show the new ring settings
            updateDisplayCount();
            
            // Check if ring selectors are in a valid position
            ringSelectorChecker();
        }

        private void btnMinusMinutes1_Click(object sender, RoutedEventArgs e)
        {
            // Decrease the selected ring position for minutes by one
            Settings.ringSelectionCounter(1, '-');
            
            // Update the display to show the new ring settings
            updateDisplayCount();
            
            // Check if ring selectors are in a valid position
            ringSelectorChecker();
        }

        private void btnMinusHours1_Click(object sender, RoutedEventArgs e)
        {
            // Decrease the selected ring position for hours by one
            Settings.ringSelectionCounter(2, '-');
            
            // Update the display to show the new ring settings
            updateDisplayCount();
            
            // Check if ring selectors are in a valid position
            ringSelectorChecker();
        }

        private void btnPlusSeconds2_Click(object sender, RoutedEventArgs e)
        {
            // Increase the selected ring settings for seconds by one position
            Settings.ringSettingsCounter(0, '+');
            
            // Update the display to show the new ring settings
            updateDisplayCount();
        }

        private void btnPlusMinutes2_Click(object sender, RoutedEventArgs e)
        {
            // Increase the selected ring settings for minutes by one position
            Settings.ringSettingsCounter(1, '+');
            
            // Update the display to show the new ring settings
            updateDisplayCount();
        }

        private void btnPlusHours2_Click(object sender, RoutedEventArgs e)
        {
            // Increase the selected ring settings for hours by one position
            Settings.ringSettingsCounter(2, '+');
            
            // Update the display to show the new ring settings
            updateDisplayCount();
        }

        private void btnMinusSeconds2_Click(object sender, RoutedEventArgs e)
        {
            // Decrease the selected ring settings for seconds by one position
            Settings.ringSettingsCounter(0, '-');
            
            // Update the display to show the new ring settings
            updateDisplayCount();
        }

        private void btnMinusMinutes2_Click(object sender, RoutedEventArgs e)
        {
            // Decrease the selected ring settings for minutes by one position
            Settings.ringSettingsCounter(1, '-');
            
            // Update the display to show the new ring settings
            updateDisplayCount();
        }

        private void btnMinusHours2_Click(object sender, RoutedEventArgs e)
        {
            // Decrease the selected ring settings for hours by one position
            Settings.ringSettingsCounter(2, '-');
            
            // Update the display to show the new ring settings
            updateDisplayCount();
        }

        private void cbxReflector_Checked(object sender, RoutedEventArgs e)
        {
            // Set a flag to indicate that the reflector checkbox is checked
            Settings.checkboxIsChecked = true;
        }

        private void cbxReflector_Unchecked(object sender, RoutedEventArgs e)
        {
            // Set a flag to indicate that the reflector checkbox is unchecked
            Settings.checkboxIsChecked = false;
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            // Set a flag indicating that the "Set" button has been clicked
            btnSetIsClicked = true;
            
            // Display a confirmation dialog to ensure the user's intention
            if (MessageBox.Show("Do you really want to LOCK THE SELECTION?", "Enigma", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Offset the rotors to set the Enigma machine in the locked state
                Settings.adjustRotors();
                
                // Show a message indicating that the Enigma machine has been activated
                MessageBox.Show("Enigma has been activated!", "Enigma", MessageBoxButton.OK, MessageBoxImage.Information);

                // Disable various UI elements to prevent further configuration
                btnPlusSeconds1.IsEnabled = false;
                btnPlusMinutes1.IsEnabled = false;
                btnPlusHours1.IsEnabled = false;
                btnMinusSeconds1.IsEnabled = false;
                btnMinusMinutes1.IsEnabled = false;
                btnMinusHours1.IsEnabled = false;
                btnPlusSeconds2.IsEnabled = false;
                btnPlusMinutes2.IsEnabled = false;
                btnPlusHours2.IsEnabled = false;
                btnMinusSeconds2.IsEnabled = false;
                btnMinusMinutes2.IsEnabled = false;
                btnMinusHours2.IsEnabled = false;
                btnSet.IsEnabled = false;
                btnRingFileSelector.IsEnabled = false;
                cbxReflector.IsEnabled = false;

                // Set focus on the input textbox for user interaction
                tbxInput.Focus();
            }
        }

        private void TbxInput_KeyDown(object sender, KeyEventArgs e)
        {

            if (keyEllipseDictionary.TryGetValue(e.Key, out Ellipse ell))
            {
                ell.Fill = new SolidColorBrush(Colors.Cyan);
            }
        }

        private void LightUpEllipse(Ellipse ell)
        {
            // Light up the specified Ellipse by changing its fill color to cyan
            ell.Fill = new SolidColorBrush(Colors.Cyan);
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            // Display a confirmation dialog to ensure the user wants to reset the Enigma configuration
            if (MessageBox.Show("Are you certain you want to RESET the enigma configuration?", "Enigma", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // If the user confirms the reset:

                // Clear the input and output text boxes
                tbxInput.Text = "";
                tbxOutput.Text = "";

                // Uncheck the reflector checkbox
                cbxReflector.IsChecked = false;

                // Clear the internal lists for textbox input and output
                Settings.textboxInput.Clear();
                Settings.textboxOutput.Clear();

                // Reset the rotor ring selections and offsets to zeros
                Settings.ringSelection = new int[3] { 0, 0, 0 };
                Settings.ringOffset = new int[3] { 0, 0, 0 };

                // Update the display count
                updateDisplayCount();

                // Offset the rotor positions
                Settings.adjustRotors();

                // Reset button states and flags
                btnSetIsClicked = false;
                btnPlusSeconds1.IsEnabled = true;
                btnPlusMinutes1.IsEnabled = true;
                btnPlusHours1.IsEnabled = true;
                btnMinusSeconds1.IsEnabled = true;
                btnMinusMinutes1.IsEnabled = true;
                btnMinusHours1.IsEnabled = true;
                btnPlusSeconds2.IsEnabled = false;
                btnPlusMinutes2.IsEnabled = false;
                btnPlusHours2.IsEnabled = false;
                btnMinusSeconds2.IsEnabled = false;
                btnMinusMinutes2.IsEnabled = false;
                btnMinusHours2.IsEnabled = false;
                btnSet.IsEnabled = false;
                cbxReflector.IsEnabled = true;
                btnRingFileSelector.IsEnabled = true;
                Settings.checkboxIsChecked = false;

                // Reset the color of the Ellipse buttons and their labels
                for (int x = 0; x < key.Length; x++)
                {
                    key[x].Fill = originalColor;
                    keyLabels[x].Foreground = labelOriginalColor;
                }

                // Show a message box to inform the user that the Enigma setup has been RESET
                MessageBox.Show("The Enigma setup has been RESET." , "Enigma", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
