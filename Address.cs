namespace ArktiLight {
    public class Address {
        public string Alias { get; set; }
        public string Path { get; set; }

        public override string ToString() {
            return Alias + " => " + Path;
        }
    }
}
