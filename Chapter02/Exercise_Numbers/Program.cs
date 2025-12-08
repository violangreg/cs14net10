using System.Diagnostics;
using static System.Console;

unsafe
{
    Table table = new();
    table.Centered();
    table.Title("Number Types in .NET");
    table.Border = TableBorder.Rounded;
    table.Caption("Sizes and Ranges of Numeric Types");

    AnsiConsole
        .Live(table)
        .Start(ctx =>
        {
            table.AddColumn(new TableColumn("Type").LeftAligned());
            ctx.Refresh();
            Thread.Sleep(250);
            table.AddColumn(new TableColumn("Byte(s) of memory").LeftAligned());
            ctx.Refresh();
            Thread.Sleep(250);

            table.AddColumn(new TableColumn("Min").RightAligned());
            ctx.Refresh();
            Thread.Sleep(250);
            table.AddColumn(new TableColumn("Max").RightAligned());
            ctx.Refresh();
            Thread.Sleep(250);

            table.AddRow(
                "sbyte",
                sizeof(sbyte).ToString(),
                sbyte.MinValue.ToString(),
                sbyte.MaxValue.ToString()
            );
            table.AddRow(
                "byte",
                sizeof(byte).ToString(),
                byte.MinValue.ToString(),
                byte.MaxValue.ToString()
            );
            table.AddRow(
                "short",
                sizeof(short).ToString(),
                short.MinValue.ToString(),
                short.MaxValue.ToString()
            );
            table.AddRow(
                "ushort",
                sizeof(ushort).ToString(),
                ushort.MinValue.ToString(),
                ushort.MaxValue.ToString()
            );
            table.AddRow(
                "int",
                sizeof(int).ToString(),
                int.MinValue.ToString(),
                int.MaxValue.ToString()
            );
            table.AddRow(
                "uint",
                sizeof(uint).ToString(),
                uint.MinValue.ToString(),
                uint.MaxValue.ToString()
            );
            table.AddRow(
                "long",
                sizeof(long).ToString(),
                long.MinValue.ToString(),
                long.MaxValue.ToString()
            );
            table.AddRow(
                "ulong",
                sizeof(ulong).ToString(),
                ulong.MinValue.ToString(),
                ulong.MaxValue.ToString()
            );
            table.AddRow(
                "Int128",
                sizeof(Int128).ToString(),
                Int128.MinValue.ToString(),
                Int128.MaxValue.ToString()
            );
            table.AddRow(
                "Uint128",
                sizeof(UInt128).ToString(),
                UInt128.MinValue.ToString(),
                UInt128.MaxValue.ToString()
            );
            table.AddRow(
                "Half",
                sizeof(Half).ToString(),
                Half.MinValue.ToString(),
                Half.MaxValue.ToString()
            );
            table.AddRow(
                "float",
                sizeof(float).ToString(),
                float.MinValue.ToString(),
                float.MaxValue.ToString()
            );
            table.AddRow(
                "double",
                sizeof(double).ToString(),
                double.MinValue.ToString(),
                double.MaxValue.ToString()
            );
            table.AddRow(
                "decimal",
                sizeof(decimal).ToString(),
                decimal.MinValue.ToString(),
                decimal.MaxValue.ToString()
            );

            //AnsiConsole.Write(table);
        });
}

Table table2 = new();
bool p = true;
bool q = false;
table2.AddColumn(new TableColumn("AND"));
table2.AddColumn(new TableColumn("p"));
table2.AddColumn(new TableColumn("q"));
table2.AddRow("p", $"{p & p}", $"{p & q}");
table2.AddRow("q", $"{q & p}", $"{q & q}");

table2.AddColumn(new TableColumn("OR"));
table2.AddColumn(new TableColumn("p"));
table2.AddColumn(new TableColumn("q"));
table2.AddRow("p", $"{p | p}", $"{p | q}");
table2.AddRow("q", $"{q | p}", $"{q | q}");