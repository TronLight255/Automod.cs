using System;
using MCGalaxy;
using MCGalaxy.Events.PlayerEvents;

public class AntiMod : Plugin {

    public override string name { get { return "AntiMod"; } }
    public override string creator { get { return "ChatGPT"; } }
    public override string MCGalaxy_Version { get { return "1.9.5.3"; } }

    // Palabras prohibidas
    string[] badWords = { "puta", "puto", "pendejo", "pendejo", "idiota", "mierda"};

    // Anti-spam (tiempos por jugador)
    static DateTime[] lastMsg = new DateTime[128];
    static int[] spamCount = new int[128];

    public override void Load(bool startup) {
        OnPlayerChatEvent.Register(HandleChat, Priority.Normal);
    }

    public override void Unload(bool shutdown) {
        OnPlayerChatEvent.Unregister(HandleChat);
    }

    void HandleChat(Player p, string msg) {

        // ------------------------------
        //  ANTI-INSULTOS
        // ------------------------------
        string lower = msg.ToLower();

        foreach (string bad in badWords) {
            if (bad.Length > 0 && lower.Contains(bad)) {
                p.Kick("Usaste lenguaje inapropiado.");
                return;
            }
        }

        // ------------------------------
        //  ANTI-SPAM
        // ------------------------------
        int id = p.id;

        DateTime now = DateTime.UtcNow;

        double seconds = (now - lastMsg[id]).TotalSeconds;

        // Si escribe mensajes cada menos de 0.7 segundos → spam
        if (seconds < 0.7) {
            spamCount[id]++;

            if (spamCount[id] == 2) {
                p.Message("&c[AntiSpam] Deja de escribir tan rápido.");
            }
            else if (spamCount[id] >= 4) {
                p.Kick("Expulsado por spam.");
                spamCount[id] = 0;
            }
        } else {
            // Si pasa tiempo, se reinicia el contador
            spamCount[id] = 0;
        }

        lastMsg[id] = now;
    }
}
