using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MediatorHarkka
{
    class ConsoleControl
    {
        public List<string> Items { get; set; }
        int Column { get; set; }
        int Width {get; set;}
        int Row { get; set; }
        int Height { get; set; }
        ConsoleColor BackColor { get; set; }
        ConsoleColor TextColor { get; set; }

        ConsoleControl(int column, int width, int row, int height)
        {
            Column = column;
            Width = width;
            Row = row;
            Height = height;
            BackColor = System.Console.BackgroundColor;
            TextColor = System.Console.ForegroundColor;
            Items = null;
        }

        public void Clear()
        {
            int org_column = CursorLeft, org_row = CursorTop;

            for (int i = 0; i < Height; i++)
            {
                SetCursorPosition(Column - 1, Row - 1 + i);
                for (int j = 0; j < Width; j++)
                {
                    Write(" ");
                }
            }
            SetCursorPosition(org_column, org_row);
        }

        public void Draw()
        {
            int org_column = CursorLeft, org_row = CursorTop;
            ConsoleColor org_fore = ForegroundColor,
            org_back = BackgroundColor;
            ForegroundColor = TextColor;
            BackgroundColor = BackColor;
            for (int i = 0; i < Height; i++)
            {
                SetCursorPosition(Column ‐ 1, Row ‐ 1 + i);
                if (Items != null && i < Items.Count)
                {
                    Write(Items[i].PadRight(Width, ' '));
                }
                else
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Write(" ");
                    }
                }
            }
            SetCursorPosition(org_column, org_row);
            ForegroundColor = org_fore;
            BackgroundColor = org_back;
        }
    }
}
