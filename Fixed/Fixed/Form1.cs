using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fixed
{
    public partial class FixedForm : Form
    {
        public FixedForm()
        {
            InitializeComponent();
        }

        // Исправление больших и маленьких букв
        private void FixCaps_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                string formattedText = FormatText(text);
                Clipboard.SetText(formattedText);

                NotifyIcon notifyIcon = new NotifyIcon();
                notifyIcon.Icon = SystemIcons.Information;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "";
                notifyIcon.BalloonTipText = ": ) " + "\nТекст исправлен и скопирован в буфер обмена.";
                notifyIcon.ShowBalloonTip(2000);
            }
            else
            {
                NotifyIcon notifyIcon = new NotifyIcon();
                notifyIcon.Icon = SystemIcons.Information;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "";
                notifyIcon.BalloonTipText = "Упс, Problem : (" + "\nУбедитесь, что ВЫ скопировали текст." + "\nПроверить можно зажав [ win + v ]";
                notifyIcon.ShowBalloonTip(2000);
            }
        }

        private string FormatText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            StringBuilder formattedText = new StringBuilder(text.ToLower());
            bool capitalizeNext = true;

            for (int i = 0; i < formattedText.Length; i++)
            {
                char currentChar = formattedText[i];

                if (capitalizeNext && char.IsLetter(currentChar))
                {
                    formattedText[i] = char.ToUpper(currentChar);
                    capitalizeNext = false;
                }
                else if (currentChar == '!' || currentChar == '?' || currentChar == ';' || currentChar == '.')
                {
                    capitalizeNext = true;
                }
            }

            return formattedText.ToString();
        }

        // Перевод текста
        private void TranslateButton_Click(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            string decodedText = DecodeText(clipboardText);

            if (!string.IsNullOrEmpty(decodedText))
            {
                Clipboard.SetText(decodedText);

                NotifyIcon notifyIcon = new NotifyIcon();
                notifyIcon.Icon = SystemIcons.Information;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "";
                notifyIcon.BalloonTipText = ": ) " + "\nТекст переведен и скопирован в буфер обмена.";
                notifyIcon.ShowBalloonTip(2000);
            }
            else
            {
                NotifyIcon notifyIcon = new NotifyIcon();
                notifyIcon.Icon = SystemIcons.Information;
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipTitle = "";
                notifyIcon.BalloonTipText = "Упс, Problem : (" + "\nУбедитесь, что ВЫ скопировали текст." + "\nПроверить можно зажав [ win + v ]";
                notifyIcon.ShowBalloonTip(2000);
            }
        }

        private string DecodeText(string text)
        {
            StringBuilder decodedText = new StringBuilder();

            // Определяем язык текста на основе первой буквы
            char firstCharacter = text.FirstOrDefault();
            bool isRussian = IsRussianCharacter(firstCharacter);

            foreach (char c in text)
            {
                if (isRussian)
                {
                    decodedText.Append(DecodeToEnglishCharacter(c));
                }
                else
                {
                    decodedText.Append(DecodeToRussianCharacter(c));
                }
            }

            return decodedText.ToString();
        }

        // Маппинг символов для декодирования с русского на английский
        private Dictionary<char, char> russianToEnglishCharacterMap = new Dictionary<char, char>()
        {
            {'q', 'й'}, {'w', 'ц'}, {'e', 'у'}, {'r', 'к'},
            {'t', 'е'}, {'y', 'н'}, {'u', 'г'}, {'i', 'ш'},
            {'o', 'щ'}, {'p', 'з'}, {'[', 'х'}, {']', 'ъ'},
            {'a', 'ф'}, {'s', 'ы'}, {'d', 'в'}, {'f', 'а'},
            {'g', 'п'}, {'h', 'р'}, {'j', 'о'}, {'k', 'л'},
            {'l', 'д'}, {';', 'ж'}, {'\'', 'э'}, {'z', 'я'},
            {'x', 'ч'}, {'c', 'с'}, {'v', 'м'}, {'b', 'и'},
            {'n', 'т'}, {'m', 'ь'}, {',', 'б'}, {'.', 'ю'},
            {'/', '.'}, {'`', 'ё'}, {'Q', 'Й'}, {'W', 'Ц'},
            {'E', 'У'}, {'R', 'К'}, {'T', 'Е'}, {'Y', 'Н'},
            {'U', 'Г'}, {'I', 'Ш'}, {'O', 'Щ'}, {'P', 'З'},
            {'{', 'Х'}, {'}', 'Ъ'}, {'A', 'Ф'}, {'S', 'Ы'},
            {'D', 'В'}, {'F', 'А'}, {'G', 'П'}, {'H', 'Р'},
            {'J', 'О'}, {'K', 'Л'}, {'L', 'Д'}, {':', 'Ж'},
            {'"', 'Э'}, {'Z', 'Я'}, {'X', 'Ч'}, {'C', 'С'},
            {'V', 'М'}, {'B', 'И'}, {'N', 'Т'}, {'M', 'Ь'},
            {'<', 'Б'}, {'>', 'Ю'}, {'?', ','}, {'&', '?'}
        };

        // Маппинг символов для декодирования с английского на русский
        private Dictionary<char, char> englishToRussianCharacterMap = new Dictionary<char, char>()
        {
            {'й', 'q'}, {'ц', 'w'}, {'у', 'e'}, {'к', 'r'},
            {'е', 't'}, {'н', 'y'}, {'г', 'u'}, {'ш', 'i'},
            {'щ', 'o'}, {'з', 'p'}, {'х', '['}, {'ъ', ']'},
            {'ф', 'a'}, {'ы', 's'}, {'в', 'd'}, {'а', 'f'},
            {'п', 'g'}, {'р', 'h'}, {'о', 'j'}, {'л', 'k'},
            {'д', 'l'}, {'ж', ';'}, {'э', '\''}, {'я', 'z'},
            {'ч', 'x'}, {'с', 'c'}, {'м', 'v'}, {'и', 'b'},
            {'т', 'n'}, {'ь', 'm'}, {',', ','}, {'.', '.'},
            {'/', '/'}, {'ё', '`'}, {'Й', 'Q'}, {'Ц', 'W'},
            {'У', 'E'}, {'К', 'R'}, {'Е', 'T'}, {'Н', 'Y'},
            {'Г', 'U'}, {'Ш', 'I'}, {'Щ', 'O'}, {'З', 'P'},
            {'Х', '{'}, {'Ъ', '}'}, {'Ф', 'A'}, {'Ы', 'S'},
            {'В', 'D'}, {'А', 'F'}, {'П', 'G'}, {'Р', 'H'},
            {'О', 'J'}, {'Л', 'K'}, {'Д', 'L'}, {'Ж', ':'},
            {'Э', '"'}, {'Я', 'Z'}, {'Ч', 'X'}, {'С', 'C'},
            {'М', 'V'}, {'И', 'B'}, {'Т', 'N'}, {'Ь', 'M'},
            {'Б', '<'}, {'Ю', '>'}, {'?', '?'}, {'&', '&'}
        };

        private bool IsRussianCharacter(char character)
        {
            return russianToEnglishCharacterMap.ContainsKey(character);
        }

        private char DecodeToEnglishCharacter(char character)
        {
            // Декодирование символа с русского на английский
            if (russianToEnglishCharacterMap.ContainsKey(character))
            {
                return russianToEnglishCharacterMap[character];
            }
            else
            {
                return character;
            }
        }

        private char DecodeToRussianCharacter(char character)
        {
            // Декодирование символа с английского на русский
            if (englishToRussianCharacterMap.ContainsKey(character))
            {
                return englishToRussianCharacterMap[character];
            }
            else
            {
                return character;
            }
        }
    }
}