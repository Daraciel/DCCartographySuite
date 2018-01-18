namespace WorldGen.Common.EventArgs
{
    public class NotifyEventArgs
    {
        public int Layer { get; set; }
        public byte[,] Map { get; set; }
    }
}
