CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();



public class CharberryTree {
    private Random _random = new Random();
    public event Action? Ripened;
    public bool Ripe { get; set; }

    public void MaybeGrow() {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe) {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

public class Notifier {
    
    public Notifier(CharberryTree tree) {
        tree.Ripened += OnRipened;
    }

    private void OnRipened() {
        Console.WriteLine("A charberry fruit has ripened!");
    }
}

public class Harvester {

    private CharberryTree tree;
    public Harvester(CharberryTree tree) {
        tree.Ripened += OnRipened;
        this.tree = tree;
    }

    private void OnRipened() {
        Console.WriteLine("Harvesting...");
        tree.Ripe = false;
    }
}