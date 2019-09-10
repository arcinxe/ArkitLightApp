namespace ArktiLight {
    class Setting {
        public string Alias { get; set; }
        public string Settings { get; set; }

        public override string ToString() {
            return Alias + " => " + Settings;
        }
    }
}