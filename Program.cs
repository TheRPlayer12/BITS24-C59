class Program
{
    static void Main(string[] args)
    {
        int n = 3;
        string[] constraints = {
            "Buttercup must be killed beside Bella",
            "Blue must be killed beside Bella",
            "Sue must be killed beside Beatrice"
        };

        var d = new Dictionary<string, HashSet<string>>();
        var monsters = new HashSet<string>();

        foreach (var constraint in constraints)
        {
            var parts = constraint.Split(" must be killed beside ");
            var x = parts[0];
            var y = parts[1];

            if (!d.ContainsKey(x)) d[x] = new HashSet<string>();
            if (!d.ContainsKey(y)) d[y] = new HashSet<string>();

            d[x].Add(y);
            d[y].Add(x);

            monsters.Add(x);
            monsters.Add(y);
        }

        var start = monsters.Min();
        var visited = new HashSet<string> { start };
        var result = new List<string> { start };

        DFS(start, d, visited, result);

        foreach (var monster in monsters.OrderBy(x => x))
        {
            if (!visited.Contains(monster))
            {
                visited.Add(monster);
                result.Add(monster);
            }
        }

        foreach (var monster in result)
        {
            Console.WriteLine(monster);
        }
    }

    static void DFS(string node, Dictionary<string, HashSet<string>> d, HashSet<string> visited, List<string> result)
    {
        foreach (var neighbor in d[node].OrderBy(x => x))
        {
            if (!visited.Contains(neighbor))
            {
                visited.Add(neighbor);
                result.Add(neighbor);
                DFS(neighbor, d, visited, result);
            }
        }
    }
}
