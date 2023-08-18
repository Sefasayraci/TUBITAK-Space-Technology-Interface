namespace Microsoft
{
    internal class Office
    {
        internal class Interop
        {
            internal class Excel
            {
                internal class Application
                {
                    public bool Visible { get; internal set; }
                    public object Workbooks { get; internal set; }
                }

                internal class Workbook
                {
                    public object Sheets { get; internal set; }
                }

                internal class Worksheet
                {
                    public object Cells { get; internal set; }
                }

                internal class Range
                {
                    public string Value2 { get; internal set; }
                }
            }
        }
    }
}